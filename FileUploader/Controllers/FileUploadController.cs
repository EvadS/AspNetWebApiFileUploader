using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FileUploader.Controllers
{
    public class FileUploadController : ApiController
    {
        // GET: api/Values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public void UploadFile()
        {
            // todo: for test
            if (HttpContext.Current.Request.Form.AllKeys.Any())
            {
                string currentUserName = HttpContext.Current.Request.Form["userName"];
                string s = currentUserName;
            }

            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {

                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
                var userName = HttpContext.Current.Request.Files["userName"];

                if (httpPostedFile != null)
                {
                    // Validate the uploaded image(optional)
                    try {
                        // Get the complete file path
                        var path = HttpContext.Current.Server.MapPath("~/UploadedFiles");
                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName);

                        // Save the uploaded file to "UploadedFiles" folder
                        httpPostedFile.SaveAs(Path.Combine(path, httpPostedFile.FileName));
                        File.SetAttributes(fileSavePath, FileAttributes.Normal);
                    }
                    catch(Exception ex )
                    {
                        int a = 10;
                    }
                    }
            }
        }
    }
}
