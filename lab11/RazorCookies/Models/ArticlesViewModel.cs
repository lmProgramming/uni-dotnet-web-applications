namespace EntityFramework.Models
{
    public class ArticlesViewModel(IEnumerable<Article> articles)
    {
        public IEnumerable<Article> Articles = articles;
    }
}
