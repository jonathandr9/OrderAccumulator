using Dapper;
using FinancialExposure.DbAdapter.Configuration;
using OrderAccumulator.Domain.Adapters;
using OrderAccumulator.Domain.DbModels;
using System.Data;

namespace FinancialExposure.DbAdapter
{
    public class OrderSqlAdapter : IOrderSqlAdapter
    {
        private readonly FinancialExposureDbAdapterContext _context;

        static OrderSqlAdapter() =>
            SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);

        public OrderSqlAdapter(
            FinancialExposureDbAdapterContext context
        )
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<OrderDbModel>> GetAll()
        {
            return await
                _context.Connection.QueryAsync<OrderDbModel>(
               @"SELECT [Id]
                      ,[Asset]
                      ,[Side]
                      ,[Quantity]
                      ,[Price]
                      ,[Date]
                  FROM [Order]
                ",
               commandType: CommandType.Text);
        }

        public async Task Add(OrderDbModel orderAdd)
        {
            await
               _context.Connection.ExecuteAsync(
              @" INSERT INTO [Order]
                    ([Id]
                    ,[Asset]
                    ,[Side]
                    ,[Quantity]
                    ,[Price]
                    ,[Date])
                VALUES
                    (@Id
                    ,@Asset
                    ,@Side
                    ,@Quantity
                    ,@Price
                    ,@Date);",
              param: orderAdd,
              commandType: CommandType.Text);
        }
    }
}
