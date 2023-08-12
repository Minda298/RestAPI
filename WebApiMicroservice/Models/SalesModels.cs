using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMicroservice.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CashierId { get; set; }
        public int Qty { get; set; }
        public double Gross { get; set; }
    }
}
