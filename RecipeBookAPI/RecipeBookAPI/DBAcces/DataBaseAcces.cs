using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        //Get Metods

        public RecipeCardModels[] RecipesCard()
        {
            RecipeCardModels[] RecipeList = new RecipeCardModels[1];
            object[] obj = new object[1];
            string connectionString = @"Data Source = (localdb)\v11.0; Initial Catalog = RecipeBooks; Integrated Security = True";
            string sqlExpression = "SELECT DISTINCT Recipes.RecipeName, CategoriesList.CategoryName, Recipes.PPhotoRecipe, Recipes.RecipeDescription FROM CategoriesList INNER JOIN Recipes ON CategoriesList.Category_ID = Recipes.Category_ID";
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
                    RecipeList = new RecipeCardModels[NumberRows];
                    obj = new object[NumberRows];
                    reader.Close();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        RecipeCardModels Recipe = new RecipeCardModels();
                        Recipe.RecipeName = (string)reader.GetValue(0);
                        Recipe.Category = (string)reader.GetValue(1);
                        Recipe.PPhotoRecipe = (string)reader.GetValue(2);
                        Recipe.RecipeDescription = (string)reader.GetValue(3);
                        obj[i] = Recipe;
                        RecipeList[i] = (RecipeCardModels)obj[i];
                        i++;
                    }
                    reader.Close();
                }
            }
            return RecipeList;
        }

        public OneRecipeModels Recipe(int Dish_ID)
        {
            OneRecipeModels recipe = new OneRecipeModels();
            string connectionString = @"Data Source = (localdb)\v11.0; Initial Catalog = RecipeBooks; Integrated Security = True";
            string sqlExpression = "SELECT Recipes.Dish_ID, Recipes.RecipeName, ProductList.ProductName, Recipes.WeightProduct, CategoriesList.CategoryName, Recipes.CookingTime, Recipes.CookingTemperature, Recipes.CookingProcess, Recipes.PPhotoRecipe, Recipes.RecipeDescription " +
                                   "FROM ProductList INNER JOIN (CategoriesList INNER JOIN Recipes ON CategoriesList.Category_ID = Recipes.Category_ID) ON ProductList.Product_ID = Recipes.Product_ID " +
                                   "WHERE Recipes.Dish_ID = @ID";
            int NumberRows = 0;
            int i = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Value = Dish_ID;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NumberRows++;
                    }
                    recipe.Product = new string[NumberRows];
                    reader.Close();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        recipe.DishID = (int)reader.GetValue(0);
                        recipe.RecipeName = (string)reader.GetValue(1);
                        recipe.Product[i] = (string)reader.GetValue(2);
                        recipe.WeightProduct = (int)reader.GetValue(3);
                        recipe.Category = (string)reader.GetValue(4);
                        recipe.CookingTime = (string)reader.GetValue(5);
                        recipe.CookingTemperature = (string)reader.GetValue(6);
                        recipe.CookingProcess = (string)reader.GetValue(7);
                        recipe.PPhotoRecipe = (string)reader.GetValue(8);
                        recipe.RecipeDescription = (string)reader.GetValue(9);
                        i++;
                    }
                    reader.Close();
                }
            }
            return recipe;
        }

        public RecipeCardModels[] SearchByRN(string RN)
        {
            RecipeCardModels[] RecipeList = new RecipeCardModels[1];
            object[] obj = new object[1];
            string connectionString = @"Data Source = (localdb)\v11.0; Initial Catalog = RecipeBooks; Integrated Security = True";
            string sqlExpression = $"SELECT DISTINCT Recipes.RecipeName, CategoriesList.CategoryName, Recipes.PPhotoRecipe, Recipes.RecipeDescription FROM CategoriesList INNER JOIN Recipes ON CategoriesList.Category_ID = Recipes.Category_ID WHERE RecipeName LIKE '%@RecipesName%'";
            int NumberRows = 0;

            int i = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add("@RecipesName", SqlDbType.NVarChar);
                command.Parameters["@RecipesName"].Value=RN;
                SqlDataReader reader = command.ExecuteReader();                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NumberRows++;
                    }
                    RecipeList = new RecipeCardModels[NumberRows];
                    obj = new object[NumberRows];
                    reader.Close();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        RecipeCardModels Recipe = new RecipeCardModels();
                        Recipe.RecipeName = (string)reader.GetValue(0);
                        Recipe.Category = (string)reader.GetValue(1);
                        Recipe.PPhotoRecipe = (string)reader.GetValue(2);
                        Recipe.RecipeDescription = (string)reader.GetValue(3);
                        obj[i] = Recipe;
                        RecipeList[i] = (RecipeCardModels)obj[i];
                        i++;
                    }
                    reader.Close();
                }
                else
                {
                    RecipeCardModels Recipe = new RecipeCardModels();
                    Recipe.RecipeName = "Not Found";
                    Recipe.Category = "Not Found";
                    Recipe.PPhotoRecipe = "Not Found";
                    Recipe.RecipeDescription = "Not Found";
                    obj[0] = Recipe;
                    RecipeList[0] = (RecipeCardModels)obj[0];
                }
            }
            return RecipeList;
        }

        //End Get Metods

        //Post Metods

        public ViewRecipeAddModels AddRecord(ViewRecipeAddModels NR)
        {
            for (int i = 0; i < NR.ProductID.Length; i++)
            {
                string connectionString = @"Data Source = (localdb)\v11.0; Initial Catalog = RecipeBooks; Integrated Security = True";
                string sqlExpression = "INSERT INTO [Recipes] ([Dish_ID], [RecipeName], [Product_ID], [WeightProduct], [Category_ID], [CookingTime], [CookingTemperature], [CookingProcess], [PPhotoRecipe], [RecipeDescription]) VALUES (@Value1,@Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8,@Value9,@Value10)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.AddWithValue("@Value1", NR.DishID);
                    command.Parameters.AddWithValue("@Value2", NR.RecipeName);
                    command.Parameters.AddWithValue("@Value3", NR.ProductID[i]);
                    command.Parameters.AddWithValue("@Value4", NR.WeightProduct);
                    command.Parameters.AddWithValue("@Value5", NR.CategoryID);
                    command.Parameters.AddWithValue("@Value6", NR.CookingTime);
                    command.Parameters.AddWithValue("@Value7", NR.CookingTemperature);
                    command.Parameters.AddWithValue("@Value8", NR.CookingProcess);
                    command.Parameters.AddWithValue("@Value9", NR.PPhotoRecipe);
                    command.Parameters.AddWithValue("@Value10", NR.RecipeDescription);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ms)
                    {
                        NR = new ViewRecipeAddModels();
                        NR.RecipeName = ms.ToString();
                    }
                }
            }
            return NR;
        }

        //End Post Metods

        //Delete Metods
        public string DeletRecipe(int DishID)
        {
            string connectionString = @"Data Source = (localdb)\v11.0; Initial Catalog = RecipeBooks; Integrated Security = True";
            string sqlExpression = $"DELETE FROM Recipes WHERE Dish_ID = '{DishID}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                try
                {
                    command.ExecuteNonQuery();
                    return "Successful execution";
                }
                catch
                {
                    return "Not successful execution";
                }
            }
        }
       
        public string DeletRecipeOnName(string RecipeName)
        {
            string connectionString = @"Data Source = (localdb)\v11.0; Initial Catalog = RecipeBooks; Integrated Security = True";
            string sqlExpression = $"DELETE FROM Recipes WHERE RecipeName = '{RecipeName}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                try
                {
                    command.ExecuteNonQuery();
                    return "Successful execution";
                }
                catch
                {
                    return "Not successful execution";
                }
            }
        }
        //End Delete Metods
        
        //Put Metods
        //End Put Metods
    }
}