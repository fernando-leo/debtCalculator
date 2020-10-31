using DebtCalc.Context.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCalc.Context.Core.Contracts.IServices
{
	public interface IInterestTypeService
	{
		IEnumerable<InterestType> GetInterestTypes(string name, int? value);
		long Add(InterestType entity);
	}
}
