using System;

public class Employee
{
    internal string name;
    private DateTime hiringDate;

    public Employee(string name, DateTime hiringDate)
    {
        this.name = name;
        this.hiringDate = hiringDate;
    }

    public int Experience()
    {
        DateTime currentDate = DateTime.Now;
        int experience = currentDate.Year - hiringDate.Year;
        if (currentDate.Month < hiringDate.Month || (currentDate.Month == hiringDate.Month && currentDate.Day < hiringDate.Day))
        {
            experience--;
        }
        return experience;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"{name} has {Experience()} years of experience");
    }
}

public class Developer : Employee
{
    private string programmingLanguage;

    public Developer(string name, DateTime hiringDate, string programmingLanguage) : base(name, hiringDate)
    {
        this.programmingLanguage = programmingLanguage;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"{name} is {programmingLanguage} programmer");
    }
}

public class Tester : Employee
{
    private bool isAutomation;

    public Tester(string name, DateTime hiringDate, bool isAutomation) : base(name, hiringDate)
    {
        this.isAutomation = isAutomation;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        if (isAutomation)
        {
            Console.WriteLine($"{name} is automated tester");
        }
        else
        {
            Console.WriteLine($"{name} is manual tester");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter developer's name:");
        string devName = Console.ReadLine();

        Console.WriteLine("Enter developer's hiring date (yyyy-mm-dd):");
        DateTime devHiringDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter developer's programming language:");
        string devProgrammingLanguage = Console.ReadLine();

        Developer dev = new Developer(devName, devHiringDate, devProgrammingLanguage);

        Console.WriteLine("Enter tester's name:");
        string testerName = Console.ReadLine();

        Console.WriteLine("Enter tester's hiring date (yyyy-mm-dd):");
        DateTime testerHiringDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Is the tester automated? (true/false):");
        bool isAutomated = bool.Parse(Console.ReadLine());

        Tester tester = new Tester(testerName, testerHiringDate, isAutomated);

        Console.WriteLine("\nDeveloper Info:");
        dev.ShowInfo();

        Console.WriteLine("\nTester Info:");
        tester.ShowInfo();
    }
}
