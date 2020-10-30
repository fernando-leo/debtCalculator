using System;

namespace DebtCalc
{
	public class Debt
	{
		public float OriginalValue { get; set; }
		public DateTime OriginalDate { get; set; }
		public InterestType InterestType { get; set; }
		public int Installments { get; set; }
		public DateTime FinalDate { get; set; }
		public int Comission { get; set; }
		//public int TemperatureF => 32 + (int)(Installments / 0.5556);

	}
}
