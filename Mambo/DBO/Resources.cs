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

        public Resources(int id, int languageId, List<Article> articlesList, string title, string description, string path)
        {
            Id = Id;
            LanguageId = languageId;
            ArticlesList = articlesList;
            Title = title;
            Description = description;
            Path = path;
        }

        public Resources(int languageId, string title, string description, string path)
        {
            LanguageId = languageId;
            Title = title;
            Description = description;
            Path = path;
        }

        public Resources(int id, int languageId, string title, string description, string path)
        {
            Id = id;
            LanguageId = languageId;
            Title = title;
            Description = description;
            Path = path;
        }

        public bool isEqual(Resources obj)
        {
            return LanguageId == obj.LanguageId
                && Title == obj.Title
                && Description == obj.Description
                && Path == obj.Path;
        }
    }
}