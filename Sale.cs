using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petshopmanagament
{
    public class Sale
    {
        public int Id { get; set; }  // Eğer büyük harfle 'ID' olarak kullanılmıyorsa küçük harfle 'Id' kullanın
        public Customer Customer { get; set; }
        public Pet Pet { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
