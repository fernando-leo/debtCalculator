using DebtCalc.Context.Core.Contracts.IServices;
using DebtCalc.Context.Core.Models.Entities;
using DebtCalc.Context.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DebtCalc.Context.Core
{
	public class DebtService : IDebtService
	{
		IDebtRepository _debtRepository;
		IInterestTypeService _interestTypeService;

		public DebtService(IDebtRepository repository, InterestTypeService interestTypeService)
		{
			_debtRepository = repository;
			_interestTypeService = interestTypeService;
		}

		public IEnumerable<Debt> GetDebts(decimal? originalValue, DateTime? originalDate,
			long? FKInterestType, int? installments, DateTime? finalDate, int? comission)
		{
			return _debtRepository.GetDebts(originalValue, originalDate, FKInterestType, installments, finalDate, comission);
		}

		public Debt DebtCalc(decimal originalValue, DateTime originalDate, long FKInterestType, int installments, int comission)
		{
			Debt debt = new Debt();
			try
			{
				debt.OriginalDate = originalDate;
				debt.OriginalValue = originalValue;
				debt.Comission = comission;
				debt.Installments = installments;

				IEnumerable<InterestType> interestTypes = _interestTypeService.GetInterestTypes(null, null);
				debt.InterestTypeId = FKInterestType;
				debt.InterestType = interestTypes.Where(x => x.Id == FKInterestType).FirstOrDefault();

				int debtLateDays = (int)(DateTime.Now - originalDate).TotalDays;
				debt.FinalValue = ((originalValue * (1 + debt.InterestType.Value * debtLateDays)) / comission);
			}
			catch (Exception)
			{
			}
			return debt;
		}

		public long Add(Debt debt)
		{
			return _debtRepository.Add(debt);
		}
	}
}
