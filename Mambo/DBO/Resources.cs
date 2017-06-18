using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mambo.DBO
{
    public class Resources
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public Resources() { }

        public Resources(int languageId, int articleId, string title, string description, string path)
        {
            LanguageId = languageId;
            ArticleId = articleId;
            Title = title;
            Description = description;
            Path = path;
        }
    }
}