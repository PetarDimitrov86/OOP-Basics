using System;
using System.Text;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public virtual string FirstName
    {
        get { return this.firstName; }
        protected set
        {
            if (char.IsLower(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {nameof(firstName)}");
            }
            this.firstName = value;
        }
    }
    public virtual string LastName
    {
        get { return this.lastName; }
        protected set
        {
            if (char.IsLower(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {nameof(lastName)}");
            }
            this.lastName = value;
        }
    }
}

public class Worker : Human
{
    private decimal weekSalary;
    private decimal workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public override string LastName
    {
        get { return base.FirstName; }
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            base.LastName = value;
        }
    }

    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        private set
        {
            if (value <= 10)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(weekSalary)}");
            }
            this.weekSalary = value;
        }
    }

    public decimal WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        private set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(workHoursPerDay)}");
            }
            this.workHoursPerDay = value;
        }
    }

    public decimal CalculateMoneyPerHour()
    {
        return (this.weekSalary / 5) / this.workHoursPerDay;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"First Name: {base.FirstName}");
        sb.Append(Environment.NewLine);
        sb.Append($"Last Name: {base.LastName}");
        sb.Append(Environment.NewLine);
        sb.Append($"Week Salary: {this.WeekSalary:f2}");
        sb.Append(Environment.NewLine);
        sb.Append($"Hours per day: {this.WorkHoursPerDay:f2}");
        sb.Append(Environment.NewLine);
        sb.Append($"Salary per hour: {CalculateMoneyPerHour():f2}");
        return sb.ToString();
    }
}

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        :base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public override string FirstName
    {
        get { return base.FirstName; }
        protected set
        {
            if (value.Length < 4)
            {
                throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
            }
            base.FirstName = value;
        }
    }

    public override string LastName
    {
        get { return base.LastName; }
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            base.LastName = value;
        }
    }

    public string FacultyNumber
    {
        get { return this.facultyNumber; }
        private set
        {
            if (value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsLetterOrDigit(value[i]))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
            }
            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"First Name: {base.FirstName}");
        sb.Append(Environment.NewLine);
        sb.Append($"Last Name: {base.LastName}");
        sb.Append(Environment.NewLine);
        sb.Append($"Faculty number: {this.FacultyNumber}");
        sb.Append(Environment.NewLine);
        return sb.ToString();
    }
}

class Mankind
{
    static void Main(string[] args)
    {
        string[] studentInfo = Console.ReadLine().Split(new char[] { ' '},StringSplitOptions.RemoveEmptyEntries);
        string studentFirstName = studentInfo[0];
        string studentLastName = studentInfo[1];
        string studentFacultyNumber = studentInfo[2];
        Student student = new Student("Firstfsdf", "Lastsd", "facNum");
        try
        {
            student = new Student(studentFirstName, studentLastName, studentFacultyNumber);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
            return;
        }

        string[] workerInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string workerFirstName = workerInfo[0];
        string workerLastName = workerInfo[1];
        decimal workerWeekSalary = decimal.Parse(workerInfo[2]);
        decimal workerWorkHoursPerDay = decimal.Parse(workerInfo[3]);
        Worker worker = new Worker("First", "Last", 15, 10);
        try
        {
            worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workerWorkHoursPerDay);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
            return;
        }

        Console.WriteLine(student);
        Console.WriteLine(worker);
    }
}