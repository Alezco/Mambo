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

        // La liste des traductions disponibles de l'article 
        public List<Translation> Translations { get; set; }

        // La nouvelle traduction à venir
        public Translation NewTranslation { get; set; }

        // La liste des ressources traduites de l'article
        public List<DBO.Resources> Resources { get; set; }

        public List<DBO.Language> ExistingTranslatedLanguage { get; set; }

        public List<System.Web.Mvc.SelectListItem> LanguageSelectList { get; set; }
        public string SelectedLanguage { get; set; }
    }
}