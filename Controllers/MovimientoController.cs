using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private string _connection = @"Server=localhost; Database=inventoryapi; Uid=root; Pwd=admin";

        [HttpGet("Getmovimientos")]
        public IActionResult Getmovimientos()
        {
            IEnumerable<Models.Product> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "select * from movimientos";
                lst = db.Query<Models.Product>(sql);
            }

            return Ok(lst);
        }

        [HttpPost("InsertMovimientos")]
        public IActionResult InsertMovimientos(Models.Product model,Models.Usuario usuario, Models.Movimiento movimiento, string cantidad)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "insert into movimientos(nombre,precio,cantidad)" +
                    " values(@nombre,@precio,@cantidad)";
                result = db.Execute(sql, model);

            }
            return Ok(result);
        }




    }
}
