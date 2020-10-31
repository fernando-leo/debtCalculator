using DebtCalc.Context.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCalc.Context.Core.IRepositories
{
	public interface IInterestTypeRepository
	{
		IEnumerable<InterestType> GetInterestTypes(string name, int? value);
		long Add(InterestType entity);
	}
}
