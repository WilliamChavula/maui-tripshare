namespace tripshare.interfaces;

public interface IFetchDataClient<T>
{
    Task<T> FetchDataAsync(string source);
}

