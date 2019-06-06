using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RecipeBookAPI.DBAcces;
using System.Data.SqlClient;
using RecipeBookAPI.Models;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
namespace RecipeBookAPI.Controllers
{
    public class ImageController : ApiController
    {
        [HttpPost]
        [Route("api/UploadImage")]
        public string UploadImage()
        {
            var httpRequest = HttpContext.Current.Request;
            var postedFile = httpRequest.Files["Image"];
            string fileName = PathFile(postedFile);
            string file = "http://localhost:50790/api/Image?imageName=" + fileName;
            return file;
        }

        [HttpGet]
        [Route("api/Image")]
        public HttpResponseMessage Image(string imageName)
        {
            string filePath = @"E:\HM\RecipeBookAPI\RecipeBookAPI\Image\" + imageName;
            var dataBytes = File.ReadAllBytes(filePath);
            var dataStream = new MemoryStream(dataBytes);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = imageName;
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }

        public string PathFile(HttpPostedFile postedFile)
        {
            string imageName = null;
            string imageFullName = "";
            imageName = new string(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "_");
            imageName = imageName + "_" + "20" + DateTime.Now.ToString("yy.dd.MM") + Path.GetExtension(postedFile.FileName);
            imageFullName = imageName;
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
            postedFile.SaveAs(filePath);
            return imageFullName;
        }

    }
}