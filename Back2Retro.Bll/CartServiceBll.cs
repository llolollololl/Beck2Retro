using Back2Retro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Back2Retro.Bll
{
    public class CartService
    {
        // Ключ для хранения корзины в сессии
        private const string CartSessionKey = "CartSession";

        // Получить корзину из сессии или создать новую, если нет
        public static List<CartItem> GetCart(HttpSessionStateBase session)
        {
            if (session[CartSessionKey] == null)           // Если корзина ещё не создана
                session[CartSessionKey] = new List<CartItem>();  // Создать пустую корзину

            return (List<CartItem>)session[CartSessionKey]; // Вернуть корзину из сессии
        }

        // Добавить продукт в корзину
        public static void AddToCart(HttpSessionStateBase session, Product product)
        {
            var cart = GetCart(session);                     // Получить текущую корзину
            var item = cart.Find(i => i.Product.ProductId == product.ProductId);  // Найти товар в корзине по Id

            if (item != null)                                // Если товар уже есть в корзине
                item.Quantity++;                             // Увеличить количество на 1
            else
                cart.Add(new CartItem(product, 1));         // Иначе добавить новый товар с количеством 1
        }

        // Удалить товар из корзины по Id продукта
        public static void RemoveFromCart(HttpSessionStateBase session, int productId)
        {
            var cart = GetCart(session);                      // Получить корзину
            var item = cart.Find(i => i.Product.ProductId == productId);  // Найти товар для удаления

            if (item != null)                                 // Если товар найден
                cart.Remove(item);                            // Удалить его из корзины
        }

        // Получить общую сумму товаров в корзине
        public static decimal GetTotalPrice(HttpSessionStateBase session)
        {
            var cart = GetCart(session);                       // Получить корзину
            decimal total = 0;                                 // Переменная для суммы

            foreach (var item in cart)                         // Пройтись по всем товарам в корзине
                total += item.Product.Price * item.Quantity;  // Добавить стоимость товара * количество

            return total;                                      // Вернуть итоговую сумму
        }



    }
}
