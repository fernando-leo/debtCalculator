using DebtCalc.Context.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCalc.Context.Core.Contracts.IServices
{
	public interface IDebtService
	{
		IEnumerable<Debt> GetDebts(decimal? originalValue, DateTime? originalDate,
			long? FKInterestType, int? installments, DateTime? finalDate, int? comission);
		long Add(Debt debt);
		Debt DebtCalc(decimal originalValue, DateTime originalDate, long FKInterestType, int installments, int comission);
	}
}
