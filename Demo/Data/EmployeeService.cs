using SQLite;
namespace Demo.Data;
public class EmployeeService
{
    string _dbPath;
    public string StatusMessage { get; set; }
    private SQLiteAsyncConnection conn;
    public EmployeeService(string dbPath)
    {
        _dbPath = dbPath;
    }
    private async Task InitAsync()
    {
        // Don't Create database if it exists
        if (conn != null)
            return;
        // Create database and Employee Table
        conn = new SQLiteAsyncConnection(_dbPath);
        await conn.CreateTableAsync<Employee>();
    }
    public async Task<List<Employee>> GetEmployeeAsync()
    {
        await InitAsync();
        return await conn.Table<Employee>().ToListAsync();
    }
    public async Task<Employee> CreateEmployeeAsync(
        Employee paramEmployee)
    {
        // Insert
        await conn.InsertAsync(paramEmployee);
        // return the object with the
        // auto incremented Id populated
        return paramEmployee;
    }
    public async Task<Employee> UpdateEmployeeAsync(
        Employee paramEmployee)
    {
        // Update
        await conn.UpdateAsync(paramEmployee);
        // Return the updated object
        return paramEmployee;
    }
    public async Task<Employee> DeleteEmployeeAsync(
        Employee paramEmployee)
    {
        // Delete
        await conn.DeleteAsync(paramEmployee);
        return paramEmployee;
    }
}