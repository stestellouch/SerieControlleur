﻿using SerieControlleur.Models;
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
    }
}
