using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Collections;

namespace Read_WriteXML
{
    public partial class Read : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Select file to upload:" + "<br />");
        }

        private void UploadFiles()
        {
            if (FileUpload.HasFile)

           try {
                ArrayList MyList = new ArrayList();
                String MyFile;
                MyFile = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
                FileUpload.PostedFile.SaveAs(Server.MapPath("~/MyUploads/" + MyFile));
                MyFile = (Server.MapPath("~/MyUploads/" + MyFile));
                XDocument doc = XDocument.Load(MyFile);
                foreach (XElement result in doc.Elements("Modules")
                                                .Elements("Module"))
                {
                    Module MS = new Module();
                    MS.ModuleName = Convert.ToString(result.Element("Name").Value);
                    MS.ModuleNumber = Convert.ToInt16(result.Element("Code").Value);
                    MyList.Add(MS);
                    Response.Write(MS.ModuleName + " " + MS.ModuleNumber + "<br />");  
                }
                Response.Write("File Uploaded");
            }
           catch
           {               
               Response.Write("File could not be loaded");
           }
        }

        protected void UploadFileButton_Click(object sender, EventArgs e)
        {
            UploadFiles();
        }
    }
}