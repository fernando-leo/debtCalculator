using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCalc.Context.Core.Models.Entities
{
	public class Debt
	{
		public long Id { get; set; }
		public decimal OriginalValue { get; set; }
		public DateTime OriginalDate { get; set; }
		public long InterestTypeId { get; set; }
		public InterestType InterestType { get; set; }
		public int Installments { get; set; }
		public DateTime FinalDate { get; set; }
		public int Comission { get; set; }
		public decimal FinalValue { get; set; }

		public Debt() {}

		public Debt(decimal originalValue,
			DateTime originalDate,
			InterestType interestType,
			int installments,
			DateTime finalDate,
			int comission,
			int finalValue)
		{
			OriginalValue = originalValue;
			OriginalDate = originalDate;
			InterestType = interestType;
			Installments = installments;
			FinalDate = finalDate;
			Comission = comission;
			FinalValue = finalValue;
		}
	}
}
