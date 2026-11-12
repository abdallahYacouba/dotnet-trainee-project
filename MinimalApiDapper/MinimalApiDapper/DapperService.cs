using Dapper;
using Microsoft.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;

namespace MinimalApiDapper;
public class DapperService
{
    public async Task AddEmployee(Employee employee)
    {
        using (var sqlConnection = new SqlConnection("YOURCONNECTIONSTRING"))
        {
            var sql = "INSERT INTO Employees" +
                "(Name, Salary, Address, City," +
                "Region, Country, Phone) VALUES " +
                "(@Name, @Salary, @Address, " +
                "@City, @Region, @Country, @Phone)";
            await sqlConnection.ExecuteAsync(sql, new
            {
                employee.PostalCode,
                employee.Name,
                employee.Salary,
                employee.Address,
                employee.City,
                employee.Region,
                employee.Country,
                employee.Phone
            });
        }
    }


}
