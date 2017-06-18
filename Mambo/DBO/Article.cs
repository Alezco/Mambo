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
        public List<Resources> ResourcesList { get; set; }
        public DateTime CreationDate { get; set; }
        public string Status { get; set; }
        public int NbViews { get; set; }

        public Article() { }

        public Article(int adminId, List<Resources> resourcesList, DateTime creationDate, string status, int nbViews)
        {
            AdminId = adminId;
            ResourcesList = resourcesList;
            CreationDate = creationDate;
            Status = status;
            NbViews = nbViews;
        }
    }
}