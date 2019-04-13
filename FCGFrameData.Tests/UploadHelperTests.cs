using System;
using System.IO;
using System.Web;
using FGCFrameData.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FGCFrameData.Tests
{
    [TestClass]
    public class UploadHelperTests
    {
        private class UploadedFileMock : HttpPostedFileBase
        {
            private int _contentLength;
            private string _fileName;

            public override int ContentLength
            {
                get { return _contentLength; }
            }

            public override string FileName
            {
                get { return _fileName; }
            }

            public override void SaveAs(string filename) { }

            public void SetContentLength(int value)
            {
                _contentLength = value;
            }

            public void SetFileName(string value)
            {
                _fileName = value;
            }
        }

        private class ServerMock : HttpServerUtilityBase
        {
            public override string MapPath(string path)
            {
                return path.Replace("~", Path.GetTempPath());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestUploadNull()
        {
            var uploadHelper = new UploadHelper(null);

            uploadHelper.Upload(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void TestUploadEmptyFile()
        {
            var uploadHelper = new UploadHelper(null);
            HttpPostedFileBase mockFile = new UploadedFileMock();

            uploadHelper.Upload(mockFile);
        }

        [TestMethod]
        public void TestUpload()
        {
            var fileName = "Test file name.png";
            var server = new ServerMock();
            var uploadHelper = new UploadHelper(server);
            UploadedFileMock mockFile = new UploadedFileMock();
            mockFile.SetContentLength(2);
            mockFile.SetFileName(fileName);

            var uploadPath = uploadHelper.Upload(mockFile);

            Assert.AreEqual(uploadPath, server.MapPath(UploadHelper.UploadDirectory + fileName));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDuplicateUpload()
        {
            var duplicateFileName = "Duplicate image.png";
            var server = new ServerMock();
            var uploadHelper = new UploadHelper(server);

            var duplicateFilePath = server.MapPath("~" + duplicateFileName);
            
            File.Create(duplicateFilePath).Dispose();

            UploadedFileMock mockFile = new UploadedFileMock();
            mockFile.SetContentLength(2);
            mockFile.SetFileName(duplicateFileName);

            var filePath = uploadHelper.Upload(mockFile);
          

            File.Delete(duplicateFilePath);

            Assert.AreEqual(filePath, server.MapPath(UploadHelper.UploadDirectory + "Duplicate image(1).png"));
        }
    }
}
