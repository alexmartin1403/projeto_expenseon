using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIExpenseon.Controllers
{
    public class ValuesController : ApiController
    {
        

        // GET api/values

        //public IEnumerable<string> Get()
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"SELECT [NOME]
      ,[RES_HOTEL]
      ,[ESTRELAS]
      ,[LOGRADOURO]
      ,[NUMERO]
      ,[BAIRRO]
      ,[CIDADE]
      ,[ESTADO]
      ,[ESTACIONAMENTO]
      ,[PISCINA]
      ,[SAUNA]
      ,[WIFI]
      ,[RESTAURANTE]
      ,[BAR]
      ,[ACADEMIA] FROM [bancoexpenseon].[dbo].[HOTEL]";

            using (var con = new SqlConnection("Data Source=den1.mssql8.gear.host;Initial Catalog=bancoexpenseon;Persist Security Info=True;User ID=bancoexpenseon;Password=expense@1975;MultipleActiveResultSets=True;Application Name=EntityFramework"))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
