using NewsPortal.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.DAL.Interfaces
{
    public interface INewsRepository
    {
        
       List<NewsDto> GetAll();
        
    }
}
