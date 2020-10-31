using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtCalc.UI.Web
{
	public class InterestType
	{
		public string Name { get; set; }
		public int Value { get; set; }

		public InterestType(string name, int value)
		{
			Name = name;
			Value = value;
		}
	}
}
