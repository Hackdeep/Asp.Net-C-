using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace xss_form.Web_Vul
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       // [Obsolete]
        protected void Button1_Click(object sender, EventArgs e)
        {
            //  Referance URL : https://rules.sonarsource.com/csharp/RSPEC-2755
            // To execute xxe with XMLReader we need two different example for .net framework
            //1. exmaple one lower version of .net framework in web.config file as 4.3.2 
            //2. example two use xmlResolver with XMLURLResolver() in latest .net framework as 4.7.2
            //Add machCharactersFromEntities = more than 1024 bytes

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.IgnoreWhitespace = true;
            settings.XmlResolver = new XmlUrlResolver();
            settings.MaxCharactersFromEntities = 2048;

            XmlReader xReader = XmlReader.Create("E:\\Asp Projects\\xss form\\xss form\\Web_Vul\\img\\secret.xml", settings);
            
            while (xReader.Read())//.net framework version reduced and made to 4.3.2 to work xxe in webconfig
            {
                switch (xReader.NodeType)
                {
                    case XmlNodeType.Element:
                        ListBox1.Items.Add("<" + xReader.Name + ">");
                        break;
                    case XmlNodeType.Text:
                        ListBox1.Items.Add(xReader.Value);
                        break;
                    case XmlNodeType.EndElement:
                        ListBox1.Items.Add("</" + xReader.Name + ">");
                        break;
                } // end of switch  
            } //end of while  
        }
    }
}
/* string xmldata = "<?xml version='1.0' encoding='utf-8' ?><Tenders><Ravina>";
            xmldata +=          "<BillNo>1</BillNo>";
            xmldata +=              "<PageNo>10</PageNo>";
            xmldata +=              "<Activity>Metals</Activity>";
            xmldata += "    </Ravina></Tenders>";*/
//var abhishek =  (xmldata + fullpath) 
// string filename = Path.GetFileName("text.xml");
//string FilePath = Server.MapPath("~/img/" + filename);
//string fullpath = Path.Combine(FilePath + filename);
// XmlReaderSettings settings = new XmlReaderSettings();
//settings.IgnoreWhitespace = true;
//settings.ProhibitDtd = false;
//XmlReaderSettings settings = new XmlReaderSettings();
//settings.ProhibitDtd = false;
//xReader = DtdProcessing.Prohibit;
//xReader.XmlReader.ProhibitDTd = false;