using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back2Retro.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; } // внешний ключ 
        public string Comment { get; set; }
        public int Rating { get; set; } // от 1 до 5
        public DateTime DatePosted { get; set; }


        // это навигационное свойство
        //Оно говорит Entity Framework следующее:
        //У каждого объекта Review есть связанный объект Product.Позволь мне напрямую обращаться к нему
        public virtual Product Product { get; set; }
        public string UserName { get; set; }
    }
}
