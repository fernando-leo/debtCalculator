using DebtCalc.Context.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using DebtCalc.Context.Core.Models.Entities;

namespace DebtCalc.Data
{
	public class DebtRepository : IDebtRepository
	{
		string _connection;
		public DebtRepository(string connection)
		{
			_connection = connection;
		}

		public IEnumerable<Debt> GetDebts(decimal? originalValue, DateTime? originalDate,
			long? FKInterestType, int? installments, DateTime? finalDate, int? comission)
		{
			IEnumerable<Debt> debts = new List<Debt>();
			using (var connection = new SqlConnection(_connection))
			{
				connection.Open();
				string sql = @"SELECT Id,
									dec_original_value AS OriginalValue,
									dtt_original_date AS OriginalDate,
									FK_interest_type AS InterestTypeId,
									int_installments AS Installments,
									dtt_final_date AS FinalDate,
									int_comission AS Comission,
									dec_final_value AS FinalValue
								FROM Debt
								WHERE
									((@originalValue IS NULL OR dec_original_value = @originalValue)
									AND (@originalDate IS NULL OR dtt_original_date = @originalDate)
									AND (@FKInterestType IS NULL OR FK_interest_type = @FKInterestType)
									AND (@installments IS NULL OR int_installments = @installments)
									AND (@finalDate IS NULL OR dtt_final_date = @finalDate)
									AND (@comission IS NULL OR int_comission = @comission))";

				debts = connection.Query<Debt>(sql).ToList();
				connection.Close();
			}
			return debts;
		}

		public long Add(Debt entity)
		{
			using (var connection = new SqlConnection(_connection))
			{
				connection.Open();
				string sql = @"INSERT INTO Debt(dec_original_value,
								dtt_final_date,
								FK_interest_type,
								int_installments,
								dtt_final_date,
								int_comission,
								dec_final_value) 
								VALUES (@originalValue,
									@originalDate,
									@FKInterestType,
									@installments,
									@finalDate,
									@comission,
									@finalValue)
								SELECT SCOPE_IDENTITY()";
				connection.Execute(sql, new
				{
					originalValue = entity.OriginalValue,
					originalDate = entity.OriginalDate,
					FKInterestType = entity.InterestTypeId,
					installments = entity.Installments,
					finalDate = entity.FinalDate,
					comission = entity.Comission,
					finalValue = entity.FinalValue
				});
				connection.Close();
			}
			return entity.Id;
		}

	}
}
