using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Collections;

namespace Read_WriteXML
{
    public partial class Write : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Click to show the data to be written and to create the file" + "<br />" + "" + "<br />");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try { 
            ArrayList MyWriteList = new ArrayList();
            Module m1 = new Module();
            m1.ModuleNumber = 101;
            m1.ModuleName = "Maths";
            MyWriteList.Add(m1);
            Module m2 = new Module();
            m2.ModuleNumber = 202;
            m2.ModuleName = "Databases";
            MyWriteList.Add(m2);
            Module m3 = new Module();
            m3.ModuleNumber = 303;
            m3.ModuleName = "Software";
            MyWriteList.Add(m3);
            Response.Write(m1.ModuleName + " " + m1.ModuleNumber + "<br />" + m2.ModuleName + " " + m2.ModuleNumber + "<br />" + m3.ModuleName + " " + m3.ModuleNumber + "<br />" + "" + "<br />");

            XmlWriterSettings mySetting = new XmlWriterSettings();
            mySetting.Indent = true;
           mySetting.IndentChars = "\t";
            String TimeDateString = string.Format("-{0:dd-MM-yyyy_hh-mm-tt}",
        DateTime.Now);
            string FileName = Server.MapPath("zzzzz" + TimeDateString + ".xml");
                 using (XmlWriter myXMLwriter = XmlWriter.Create(FileName, mySetting))
            {
                myXMLwriter.WriteStartDocument();
                myXMLwriter.WriteStartElement("Modules");
                foreach (Module X in MyWriteList)
               {
                    myXMLwriter.WriteStartElement("Module");
                    myXMLwriter.WriteElementString("ModuleNumber", X.ModuleNumber.ToString());
                    myXMLwriter.WriteElementString("ModuleName", X.ModuleName);
                    myXMLwriter.WriteEndElement();
                }
                
                myXMLwriter.WriteEndElement();
                myXMLwriter.WriteEndDocument();
                Response.Write("File Written");
            }

        }
            catch{
                Response.Write("File could not be written");
            }
        }
       

    } 
    }


