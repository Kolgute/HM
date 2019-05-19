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
    public class GetController : ApiController
    {
        // GET: api/Get
        [HttpGet]
        public RecipeModels[] GetAllData()
        {
            DataBaseAcces db = new DataBaseAcces();
            return db.AllData();
        }
        [HttpGet]
        public RecipeCardModels[] GetCardsData()
        {
            DataBaseAcces db = new DataBaseAcces();
            return db.RecipesCard();
        }
        [HttpGet]
        public RecipeCardModels[] GetByRN(string id) //Не работает поиск, доделать (Invalid column name)
        {
            DataBaseAcces db = new DataBaseAcces();
            return db.SearchByRN(id);
        }
        
    }
}
