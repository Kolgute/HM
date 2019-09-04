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
    public class TestController : ApiController
    {
        [HttpGet]
        public List<CategoryList> CategoryList()
        {
            DataBaseAcces db = new DataBaseAcces();
            return db.CategoryLists();
        }
        [HttpGet]
        public List<RecipeCardModels> GetCategories(int id)
        {
            DataBaseAcces db = new DataBaseAcces();
            return db.SearchByCategory(id);
        }
    }
}