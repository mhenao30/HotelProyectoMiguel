using HotelesProyecto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HotelesProyecto.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {

        private readonly IConfiguration _configuration;


        public HotelController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select idhotel, nombre, categoria, img1, img2, img3, calificaciones from hotel";

            DataTable tabla = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelesApp");
            MySqlDataReader reader;

            using (MySqlConnection conn = new MySqlConnection(sqlDataSource))
            {
                conn.Open();
                using (MySqlCommand comando = new MySqlCommand(query, conn))
                {
                    reader = comando.ExecuteReader();
                    tabla.Load(reader);

                    reader.Close();
                    conn.Close();
                }
            }
            return new JsonResult(tabla);
        }
        [HttpGet("{Categoria}")]
        public JsonResult Get(int Categoria)
        {
            string query = @"select idhotel, nombre, categoria, img1, img2, img3, calificaciones from hotel where categoria = @categoria";

            DataTable tabla = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelesApp");
            MySqlDataReader reader;

            using (MySqlConnection conn = new MySqlConnection(sqlDataSource))
            {
                conn.Open();
                using (MySqlCommand comando = new MySqlCommand(query, conn))
                {
                    comando.Parameters.AddWithValue("@categoria", Categoria);
                    reader = comando.ExecuteReader();
                    tabla.Load(reader);

                    reader.Close();
                    conn.Close();
                }
            }
            return new JsonResult(tabla);
        }

        [HttpPost]
        public JsonResult Post(Hotel hotel)
        {
            string query = @"insert into hotel(nombre, categoria, img1, img2, img3, calificaciones) values(@nombre, @categoria, @imagen1, @imagen2, @imagen3, @calificaciones)";

            DataTable tabla = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelesApp");
            MySqlDataReader reader;
            using (MySqlConnection conn = new MySqlConnection(sqlDataSource))
            {
                conn.Open();
                using (MySqlCommand comando = new MySqlCommand(query, conn))
                {
                    comando.Parameters.AddWithValue("@nombre", hotel.nombre);
                    comando.Parameters.AddWithValue("@categoria", hotel.categoria);
                    comando.Parameters.AddWithValue("@imagen1", hotel.img1);
                    comando.Parameters.AddWithValue("@imagen2", hotel.img2);
                    comando.Parameters.AddWithValue("@imagen3", hotel.img3);
                    comando.Parameters.AddWithValue("@calificaciones", hotel.calificaciones);


                    reader = comando.ExecuteReader();
                    tabla.Load(reader);

                    reader.Close();
                    conn.Close();
                }
            }

            return new JsonResult("Hotel Agregado");
        }

        [HttpPut]
        public JsonResult Put(Hotel hotel)
        {
            string query = @"update hotel set nombre = @nombre, categoria = @categoria, img1 = @imagen1, img2 = @imagen2, img3 = @imagen3, calificaciones = @calificaciones where idhotel = @idhotel";

            DataTable tabla = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelesApp");
            MySqlDataReader reader;
            using (MySqlConnection conn = new MySqlConnection(sqlDataSource))
            {
                conn.Open();
                using (MySqlCommand comando = new MySqlCommand(query, conn))
                {
                    comando.Parameters.AddWithValue("@idhotel", hotel.idhotel);
                    comando.Parameters.AddWithValue("@nombre", hotel.nombre);
                    comando.Parameters.AddWithValue("@categoria", hotel.categoria);
                    comando.Parameters.AddWithValue("@imagen1", hotel.img1);
                    comando.Parameters.AddWithValue("@imagen2", hotel.img2);
                    comando.Parameters.AddWithValue("@imagen3", hotel.img3);
                    comando.Parameters.AddWithValue("@calificaciones", hotel.calificaciones);
                    reader = comando.ExecuteReader();
                    tabla.Load(reader);

                    reader.Close();
                    conn.Close();
                }
            }

            return new JsonResult("Hotel Actualizado");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from hotel where idhotel = @idhotel";

            DataTable tabla = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelesApp");
            MySqlDataReader reader;
            using (MySqlConnection conn = new MySqlConnection(sqlDataSource))
            {
                conn.Open();
                using (MySqlCommand comando = new MySqlCommand(query, conn))
                {
                    comando.Parameters.AddWithValue("@idhotel", id);
                    reader = comando.ExecuteReader();
                    tabla.Load(reader);

                    reader.Close();
                    conn.Close();
                }
            }

            return new JsonResult("Hotel Eliminado");
        }
    }

 }

