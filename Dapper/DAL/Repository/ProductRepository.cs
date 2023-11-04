using DAL.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;
        public ProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<int> AddAsync(Product entity)
        {
            entity.AddedOn = DateTime.Now;
            var sql = "Insert into Products (Name,Description,Barcode,Rate,AddedOn) VALUES (@Name,@Description,@Barcode,@Rate,@AddedOn)";
            var result = await _dbConnection.ExecuteAsync(sql, entity);
            return result;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            var result = await _dbConnection.ExecuteAsync(sql, new { Id = id });
            return result;
        }
        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            var sql = "SELECT * FROM Products";
            var result = await _dbConnection.QueryAsync<Product>(sql);
            return result.ToList();
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            var result = await _dbConnection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
            return result;
        }
        public async Task<int> UpdateAsync(Product entity)
        {
            entity.ModifiedOn = DateTime.Now;
            var sql = "UPDATE Products SET Name = @Name, Description = @Description, Barcode = @Barcode, Rate = @Rate, ModifiedOn = @ModifiedOn  WHERE Id = @Id";
            var result = await _dbConnection.ExecuteAsync(sql, entity);
            return result;
        }
    }
}
