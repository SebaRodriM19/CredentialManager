using Application;
using Application.Exceptions;
using CredentialManager.FactoryMethod;
using CredentialManagerDb.Repositories;
using IOC;
using Microsoft.Extensions.DependencyInjection;

var provider = CredentialManagerIOC.GetProvider();
var serviceManagerValidator = provider.GetService<ManagerValidator>();
var managerCsv = provider.GetService<ManagerWriterCSV>();

try
{
    serviceManagerValidator.SaveAccountInDb("Sebastian@mail.pollo", "UnoSBalloPazz3Sko%!");
    serviceManagerValidator.PrintDataAccount("Sebastian@mail.pollo", "UnoSBalloPazz3Sko%!");
}
catch (AccountAlreadyExistsException exc)
{
    Console.WriteLine(exc.Message);
}
catch (InvalidAccountException exc)
{
    Console.WriteLine(exc.Message);
}
catch (InvalidPasswordAccountException exc)
{
    Console.WriteLine(exc.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

managerCsv.WriteCSV();

