using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mambo.DBO
{
    public class ArticleLike
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }

        public ArticleLike() { }

        public ArticleLike(int userId, int articleId)
        {
            UserId = userId;
            ArticleId = articleId;
        }
    }
}