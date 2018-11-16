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
