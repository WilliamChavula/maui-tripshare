using System.IO;

namespace tripshare.services;

public class FetchFromJsonFile : IFetchDataClient<string>
{
    public Task<string> FetchDataAsync(string source)
    {
        var assembly = typeof(FetchFromJsonFile).GetTypeInfo().Assembly;
        var stream = assembly.GetManifestResourceStream(source);

        if (stream == null) throw new ArgumentNullException(nameof(source), $"Did not find the file: {source} in the assembly");
        using var reader = new StreamReader(stream);
        return reader.ReadToEndAsync();
    }
}

