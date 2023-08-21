using Newtonsoft.Json;
using SimplePressureRegulator.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SimplePressureRegulator.Services
{
    public static class InternetProductService
    {
        static string BaseUrl = "https://plastomaticappapi.azurewebsites.net/";

        static HttpClient client;

        static InternetProductService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public static async Task<IEnumerable<Product>> GetPRHM(string _valveSize, string _bodyMaterial, string _sealMaterial)
        {
            var json = await client.GetStringAsync($"api/products/PRHM/" + _valveSize + "/" + _bodyMaterial + "/" + _sealMaterial);
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            return products;
        }
        public static async Task<IEnumerable<Product>> GetPRD(string _valveSize, string _bodyMaterial, string _sealMaterial)
        {
            var json = await client.GetStringAsync($"api/products/PRD/" + _valveSize + "/" + _bodyMaterial + "/" + _sealMaterial);
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            return products;
        }
        public static async Task<IEnumerable<Product>> GetPRHU(string _valveSize, string _spigotType)
        {
            var json = await client.GetStringAsync($"api/products/PRHU/" + _valveSize + "/" + _spigotType);
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            return products;
        }
        public static async Task<IEnumerable<Product>> GetUPR(string _valveSize, string _spigotType)
        {
            var json = await client.GetStringAsync($"api/products/UPR/" + _valveSize + "/" + _spigotType);
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            return products;
        }
        public static async Task<IEnumerable<Product>> GetUPRS(string _valveSize, string _spigotType, string _gauge)
        {
            var json = await client.GetStringAsync($"api/products/UPRS/" + _valveSize + "/" + _spigotType + "/" + _gauge);
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            return products;
        }
    }
}
