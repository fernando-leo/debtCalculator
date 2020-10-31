using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtCalc.API.AutoMapper
{
	public class DebtCalcProfile : Profile
	{
        public DebtCalcProfile()
        {
            DebtProfile();
            InterestTypeProfile();
        }

        private void DebtProfile()
        {
            CreateMap<Debt, DebtCalc.Context.Core.Models.Entities.Debt>();
        }

        private void InterestTypeProfile()
        {
            CreateMap<InterestType, DebtCalc.Context.Core.Models.Entities.InterestType>();
        }
    }
}
