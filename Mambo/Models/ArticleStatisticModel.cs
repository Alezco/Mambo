using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mambo.Models
{
    public class ArticleStatisticModel
    {
        public DBO.Article Article { get; set; }

        public List<DBO.Translation> Translations { get; set; }

        public int NbComments { get; set; }

        public int NbLikes { get; set; }
    }
}