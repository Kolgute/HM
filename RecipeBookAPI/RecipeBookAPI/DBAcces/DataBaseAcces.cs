using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Xml;
using RecipeBookAPI.Models;

namespace RecipeBookAPI.DBAcces
{
    public class DataBaseAcces
    {

        public string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //Get Metods

        public List<RecipeCardModels> RecipesCard()
        {
            List<RecipeCardModels> recipeList = new List<RecipeCardModels>();
            RecipeCardModels recipe = new RecipeCardModels();
            
            string sqlExpression = "RecipeCards";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        recipe.RecipeName = (string)reader.GetValue(0);
                        recipe.Category = (string)reader.GetValue(1);
                        recipe.PPhotoRecipe = (string)reader.GetValue(2);
                        recipe.RecipeDescription = (string)reader.GetValue(3);
                        recipe.dishID = (int)reader.GetValue(4);
                        recipeList.Add(recipe);
                        recipe = new RecipeCardModels();
                    }
                    reader.Close();
                }
            }
            return recipeList;
        }

        public OneRecipeModels Recipe(int Dish_ID)
        {
            OneRecipeModels recipe = new OneRecipeModels();
            recipe.productAndWeight = new List<Tuple<string, string>>();
            string sqlExpression = "OneRecipe";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@ID",
                    Value = Dish_ID
                };
                command.Parameters.Add(nameParam);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {                  
                    while (reader.Read())
                    {
                        recipe.DishID = (int)reader.GetValue(0);
                        recipe.RecipeName = (string)reader.GetValue(1);
                        recipe.productAndWeight.Add(Tuple.Create((string)reader.GetValue(2), (string)reader.GetValue(3)));
                        recipe.Category = (string)reader.GetValue(4);
                        recipe.CookingTime = (string)reader.GetValue(5);
                        recipe.CookingTemperature = (string)reader.GetValue(6);
                        recipe.CookingProcess = (string)reader.GetValue(7);
                        recipe.PPhotoRecipe = (string)reader.GetValue(8);
                        recipe.RecipeDescription = (string)reader.GetValue(9);
                        
                    }
                    reader.Close();
                }
            }
            return recipe;
        }

        public List<RecipeCardModels> SearchByRN(string RN)
        {
            List<RecipeCardModels> RecipeList = new List<RecipeCardModels>();
            RecipeCardModels Recipe = new RecipeCardModels();
            SqlParameter parameter;
            
            string sqlExpression = "SearchByRN";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;            
                command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@RN", Value = RN });
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Recipe.RecipeName = (string)reader.GetValue(0);
                        Recipe.Category = (string)reader.GetValue(1);
                        Recipe.PPhotoRecipe = (string)reader.GetValue(2);
                        Recipe.RecipeDescription = (string)reader.GetValue(3);
                        Recipe.dishID = (int)reader.GetValue(4);
                        RecipeList.Add(Recipe);
                        Recipe = new RecipeCardModels();
                    }
                    reader.Close();
                }
                else
                {
                    Recipe.RecipeName = "Not Found";
                    Recipe.Category = "Not Found";
                    Recipe.PPhotoRecipe = "Not Found";
                    Recipe.RecipeDescription = "Not Found";
                    RecipeList.Add(Recipe);
                }
            }
            return RecipeList;
        }

        public List<RecipeCardModels> SearchByDish(int Dish)
        {
            List<RecipeCardModels> RecipeList = new List<RecipeCardModels>();
            RecipeCardModels Recipe = new RecipeCardModels();
            
            string sqlExpression = "SearchByDish";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@Dish_ID",
                    Value = Dish
                };
                command.Parameters.Add(nameParam);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Recipe.RecipeName = (string)reader.GetValue(0);
                        Recipe.Category = (string)reader.GetValue(1);
                        Recipe.PPhotoRecipe = (string)reader.GetValue(2);
                        Recipe.RecipeDescription = (string)reader.GetValue(3);
                        Recipe.dishID = (int)reader.GetValue(4);
                        RecipeList.Add(Recipe);
                        Recipe = new RecipeCardModels();
                    }
                    reader.Close();
                }
                else
                {
                    Recipe.RecipeName = "Not Found";
                    Recipe.Category = "Not Found";
                    Recipe.PPhotoRecipe = "Not Found";
                    Recipe.RecipeDescription = "Not Found";
                    RecipeList.Add(Recipe);
                }
            }
            return RecipeList;
        }

        public List<RecipeCardModels> SearchByCategory(int category)
        {
            List<RecipeCardModels> RecipeList = new List<RecipeCardModels>();
            RecipeCardModels Recipe = new RecipeCardModels();

            string sqlExpression = "SearchByCategory";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@category",
                    Value = category
                };
                command.Parameters.Add(nameParam);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Recipe.RecipeName = (string)reader.GetValue(0);
                        Recipe.Category = (string)reader.GetValue(1);
                        Recipe.PPhotoRecipe = (string)reader.GetValue(2);
                        Recipe.RecipeDescription = (string)reader.GetValue(3);
                        Recipe.dishID = (int)reader.GetValue(4);
                        RecipeList.Add(Recipe);
                        Recipe = new RecipeCardModels();
                    }
                    reader.Close();
                }
                else
                {
                    Recipe.RecipeName = null;
                    Recipe.Category = null;
                    Recipe.PPhotoRecipe = null;
                    Recipe.RecipeDescription = null;
                    RecipeList.Add(Recipe);
                }
            }
            return RecipeList;
        }

        public List<CategoryList> CategoryLists()
        {
            List<CategoryList> response = new List<CategoryList>();
            CategoryList res = new CategoryList();

            string sqlExpression = "CategoryList";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        res.cateheryID = ((int)reader.GetValue(0));
                        res.categoryName = ((string)reader.GetValue(1));
                        response.Add(res);
                        res = new CategoryList();
                    }
                }
                else
                {
                    return response;
                }
            }
            return response;
        }
     
        //End Get Metods

        //Post Metods

        public string AddRecord(ViewRecipeAddModels NR)
        {
  
            VRAM recipe = new VRAM();
            recipe.Product = new List<int>(NR.Product.Count);
            SqlParameter parameter;
            
            for (int i = 0;i<NR.Product.Count;i++)
            { CheckProduct(NR.Product[i]); }
            CheckCategory(NR.Category);
            int dish = LastDish() + 1;
            for (int i = 0; i< NR.Product.Count; i++)
            {
                string sqlExpression = "SearchProduct";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@Product", Value = NR.Product[i] });
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    recipe.Product.Add(reader.GetInt32(0));    
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SearchCategory";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@Category", Value = NR.Category });
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                recipe.Category = reader.GetInt32(0);
            }
            for (int i = 0; i < NR.Product.Count; i++)
                {
                 string sqlExpression = "AddRecord";
                 using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@Dish_ID", Value = dish });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@RecipeName", Value = NR.RecipeName });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@Product_ID", Value = recipe.Product[i] });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@WeightProduct", Value = NR.WeightProduct });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@Category_ID", Value = recipe.Category });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@CookingTime", Value = NR.CookingTime });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@CookingTemperature", Value = NR.CookingTemperature });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@CookingProcess", Value = NR.CookingProcess });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@PPhotoRecipe", Value = NR.PPhotoRecipe });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@RecipeDescription", Value = NR.RecipeDescription });
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ms)
                    {
                        return "Fail";
                    }
                    }
                }
            return "Success";
        }

        //End Post Metods

        //Delete Metods
        public string DeletRecipe(int DishID)
        {
            SqlParameter parameter;
            
            string sqlExpression = "DeleteRecord";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@Dish_ID", Value = DishID });
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
        public string UpdateRecipe(ViewRecipeAddModels UR)
        {
            if (UR.DishID == 0)
            {
                return "Fail";
            }
            VRAM recipe = new VRAM();
            recipe.Product = new List<int>(UR.Product.Count);
            SqlParameter parameter;
            for (int i = 0; i < UR.Product.Count; i++) { CheckProduct(UR.Product[i]); }
            CheckCategory(UR.Category);
            for (int i = 0; i < UR.Product.Count; i++)
            {
                string sqlExpression = "SearchProduct";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@Product", Value = UR.Product[i] });
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    recipe.Product.Add(reader.GetInt32(0));
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SearchCategory";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@Category", Value = UR.Category });
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                recipe.Category = reader.GetInt32(0);
            }
            for (int i = 0; i < UR.Product.Count; i++)
            {
                string sqlExpression = "UpdateRecord";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@Dish_ID", Value = UR.DishID });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@RecipeName", Value = UR.RecipeName });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@Product_ID", Value = recipe.Product[i] });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@WeightProduct", Value = UR.WeightProduct });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@Category_ID", Value = recipe.Category });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@CookingTime", Value = UR.CookingTime });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@CookingTemperature", Value = UR.CookingTemperature });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@CookingProcess", Value = UR.CookingProcess });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@PPhotoRecipe", Value = UR.PPhotoRecipe });
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@RecipeDescription", Value = UR.RecipeDescription });
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        return "Fail";
                    }
                }
            }
            return "Success";
        }
        //End Put Metods

        //Help Metods
        public void CheckProduct(string product)
        {
                bool response = true;
                SqlParameter parameter;
                
                string sqlExpression = "SearchProduct";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@Product", Value = product });
                    SqlDataReader reader = command.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        response = false;                   
                    }
                }
                if (response == false)
            {
                AddProduct(product);
            }
        }

        public void AddProduct(string product)
        {
            SqlParameter parameter;
            
            string sqlExpression = "AddProduct";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@Product", Value = product });
                command.ExecuteNonQuery();
            }
        }

        public void CheckCategory(string category)
        {
            bool response = true;
            SqlParameter parameter;
            
            string sqlExpression = "SearchCategory";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@Category", Value = category });
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    response = false;                  
                }
            }
            if (response == false)
            {
                AddCategory(category);
            }
        }

        public void AddCategory(string category)
        {
            SqlParameter parameter;
            
            string sqlExpression = "AddCategory";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(parameter = new SqlParameter { ParameterName = "@Category", Value = category });
                command.ExecuteNonQuery();
            }
        }

        public int LastDish()
        {
            int response = 0;
            
            string sqlExpression = "SearchLastDish";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        response = (int)reader.GetValue(0);
                    }
                }
                else
                {
                    return 1;
                }      
            }
            return response;
        }

        //End Help Metods
    }
}