using App.Mobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.Mobile.Data.Api
{
   public class API_Nota
    {

		/// <summary>
		/// Método para eliminar uma nota
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<string> DeleteNote(Guid id)
		{
			var httpClientHandler = new HttpClientHandler();
			httpClientHandler.ServerCertificateCustomValidationCallback =
			(message, cert, chain, errors) => { return true; };

			try
			{
				using (var client = new HttpClient(httpClientHandler))
				{
					string URL = string.Concat(ConfigSystem.URLAPI, "/Nota/delete/", id);//ESTRUTURA DA URI DO CONTROLLER
					client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
					var uri = new Uri(URL);
					HttpResponseMessage response = await client.GetAsync(uri);
					var responseString = response.Content.ReadAsStringAsync().Result;
					return responseString;
				};
			}
			catch (JsonException ex)
			{
				string ERRO = ex.Message;
				return ERRO;
			}
			catch (HttpRequestException ex)
			{
				string ERRO = ex.Message;
				return ERRO;
			}
			catch (Exception ex)
			{
				string ERRO = ex.Message;
				return ERRO;
			}
			finally
			{
			}

		}

		public async Task<Note> SaveNote(Note note)
		{
			var httpClientHandler = new HttpClientHandler();

			httpClientHandler.ServerCertificateCustomValidationCallback =
			(message, cert, chain, errors) => { return true; };

			var json = JsonConvert.SerializeObject(note);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			using (var client = new HttpClient(httpClientHandler))
			{
				string URL = string.Concat(ConfigSystem.URLAPI, "/Nota");//ESTRUTURA DA URI DO CONTROLLER
																				   //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
				var result = await client.PostAsync(URL, content);
				if (result.StatusCode == System.Net.HttpStatusCode.Created)
				{
					var error = await result.Content.ReadAsStringAsync();
					var Result = JsonConvert.DeserializeObject<Note>(error);
					return Result;
				}
				else if (result.StatusCode == System.Net.HttpStatusCode.OK)
				{
					var error = await result.Content.ReadAsStringAsync();
					var Token = JsonConvert.DeserializeObject<Note>(error);
					return Token;
				}
				else if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
				{
					var error = await result.Content.ReadAsStringAsync();
					var Result = JsonConvert.DeserializeObject<Note>(error);
					return Result;
				}
				else
				{
					var error = await result.Content.ReadAsStringAsync();
					var Result = JsonConvert.DeserializeObject<Note>(error);
					return Result;
				}
			};
		}

		public async Task<Note> UpdateNote(Note note)
		{
			var httpClientHandler = new HttpClientHandler();

			httpClientHandler.ServerCertificateCustomValidationCallback =
			(message, cert, chain, errors) => { return true; };

			var json = JsonConvert.SerializeObject(note);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			using (var client = new HttpClient(httpClientHandler))
			{
				string URL = string.Concat(ConfigSystem.URLAPI, "/Nota/update");//ESTRUTURA DA URI DO CONTROLLER
																		 //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
				var result = await client.PostAsync(URL, content);
				if (result.StatusCode == System.Net.HttpStatusCode.Created)
				{
					var error = await result.Content.ReadAsStringAsync();
					var Result = JsonConvert.DeserializeObject<Note>(error);
					return Result;
				}
				else if (result.StatusCode == System.Net.HttpStatusCode.OK)
				{
					var error = await result.Content.ReadAsStringAsync();
					var Token = JsonConvert.DeserializeObject<Note>(error);
					return Token;
				}
				else if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
				{
					var error = await result.Content.ReadAsStringAsync();
					var Result = JsonConvert.DeserializeObject<Note>(error);
					return Result;
				}
				else
				{
					var error = await result.Content.ReadAsStringAsync();
					var Result = JsonConvert.DeserializeObject<Note>(error);
					return Result;
				}
			};
		}
	}
}
