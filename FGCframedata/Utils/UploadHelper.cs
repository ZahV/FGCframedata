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

        private HttpServerUtilityBase Server { get; }

        // TODO file type limitation
        public UploadHelper(HttpServerUtilityBase server)
        {
            Server = server;
        }
        
        // TODO fix duplicate image names
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

            filePath = Path.Combine(Server.MapPath(UploadDirectory), fileName);
            int counter = 0;

            while (File.Exists(filePath))
            {
                
                counter += 1;

                fileName = Path.GetFileNameWithoutExtension(file.FileName) + "(" + counter + ")" + Path.GetExtension(file.FileName);
                filePath = Path.Combine(Server.MapPath(UploadDirectory), fileName);

            }

            file.SaveAs(filePath);

            return filePath;
        }
    }
}

