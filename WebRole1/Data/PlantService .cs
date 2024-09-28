using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebRole1.Models;

namespace WebRole1.Data
{
    public class PlantService
    {
        private Connection sql;
        public PlantService()
        {
            sql = new Connection();
        }

        public void insertPlants(Plant plants)
        {

            using (var connection = new SqlConnection(sql.getconnection()))
            {
                var command = new SqlCommand(" EXEC InsertPlant @PlantName, @Species,@Price,@InStock", connection);
                command.Parameters.AddWithValue("@PlantName", plants.PlantName);
                command.Parameters.AddWithValue("@Species", plants.Species);
                command.Parameters.AddWithValue("@Price", plants.Price);
                command.Parameters.AddWithValue("@InStock", plants.InStock);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public List<Plant> GetAllPlants()
        {
            var plants = new List<Plant>();

            using (var connection = new SqlConnection(sql.getconnection()))
            {

                var command = new SqlCommand("EXEC GetPlants", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        plants.Add(new Plant
                        {
                            PlantId = reader.GetInt32(reader.GetOrdinal("PlantId")),
                            PlantName = reader.GetString(reader.GetOrdinal("PlantName")),
                            Species = reader.GetString(reader.GetOrdinal("Species")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            InStock = reader.GetInt32(reader.GetOrdinal("InStock"))
                        });
                    }
                }
            }

            return plants;
        }

        public Plant GetPlantById(int id)
        {
            Plant item = null;

            using (var connection = new SqlConnection(sql.getconnection()))
            {
                var command = new SqlCommand("EXEC GetPlantByID @PlantID", connection);
                command.Parameters.AddWithValue("@PlantID", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        item = new Plant()
                        {
                            PlantId = reader.GetInt32(reader.GetOrdinal("PlantId")),
                            PlantName = reader.GetString(reader.GetOrdinal("PlantName")),
                            Species = reader.GetString(reader.GetOrdinal("Species")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            InStock = reader.GetInt32(reader.GetOrdinal("InStock"))
                        };
                    }
                }
            }

            return item;
        }



        public void UpdatePlant(Plant plant)
        {

            try
            {
                using (var connection = new SqlConnection(sql.getconnection()))
                {
                    var command = new SqlCommand("EXEC UpdatePlant @PlantID, @PlantName,@Species, @Price, @InStock", connection);
                    command.Parameters.AddWithValue("@PlantID", plant.PlantId);
                    command.Parameters.AddWithValue("@PlantName", plant.PlantName);
                    command.Parameters.AddWithValue("@Species", plant.Species);
                    command.Parameters.AddWithValue("@Price", plant.Price);
                    command.Parameters.AddWithValue("@InStock", plant.InStock);
                    connection.Open();
                    command.ExecuteNonQuery();

                    var rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception("No rows were updated. The item might not exist.");
                    }
                }

            }
            catch (Exception ex)
            {
                // Log the exception or rethrow it
                throw new ApplicationException("An error occurred while updating the item.", ex);
            }
        }

        public void Delete(int id)
        {

            try
            {
                using (var connection = new SqlConnection(sql.getconnection()))
                {
                    var command = new SqlCommand("EXEC DeletePlant @PlantID", connection);
                    command.Parameters.AddWithValue("@PlantID", id);

                    connection.Open();
                    command.ExecuteNonQuery();

 
                }

            }
            catch (Exception ex)
            {
                // Log the exception or rethrow it
                throw new ApplicationException("An error occurred while updating the item.", ex);
            }
        }

    }
    
}