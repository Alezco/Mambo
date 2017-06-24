using Mambo.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mambo.Models
{
    public class ArticleTranslateModel
    {
        public Article Article { get; set; }
        public List<Translation> Translations { get; set; }

        public List<DBO.Language> ExistingTranslatedLanguage { get; set; }

        public List<System.Web.Mvc.SelectListItem> LanguageSelectList { get; set; }
        public string SelectedLanguage { get; set; }
    }
}