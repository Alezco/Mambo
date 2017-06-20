using Mambo.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mambo.Models
{
    public class ArticleDetailModel
    {
        public Article Article { get; set; }

        public List<Translation> Translations { get; set; }

        public List<Resources> Medias { get; set; }

        public List<CommentModel> Comments { get; set; }

        public int NbLikes { get; set; }

        public UserComment UserComment { get; set; }
    }
}