using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace CincoWarMaker
{
    class Session
    {
		private static HttpClient client;

		public Session()
		{
			client = new HttpClient();
			var doc = new HtmlDocument();

<<<<<<< HEAD
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Login();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }
=======
			Login();
		}
>>>>>>> 3f6bdfa9c41ce23f91f04d6652f8c5a6e57e85c1
		/*
		 * // From String
			var doc = new HtmlDocument();
			doc.LoadHtml(html); */

		/*	var url = "http://html-agility-pack.net/";
			var web = new HtmlWeb();
			var doc = web.Load(url); */

		private async Task Login()
		{
			//deadringer comment 21:06 20181114
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
            ReadAccounts(accountsString);
        }

        private void ReadAccounts(string src)
        {
            /*This needs a bunch of work. It currently executes but the data returned is not what's expected.*/

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(src);

            // used a method to select a single node in html document. I'm passing the node in as an XPath - you can get this by inspecting an html doc, and clicking Copy on a specified piece of code.
            // the node object has a property - .InnerHtml - this returns the information inside the specified tags.
            var htmlNodes = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"characterTable\"]/tbody/tr[1]/td[2]/a");
            Console.WriteLine("Name: " + htmlNodes.InnerHtml);
            htmlNodes = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"characterTable\"]/tbody/tr[1]/td[3]");
            Console.WriteLine("Level: " + htmlNodes.InnerHtml);
            htmlNodes = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"characterTable\"]/tbody/tr[1]/td[4]");
            var inht = htmlNodes.InnerHtml;
            Console.WriteLine("Crew: " + htmlNodes.InnerHtml);

            
        }
    }
}
