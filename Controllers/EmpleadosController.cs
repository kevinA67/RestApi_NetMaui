using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PM022024RestApi.Controllers
{
    public static class EmpleadosController
    {

        //CREATE
        public async static Task<int> CreateEmpleados(Models.Empleados Empleados)
        {
            try
            {
                String jsonObject = JsonConvert.SerializeObject(Empleados);
                System.Net.Http.StringContent contenido = new StringContent(jsonObject, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = null;
                    response = await client.PostAsync(Config.Config.EndPointCreate, contenido);

                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsStringAsync().Result;
                        }
                        else
                        {
                            Console.WriteLine($"Ha ocurrido un error: {response.ReasonPhrase}");
                            return -1;
                        }
                    }
                }
                return 1;
            }
            catch (Exception ex) {
                Console.WriteLine($"Ha ocurrido un error: {ex.ToString()}");
                return -1;
            }
           
        }

        //READ
        public async static Task<List<Models.Empleados>> GetEmpleados()
        {
            List<Models.Empleados> EmpleadosList = new List<Models.Empleados> ();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = null;
                    response = await client.GetAsync(Config.Config.EndPointList);

                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsStringAsync().Result;
                            try
                            {
                                EmpleadosList = JsonConvert.DeserializeObject<List<Models.Empleados>>(result);
                            }
                            catch (JsonException ex)
                            {

                            }
                        }
                    }
                    return EmpleadosList;
                }
            }
            catch (Exception ex) {
                return null;
            }
        }

        //UPDATE
        //DELETE
    }
}
