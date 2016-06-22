using System;
using System.Collections.Generic;
using System.Linq;
public class Employee
{
    public Employee(string name, decimal salary, string position, string department)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
    }
    public string name;
    public decimal salary;
    public string position;
    public string department;
    public string email = "n/a";
    public int age = -1;
}
class CompanyRoster
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Employee> listEmployees = new List<Employee>();
        for (int i = 0; i < n; i++)
        {
            string[] employeeInfo = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string name = employeeInfo[0];
            decimal salary = decimal.Parse(employeeInfo[1]);
            string position = employeeInfo[2];
            string department = employeeInfo[3];
            Employee tempEmployee = new Employee(name, salary, position, department);
            if (employeeInfo.Length == 6)
            {
                tempEmployee.email = employeeInfo[4];
                tempEmployee.age = int.Parse(employeeInfo[5]);
            }
            else if (employeeInfo.Length == 5 && employeeInfo[4].Contains("@"))
            {
                tempEmployee.email = employeeInfo[4];
            }
            else if (employeeInfo.Length == 5 && !employeeInfo[4].Contains("@"))
            {
                tempEmployee.age = int.Parse(employeeInfo[4]);
            }
            listEmployees.Add(tempEmployee);
        }
        Dictionary<string, Dictionary<string, decimal>> departmentSalary = new Dictionary<string, Dictionary<string, decimal>>();
        foreach (var employee in listEmployees)
        {
            if (!departmentSalary.ContainsKey(employee.department))
            {
                departmentSalary.Add(employee.department, new Dictionary<string, decimal>());
            }
            if (!departmentSalary[employee.department].ContainsKey(employee.name))
            {
                departmentSalary[employee.department].Add(employee.name, employee.salary);
            }
        }
        string highestDepSalary = string.Empty;
        decimal highestSalary = decimal.MinValue;
        foreach (var outerPair in departmentSalary)
        {
            decimal totalDepSalary = 0;
            foreach (var innerPair in outerPair.Value)
            {
                totalDepSalary += innerPair.Value;
            }
            decimal averageSalary = totalDepSalary/outerPair.Value.Count;
            if (averageSalary > highestSalary)
            {
                highestSalary = averageSalary;
                highestDepSalary = outerPair.Key;
            }
        }
        Console.WriteLine("Highest Average Salary: {0}",highestDepSalary);
        var sortedEmployees = listEmployees.Where(x=>x.department == highestDepSalary).OrderByDescending(y=>y.salary);
        foreach (var sortedEmployee in sortedEmployees)
        {
            Console.WriteLine($"{sortedEmployee.name} {sortedEmployee.salary:f2} {sortedEmployee.email} {sortedEmployee.age}");
        }
    }
}