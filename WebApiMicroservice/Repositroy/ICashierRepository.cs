using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMicroservice.Models;

namespace WebApiMicroservice.Repositroy
{
    public interface ICashierRepository
    {
        IEnumerable<Cashier> GetCashier();
        Cashier GetCashierById(int Id);
        void InsertCashier(Cashier data);
        void UpdateCashier(Cashier data);
        void DeleteCashier(int Id);
        void Save();
    }
}
