using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
 
namespace BAL.Utilities
{
  public static   class ImageSaving
    {

    

        public static string savePostedFileIntoFolder(HttpPostedFileBase file,string FolderPath = "~/UploadedDocuments/",string fileName = "")
        {
            string filesavepath = FolderPath + fileName;
            try
            {
                if (file != null)
                {
                    if (true)
                    {

                    }
                    string path = System.Web.HttpContext.Current.Server.MapPath(FolderPath);
                    
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }


                
                    //file.SaveAs(FolderPath + Path.GetFileName(file.FileName));
                    file.SaveAs(path + fileName);
                     
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return filesavepath;





        }


    }
}
