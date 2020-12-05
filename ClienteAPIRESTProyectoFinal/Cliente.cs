using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClienteAPIRESTProyectoFinal
{
    public class Cliente
    {
        public int CodCliente { get; set; }
        public string NroDocumento { get; set; }
        public string NombreRazonSocial { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return this.NroDocumento;
        }

        public static async Task<List<Cliente>> ObtenerTodos()
        {
            List<Cliente> lstpersonas = new List<Cliente>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://sistemacontroldetrabajo.azurewebsites.net/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xmlns"));

                HttpResponseMessage respuesta = await client.GetAsync("api/ClientesAPI");

                if (respuesta.IsSuccessStatusCode)
                {
                    lstpersonas = await respuesta.Content.ReadAsAsync<List<Cliente>>();
                }
            }

            return lstpersonas;
        }

        public static async Task<bool> AgregarCliente(Cliente c)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://sistemacontroldetrabajo.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xmlns"));

                HttpResponseMessage respuesta = await client.PostAsJsonAsync("api/ClientesAPI", c);
                return respuesta.IsSuccessStatusCode;
            }
        }

        public static async Task<bool> ModificarCliente(Cliente c)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://sistemacontroldetrabajo.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xmlns"));
                HttpResponseMessage respuesta = await client.PutAsJsonAsync("api/ClientesAPI/" + c.CodCliente, c);
                return respuesta.IsSuccessStatusCode;
            }
        }

        public static async Task<bool> EliminarCliente(Cliente c)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://sistemacontroldetrabajo.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xmlns"));
                HttpResponseMessage respuesta = await client.DeleteAsync("api/ClientesAPI/" + c.CodCliente);
                return respuesta.IsSuccessStatusCode;
            }
        }

    }
}
