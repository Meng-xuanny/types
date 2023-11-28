IDataDownloader dataDownloader = new CacheDataDownloader(new PrintDataDownloader(new SlowDataDownloader()));

Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));

Console.ReadKey();

public interface IDataDownloader
{
    string DownloadData(string resourceId);
}

public class SlowDataDownloader : IDataDownloader
{

    public string DownloadData(string resourceId)
    {
        
        Thread.Sleep(1000);
       return $"Some data for {resourceId}";

    }

}

public class PrintDataDownloader : IDataDownloader
{
    private IDataDownloader _dataDownloader;

    public PrintDataDownloader(IDataDownloader dataDownloader)
    {
        _dataDownloader = dataDownloader;
    }

    public string DownloadData(string resourceId)
    {
        var data = _dataDownloader.DownloadData(resourceId);
        Console.WriteLine("Data is ready!");
        return data;
    }
}

public class CacheDataDownloader : IDataDownloader
{
    private IDataDownloader _dataDownloader;
    private readonly Cache<string, string> _cache = new ();

    public CacheDataDownloader(IDataDownloader dataDownloader)
    {
        _dataDownloader = dataDownloader;
    }

    public string DownloadData(string resourceId)
    {
        return _cache.Get(resourceId, _dataDownloader.DownloadData);
    }
}





public class Cache<TKey, TValue>
{
    private readonly Dictionary<TKey, TValue> _cache = new ();

    public TValue Get(TKey key, Func<TKey,TValue> createItem)
    {
        if (!_cache.ContainsKey(key))
        {
            _cache[key] = createItem(key);
        }
        return _cache[key];
    }

}