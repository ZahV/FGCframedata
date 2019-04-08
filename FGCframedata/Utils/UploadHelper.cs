using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Web;

namespace FGCFrameData.Utils
{
    public class UploadHelper
    {
        internal const string UploadDirectory = @"~\Content\AppFile\Images\";

        private readonly string[] _validFileExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff" };

        private HttpServerUtilityBase Server { get; }

       
        public UploadHelper(HttpServerUtilityBase server)
        {
            Server = server;
        }
        
       
        public string Upload(HttpPostedFileBase file, string folder = null)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            if (file.ContentLength == 0)
            {
                throw new InvalidDataException("Cannot upload empty file.");  
            }

            string filePath = null;

            var fileName = Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName);

            if (_validFileExtensions.Contains(Path.GetExtension(file.FileName)))
            {
                filePath = Path.Combine(Server.MapPath(UploadDirectory), fileName);
            }
            else
            {
                throw new ArrayTypeMismatchException("Invalid file extension type.");
            }

            
            int counter = 0;

            while (File.Exists(filePath))
            {
                counter += 1;

                fileName = Path.GetFileNameWithoutExtension(file.FileName) + "(" + counter + ")" + Path.GetExtension(file.FileName);
                filePath = Path.Combine(Server.MapPath(UploadDirectory), fileName);

            }

            file.SaveAs(filePath);

            var contentUri = new Uri(Server.MapPath("~/"));
            var fileUri = new Uri(filePath);

            return contentUri.MakeRelativeUri(fileUri).ToString();
        }
    }
}

