public class SingletonService
{
    private readonly IServiceProvider _serviceProvider;

    // SingletonService 只依賴 IServiceProvider
    public SingletonService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void DoSomething()
    {
       // 在 method 調用時, 透過 IServiceProvider create scope 取得 ScopedService
        var scope = _serviceProvider.CreateScope()

        var scopedService = scope.ServiceProvider.GetRequiredService<ScopedService>();
        scopedService.DoSomething();
    }
}
