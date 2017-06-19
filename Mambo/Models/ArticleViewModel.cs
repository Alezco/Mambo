using Mambo.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mambo.Models
{
    public class ArticleViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<Translation> Translations { get; set; }
    }
}