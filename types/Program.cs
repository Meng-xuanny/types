//var listOfInts = new ListOfInts();
//listOfInts.Add(10);
//listOfInts.Add(20);
//listOfInts.Add(30);
//listOfInts.Add(40);


//listOfInts.RemoveAt(4);

//Console.WriteLine(listOfInts.GetIntAt(3));

//var numbers = new List<int> { 2, 415, 6, -7, 9, 30 };
//var finder = new Finder();
//SimpleTuple<int,int> minandmax = finder.GetTwoInts(numbers);

//SimpleTuple<DateTime, string> sth = new SimpleTuple<DateTime, string>(new DateTime(2020, 12, 9), "hello");

//var some = new Tuple<string, int, bool>("hehe", 123, false);
//Console.WriteLine(sth.Item1);
//Console.WriteLine(sth.Item2);

//Console.WriteLine(minandmax.Item1);
//Console.WriteLine(minandmax.Item2);

//numbers.AddToFront<int>(10);
//var list = new List<decimal> { 0.5m, 3.4m, 5.5m };
//var ints=list.ConvertTo<decimal,int>();

//var doubles = new List<double> { 1.1, 3.44444, 5.784832};
//var longs = doubles.ConvertTo<double, long>();

//var date = new List<DateTime> { new DateTime(2023, 2, 14) };
//var dateToInts = date.ConvertTo<DateTime, int>();

//Console.WriteLine(typeof(DateTime));


//using System.Diagnostics;

//Stopwatch stopwatch = Stopwatch.StartNew();
//var dates = CreateCollectionOfRandomLength<DateTime>();
//stopwatch.Stop();

//var people = new List<Person>
//{
//    new Person { Name="john", YearOfBirth=1980},
//    new Person { Name="ana", YearOfBirth=1998},
//    new Person { Name="bill", YearOfBirth=2004},
//};

//var ana = new Person { Name = "ana", YearOfBirth = 1998 };
//var bill = new Person { Name = "bill", YearOfBirth = 2004 };


//var employees = new List<Employee>
//{
//    new Employee { Name="john", YearOfBirth=1980},
//    new Employee { Name="ana", YearOfBirth=1815},
//    new Employee { Name="bill", YearOfBirth=2150},
//};


//people.Sort();

//PrintInOrder(11, 12);
//PrintInOrder("ccc", "dsd");
//PrintInOrder(ana, bill);


//var names = new List<FullName>
//{
//    new FullName { FirstName = "john", LastName = "smith" },
//    new FullName { FirstName = "ana", LastName = "smith" },

//    new FullName { FirstName = "nana", LastName = "LING" },
//    new FullName{FirstName="dave",LastName="Yellow"},
//};



//var sortedList=new SortedList<FullName>(names).Items;
//var numbers = new List<int> { 23, 7, 1, 5, 67 };
//Console.WriteLine("any number in the list is larger than 10? "+ IsAny(numbers,IsLargerThan10));
//Console.WriteLine("any even numbers? "+IsAny(numbers,IsEven));

//Action<string, DateTime, int> someAction;

//Console.ReadKey();


//IEnumerable<Person> validPeople = GetOnlyValid(people);

//IEnumerable<Employee> validEmployees = GetOnlyValid(employees);

//foreach(var employee in validEmployees)
//{
//    employee.GoToWork();
//}



 bool IsAny(IEnumerable<int> numbers, Func<int, bool> predicate)
{
    foreach(var number in numbers)
    {
        if(predicate(number))
        {
            return true;
        }
    }
    return false;
}

bool IsLargerThan10(int number)
{
    return number > 10;
}

bool IsEven(int number)
{
    return number % 2 == 0;
}


void PrintInOrder<T>(T first, T second) where T: IComparable<T>
{
    if(first.CompareTo(second) > 0)
    {
        Console.WriteLine($"{second} {first}");
    }
    else
    {
        Console.WriteLine($"{first} {second}");
    }
}


IEnumerable<T> CreateCollectionOfRandomLength <T> () where T:new()
{
    //var length = new Random().Next( 0, maxLength + 1);
    var length = 100000000;
    var result = new List<T>(length);

    for(int i=0;i<length;++i)
    {
        result.Add(new T());
    }
    return result;
}

///////generic type///////
IEnumerable <TPerson> GetOnlyValid<TPerson>(
    IEnumerable<TPerson> persons)
    where TPerson : Person
{
    var result = new List<TPerson>();

    foreach (var person in persons)
    {
        if (person.YearOfBirth > 1900 &&
            person.YearOfBirth < DateTime.Now.Year)
        {
            result.Add(person);
        }
    }

    return result;
}


var employees = new List<Employee>
{
    new Employee("Jake Smith", "Space Navigation", 25000),
    new Employee("Anna Blake", "Space Navigation", 29000),
    new Employee("Barbara Oak", "Xenobiology", 21500 ),
    new Employee("Damien Parker", "Xenobiology", 22000),
    new Employee("Nisha Patel", "Machanics", 21000),
    new Employee("Gustavo Sanchez", "Machanics", 20000),
};

var result=CalculateAverageSalary(employees);
Console.ReadKey();

/// <summary>
/// dictionary
/// </summary>
/// <typeparam name="T"></typeparam>


Dictionary<string,decimal> CalculateAverageSalary(IEnumerable<Employee> employees)
{
    var employeesPerDepartment = new Dictionary<string, List<Employee>>();

    foreach(var employee in employees)
    {
        if (!employeesPerDepartment.ContainsKey(employee.Department))
        { 
            employeesPerDepartment[employee.Department] = new List<Employee>();

        }

        employeesPerDepartment[employee.Department].Add(employee);
    }
    var result = new Dictionary<string, decimal>();

    foreach(var employeePerDepartment in employeesPerDepartment)
    {
        decimal sum = 0;
        foreach(var employee in employeePerDepartment.Value)
        {
            sum += employee.Salary;
        }
        var average = sum / employeePerDepartment.Value.Count;

        result[employeePerDepartment.Key] = average;

    }

    return result;
}










public class SortedList<T> where T : IComparable<T>//your code goes here
{
    public IEnumerable<T> Items { get; }

    public SortedList(IEnumerable<T> items) 
        {
            var asList = items.ToList();
            asList.Sort();
            Items = asList;
        }
}

public class FullName : IComparable<FullName>// your code goes here
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public override string ToString() => $"{FirstName} {LastName}";


    public int CompareTo(FullName other)
    {
        int lastNameComparison = LastName.CompareTo(other.LastName);//returns 1 or -1 or 0

        if (lastNameComparison != 0)
        {
            return lastNameComparison;
        }
        else return FirstName.CompareTo(other.FirstName);

    }
}







////////type constraint of paramaterless constructor
///////1//////////






public class Person : IComparable<Person>
{
    public string Name { get; init; }
    public int YearOfBirth { get; init; }

   

    public override string ToString() => $"{Name} born in {YearOfBirth}";

    public int CompareTo(Person other)
    {
        if (YearOfBirth < other.YearOfBirth)
        {
            return 1;
        }
        else if (YearOfBirth > other.YearOfBirth)
        {
            return -1;
        }
        return 0;
    }
}

public class Employee : Person
{
    public string Name { get; }
    public string Department { get; }
    public decimal Salary { get;  }

    public Employee(string name, string dep, int salary)
    {
        Name = name;
        Department = dep;
        Salary = salary;
    }

    public void GoToWork() => Console.WriteLine("Going to work");
}






public class ListOfInts
{
    private int[] _items = new int[4];
    private int _size = 0;

    public void Add(int number)
    {
        if(_size >= _items.Length)
        {
            var newItems = new int[_items.Length * 2];
            for(int i=0;i< _items.Length; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }
        _items[_size] = number;
        ++_size;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException($"{index} is out of range");
        }
        --_size;

        for(int i =index; i< _size; ++i)
        {
            _items[i] = _items[i + 1];
        }

        _items[_size] = 0;
    }

    public int GetIntAt(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException($"{index} is out of range");
        }
        return _items[index];
    }
}













public class Finder
{
  public  SimpleTuple<int,int> GetTwoInts(IEnumerable<int> numbers)
    {
        if(!numbers.Any())
        {
            throw new ArgumentException("the collection can't be null.");
        }

        int min = numbers.First();
        int max = numbers.First();

        foreach(var number in numbers)
        {
            if(number>max)
            {
                max = number;
            }
            if(number<min)
            {
                min = number;
            }
        }
        return new SimpleTuple<int,int>(min, max);
    }
}

public class SimpleTuple<T1,T2>
{
    public T1 Item1 { get; }
    public T2 Item2 { get; }

    public SimpleTuple(T1 int1, T2 int2)
    {
        Item1 = int1;
        Item2 = int2;
    }
}




public static class  ListExtensions 
{
    public static void AddToFront<T>(this List<T> list, T item)
    {
        list.Insert(0, item);
    }

    public static List<TTarget> ConvertTo<TSource, TTarget>(this List<TSource> items)
    {
        var result = new List<TTarget>();

        foreach(var item in items)
        {
           // Console.WriteLine(typeof(TSource));
            TTarget intItem = (TTarget)Convert.ChangeType(item,typeof(TTarget ));
            result.Add(intItem);
        }
        return result;
    }
}


