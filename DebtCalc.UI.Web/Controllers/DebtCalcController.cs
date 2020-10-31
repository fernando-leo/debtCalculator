using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DebtCalc.UI.Web.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DebtCalcController : ControllerBase
	{
		private static readonly InterestType[] InterestTypes = new[]
		{
			new InterestType("Júros Simples", 10),
			new InterestType("Júros Composto", 20)
		};

		private readonly ILogger<DebtCalcController> _logger;

		public DebtCalcController(ILogger<DebtCalcController> logger)
		{
			_logger = logger;
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
	}
}
