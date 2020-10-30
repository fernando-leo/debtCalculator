using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtCalc
{
	public class InterestType
	{
		public string Name { get; set; }
		public int Value { get; set; }

		public InterestType(string v1, int v2)
		{
			Name = v1;
			Value = v2;
		}
	}
}
