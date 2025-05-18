namespace Back2Retro.Dal.Migrations
{
    using Back2Retro.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Back2Retro.Dal.Back2RetroDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        
        protected override void Seed(Back2Retro.Dal.Back2RetroDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // Добавляем категории, если их нет
            // Добавляем категории, если их ещё нет


            context.Categories.AddOrUpdate(
                x => new { x.CategoryOfProduct },
                new Category { CategoryOfProduct = "Vinyl & Turntables" },
                new Category { CategoryOfProduct = "Vintage Posters" },
                new Category { CategoryOfProduct = "Retro Clothing" },
                new Category { CategoryOfProduct = "Antique Accessories" },
                new Category { CategoryOfProduct = "Books & Magazines 70s–90s" }
            );

            context.SaveChanges(); // Сохраняем, чтобы получить Id

            // Получаем нужные категории по CategoryOfProduct и Format
            var vinyl = context.Categories.First(c => c.CategoryOfProduct == "Vinyl & Turntables");
            var posters = context.Categories.First(c => c.CategoryOfProduct == "Vintage Posters");
            var clothing = context.Categories.First(c => c.CategoryOfProduct == "Retro Clothing");
            var accessories = context.Categories.First(c => c.CategoryOfProduct == "Antique Accessories");
            var books = context.Categories.First(c => c.CategoryOfProduct == "Books & Magazines 70s–90s");

            // Добавляем тестовые продукты
            context.Products.AddOrUpdate(
                x => new { x.ProductName },
                 new Product
                 {
                     ProductName = "Sony Vinyl Player 1979",
                     Description = "A classic turntable from 1979 in great working condition.",
                     Price = 120.00M,
                     Image = "sony1979.jpg",
                     Category = vinyl
                 },
                 new Product
                 {
                     ProductName = "'Back to the Future' Movie Poster",
                     Description = "Original 1980s movie poster in excellent shape.",
                     Price = 45.50M,
                     Image = "bttf_poster.jpg",
                     Category = posters
                 },
                 new Product
                 {
                     ProductName = "Levi's Denim Jacket 1980s",
                     Description = "Authentic vintage denim jacket, classic fit.",
                     Price = 75.00M,
                     Image = "levis80.jpg",
                     Category = clothing
                 },
                 new Product
                 {
                     ProductName = "Casio F91W Digital Watch",
                     Description = "Iconic 90s digital watch, still ticking.",
                     Price = 19.99M,
                     Image = "casio_f91w.jpg",
                     Category = accessories
                 },
                 new Product
                 {
                     ProductName = "'Murzilka' Magazine No.6, 1986",
                     Description = "Soviet kids' magazine with illustrations and stories.",
                     Price = 12.00M,
                     Image = "murzilka1986.jpg",
                     Category = books
                 }
                         );



        }
    }
}
