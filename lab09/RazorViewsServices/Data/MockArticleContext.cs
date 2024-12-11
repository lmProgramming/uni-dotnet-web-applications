using WebAsp8RazorDemo.Models.ViewModels;

namespace WebAsp8RazorDemo.Data
{
    public class MockArticleContext : IArticleContext
    {
        List<ArticleViewModel> articles = new List<ArticleViewModel>() {
            new ArticleViewModel(1, "Apple", 1.5m, new DateTime(2021, 12, 31), ArticleType.Food, 10),
            new ArticleViewModel(2, "Banana", 2.5m, new DateTime(2021, 12, 31), ArticleType.Food, 20),
            new ArticleViewModel(3, "Orange", 3.5m, new DateTime(2021, 12, 31), ArticleType.Food, 30),
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
            ArticleViewModel? studToRemove = articles.FirstOrDefault(s => s.Id == id);
            if (studToRemove != null)
                articles.Remove(studToRemove);
        }
        public void UpdateArticle(ArticleViewModel person)
        {
            ArticleViewModel? studToUpdate = articles.FirstOrDefault(s => s.Id == person.Id);
            articles = articles.Select(s => (s.Id == person.Id) ? person : s).ToList();
        }
    }
}
