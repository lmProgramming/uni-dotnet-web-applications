using WebAsp8RazorDemo.Models.ViewModels;

namespace WebAsp8RazorDemo.Data
{
    public class MockDictionaryArticleContext : IArticleContext
    {
        private Dictionary<int, ArticleViewModel> articles = new()
        {
            { 1, new ArticleViewModel(1, "Apple from dictionary", 2.5m, ArticleType.Fruit, 10, new DateTime(2024, 12, 31)) },
            { 2, new ArticleViewModel(2, "Cheese from dictionary", 8.5m, ArticleType.Dairy, 20, new DateTime(2024, 12, 15)) },
            { 3, new ArticleViewModel(3, "Salmon from dictionary", 13.5m, ArticleType.Fish, 30, new DateTime(2024, 12, 16)) }
        };

        public void AddArticle(ArticleViewModel article)
        {
            int nextId = articles.Keys.Max() + 1;
            article.Id = nextId;
            articles[nextId] = article;
        }

        public ArticleViewModel? GetArticle(int id)
        {
            articles.TryGetValue(id, out var article);
            return article;
        }

        public List<ArticleViewModel> GetArticles()
        {
            return articles.Values.OrderBy(article => article.Id).ToList();
        }

        public void RemoveArticle(int id)
        {
            articles.Remove(id);
        }

        public void UpdateArticle(ArticleViewModel article)
        {
            if (articles.ContainsKey(article.Id))
            {
                articles[article.Id] = article;
            }
        }
    }
}