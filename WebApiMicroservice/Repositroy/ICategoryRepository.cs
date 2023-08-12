using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMicroservice.Models;

namespace WebApiMicroservice.Repositroy
{
    public interface ICategoryRepository
    {
        IEnumerable<Categories> GetCategories();
        Categories GetCategoriesById(int Id);
        void InsertCategories(Categories data);
        void UpdateCategories(Categories data);
        void DeleteCategories(int Id);
        void Save();
    }
}
