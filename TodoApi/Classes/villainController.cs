using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System;
using HeroGameApi;


namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VillainController : ControllerBase
    {
        
        
        
        [HttpGet("{villainId}")]
        public Villain getVillainById(int villainId)
        {
            //connection string
            using (SqlConnection sqlConnection = new SqlConnection("Server=jaddb.cczgdgxklsc1.us-east-1.rds.amazonaws.com,1433;Database=HeroDB;User Id=admin;password=testtesttest"))
            {
                //selects Villain of entered id if exists
                SqlCommand sqlCommand = new SqlCommand
                ("SELECT * FROM VILLAIN WHERE VillainId = @id", 
                sqlConnection);

                sqlCommand.Parameters.Add
                ("@id", 
                SqlDbType.Int);
                sqlCommand.Parameters
                ["@id"].Value = villainId;

                sqlConnection.Open();

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.Read())
                    {
                        return new Villain((int)sqlDataReader[0], sqlDataReader[1].ToString(), (int)sqlDataReader[2]);
                    }
                }
            }
            //returns invalid villain if VillainId doesnt exist
            return new Villain(0, "VillainIdIncorrect", 0);
        }
    }
}