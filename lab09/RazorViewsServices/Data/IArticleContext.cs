using WebAsp8RazorDemo.Models.ViewModels;

namespace WebAsp8RazorDemo.Data
{
    public interface IArticleContext
    {
        List<ArticleViewModel> GetArticles();
        ArticleViewModel? GetArticle(int id);
        void AddArticle(ArticleViewModel person);
        void RemoveArticle(int id);
        void UpdateArticle(ArticleViewModel person);
    }
}
