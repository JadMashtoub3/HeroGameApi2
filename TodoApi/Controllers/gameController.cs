using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System;
using HeroGameApi;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace HeroGameApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class gameController : ControllerBase
    {
        
        
        
        [HttpPost] //gameid
        public void logGame([FromBody] JObject jsonBody)
        {
            //TODO: fix connection string
            using (SqlConnection sqlConnection = new SqlConnection("Server=jaddb.cczgdgxklsc1.us-east-1.rds.amazonaws.com,1433;Database=HeroDB;User Id=admin;password=testtesttest"))
            {
                //inserts
                SqlCommand sqlCommand = new SqlCommand
                ("INSERT INTO GAME (GameId, Date, Winner) VALUES ((SELECT MAX(GameId) FROM Game))", 
                sqlConnection);
                
                //returns winner and throws down date
                sqlCommand.Parameters.AddWithValue
                ("@winner", 
                SqlDbType.NVarChar);
                sqlCommand.Parameters
                ["@winner"].Value = jsonBody
                ["Winner"].Value<string>();
                
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            }
        }
    }
}