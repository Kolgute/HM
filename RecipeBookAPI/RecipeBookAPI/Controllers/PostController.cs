using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RecipeBookAPI.DBAcces;
using System.Data.SqlClient;
using RecipeBookAPI.Models;

namespace RecipeBookAPI.Controllers
{
    public class PostController : ApiController
    {
        [HttpPost]
        public RecipeAddModels AddRecord(RecipeAddModels NR) // Доделать (Invalid column name)
        {
            DataBaseAcces db = new DataBaseAcces();
            
            return db.AddRecord(NR);
        }
    }
}