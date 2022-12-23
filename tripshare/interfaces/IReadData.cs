namespace tripshare.interfaces;

public interface IReadData
{
    Task<IEnumerable<Trip>> LoadDataAsync(string source);
}

