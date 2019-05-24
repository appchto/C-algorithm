using System;
using System.Collections.Generic;

namespace ConsoleAppTest
{

    public  class Link
    {
        public string description { get; set; }
        public string link { get; set; }

    }

    internal class Program
    {


        private static void Main(string[] args)
        {
            List<Link> lstOfLinks = new List<Link>();
            //var webpageUrl = "https://github.com/appchto";
            //string targetDomain = "github.com";

            var webpageUrl = "https://statsroyale.com/top/clans";
            string targetDomain = "statsroyale.com";

            
            ExtractLinks(lstOfLinks, webpageUrl, targetDomain);
            FormatLinkToShow(lstOfLinks);
            FormatToListLinksByComma(lstOfLinks);
            Console.ReadLine();

        }

        private static void ExtractLinks(List<Link> lstOfLinks, string webpageUrl, string targetDomain)
        {
            var lnkVerifier = new LinkVerifier();
            var links = lnkVerifier.FindLinksWithDomainOnWebPage(webpageUrl, targetDomain);
            foreach (var link in links)
            {
                AddLinksToObjct(lstOfLinks, link);
            }
        }

        private static void FormatLinkToShow(List<Link> lstOfLinks)
        {
            Console.WriteLine("************lstOfLinks***********");
            foreach (var link in lstOfLinks)
            {
                var desc = link.description;
                var li = link.link;
                if (string.IsNullOrEmpty(desc))
                {
                    desc = li.Split('/')[2];
                }
                var show = string.Format("{0} - {1}", desc, li);
                Console.WriteLine(show);
            }
        }
        private static void FormatToListLinksByComma(List<Link> lstOfLinks)
        {
            Console.WriteLine("************lstOfLinks***********");
            foreach (var link in lstOfLinks)
            {
                var li = link.link;
                var show = string.Format("{0},",  li);
                Console.WriteLine(show);
            }
        }
        private static void AddLinksToObjct(List<Link> lstOfLinks, AnchorTag link)
        {
            var l = new Link();
            l.description = link.InnerText.Trim();
            foreach (var lin in link.Attributes.Values)
            {
                l.link = lin;
            }
            lstOfLinks.Add(l);
        }

    }
}
