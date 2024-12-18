using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article()
                {

                },
                new Article()
                {
                    Id = 2,
                    Index = 222222,
                    Name = "Yasmin",
                    Gender = Gender.Female,
                    BirthDate = new DateTime(2000, 2, 2),
                    DepartmentId = 2,
                    Active = false,
                }

                ); ;

        }
    }
}
