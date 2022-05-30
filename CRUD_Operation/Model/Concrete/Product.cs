using CRUD_Operation.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Operation.Model.Concrete
{
    public class Product:BaseEntity
    {

        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        //Database yansıyacak olan alan
        public int CategoryId { get; set; }

        //Navigation property olarak kullanılacak
        //Burası database'de herhangi bir field olarak tutulmaz
        public Category Category { get; set; }



    }
}
