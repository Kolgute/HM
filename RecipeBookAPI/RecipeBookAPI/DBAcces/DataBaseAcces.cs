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

        public ViewRecipeModels OneRecipe(string RN)
        {
            ViewRecipeModels Recipe = new ViewRecipeModels();
            string[] ProductList = new string[1];

            string connectionString = @"Data Source = (localdb)\v11.0; Initial Catalog = RecipeBooks; Integrated Security = True";
            string sqlExpression = $"SELECT * FROM Recipes WHERE RecipeName = \"{RN}\"";
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
                    ProductList = new string[NumberRows];
                    reader.Close();
                    reader = command.ExecuteReader();
                    Recipe.RecipeID = (int)reader.GetValue(0);
                    Recipe.DishID = (int)reader.GetValue(1);
                    Recipe.RecipeName = (string)reader.GetValue(2);
                    Recipe.WeightProduct = (int)reader.GetValue(4);
                    Recipe.Category = (string)reader.GetValue(5);
                    Recipe.CookingTemperature = (string)reader.GetValue(6);
                    Recipe.CookingProcess = (string)reader.GetValue(7);
                    Recipe.CookingTime = (string)reader.GetValue(8);
                    Recipe.PPhotoRecipe = (string)reader.GetValue(9);
                    Recipe.RecipeDescription = (string)reader.GetValue(10);
                    while (reader.Read())
                    {
                        ProductList[i] = (string)reader.GetValue(3);    
                        i++;
                    }
                    Recipe.Products = ProductList;
                    reader.Close();
                }

            }
            return Recipe;
        }

        public RecipeCardModels[] RecipesCard()
        {
            RecipeCardModels[] RecipeList = new RecipeCardModels[1];
            object[] obj = new object[1];
            string connectionString = @"Data Source = (localdb)\v11.0; Initial Catalog = RecipeBooks; Integrated Security = True";
            string sqlExpression = "SELECT DISTINCT RecipeName, PPhotoRecipe, RecipeDescription FROM Recipes";
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
                        Recipe.PPhotoRecipe = (string)reader.GetValue(1);
                        Recipe.RecipeDescription = (string)reader.GetValue(2);
                        obj[i] = Recipe;
                        RecipeList[i] = (RecipeCardModels)obj[i];
                        i++;
                    }
                    reader.Close();
                }
            }
            return RecipeList;
        }

        public RecipeCardModels[] SearchByRN(string RN)
        {
            RecipeCardModels[] RecipeList = new RecipeCardModels[1];
            object[] obj = new object[1];
            string connectionString = @"Data Source = (localdb)\v11.0; Initial Catalog = RecipeBooks; Integrated Security = True";
            string sqlExpression = $"SELECT RecipeName, PPhotoRecipe, RecipeDescription FROM Recipes WHERE RecipeName = \"{RN}\"";
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

        public ViewRecipeAddModels AddRecord(ViewRecipeAddModels NR)
        {
            for(int i = 0; i < NR.ProductID.Length; i++)
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
    }
}