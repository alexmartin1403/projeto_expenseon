using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.MobileControls;
using System.Windows.Input;
using APIExpenseon.Models;

namespace APIExpenseon.Controllers
{
    public class HotelController : ApiController
    {
        SqlConnection con = new SqlConnection(@"Data Source=den1.mssql8.gear.host;Initial Catalog=bancoexpenseon;Persist Security Info=True;User ID=bancoexpenseon;Password=expense@1975;MultipleActiveResultSets=True;Application Name=EntityFramework");

        private bancoexpenseonEntities db = new bancoexpenseonEntities();

        // GET: api/Hotel
        public IQueryable<HOTEL> GetHOTEL( string nome, bool estacionamento, bool piscina, bool sauna, bool wifi, bool restaurante, bool bar, bool academia)
        {  
            return db.HOTEL.Where(n => n.NOME.Contains(nome) || (n.ESTACIONAMENTO.Equals(estacionamento) && n.PISCINA.Equals(piscina) && n.SAUNA.Equals(sauna) && n.WIFI.Equals(wifi) && n.RESTAURANTE.Equals(restaurante) && n.BAR.Equals(bar) && n.ACADEMIA.Equals(academia)));
        }

        // GET: api/Hotel/5
        [ResponseType(typeof(HOTEL))]
        public IQueryable<HOTEL> GetHOTEL(int id)
        {      
            return db.HOTEL.Where(n => n.ID.Equals(id));
        }

        // PUT: api/Hotel
        public string Put([FromBody] string inicio, string nome, string resumo, string estrelas, string logradouro, int numero, string bairro, string cidade, string estado, bool estacionamento, bool piscina, bool sauna, bool wifi, bool restaurante, bool bar, bool academia, int id)
        {
            SqlCommand cmd = new SqlCommand("UPDATE HOTEL SET NOME = '" + nome + "', RES_HOTEL ='" + resumo + "', ESTRELAS ='" + estrelas + "', LOGRADOURO ='" + logradouro + "', NUMERO ='" + numero + "', BAIRRO ='" + bairro + "', CIDADE ='" + cidade + "', ESTADO ='" + estado + "', ESTACIONAMENTO ='" + estacionamento + "', PISCINA ='" + piscina + "', SAUNA ='" + sauna + "', WIFI ='" + wifi + "', RESTAURANTE ='" + restaurante + "', BAR ='" + bar + "', ACADEMIA ='" + academia + "' WHERE ID = '" + id + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "ok";
            }
            else
            {
                return "nok";
            }
        }

        // POST: api/Hotel
        [ResponseType(typeof(HOTEL))]
        public IHttpActionResult PostHOTEL(HOTEL hOTEL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HOTEL.Add(hOTEL);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hOTEL.ID }, hOTEL);
        }

        // DELETE: api/Hotel/5
        public string Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM HOTEL WHERE ID = '" + id + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "ok";
            }
            else
            {
                return "nok";
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HOTELExists(int id)
        {
            return db.HOTEL.Count(e => e.ID == id) > 0;
        }
    }
}