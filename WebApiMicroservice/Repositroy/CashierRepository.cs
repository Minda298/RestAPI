using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMicroservice.DBContexts;
using WebApiMicroservice.Models;

namespace WebApiMicroservice.Repositroy
{
    public class CashierRepository : ICashierRepository
    {
        private readonly ProductContext _dbContext;

        public CashierRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCashier(int Id)
        {
            var cashier = _dbContext.Cashiers.Find(Id);
            _dbContext.Cashiers.Remove(cashier);
            Save();
        }

        public IEnumerable<Cashier> GetCashier()
        {
            return _dbContext.Cashiers.ToList();
        }

        public Cashier GetCashierById(int Id)
        {
            return _dbContext.Cashiers.FirstOrDefault(x => x.Id == Id);
        }

        public void InsertCashier(Cashier data)
        {
            _dbContext.Add(data);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateCashier(Cashier data)
        {
            _dbContext.Entry(data).State = EntityState.Modified;
            Save();
        }
    }
}
