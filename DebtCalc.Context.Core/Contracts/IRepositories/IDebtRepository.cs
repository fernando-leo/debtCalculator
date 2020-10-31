using DebtCalc.Context.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCalc.Context.Core
{
	public interface IDebtRepository
	{
		IEnumerable<Debt> GetDebts(decimal? originalValue, DateTime? originalDate,
			long? FKInterestType, int? installments, DateTime? finalDate, int? comission);

		long Add(Debt debt);
	}
}
