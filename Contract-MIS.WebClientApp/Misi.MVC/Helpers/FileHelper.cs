using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace Misi.MVC.Helpers
{
    public class FileHelper
    {

        /// <summary>
        /// Convert any object to array of byte.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        /// <summary>
        /// Convert stored array of byte to object
        /// </summary>
        /// <param name="arrBytes"></param>
        /// <returns></returns>
        public static Object ByteArrayToObject(byte[] arrBytes)
        {
            var memStream = new MemoryStream();
            var binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            var obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int fileExtPos = fileName.LastIndexOf(".");
            if (fileExtPos >= 0)
                return fileName.Substring(0, fileExtPos);
            return fileName;
        }

        public static string GetFileExtension(string fileName)
        {
            int fileExtPos = fileName.LastIndexOf(".");
            if (fileExtPos >= 0)
                return fileName.Substring(fileExtPos, fileName.Length - fileExtPos);
            return "";
        }

        /// <summary>
        /// Validate uploaded file size is less than 10 MB
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool ValidateFileSize(HttpPostedFileBase file)
        {
            const int maxUploadSize = (10 * 1024 * 1024);
            return file.ContentLength <= maxUploadSize;
        }

        /// <summary>
        /// Validate content uploaded to the application
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool ValidateContentType(HttpPostedFileBase file)
        {
            return GetExtension().ContainsKey(file.ContentType);
        }

        /// <summary>
        /// Content type allowed to be uploaded to the application
        /// </summary>
        /// <returns></returns>
        public static IDictionary<string, string> GetExtension()
        {
            return new Dictionary<string, string>
            {
                {"application/msword", "doc"},
                {"application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx"},
                {"application/pdf", "pdf"},
                {"image/jpeg", "jpeg"},
                {"image/png", "png"}
            };
        }        


    }
}