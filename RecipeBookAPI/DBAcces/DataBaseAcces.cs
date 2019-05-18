using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Xml;
using RecipeBookAPI.Models;

namespace RecipeBookAPI.DBAcces
{
    public class DataBaseAcces
    {

        public RecipeModels[] AllData()
        {
            RecipeModels[] RecipeList = new RecipeModels[1];
            object[] obj = new object[1];
            string connectionString = @"Data Source = (localdb)\v11.0; Initial Catalog = RecipeBooks; Integrated Security = True";
            string sqlExpression = "SELECT Recipes.Recipe_ID, Recipes.Dish_ID, Recipes.RecipeName, ProductList.ProductName, Recipes.WeightProduct, CategoriesList.CategoryName, Recipes.CookingTime, Recipes.CookingTemperature, Recipes.CookingProcess, Recipes.PPhotoRecipe, Recipes.RecipeDescription FROM ProductList INNER JOIN (CategoriesList INNER JOIN Recipes ON CategoriesList.Category_ID = Recipes.Category_ID) ON ProductList.Product_ID = Recipes.Product_ID";
            int NumberRows = 0;
            int i = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NumberRows++;                       
                    }
                    RecipeList = new RecipeModels[NumberRows];
                    obj = new object[NumberRows];
                    reader.Close();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        RecipeModels Recipe = new RecipeModels();
                        Recipe.RecipeID = (int)reader.GetValue(0);
                        Recipe.DishID = (int)reader.GetValue(1);
                        Recipe.RecipeName = (string)reader.GetValue(2);
                        Recipe.Products = (string)reader.GetValue(3);
                        Recipe.WeightProduct = (int)reader.GetValue(4);
                        Recipe.Category = (string)reader.GetValue(5);
                        Recipe.CookingTemperature = (string)reader.GetValue(6);
                        Recipe.CookingProcess = (string)reader.GetValue(7);
                        Recipe.CookingTime = (string)reader.GetValue(8);
                        Recipe.PPhotoRecipe = (string)reader.GetValue(9);
                        Recipe.RecipeDescription = (string)reader.GetValue(10);
                        obj[i] = Recipe;
                        RecipeList[i] = (RecipeModels)obj[i];
                        i++;
                    }
                 reader.Close();
                }
            }
            return RecipeList;
        }

    }
}