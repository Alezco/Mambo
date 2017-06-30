using Mambo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace Mambo.RSS
{
    public class RssReader
    {
        public static IEnumerable<Rss> GetRssFeed(SyndicationFeed feed)
        {
            var feeds = from feedi in feed.Items
                        select new Rss
                        {
                            Title = feedi.Title.Text.ToString(),
                            Description = feedi.LastUpdatedTime.ToString()
                        };

            return feeds;

        }
    }
}