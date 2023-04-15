using NewsPortal.DAL.Interfaces;
using NewsPortal.Models.DomainModels;
using NewsPortal.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.DAL.Repositories
{
    public class NewsRepository : INewsRepository
    {

        public List<NewsDto> GetAll()
        {
            var projectfromDB = GetSampleNews();
            var result = new List<NewsDto>();
            foreach (var projects in projectfromDB)
            {
                result.Add(new NewsDto()
                {
                    NewsId = 1,
                    Title = "News1"



                });
            }

            return result;

        }

        private List<News> GetSampleNews()
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
