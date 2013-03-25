using System;

public class Worker : Human
{
    private int weekweekSalary;
    private int workHoursPerDay;
    
    public Worker(string firstName, string secondName, int weekweekSalary, int workHoursPerDay) : base(firstName, secondName)
    {
        this.weekweekSalary = weekweekSalary;
        this.workHoursPerDay = workHoursPerDay;
    }

    public int WorkHoursPerDay
    {
        get
        {
            return this.workHoursPerDay;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Work hours cant be a negative number!");
            }

            this.workHoursPerDay = value;
        }
    }

    public int WeekweekSalary
    {
        get
        {
            return this.weekweekSalary;
        }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Salary can not be a negative number");
            }

            this.weekweekSalary = value;
        }
    }

    public int MoneyPerHour()
    {
        int moneyPerHour = 0;
        moneyPerHour = this.weekweekSalary / this.workHoursPerDay * 5;
        return moneyPerHour;
    }
}
