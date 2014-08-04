using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace php_pb.Src.Classes
{
    class BlogService
    {
        public delegate void BlogServiceDelegate(List<Blog> blog);
        public static void GetBlogAsync(BlogServiceDelegate callback, bool cache)
        {
            Debug.WriteLine("Buscando dados no servidor...");
            String URL = "http://www.php-pb.net/feed.xml";
            httpHelper.get(URL, (String xml) => 
            {
                //recebe o retorno aqui, que é o arquivo xml
                List<Blog> b = parserXML(xml);
                callback(b);
                Debug.WriteLine("Fim busca");
            });
        }

        private static List<Blog> parserXML(String xml)
        {
            List<Blog> blog = new List<Blog>();            
            if (xml != null)
            {
                try
                {
                    Debug.WriteLine("Chegou no parser");
                    //blog em memória
                    XDocument xdoc = XDocument.Parse(xml);
                    //le a tag <item>
                    XElement TagRss = xdoc.Element("rss");

                    XElement TagChannel = TagRss.Element("channel");
                    //le todas as tags item
                    IEnumerable<XElement> array = TagChannel.Elements("item");
                    //para cada notícia, lê os dados
                    if (array != null)
                    {
                        foreach (XElement Item in array)
                        {
                            Blog b = new Blog();
                            b.Title = Item.Element("title").Value;
                            b.Description = Item.Element("description").Value;
                            b.Date = Item.Element("pubDate").Value;
                            b.Link = Item.Element("link").Value;
                            //add a notícia na lista
                            blog.Add(b);
                        }
                    }
                }
                catch (XmlException e)
                {
                    //caso retorne erro
                    Debug.WriteLine("Erro no parser: " + e.Message);
                }
            }
            return blog;
        }
    }
}
