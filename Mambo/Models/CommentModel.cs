using Mambo.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mambo.Models
{
    public class CommentModel
    {
        public string Comment { get; set; }

        public string Username { get; set; }

        public DateTime Date { get; set; }
    }
}