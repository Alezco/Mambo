using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mambo.DBO
{
    public class Article
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int ResourcesId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Status { get; set; }
        public int NbViews { get; set; }

        public Article() { }

        public Article(int adminId, int resourcesId, DateTime creationDate, string status, int nbViews)
        {
            AdminId = adminId;
            ResourcesId = resourcesId;
            CreationDate = creationDate;
            Status = status;
            NbViews = nbViews;
        }
    }
}