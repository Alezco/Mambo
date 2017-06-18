using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mambo.DBO
{
    public class Translation
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int TranslatorId { get; set; }
        public int LanguageId { get; set; }
        public string TranslationArticleTitle { get; set; }
        public string TranslationArticleContent { get; set; }

        public Translation() { }

        public Translation(int articleId, int translatorId, int languageId, string translationArticleTitle, string translationArticleContent)
        {
            ArticleId = articleId;
            TranslatorId = translatorId;
            LanguageId = languageId;
            TranslationArticleTitle = translationArticleTitle;
            TranslationArticleContent = translationArticleContent;
        }
    }
}