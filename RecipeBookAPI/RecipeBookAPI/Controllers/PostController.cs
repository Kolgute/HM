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
        public ViewRecipeAddModels AddRecord(ViewRecipeAddModels NR)
        {
            DataBaseAcces db = new DataBaseAcces();

            return db.AddRecord(NR);
        }
        [HttpPost]
        public string DeleteRecord(RecipeAddModels RM)
        {
            DataBaseAcces db = new DataBaseAcces();

            return db.DeletRecipe(RM.DishID);
        }
        [HttpPost]
        public string DeleteRecordOnName(RecipeAddModels RM)
        {
            DataBaseAcces db = new DataBaseAcces();

            return db.DeletRecipeOnName(RM.RecipeName);
        }
        [HttpPost]
        public string Recipe(ViewRecipeModels VRM)
        {
            DataBaseAcces db = new DataBaseAcces();

            return db.DeletRecipeOnName(VRM.RecipeName);
        }

    }
}