using Application;
using CredentialManager.FactoryMethod;
using CredentialManager.ChainOfResponsabilities;
using CredentialManagerCSV.Writers;
using CredentialManagerDb.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IOC;

public static class CredentialManagerIOC { 

    private static void GetCollection(this IServiceCollection service)
    { 
        service.AddSingleton<ManagerValidator>();
        service.AddSingleton<ManagerWriterCSV>();
        service.AddSingleton<IAccountRepository, AccountRepository>();
        service.AddSingleton<AccountFactory>();
        service.AddSingleton<SetUpChainPasswordValidation>();
        service.AddSingleton<IWriter, WriterCsv>();

    }

    public static ServiceProvider GetProvider()
    {
        var services = new ServiceCollection();
        services.GetCollection();
        return services.BuildServiceProvider();
    }
}

