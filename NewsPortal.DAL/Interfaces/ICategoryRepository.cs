using NewsPortal.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        //List<CategoryDto> GetAll();
        void Add(Category category);
        void Delete(Category category);
        void Update(Category category);
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetMany(Expression<Func<Category, bool>> where);
    }
}
