using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace CincoWarMaker
{
    class Session
    {
		private static HttpClient client; // Primary object for making GET and POST calls
		private static CookieContainer cookies; // Track session cookies for the HttpClient
		private static HttpClientHandler handler; // Not really sure what this does, but I'd imagine it just maintains the list of cookies as they change with each request
		private static string sessid; // The cookie token identifying the login session.  This value is needed in order to open a web browser logged into the current session
		private static Uri loginPage, accountPage, homePage;

		public Session()
		{
			loginPage = new Uri("http://torax.outwar.com/index.php");
			accountPage = new Uri("http://torax.outwar.com/myaccount.php");
			homePage = new Uri("http://torax.outwar.com/home.php");
			// Initialize standard web/cookie objects
			cookies = new CookieContainer();
			handler = new HttpClientHandler();
			handler.CookieContainer = cookies;
			client = new HttpClient(handler);
			var doc = new HtmlDocument(); // Initialize HtmlDocument object from HTML Agility Pack library
        }

		/// <summary>
		/// Empty login constructor to login with default credentials (RGA trust)
		/// </summary>
		/// <returns></returns>
		public async Task Login() { await Login("trust", "rockets123", "2"); }

		/// <summary>
		/// Login with specified Username, Password, and ServerID
		/// </summary>
		/// <param name="user">RGA USername</param>
		/// <param name="pass">RGA Password</param>
		/// <param name="sid">ServerID (2=Torax, 1=Sigil)</param>
		/// <returns></returns>
		public async Task Login(string user, string pass, string sid)
		{
			var login = new Dictionary<string, string>
			{ // Write data to send with the POST request for the Outwar login
				{ "login_username"	,	user	},
				{ "login_password"	,	pass	},
				{ "serverid"		,	sid		}
			};
			var content = new FormUrlEncodedContent(login);
			var response = await client.PostAsync(loginPage, content); // The actual POST request to the Outwar server
			var responseString = await response.Content.ReadAsStringAsync(); // Read the response from the login request
			// @TODO read the response to verify that the login request was successful.  There are two alternate possibilities:
			// 1) Invalid login/password, so the login fails
			// 2) After three invalid logins within fifteen minutes, the IP will be locked out and unable to login to any account

			var accountsString = await client.GetStringAsync(accountPage);
            ReadAccounts(accountsString);
        }

		public void OpenInBrowser()
		{
			// @TODO figure out how to read the cookies from the HttpClient object.  Once we're able to read the cookies, extract the value of the rgsessid so we can open the session in a browser
			IEnumerable<Cookie> responseCookies = cookies.GetCookies(homePage).Cast<Cookie>();
			foreach (Cookie cookie in responseCookies)
				Console.WriteLine(cookie.Name + ": " + cookie.Value);
			System.Diagnostics.Process.Start("http://torax.outwar.com/profile.php?rgsessid=" + sessid);
		}

        private void ReadAccounts(string src)
        {
			// @TODO fix this up to make it read proper data
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
