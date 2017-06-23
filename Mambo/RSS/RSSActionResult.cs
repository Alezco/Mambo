using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.ServiceModel.Syndication;

namespace Mambo.RSS
{
    public class RSSActionResult : ActionResult
    {
        
            public SyndicationFeed Feed { get; set; }
            public override void ExecuteResult(ControllerContext context)
            {
                context.HttpContext.Response.ContentType = "application/rss+xml";
                var rssFormatter = new Rss20FeedFormatter(Feed);
                using (var writer = XmlWriter.Create(context.HttpContext.Response.Output))
                {
                    rssFormatter.WriteTo(writer);
                }
            }
        }
}