var numbers = new List<int> { 5, 3, 2, 8, 16, 7, -10, -13 };
var filterSelector = new FilteringStrategySelector();

//Console.WriteLine("Select filter:");
//Console.WriteLine(string.Join(Environment.NewLine,filterSelector.FilteringStrategy));
//var input=Console.ReadLine();

//var userSelectedFunc = filterSelector.Select(input);
//var result=new Filter().FilterBy(userSelectedFunc,numbers);
//Print(result);


var words = new[] { "mama", "baba", "banana" };
var filteredWords = new Filter().FilterBy( word => word.StartsWith("b"), words);

Console.ReadKey();

void Print(IEnumerable<int> result)
{
    foreach(var number in result)
    {
        Console.WriteLine(number);

    }
}

public class FilteringStrategySelector
{
    private readonly Dictionary<string, Func<int, bool>> _filteringStrategy = new Dictionary<string, Func<int, bool>>
    {
        ["even"] = n => n % 2 == 0,
        ["odd"] = n => n % 2 != 0,
        ["positive"] = n => n > 0,
        ["negative"] = n => n < 0
    };

    public IEnumerable<string> FilteringStrategy => _filteringStrategy.Keys;


    public Func<int, bool> Select(string input)
    {
        if(!_filteringStrategy.ContainsKey(input))
        {
            throw new NotSupportedException("not supported");
        }
        return _filteringStrategy[input];
        
    }
}

public class Filter
{
    public IEnumerable<T> FilterBy<T>(Func<T,bool> predicate, IEnumerable<T> numbers)
    {
        var result = new List<T>();
        foreach (var num in numbers)
        {
            if (predicate(num))
            {
                result.Add(num);

            }
        }
        return result;


    }
}