﻿using System;
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
        public List<RecipeCardModels> RecipeCards()
        {
            DataBaseAcces db = new DataBaseAcces();
            return db.RecipesCard();
        }
        [HttpGet]
        public List<RecipeCardModels> GetByRN(string id)
        {
            DataBaseAcces db = new DataBaseAcces();
            return db.SearchByRN(id);
        }
        [HttpGet]
        public List<RecipeCardModels> GetByDI(int id)
        {
            DataBaseAcces db = new DataBaseAcces();
            return db.SearchByDish(id);
        }
        [HttpGet]
        public OneRecipeModels OneRecipe(int id)
        {
            DataBaseAcces db = new DataBaseAcces();
            return db.Recipe(id);
        }
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
