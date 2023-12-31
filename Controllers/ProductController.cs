﻿using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private string _connection = @"Server=localhost; Database=inventoryapi; Uid=root; Pwd=admin";


        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            IEnumerable<Models.Product> lst = null;
            using (var db=new MySqlConnection(_connection))
            {
            var sql = "select * from productos";
                lst = db.Query<Models.Product>(sql);
            }

            return Ok(lst);
        }

        [HttpPost("InsertProduct")]
        public IActionResult InsertProduct(Models.Product model)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "insert into productos(nombre,precio,cantidad)" +
                    " values(@nombre,@precio,@cantidad)";
                result = db.Execute(sql, model);

            }
            return Ok(result);
        }

    }


}
