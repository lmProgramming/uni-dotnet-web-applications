using WebAsp8RazorDemo.Models.ViewModels;

namespace WebAsp8RazorDemo.Data
{
    public class MockArticleContext : IArticleContext
    {
        List<ArticleViewModel> articles = new() {
            new(1, "Apple", 1.5m, ArticleType.Food, 10, new DateTime(2021, 12, 31)),
            new(2, "Banana", 2.5m, ArticleType.Food, 20, new DateTime(2021, 12, 31)),
            new(3, "Orange", 3.5m, ArticleType.Food, 30, new DateTime(2021, 12, 31)),
        };
        public void AddArticle(ArticleViewModel student)
        {
            int nextNumber = articles.Max(s => s.Id) + 1;
            student.Id = nextNumber;
            articles.Add(student);
        }
        public ArticleViewModel? GetArticle(int id)
        {
            return articles.FirstOrDefault(s => s.Id == id);
        }
        public List<ArticleViewModel> GetArticles()
        {
            return articles;
        }
        public void RemoveArticle(int id)
        {
            ArticleViewModel? articleToRemove = articles.FirstOrDefault(s => s.Id == id);
            if (articleToRemove != null)
                articles.Remove(articleToRemove);
        }
        public void UpdateArticle(ArticleViewModel article)
        {
            ArticleViewModel? articleToUpdate = articles.FirstOrDefault(s => s.Id == article.Id);
            articles = articles.Select(s => (s.Id == article.Id) ? article : s).ToList();
        }
    }
}
