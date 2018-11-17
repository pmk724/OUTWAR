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

		public Session()
		{
			// Initialize standard web/cookie objects
			cookies = new CookieContainer();
			handler = new HttpClientHandler();
			handler.CookieContainer = cookies;
			client = new HttpClient(handler);
			
			var doc = new HtmlDocument(); // Initialize HtmlDocument object from HTML Agility Pack library

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
			// Note:  We cannot "await" this call in a non-async method, and constructors cannot be declared as async
			// We may need to find another approach to this logic in the future.  The current setup works, but warnings exist for a reason so we're probably missing the ideal approach
			Login();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

		private async Task Login()
		{
			var login = new Dictionary<string, string>
			{ // Write data to send with the POST request for the Outwar login
				{ "login_username", "TheMooninites" },
				{ "login_password", "TaCtIhMfS1=" },
				{ "serverid", "2" }
			};
			var content = new FormUrlEncodedContent(login);
			var response = await client.PostAsync("http://torax.outwar.com/index.php", content); // The actual POST request to the Outwar server
			var responseString = await response.Content.ReadAsStringAsync(); // Read the response from the login request
			// @TODO read the response to verify that the login request was successful.  There are two alternate possibilities:
			// 1) Invalid login/password, so the login fails
			// 2) After three invalid logins within fifteen minutes, the IP will be locked out and unable to login to any account

			/*
			// @TODO figure out how to read the cookies from the HttpClient object.  Once we're able to read the cookies, extract the value of the 
			IEnumerable<Cookie> responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
			foreach (Cookie cookie in responseCookies)
				Console.WriteLine(cookie.Name + ": " + cookie.Value);
			System.Diagnostics.Process.Start("http://torax.outwar.com/profile.php?rgsessid=" + sessid);

			var accountsString = await client.GetStringAsync("http://torax.outwar.com/myaccount.php");
            ReadAccounts(accountsString);
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
