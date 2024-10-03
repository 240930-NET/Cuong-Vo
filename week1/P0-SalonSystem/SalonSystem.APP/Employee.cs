//Abstract class for a general employee
public abstract class Employee 
{
    public int EmployeeID { get; private set; }
    public string? Name  {get; set;}
    public int Salary  {get; set;}
    public short SalaryInterval {get ; set;}
    public string? EmployeeType {get;set;}

    public Employee (int employeeID, string name, int salary, short salaryInterval) {
        EmployeeID = employeeID;
        Name = name;
        Salary = salary;
        SalaryInterval = salaryInterval;
    }
    
}