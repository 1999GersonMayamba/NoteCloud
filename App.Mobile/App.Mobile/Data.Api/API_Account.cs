using App.Mobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.Mobile.Data.Api
{
  public  class API_Account
    {

		/// <summary>
		/// Método para se autenticar na web api
		/// </summary>
		/// <param name="account">Objecto com os dados do utilizador</param>
		/// <returns></returns>
		public async Task<Account> Login(Account account)
		{

			var json = JsonConvert.SerializeObject(account);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			using (var client = new HttpClient())
			{
				string URL = string.Concat(ConfigSystem.URLAPI, "/account/entrar");//ESTRUTURA DA URI DO CONTROLLER
				//client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
				var result = await client.PostAsync(URL, content);
				if (result.StatusCode == System.Net.HttpStatusCode.Created)
				{
					var error = await result.Content.ReadAsStringAsync();
					var Result = JsonConvert.DeserializeObject<Account>(error);
					return Result;
				}
				else if (result.StatusCode == System.Net.HttpStatusCode.OK)
				{
					var error = await result.Content.ReadAsStringAsync();
					var Token = JsonConvert.DeserializeObject<Account>(error);
					return Token;
				}
				else if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
				{
					var error = await result.Content.ReadAsStringAsync();
					var Result = JsonConvert.DeserializeObject<Account>(error);
					return Result;
				}
				else
				{
					var error = await result.Content.ReadAsStringAsync();
					var Result = JsonConvert.DeserializeObject<Account>(error);
					return Result;
				}
			};
		}

		/// <summary>
		/// Método para criar uma nova conta na web api
		/// </summary>
		/// <param name="account">Objecto com os dados do utilixador</param>
		/// <returns></returns>
		public async Task<Account> CreateAccount(Account account)
		{

			var json = JsonConvert.SerializeObject(account);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			using (var client = new HttpClient())
			{
				string URL = string.Concat(ConfigSystem.URLAPI, "/account/nova-conta");//ESTRUTURA DA URI DO CONTROLLER
																			//client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ConfigSystem.Token);
				var result = await client.PostAsync(URL, content);
				if (result.StatusCode == System.Net.HttpStatusCode.Created)
				{
					var error = await result.Content.ReadAsStringAsync();
					var Result = JsonConvert.DeserializeObject<Account>(error);
					return Result;
				}
				else if (result.StatusCode == System.Net.HttpStatusCode.OK)
				{
					var error = await result.Content.ReadAsStringAsync();
					var Result = JsonConvert.DeserializeObject<Account>(error);
					return Result;
				}
				else if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
				{
					var error = await result.Content.ReadAsStringAsync();
					var Result = JsonConvert.DeserializeObject<Account>(error);
					return Result;
				}
				else
				{
					var error = await result.Content.ReadAsStringAsync();
					var Result = JsonConvert.DeserializeObject<Account>(error);
					return Result;
				}
			};
		}


	}
}
