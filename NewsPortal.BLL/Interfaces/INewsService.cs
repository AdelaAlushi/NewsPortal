using NewsPortal.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.BLL.Interfaces
{
    public interface INewsService
    {
        List<News> GetAll();
    }
}
