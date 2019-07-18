using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace MyMovie_Sqlite2._0
{
    public class FuncNFO
    {
        /// <summary>
        /// 获得genre与actor节点的内容
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>返回泛型集合。</returns>
        public List<string> GetTags(string fileName)
        {
            //创建一个泛型集合
            List<string> vs = new List<string>();

            XmlDocument xml = new XmlDocument();
            xml.Load(fileName);
            XmlElement movie = xml.DocumentElement;//根

           XmlNodeList nodeList= movie.ChildNodes;
            foreach (XmlNode node in nodeList)
            {
                if (node.Name=="genre")
                {
                    vs.Add("Ge"+node.InnerText);
                }

            }

            XmlNodeList actorList = xml.SelectNodes("movie/actor");//获得所有actor同级子节点

            if (actorList.Count>0)
            {
                foreach (var actor in actorList)
                {
                    XmlElement actorE = (XmlElement)actor;
                    vs.Add(actorE.FirstChild.InnerText);
                }
            }


            return vs;
        }







        /// <summary>
        /// 添加Genre类别。
        /// </summary>
        /// <param name="fileName">nfo文件的路径及文件名</param>
        /// <param name="txtGenre">genre的内容。</param>
        public void AddGenre(string fileName, string txtGenre)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(fileName);
            XmlElement movie = xml.DocumentElement; //根节点。
                                                    
            XmlElement element = xml.CreateElement("genre");//创建Genre节点
            element.InnerText = txtGenre;
            XmlNode runtime = xml.SelectSingleNode("movie/runtime");
            movie.InsertAfter(element, runtime);
            xml.Save(fileName);

        }



    }
}
