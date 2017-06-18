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
        public List<Article> ArticlesList { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public Resources() { }

        public Resources(int languageId, List<Article> articlesList, string title, string description, string path)
        {
            LanguageId = languageId;
            ArticlesList = articlesList;
            Title = title;
            Description = description;
            Path = path;
        }
    }
}