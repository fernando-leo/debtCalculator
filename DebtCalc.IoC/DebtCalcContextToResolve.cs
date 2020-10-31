using DebtCalc.Context.Core;
using DebtCalc.Context.Core.Contracts.IServices;
using DebtCalc.Context.Core.IRepositories;
using DebtCalc.Context.Core.Services;
using DebtCalc.Data;
using DebtCalc.Data.Repositories;
using StructureMap;

namespace DebtCalc.IoC
{
	public class DebtCalcContextToResolve : BoundContextToResolve
	{
		public DebtCalcContextToResolve(ConfigurationExpression config)
			: base(config)
		{
			Register<IDebtService, DebtService>();
			Register<IDebtRepository, DebtRepository>();
			Register<IInterestTypeService, InterestTypeService>();
			Register<IInterestTypeRepository, InterestTypeRepository>();
		}
	}
}
