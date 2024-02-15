using Newtonsoft.Json;
using SerieControlleur.Models;
using SerieControlleur.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SerieControlleur.Services
{
    public class WSService
    {
        HttpClient client = new HttpClient();

        public WSService(string uri)
        {
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<List<Serie>> GetSeriesAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Serie>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public async Task<bool> PostSerieAsync(string nomControleur, Serie serie)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(nomControleur, serie);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteSerieAsync(string nomControleur, int serieId)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"{nomControleur}/{serieId}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<Serie> GetSerieByIdAsync(string nomControleur, int serieId)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{nomControleur}/{serieId}");
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Serie>(responseBody);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> UpdateSerieAsync(string nomControleur, int serieId, Serie serie)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"{nomControleur}/{serieId}", serie);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
