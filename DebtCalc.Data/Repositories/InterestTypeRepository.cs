using Dapper;
using DebtCalc.Context.Core.IRepositories;
using DebtCalc.Context.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DebtCalc.Data.Repositories
{
	public class InterestTypeRepository : IInterestTypeRepository
	{
		string _connection;
		public InterestTypeRepository(string connection)
		{
			_connection = connection;
		}

		public IEnumerable<InterestType> GetInterestTypes(string name, int? value)
		{
			IEnumerable<InterestType> interestTypes = new List<InterestType>();
			using (var connection = new SqlConnection(_connection))
			{
				connection.Open();
				string sql = @"SELECT Id, vch_name, int_value
								FROM InterestType
								WHERE ((@name IS NULL OR vch_name LIKE '%'+@name+'%')
								AND (@value IS NULL OR int_value = @value))";

				interestTypes = connection.Query<InterestType>(sql).ToList();
				connection.Close();
			}
			return interestTypes;
		}

		public long Add(InterestType entity)
		{
			using (var connection = new SqlConnection(_connection))
			{
				connection.Open();
				string sql = @"INSERT INTO InterestType(vch_name,int_value) VALUES (@name,@value)
								SELECT SCOPE_IDENTITY();";
				connection.Execute(sql, new
				{
					name = entity.Name,
					value = entity.Value
				});
				connection.Close();
			}
			return entity.Id;
		}

	}
}