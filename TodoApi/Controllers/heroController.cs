using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using HeroGameApi;

namespace HeroGameApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        [HttpGet("{heroId}")]
        public Hero getHeroById(int heroId)
        {
            using (SqlConnection sqlConnection = new SqlConnection("workstation id=MasterDBJad.mssql.somee.com;packet size=4096;user id=jadDb_103596586;pwd=Skylines33;data source=MasterDBJad.mssql.somee.com;persist security info=False;initial catalog=MasterDBJad"))
            {
            
            }
        }
    }
}