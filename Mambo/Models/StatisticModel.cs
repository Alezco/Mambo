using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mambo.Models
{
    public class StatisticModel
    {
        public List<ArticleStatisticModel> ArticleList { get; set; }

        public StatisticModel()
        {
            ArticleList = new List<ArticleStatisticModel>();
        }
    }
}