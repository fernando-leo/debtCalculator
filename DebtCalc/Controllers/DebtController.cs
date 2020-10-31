using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DebtCalc.Context.Core;
using DebtCalc.Context.Core.Contracts.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DebtCalc.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DebtController : ControllerBase
	{
		private static readonly InterestType[] InterestTypes = new[]
		{
			new InterestType("Júros Simples", 10),
			new InterestType("Júros Composto", 20)
		};

		private readonly ILogger<DebtController> _logger;
		private readonly IDebtService _debtService;
		private readonly IInterestTypeService _interestTypeService;
		readonly IMapper _iMapper;

		public DebtController(ILogger<DebtController> logger,
			IDebtService debtService,
			IInterestTypeService interestTypeService,
			IMapper iMapper)
		{
			_logger = logger;
			_debtService = debtService;
			_interestTypeService = interestTypeService;
			_iMapper = iMapper;
		}

		[HttpGet]
		public IEnumerable<Debt> Get()
		{
			var random = new Random();
			return Enumerable.Range(1, 5).Select(index => new Debt
			{
				OriginalDate = DateTime.Now.AddDays(-index),
				OriginalValue = random.Next(2000, 14000),
				FinalDate = DateTime.Now.AddDays(index),
				Installments = random.Next(-20, 55),
				InterestType = InterestTypes[random.Next(InterestTypes.Length)],
				Comission = random.Next(1, 20)
			})
			.ToArray();
		}


		[HttpPost]
		[Route("GetDebts")]
		public IEnumerable<Debt> GetDebts(decimal? originalValue, DateTime? originalDate,
			long? FKInterestType, int? installments, DateTime? finalDate, int? comission)
		{
			IEnumerable<Debt> response = _iMapper.Map<List<Debt>>(_debtService.GetDebts(originalValue, originalDate, FKInterestType, installments, finalDate, comission).ToList());
			return response;
		}

		[HttpPost]
		[Route("DebtCalc")]
		public Debt DebtCalc(decimal originalValue, DateTime originalDate, long FKInterestType, int installments, int comission)
		{
			Debt debt = _iMapper.Map<Debt>(_debtService.DebtCalc(originalValue, originalDate, FKInterestType, installments, comission));
			return debt;
		}

		[HttpPost]
		[Route("AddDebt")]
		public long AddDebt(Debt debt)
		{
			return _debtService.Add(_iMapper.Map<DebtCalc.Context.Core.Models.Entities.Debt>(debt));
		}

		[HttpPost]
		[Route("GetInterestTypes")]
		public IEnumerable<InterestType> GetInterestTypes(string name, int? value)
		{
			IEnumerable<InterestType> response = _iMapper.Map<List<InterestType>>(_interestTypeService.GetInterestTypes(name, value).ToList());
			return response;
		}

		[HttpPost]
		[Route("AddInterestType")]
		public long AddInterestType(InterestType it)
		{
			return _interestTypeService.Add(_iMapper.Map<DebtCalc.Context.Core.Models.Entities.InterestType>(it));
		}
	}
}
