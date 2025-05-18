    using Back2Retro.Bll;
    using Back2Retro.Entities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;

    namespace Back2Retro.WebApp.Controllers
    {
        public class ProductsController : Controller
        {
            public ActionResult Index()
            {
                try
                {
                    List<Product> products = ProductBll.ReadAll();
                    return View(products);
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return View("Error");
                }
            }

            public ActionResult Details(int id)
            {
                try
                {
                    Product product = ProductBll.ReadOne(id);
                    return View(product);
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return View("Error");
                }
            }

        /*public ActionResult Create()
         {
             return View();
         }

         [HttpPost]
         public ActionResult Create(string productName, string description, decimal price,
             HttpPostedFileBase image, int categoryId)
         {
             string imageName = "unknown.jpg";

             if (image != null && (image.ContentType == "image/jpeg" || image.ContentType == "image/png"))
             {
                 string path = Server.MapPath("~/Content/images/products/");
                 string extension = Path.GetExtension(image.FileName);
                 imageName = Guid.NewGuid() + extension;
                 image.SaveAs(Path.Combine(path, imageName));
             }

             Category category = new Category { Id = categoryId };
             bool productCreated = ProductBll.Create(productName, description, price, imageName, category);

             if (productCreated)
             {
                 ViewBag.Feedback = productName + " added.";
             }
             else
             {
                 ViewBag.Feedback = "Something went wrong - failed to add product.";
             }

             return View();
         }*/



        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(CategoryBll.GetAll(), "Id", "CategoryOfProduct");
            return View();
        }

        [HttpPost]
        public ActionResult Create(string productName, string description, decimal price,
            HttpPostedFileBase image, int categoryId)
        {
            string imageName = "unknown.jpg";

            // Обработка изображения
            if (image != null && (image.ContentType == "image/jpeg" || image.ContentType == "image/png"))
            {
                string path = Server.MapPath("~/Content/images/products/");
                string extension = Path.GetExtension(image.FileName);
                imageName = Guid.NewGuid() + extension;
                image.SaveAs(Path.Combine(path, imageName));
            }

            // Ищем категорию по Id
            Category category = CategoryBll.GetCategoryById(categoryId);

            if (category == null)
            {
                ViewBag.ErrorMessage = "Invalid category selected.";
                return View();
            }

            // Создание нового продукта
            bool productCreated = ProductBll.Create(productName, description, price, imageName, category);

            if (productCreated)
            {
                ViewBag.Feedback = productName + " added.";
            }
            else
            {
                ViewBag.Feedback = "Something went wrong - failed to add product.";
            }

            // Перезаписываем список категорий для использования в представлении
            ViewBag.Categories = new SelectList(CategoryBll.GetAll(), "Id", "CategoryOfProduct");

            return View();
        }

        public ActionResult Delete(int id)
            {
                try
                {
                    Product product = ProductBll.ReadOne(id);
                    return View(product);
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return View("Error");
                }
            }

            [HttpPost]
            public ActionResult Delete(string id)
            {
                int productId = Convert.ToInt32(id);
                bool productDeleted = ProductBll.Delete(productId);

                if (productDeleted)
                {
                    TempData["Feedback"] = "Product deleted.";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }

        public ActionResult Edit(int id)
        {
            try
            {
                // Получаем продукт
                Product product = ProductBll.ReadOne(id);

                // Получаем список категорий
                List<Category> categories = CategoryBll.ReadAll();

                // Передаём список категорий в DropDownList через ViewBag.categoryId
                ViewBag.categoryId = new SelectList(categories, "Id", "CategoryOfProduct", product.Category?.Id);

                return View(product);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
            public ActionResult Edit(int id, string productName, string description, decimal price,
                HttpPostedFileBase image, int? categoryId)
            {
                string imageName = "unknown.jpg";

                if (image != null && (image.ContentType == "image/jpeg" || image.ContentType == "image/png"))
                {
                    string path = Server.MapPath("~/Content/images/products/");
                    string extension = Path.GetExtension(image.FileName);
                    imageName = Guid.NewGuid() + extension;
                    image.SaveAs(Path.Combine(path, imageName));
                }
            //(int)categoryId потому что выше в Edit(стоит ? перед categoryId)
            Category category = new Category { Id = (int)categoryId };
                bool productUpdated = ProductBll.Update(id, productName, description, price, imageName, category);

                if (productUpdated)
                {
                    TempData["Feedback"] = "Product updated.";
                }
                else
                {
                    TempData["Feedback"] = "Something went wrong - failed to update product.";
                }

                return RedirectToAction("Details", new { id = id });
            }
        }
    }
