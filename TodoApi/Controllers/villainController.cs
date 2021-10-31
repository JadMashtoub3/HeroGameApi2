using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using HeroGameApi;

namespace HeroGameApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VillainController : ControllerBase
    {
        [HttpGet("{villainId}")]
        public Villain getVillainById(int villainId)
        {
            using (SqlConnection sqlConnection = new SqlConnection("workstation id=MasterDBJad.mssql.somee.com;packet size=4096;user id=jadDb_103596586;pwd=Skylines33;data source=MasterDBJad.mssql.somee.com;persist security info=False;initial catalog=MasterDBJad"))
            {

            }
        }
    }
}
