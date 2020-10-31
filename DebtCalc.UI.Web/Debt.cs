using System;

namespace DebtCalc.UI.Web
{
	public class Debt
	{
		public decimal OriginalValue { get; set; }
		public DateTime OriginalDate { get; set; }
		public InterestType InterestType { get; set; }
		public int Installments { get; set; }
		public DateTime FinalDate { get; set; }
		public int Comission { get; set; }
		public decimal FinalValue { get; set; }
	}
}
