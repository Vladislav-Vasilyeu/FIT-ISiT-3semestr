using System;
using System.Collections.Generic;

public class Organization
{
    private int id;
    private string name;
    private string shortName;
    private string address;
    private DateTime timeStamp;

    
    public Organization()
    {
        timeStamp = DateTime.Now;
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
        timeStamp = DateTime.Now;
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

    
    public virtual void PrintInfo()
    {
        Console.WriteLine($"ID: {id}, Название: {name}, Краткое название: {shortName}, Адрес: {address}, Время создания: {timeStamp}");
    }
}

public class University : Organization
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

    
    public bool DelFaculty(int index)
    {
        if (index >= 0 && index < faculties.Count)
        {
            faculties.RemoveAt(index);
            return true;
        }
        return false;
    }

    
    public bool UpdFaculty(Faculty faculty)
    {
        for (int i = 0; i < faculties.Count; i++)
        {
            if (faculties[i].Id == faculty.Id)
            {
                faculties[i] = faculty;
                return true;
            }
        }
        return false;
    }

    
    public bool VerFaculty(int index)
    {
        return index >= 0 && index < faculties.Count;
    }

    
    public List<Faculty> GetFaculties()
    {
        return faculties;
    }

    
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Количество факультетов: {faculties.Count}");
    }
}

public class Faculty : Organization
{
    protected List<Department> departments;

    
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

    
    public bool DelDepartment(int index)
    {
        if (index >= 0 && index < departments.Count)
        {
            departments.RemoveAt(index);
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

    
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Количество кафедр: {departments.Count}");
    }
}

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
        
        University university = new University("Белорусский государственный технологический университет", "БГТУ", "г. Минск, ул. Свердлова, 13А");
        university.SetId(1); 

        Faculty faculty1 = new Faculty("Факультет информационных технологий", "ФИТ", "г. Минск, ул. Свердлова, 13А");
        faculty1.SetId(2); 
        university.AddFaculty(faculty1); 

        Faculty faculty2 = new Faculty("Факультет экономики", "ФЭ", "г. Минск, ул. Свердлова, 13А");
        faculty2.SetId(3); 
        university.AddFaculty(faculty2); 

        Department department1 = new Department("Кафедра Информационных систем и технологий", "ИСиТ", "г. Минск, ул. Свердлова, 13А");
        department1.SetId(4); 
        faculty1.AddDepartment(department1); 

        
        Console.WriteLine("Информация об университете:");
        university.PrintInfo();

        Console.WriteLine("\nИнформация о факультетах:");
        foreach (var faculty in university.GetFaculties())
        {
            faculty.PrintInfo();
            Console.WriteLine();
        }

        Console.WriteLine("\nИнформация о кафедрах:");
        foreach (var faculty in university.GetFaculties())
        {
            Console.WriteLine($"Факультет: {faculty.Name}");
            foreach (var department in faculty.GetDepartments())
            {
                department.PrintInfo();
            }
        }
    }
}