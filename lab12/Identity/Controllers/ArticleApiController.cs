﻿using Identity.Data;
using Identity.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Identity.Utilities;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Identity.Controllers
{
    [EnableCors]
    [Route("api/article/")]
    [ApiController]
    public class ArticleApiController : ControllerBase
    {
        private readonly ArticleDbContext _context;
        private IWebHostEnvironment _hostingEnvironment;

        public ArticleApiController(ArticleDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/article
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var articles = await _context.Articles.Include(a => a.Category).ToListAsync();
            return Ok(articles);
        }

        // GET: api/article/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var article = await _context.Articles.Include(a => a.Category).FirstOrDefaultAsync(a => a.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        [HttpGet("page/{page:int}/pageSize/{pageSize:int}")]
        public async Task<IActionResult> Get(int page, int pageSize, int? categoryId = null)
        {
            IQueryable<Article> articlesQuery = _context.Articles.Include(a => a.Category);

            if (categoryId.HasValue)
            {
                articlesQuery = articlesQuery.Where(a => a.CategoryId == categoryId.Value);
            }

            var articles = await articlesQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(a => new
                {
                    a.Id,
                    a.Name,
                    a.Price,
                    a.ImageName,
                    CategoryName = a.Category.Name
                })
                .ToListAsync();

            return Ok(articles);
        }

        // POST: api/article
        [HttpPost]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post([FromBody] Article article)
        {
            Debug.WriteLine(article);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                article.Category = await _context.Categories.FirstAsync(c => c.Id == article.CategoryId);
                _context.Articles.Add(article);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = article.Id }, article);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT: api/article/{id}
        [HttpPut("{id}")]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Put(int id, [FromBody] Article article)
        {
            if (id != article.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Articles.AnyAsync(a => a.Id == id))
                {
                    return NotFound();
                }

                throw;
            }
            catch (DbUpdateException e)
            {
                return BadRequest(e);
            }

            return NoContent();
        }

        // DELETE: api/article/{id}
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }
            else
            {
                ImageHelper.DeleteArticleImage(article);

                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }
    }
}