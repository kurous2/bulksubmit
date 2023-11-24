using System.Data;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProgramTest.Data;
using ProgramTest.Models;
using ProgramTest.Repositories.Services;

namespace ProgramTest.Repositories;

public class PersonalRepository : IPersonalService
{
    private readonly ApplicationDbContext _dbContext;

    public PersonalRepository(ApplicationDbContext dbContext){
        _dbContext = dbContext;
    }

    public async Task<List<Personal>> GetPersonalListAsync()
    {
        var result = await _dbContext.tblT_Personal.ToListAsync();
        return result;
    }

    public async Task<int> InsertDataAsync(List<PersonalType> personal)
    {
        var param = new SqlParameter("@PersonalData", SqlDbType.Structured)
        {
            TypeName = "dbo.PersonalType",
            Value = ToDataTable(personal)
        };
        
        return await _dbContext.Database.ExecuteSqlRawAsync("EXEC dbo.SPInsertData @PersonalData", param);
    }

     public static DataTable ToDataTable<T>(List<T> items)
    {
        DataTable dataTable = new DataTable();

        // Get all the properties
        PropertyInfo[] props = typeof(T).GetProperties();

        // Create columns in DataTable based on properties
        foreach (PropertyInfo prop in props)
        {
            // Setting column names as Property names
            dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        }

        // Add rows to DataTable using iterative approach
        foreach (T item in items)
        {
            DataRow row = dataTable.NewRow();

            // Iterate through properties and fill values in DataRow
            for (int i = 0; i < props.Length; i++)
            {
                // Inserting property values to DataRow
                row[props[i].Name] = props[i].GetValue(item, null) ?? DBNull.Value;
            }

            // Add the filled DataRow to DataTable
            dataTable.Rows.Add(row);
        }

        return dataTable;
    }

}