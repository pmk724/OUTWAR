using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CincoWarMaker
{
    class Session
    {
		private static HttpClient client;

		public Session()
		{
			client = new HttpClient();
			var doc = new HtmlDocument();

			Login();
		}
		/*
		 * // From String
			var doc = new HtmlDocument();
			doc.LoadHtml(html); */

		/*	var url = "http://html-agility-pack.net/";
			var web = new HtmlWeb();
			var doc = web.Load(url); */

		private async Task Login()
		{
			var login = new Dictionary<string, string>
			{
				{ "login_username", "TheMooninites" },
				{ "login_password", "TaCtIhMfS1=" },
				{ "serverid", "2" }
			};
			var content = new FormUrlEncodedContent(login);
			var response = await client.PostAsync("http://torax.outwar.com/index.php", content);
			var responseString = await response.Content.ReadAsStringAsync();
			var accountsString = await client.GetStringAsync("http://torax.outwar.com/myaccount.php");
			//return accountsString;
		}
	}
}
