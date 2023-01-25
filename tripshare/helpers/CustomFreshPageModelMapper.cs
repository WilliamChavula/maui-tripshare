namespace tripshare.helpers;

public class CustomFreshPageModelMapper: IFreshPageModelMapper
{
    private readonly string _pageNamespace;

    public CustomFreshPageModelMapper(string pageNamespace = null)
    {
        _pageNamespace = pageNamespace;
    }
    public string GetPageTypeName(Type pageModelType)
    {
        var assemblyQualifiedName = pageModelType.AssemblyQualifiedName!;

        // Replace Namespace
        if (_pageNamespace != null)
            assemblyQualifiedName = assemblyQualifiedName.Replace(pageModelType.Namespace!, _pageNamespace);
        
        // Replace "Model"
        assemblyQualifiedName = assemblyQualifiedName
            .Replace("PageModel", "Page")
            .Replace("ViewModel", "Page");

        return assemblyQualifiedName;
    }
}