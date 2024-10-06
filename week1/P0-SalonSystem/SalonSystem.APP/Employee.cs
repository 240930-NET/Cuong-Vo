//Abstract class for a general employee
namespace SalonSystem.APP.Employees;


public enum PayPeriod
{
    Weekly = 1,
    BiWeekly = 2,
    Monthly = 3
}

public abstract class Employee 
{
    public int ID { get; private set; }
    public string? Name  {get; set;}
    public int Salary  {get; set;}
    public PayPeriod PayPeriodType { get; set; }
    public string? EmployeeType {get;set;}

    public Employee (int employeeID, string name, int salary, PayPeriod payPeriodType) {
        ID = employeeID;
        Name = name;
        Salary = salary;
        PayPeriodType = payPeriodType;
    }
}