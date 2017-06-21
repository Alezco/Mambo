using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mambo.Models
{
    public class ArticleCreationModel
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public Language Language { get; set; }
    }

    public  enum Language
    {
        FRA = 1,
        ANG = 2,
        ESP = 3
    }
}