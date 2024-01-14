using SQLite;
namespace Demo.Data;
public class Employee
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public int YearsEmployed { get; set; }
    public int Salary { get; set; }
    public int Rating { get; set; }

}