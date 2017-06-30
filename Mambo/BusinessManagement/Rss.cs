using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;

namespace Mambo.BusinessManagement
{
    public class Rss
    {
        private BusinessManagement.Article articleManagement = new BusinessManagement.Article();
        private BusinessManagement.Translation translationManagement = new BusinessManagement.Translation();
        public SyndicationFeed getRssData()
        {
            List<DBO.Translation> listTransaction = translationManagement.GetAll();
            List<DBO.Translation> listArticlesInWaiting = new List<DBO.Translation>();
            foreach (var elt in listTransaction)
            {
                DBO.Article a = articleManagement.Get(elt.ArticleId);
                if (a.Status == "VALIDATED")
                {
                    listArticlesInWaiting.Add(elt);
                }
            }
            var feed = new SyndicationFeed("New articles", "Mambo RSS Feed",
                new Uri("https://raw.githubusercontent.com/Alezco/Mambo/master/Ressources/file_placeholder.png"),
                Guid.NewGuid().ToString(), DateTime.Now);
            var items = new List<SyndicationItem>();
            foreach (DBO.Translation a in listTransaction)
            {
                DBO.Article elt = articleManagement.Get(a.ArticleId);
                Uri tempValue = new Uri("https://fr.wikipedia.org/wiki/Mambo");
                if (elt.ResourcesList.Count > 0 && Uri.TryCreate(elt.ResourcesList[0].Path, UriKind.RelativeOrAbsolute, out tempValue))
                {
                }
                var item =
                    new SyndicationItem(a.TranslationArticleTitle, a.TranslationArticleContent, tempValue);
                item.LastUpdatedTime = elt.CreationDate;
                items.Add(item);
            }
            feed.Items = items;
            return feed;
        }
    }
}