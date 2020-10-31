using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCalc.Context.Core.Models.Entities
{
	public class InterestType
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public int Value { get; set; }

		public InterestType() { }

		public InterestType(long id, string v1, int v2)
		{
			Id = id;
			Name = v1;
			Value = v2;
		}
	}
}
