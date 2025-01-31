using System;
using System.Collections.Generic;



public class Program
{
    public static void Main(string[] args)
    {
        University university = new University("Белорусский государственный технологический университет", "БГТУ", "г. Минск, ул. Свердлова 13А");
        university.PrintInfo();

        Faculty faculty1 = new Faculty { Name = "Факультет информационных технологий" };
        Faculty faculty2 = new Faculty { Name = "Факультет ллесного хозяйства" };

        university.AddFaculty(faculty1);
        university.AddFaculty(faculty2);

        Console.WriteLine("Факультеты университета:");
        university.PrintInfo();

        JobTitle jobTitle1 = new JobTitle { Id = 1, Title = "Лектор" };
        JobTitle jobTitle2 = new JobTitle { Id = 2, Title = "Лаборант" };

        university.AddJobTitle(jobTitle1);
        university.AddJobTitle(jobTitle2);

        JobVacancy vacancy1 = new JobVacancy { Id = 1, JobTitle = jobTitle1 };
        JobVacancy vacancy2 = new JobVacancy { Id = 2, JobTitle = jobTitle2 };

        university.OpenJobVacancy(vacancy1);
        university.OpenJobVacancy(vacancy2);

        Console.WriteLine("Свободные Вакансии:");
        foreach (var vacancy in university.GetJobVacancies())
        {
            Console.WriteLine($"- {vacancy.JobTitle.Title}");
        }

        Person person = new Person { Name = "Иванов Иван" };

        Employee newEmployee = university.Recruit(vacancy1, person);
        Console.WriteLine($"Новый нанятый сотрудни: {newEmployee.Name}, Должность: {newEmployee.JobTitle.Title}");

        university.Dismiss(newEmployee.Id, "по своему желанию");

        university.PrintInfo();
    }
}






public class Organization
{
    private int id;
    private string name;
    private string shortName;
    private string address;
    private DateTime timeStamp;

    public Organization()
    {
        this.timeStamp = DateTime.Now;
    }

    public Organization(Organization other)
    {
        this.id = other.id;
        this.name = other.name;
        this.shortName = other.shortName;
        this.address = other.address;
        this.timeStamp = other.timeStamp;
    }

    public Organization(string name, string shortName, string address)
    {
        this.name = name;
        this.shortName = shortName;
        this.address = address;
        this.timeStamp = DateTime.Now;
    }

    public int Id
    {
        get
        {
            return id;
        }
        private set
        {
            id = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
        protected set
        {
            name = value;
        }
    }
    public string ShortName
    {
        get
        {
            return shortName;
        }
        protected set
        {
            shortName = value;
        }
    }

    public string Address
    {
        get
        {
            return address;
        }
        protected set
        {
            address = value;
        }
    }

    public DateTime TimeStamp
    {
        get
        {
            return timeStamp;
        }
        protected set
        {
            timeStamp = value;
        }
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Organization ID: {id}");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Short Name: {shortName}");
        Console.WriteLine($"Address: {address}");
        Console.WriteLine($"TimeStamp: {timeStamp}");
    }

}

public class University
{
    private string name;
    private string shortName;
    private string address;
    protected List<Faculty> faculties;
    private List<JobVacancy> jobVacancies;
    private List<JobTitle> jobTitles;
    private List<Employee> employees;

    public University()
    {
        faculties = new List<Faculty>();
        jobVacancies = new List<JobVacancy>();
        jobTitles = new List<JobTitle>();
        employees = new List<Employee>();
    }

    public University(University other) : this()
    {
        this.name = other.name;
        this.shortName = other.shortName;
        this.address = other.address;
        this.faculties = new List<Faculty>(other.faculties);
        this.jobVacancies = new List<JobVacancy>(other.jobVacancies);
        this.jobTitles = new List<JobTitle>(other.jobTitles);
        this.employees = new List<Employee>(other.employees);
    }

    public University(string name, string shortName, string address) : this()
    {
        this.name = name;
        this.shortName = shortName;
        this.address = address;
    }

    
    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    public string ShortName
    {
        get { return shortName; }
        protected set { shortName = value; }
    }

    public string Address
    {
        get { return address; }
        protected set { address = value; }
    }

    
    public int AddFaculty(Faculty faculty)
    {
        faculties.Add(faculty);
        return faculties.Count - 1;
    }

    public bool DelFaculty(int index)
    {
        if (VerFaculty(index))
        {
            faculties.RemoveAt(index);
            return true;
        }
        return false;
    }

    public bool UpdFaculty(Faculty faculty)
    {
        int index = faculties.FindIndex(f => f.Name == faculty.Name);
        if (index >= 0)
        {
            faculties[index] = faculty;
            return true;
        }
        return false;
    }

    private bool VerFaculty(int index)
    {
        return index >= 0 && index < faculties.Count;
    }

    public List<Faculty> GetFaculties()
    {
        return faculties;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Университет: {Name}, {ShortName}, Адрес: {Address}");
        foreach (var faculty in faculties)
        {
            Console.WriteLine($"Факультет: {faculty.Name}");
        }
    }

    
    public List<JobVacancy> GetJobVacancies()
    {
        return jobVacancies;
    }

    public int AddJobTitle(JobTitle jobTitle)
    {
        jobTitles.Add(jobTitle);
        return jobTitles.Count - 1;
    }

    public bool DelJobTitle(int index)
    {
        if (index >= 0 && index < jobTitles.Count)
        {
            jobTitles.RemoveAt(index);
            return true;
        }
        return false;
    }

    public int OpenJobVacancy(JobVacancy vacancy)
    {
        jobVacancies.Add(vacancy);
        return jobVacancies.Count - 1;
    }

    public bool CloseJobVacancy(int index)
    {
        if (index >= 0 && index < jobVacancies.Count)
        {
            jobVacancies.RemoveAt(index);
            return true;
        }
        return false;
    }

    public Employee Recruit(JobVacancy vacancy, Person person)
    {
        Employee employee = new Employee(person.Name, vacancy.JobTitle);
        employees.Add(employee);
        return employee;
    }

    public bool Dismiss(int employeeId, string reason)
    {
        int index = employees.FindIndex(e => e.Id == employeeId);
        if (index >= 0)
        {
            employees.RemoveAt(index);
            Console.WriteLine($"Сотрудников {employeeId} уволено по причине: {reason}");
            return true;
        }
        return false;
    }
}
public class Faculty
{
    protected List<Department> departments;
    private List<JobVacancy> jobVacancies;
    private List<JobTitle> jobTitles;

    
    public Faculty()
    {
        departments = new List<Department>();
        jobVacancies = new List<JobVacancy>();
        jobTitles = new List<JobTitle>();
    }

    
    public Faculty(Faculty other)
    {
        departments = new List<Department>(other.departments);
        jobVacancies = new List<JobVacancy>(other.jobVacancies);
        jobTitles = new List<JobTitle>(other.jobTitles);
    }

    
    public Faculty(string name, string shortName, string address) : this()
    {
        Name = name;
        ShortName = shortName;
        Address = address;
    }

    
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string Address { get; set; }

    
    public int AddDepartment(Department department)
    {
        departments.Add(department);
        return departments.Count - 1;
    }

    public bool DelDepartment(int index)
    {
        if (VerDepartment(index))
        {
            departments.RemoveAt(index);
            return true;
        }
        return false;
    }

    public bool UpdDepartment(Department department)
    {
        int index = departments.FindIndex(d => d.Id == department.Id);
        if (index >= 0)
        {
            departments[index] = department;
            return true;
        }
        return false;
    }

    private bool VerDepartment(int index)
    {
        return index >= 0 && index < departments.Count;
    }

    public List<Department> GetDepartments()
    {
        return departments;
    }

    
    public void PrintInfo()
    {
        Console.WriteLine($"Faculty: {Name}, Short Name: {ShortName}, Address: {Address}");
        foreach (var department in departments)
        {
            Console.WriteLine($"  Department: {department.Name}");
        }
    }

    
    public List<JobVacancy> GetJobVacancies()
    {
        return jobVacancies;
    }

    public int AddJobTitle(JobTitle jobTitle)
    {
        jobTitles.Add(jobTitle);
        return jobTitles.Count - 1;
    }

    public bool DelJobTitle(int index)
    {
        if (index >= 0 && index < jobTitles.Count)
        {
            jobTitles.RemoveAt(index);
            return true;
        }
        return false;
    }

    public int OpenJobVacancy(JobVacancy vacancy)
    {
        jobVacancies.Add(vacancy);
        return jobVacancies.Count - 1;
    }

    public bool CloseJobVacancy(int index)
    {
        if (index >= 0 && index < jobVacancies.Count)
        {
            jobVacancies.RemoveAt(index);
            return true;
        }
        return false;
    }

    public Employee Recruit(JobVacancy vacancy, Person person)
    {
        Employee employee = new Employee(person.Name, vacancy.JobTitle);
        return employee;
    }

    public void Dismiss(int employeeId, string reason)
    {
        
        Console.WriteLine($"Employee {employeeId} dismissed for reason: {reason}");
    }
}

public class Department
{
    private static int idCounter = 0;
    public int Id { get; private set; }
    public string Name { get; set; }
    public string ShortName { get; set; }

    public Department(string name, string shortName)
    {
        Id = ++idCounter;
        Name = name;
        ShortName = shortName;
    }
}

public class JobVacancy
{
    public int Id { get; set; }
    public JobTitle JobTitle { get; set; }
}

public class JobTitle
{
    public int Id { get; set; }
    public string Title { get; set; }
}

public class Person
{
    public string Name { get; set; }
}

public class Employee : Person
{
    public int Id { get; set; }
    public JobTitle JobTitle { get; set; }

    public Employee(string name, JobTitle jobTitle)
    {
        Name = name;
        JobTitle = jobTitle;
    }
}
public interface IStaff
{
    List<JobVacancy> GetJobVacancies();
    List<Employee> GetEmployees();
    List<JobTitle> GetJobTitles();
    int AddJobTitle(JobTitle jobTitle);
    string PrintJobVacancies();
    bool DelJobTitle(int id);
    void OpenJobVacancy(JobVacancy vacancy);
    bool CloseJobVacancy(int id);
    Employee Recruit(JobVacancy vacancy, Person person);
    bool Dismiss(int employeeId, string reason);
}