using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mambo.DBO
{
    public class CommentArticle
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CommentContent { get; set; }

        public CommentArticle() { }
        
        public CommentArticle(int userId, int articleId, DateTime creationDate, string commentContent)
        {
            UserId = userId;
            ArticleId = articleId;
            CreationDate = creationDate;
            CommentContent = commentContent;
        }
    }
}