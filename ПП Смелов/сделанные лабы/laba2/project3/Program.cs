using System;
using System.Collections.Generic;

public interface Staff
{
    List<JobVacancy> GetJobVacancies();
    List<Employee> GetEmployees();
    List<JobTitle> GetJobTitles();
    int AddJobTitle(JobTitle jobTitle);
    string PrintJobVacancies();
    bool DelJobTitle(int jobTitleId);
    int OpenJobVacancy(JobVacancy jobVacancy);
    bool CloseJobVacancy(int jobVacancyId);
    Employee Recruit(JobVacancy jobVacancy, Person person);
    bool Dismiss(int employeeId, string reason);
}

public class Organization : Staff
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

    public Organization(Organization org)
    {
        id = org.id;
        name = org.name;
        shortName = org.shortName;
        address = org.address;
        timeStamp = org.timeStamp;
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
        get { return id; }
        private set { id = value; }
    }

    public void SetId(int value)
    {
        Id = value;
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

    public DateTime TimeStamp
    {
        get { return timeStamp; }
        protected set { timeStamp = value; }
    }


    public List<JobVacancy> GetJobVacancies()
    {

        return new List<JobVacancy>();
    }

    public List<Employee> GetEmployees()
    {
        return new List<Employee>();
    }

    public List<JobTitle> GetJobTitles()
    {
        return new List<JobTitle>();
    }

    public int AddJobTitle(JobTitle jobTitle)
    {
        return 0;
    }

    public string PrintJobVacancies()
    {
        return "Vacancies";
    }

    public bool DelJobTitle(int jobTitleId)
    {
        return true;
    }

    public int OpenJobVacancy(JobVacancy jobVacancy)
    {
        return 0;
    }

    public bool CloseJobVacancy(int jobVacancyId)
    {
        return true; 
    }

    public Employee Recruit(JobVacancy jobVacancy, Person person)
    {
        return new Employee(); 
    }

    public bool Dismiss(int employeeId, string reason)
    {
        return true; 
    }




    public virtual void PrintInfo()
    {
        Console.WriteLine($"ID: {id}, Название: {name}, Краткое название: {shortName}, Адрес: {address}, Время создания: {timeStamp}");
    }
}


public class University : Organization, Staff
{
    protected List<Faculty> faculties;

    public University() : base()
    {
        faculties = new List<Faculty>();
    }

    public University(University university) : base(university)
    {
        faculties = new List<Faculty>(university.faculties);
    }

    public University(string name, string shortName, string address) : base(name, shortName, address)
    {
        faculties = new List<Faculty>();
    }

    public int AddFaculty(Faculty faculty)
    {
        faculties.Add(faculty);
        return faculties.Count - 1; 
    }

    public bool DelFaculty(int id)
    {
        if (id >= 0 && id < faculties.Count)
        {
            faculties.RemoveAt(id);
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

    

    
    public List<JobVacancy> GetJobVacancies()
    {
        
        return new List<JobVacancy>();
    }

    public List<Employee> GetEmployees()
    {
        return new List<Employee>();
    }

    public List<JobTitle> GetJobTitles()
    {
        return new List<JobTitle>();
    }

    public int AddJobTitle(JobTitle jobTitle)
    {
        return 0; 
    }

    public string PrintJobVacancies()
    {
        return "Vacancies"; 
    }

    public bool DelJobTitle(int jobTitleId)
    {
        return true; 
    }

    public int OpenJobVacancy(JobVacancy jobVacancy)
    {
        return 0; 
    }

    public bool CloseJobVacancy(int jobVacancyId)
    {
        return true; 
    }

    public Employee Recruit(JobVacancy jobVacancy, Person person)
    {
        return new Employee(); 
    }

    public bool Dismiss(int employeeId, string reason)
    {
        return true; 
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine("Это университет.");
    }
}

public class Faculty : Organization, Staff
{
    private List<Department> departments;

    public Faculty() : base()
    {
        departments = new List<Department>();
    }

    public Faculty(Faculty faculty) : base(faculty)
    {
        departments = new List<Department>(faculty.departments);
    }

    public Faculty(string name, string shortName, string address) : base(name, shortName, address)
    {
        departments = new List<Department>();
    }



    public int AddDepartment(Department department)
    {
        departments.Add(department);
        return departments.Count - 1;
    }

    public bool DelDepartment(int id)
    {
        if (id >= 0 && id < departments.Count)
        {
            departments.RemoveAt(id);
            return true;
        }
        return false;
    }

    public bool UpdDepartment(Department department)
    {
        for (int i = 0; i < departments.Count; i++)
        {
            if (departments[i].Id == department.Id)
            {
                departments[i] = department;
                return true;
            }
        }
        return false;
    }

    public bool VerDepartment(int index)
    {
        return index >= 0 && index < departments.Count;
    }


    public List<Department> GetDepartments()
    {
        return departments;
    }

    
    public List<JobVacancy> GetJobVacancies()
    {
        return new List<JobVacancy>(); 
    }

    public List<Employee> GetEmployees()
    {
        return new List<Employee>(); 
    }

    public List<JobTitle> GetJobTitles()
    {
        return new List<JobTitle>(); 
    }

    public int AddJobTitle(JobTitle jobTitle)
    {
        return 0; 
    }

    public string PrintJobVacancies()
    {
        return "Vacancies"; 
    }

    public bool DelJobTitle(int jobTitleId)
    {
        return true; 
    }

    public int OpenJobVacancy(JobVacancy jobVacancy)
    {
        return 0; 
    }

    public bool CloseJobVacancy(int jobVacancyId)
    {
        return true; 
    }

    public Employee Recruit(JobVacancy jobVacancy, Person person)
    {
        return new Employee(); 
    }

    public bool Dismiss(int employeeId, string reason)
    {
        return true; 
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine("Это факультет.");
    }
}
public class JobVacancy { }
public class Employee { }
public class JobTitle { }
public class Person { }
public class Department : Organization
{
    public Department(string name, string shortName, string address) : base(name, shortName, address)
    {
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        University university = new University("Белорусский Государственный Технологический Университет", "БГТУ", "г. Минск, ул. Свердлова, 13А");
        university.SetId(1);

        Console.WriteLine("Информация об университете:");
        Console.WriteLine($"Название: {university.Name}");
        Console.WriteLine($"Краткое название: {university.ShortName}");
        Console.WriteLine($"Адрес: {university.Address}");

        university.PrintInfo();

        Faculty faculty = new Faculty("Факультет информационных технологий", "ФИТ", "г. Минск, ул. Свердлова, 13А");
        faculty.SetId(2);

        Console.WriteLine("\nИнформация о факультете:");
        Console.WriteLine($"Название: {faculty.Name}");
        Console.WriteLine($"Краткое название: {faculty.ShortName}");
        Console.WriteLine($"Адрес: {faculty.Address}");

        faculty.PrintInfo();

        Department department = new Department("Кафедра Информационных Систем и Технологий", "ИСиТ", "г. Минск, ул. Свердлова, 13А");
        department.SetId(3);

        Console.WriteLine("\nИнформация о кафедре:");
        Console.WriteLine($"Название: {department.Name}");
        Console.WriteLine($"Краткое название: {department.ShortName}");
        Console.WriteLine($"Адрес: {department.Address}");

        department.PrintInfo();

        university.AddFaculty(faculty);
        Console.WriteLine("\nСписок факультетов в университете:");
        foreach (var fac in university.GetFaculties())
        {
            fac.PrintInfo();
        }

        faculty.AddDepartment(department);
        Console.WriteLine("\nСписок кафедр на факультете:");
        foreach (var dep in faculty.GetDepartments())
        {
            dep.PrintInfo();
        }
    }
}