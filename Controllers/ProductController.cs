using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private string _connection = @"Server=localhost; Database=inventory; Uid=root; Pwd=admin";


        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Models.Product> lst = null;
            using (var db=new MySqlConnection(_connection))
            {
            var sql = "select id,description from product";
                lst = db.Query<Models.Product>(sql);
            }

            return Ok(lst);
        }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class InsertProductController : ControllerBase
    {
        private string _connection = @"Server=localhost; Database=inventory; Uid=root; Pwd=admin";

        [HttpPost]
        public IActionResult Insert(Models.Product model)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "insert into product(id,description,stock)"+
                    " values(@id,@description,@stock)";
                result = db.Execute(sql, model);
              
            }
            return Ok(result);
        }
    }

}
