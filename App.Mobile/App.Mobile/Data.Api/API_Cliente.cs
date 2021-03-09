using App.Mobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.Mobile.Data.Api
{
  public  class API_Cliente
    {

		/// <summary>
		/// Método para trazer as notas de um determinado cliente
		/// </summary>
		/// <param name="cliente"></param>
		/// <returns></returns>
		public async Task<Cliente> NotasCliente(string id_cliente)
		{
			var httpClientHandler = new HttpClientHandler();
			httpClientHandler.ServerCertificateCustomValidationCallback =
			(message, cert, chain, errors) => { return true; };
		
			try
			{
				using (var client = new HttpClient(httpClientHandler))
				{
					string URL = string.Concat(ConfigSystem.URLAPI, "/cliente/Notes/", id_cliente);//ESTRUTURA DA URI DO CONTROLLER
					client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
					var uri = new Uri(URL);
					HttpResponseMessage response = await client.GetAsync(uri);
					var responseString = response.Content.ReadAsStringAsync().Result;
					var json = JsonConvert.DeserializeObject<Cliente>(responseString);
					return json;
				};
			}
			catch (JsonException ex)
			{
				string ERRO = ex.Message;
				return new Cliente();
			}
			catch (HttpRequestException ex)
			{
				string ERRO = ex.Message;
				return new Cliente();
			}
			catch (Exception ex)
			{
				string ERRO = ex.Message;
				return new Cliente();
			}
			finally
			{
			}

		}


		public static async Task<Cliente> GetNotasAsync(string id_cliente)
		{
			var httpClientHandler = new HttpClientHandler();
			httpClientHandler.ServerCertificateCustomValidationCallback =
			(message, cert, chain, errors) => { return true; };

			using (var client = new HttpClient(httpClientHandler))
			{
				string URL = string.Concat(ConfigSystem.URLAPI, "/cliente/Notes/", id_cliente);//ESTRUTURA DA URI DO CONTROLLER
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
				var uri = new Uri(URL);
				HttpResponseMessage response = await client.GetAsync(uri);
				var responseString = response.Content.ReadAsStringAsync().Result;
				var json = JsonConvert.DeserializeObject<Cliente>(responseString);
				return json;
			};


		}

		public async Task<string> RegistarCliente(Cliente cliente)
		{
			var httpClientHandler = new HttpClientHandler();

			httpClientHandler.ServerCertificateCustomValidationCallback =
			(message, cert, chain, errors) => { return true; };

			var json = JsonConvert.SerializeObject(cliente);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			using (var client = new HttpClient(httpClientHandler))
			{
				string URL = string.Concat(ConfigSystem.URLAPI, "/api/cliente");//ESTRUTURA DA URI DO CONTROLLER
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
				var result = await client.PostAsync(URL, content);
				if (result.StatusCode == System.Net.HttpStatusCode.Created)
				{
					var error = await result.Content.ReadAsStringAsync();
					return error;
				}
				else if (result.StatusCode == System.Net.HttpStatusCode.OK)
				{
					var error = await result.Content.ReadAsStringAsync();
					return error;
				}
				else if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
				{
					var error = await result.Content.ReadAsStringAsync();
					return "Servidor indisponivel.";
				}
				else
				{
					var error = await result.Content.ReadAsStringAsync();
					return error;
				}
			};
		}

	}
}
