using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System;
using HeroGameApi;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
       
       
       
        [HttpGet("{heroId}")]
        public Hero getHeroById(int heroId)
        {
            //TODO: fix connection string
            using (SqlConnection sqlConnection = new SqlConnection("Server=jaddb.cczgdgxklsc1.us-east-1.rds.amazonaws.com,1433;Database=HeroDB;User Id=admin;password=testtesttest"))
            {
                //selects hero's of entered id if exists
                SqlCommand sqlCommand = new SqlCommand
                ("SELECT * FROM HERO WHERE HeroId = @id", 
                sqlConnection);
                //adds hero with entered id
                sqlCommand.Parameters.Add
                ("@id", 
                SqlDbType.Int);
                sqlCommand.Parameters
                ["@id"].Value = heroId;
                
                sqlConnection.Open();

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.Read())
                    {
                        return new Hero((int)sqlDataReader[0], sqlDataReader[1].ToString(), (int)sqlDataReader[2], (int)sqlDataReader[3]);
                    }
                }
            }
            //returns invalid hero if heroId doesnt exist
            return new Hero(0, "HeroIdIncorrect", 0, 0);
        }
    }
}