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
			// Adding comment while I demonstrate push process
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

		/// <summary>
		/// Since trustee accounts don't include Power/Exp/Rage on myaccount.php, the stats must be read individually
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task readStats()
		{
			/*
			 * home.php?suid=12345 displays detailed stats - REQUIRES switching to the specified account to review home data
			 * There are five <div id="divPlayerStats"> nodes:
			 *	 The third includes detailed elemental damage, and the fourth includes detailed elemental resistance
			 *
			 * profile.php?suid=12345 displays Power, Atk, HP, totalElements, totalResists
			 *	 Power: #divPlayerInfo > table:nth-child(2) > tbody:nth-child(1) > tr:nth-child(4) > td:nth-child(2) > b:nth-child(1) > font:nth-child(1)
			 *	 Atk: #divPlayerInfo > table:nth-child(2) > tbody:nth-child(1) > tr:nth-child(5) > td:nth-child(2) > b:nth-child(1) > font:nth-child(1)
			 *	 HP: #divPlayerInfo > table:nth-child(2) > tbody:nth-child(1) > tr:nth-child(6) > td:nth-child(2) > b:nth-child(1) > font:nth-child(1)
			 *	 totalElements: #divPlayerInfo > table:nth-child(2) > tbody:nth-child(1) > tr:nth-child(7) > td:nth-child(2) > b:nth-child(1) > font:nth-child(1)
			 *	 totalResists: #divPlayerInfo > table:nth-child(2) > tbody:nth-child(1) > tr:nth-child(8) > td:nth-child(2) > b:nth-child(1) > font:nth-child(1)
			 * 
			 */
		}
	}
}
