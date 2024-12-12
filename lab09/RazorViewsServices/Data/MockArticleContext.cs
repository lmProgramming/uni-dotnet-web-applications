using WebAsp8RazorDemo.Models.ViewModels;

namespace WebAsp8RazorDemo.Data
{
    public class MockArticleContext : IArticleContext
    {
        List<ArticleViewModel> articles = [
            new(1, "Apple from a list", 2.5m, ArticleType.Fruit, 10, new DateTime(2024, 12, 31)),
            new(2, "Cheese", 8.5m, ArticleType.Dairy, 20, new DateTime(2024, 12, 15)),
            new(3, "Salmon", 13.5m, ArticleType.Fish, 30, new DateTime(2024, 12, 16)),
        ];

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
