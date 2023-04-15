using NewsPortal.BLL.Interfaces;
using NewsPortal.DAL.Interfaces;
using NewsPortal.Models.DomainModels;
using NewsPortal.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.BLL.Services
{
    public class NewsService : INewsService
    {
       
        private readonly INewsRepository _newsRepository;


        public NewsService(INewsRepository newsRepository)
        {
            newsRepository = _newsRepository;
        }
        public List<NewsDto> GetAll()
        {

            return _newsRepository.GetAll();



        }

      
       
        List<News> INewsService.GetAll()
        {

            return new List<News>()
        {
            new News() { NewsId = 1, Title = "News1" },
            new News() { NewsId = 2, Title = "News2" },

                new News() { NewsId = 3, Title = "News3" },

            };
        }

        
    }
}
