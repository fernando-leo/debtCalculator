using DebtCalc.Context.Core.Contracts.IServices;
using DebtCalc.Context.Core.IRepositories;
using DebtCalc.Context.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCalc.Context.Core.Services
{
	public class InterestTypeService : IInterestTypeService
	{
		IInterestTypeRepository _interestTypeRepository;

		public InterestTypeService(IInterestTypeRepository repository)
		{
			_interestTypeRepository = repository;
		}

		public long Add(InterestType entity)
		{
			return _interestTypeRepository.Add(entity);
		}

		public IEnumerable<InterestType> GetInterestTypes(string name, int? value)
		{
			return _interestTypeRepository.GetInterestTypes(name, value);
		}
	}
}
