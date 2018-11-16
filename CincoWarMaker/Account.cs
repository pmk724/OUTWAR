using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CincoWarMaker
{
	class Account
	{
		private string name, crew;
		private int level, suid;
		private long exp, power;

		/// <summary>
		/// Account(name,suid)
		/// Used for a quick-read of the accounts on the RGA
		/// Source page is http://www.outwar.com/ajax/accounts.php
		/// </summary>
		/// <param name="name"></param>
		/// <param name="suid"></param>
		public Account(string name, int suid)
		{
			this.name = name;
			this.suid = suid;
		}

		/// <summary>
		/// Account(name, level, crew, exp, power, suid)
		/// Used for a full read of Accounts including extra details not included in the two-param constructor
		/// Source page is http://www.outwar.com/myaccount.php
		/// </summary>
		/// <param name="name"></param>
		/// <param name="level"></param>
		/// <param name="crew"></param>
		/// <param name="exp"></param>
		/// <param name="power"></param>
		/// <param name="suid"></param>
		public Account(string name, int level, string crew, long exp, long power, int suid)
		{
			this.name = name;
			this.level = level;
			this.crew = crew;
			this.exp = exp;
			this.power = power;
			this.suid = suid;
		}
	}
}
