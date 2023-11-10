using cSharpWebApi.Data;
using cSharpWebApi.Data.Address;
using cSharpWebApi.Service.AddressService;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace cSharpWebApi.tests;

[Binding]
public class CommonSteps
{
    private CSharpContext _scenarioContext;
    public CommonSteps(CSharpContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    [Given(@"i seguenti indirizzi nella nostra base dati")]
    public void GivenISeguentiIndirizziNellaNostraBaseDati(Table table)
    {
        var addresses = table.CreateSet<Address>();
        var dbContext = new DatabaseContext(null);
        dbContext.SystemInfoService = _scenarioContext.SystemInfoService.Object;
        dbContext.Addresses.AddRange(addresses);
        dbContext.SaveChanges();
        _scenarioContext.DbContext = dbContext;
    }

    [When(@"chiedo la lista degli indirizzi")]
    public async Task WhenChiedoLaListaDegliIndirizzi()
    {
        var servizio = new AddressService(_scenarioContext.DbContext);
        _scenarioContext.Addresses = await servizio.GetAllAddresses();
    }

    [Then(@"ottengo i seguenti indirizzi nella risposta")]
    public void ThenOttengoISeguentiIndirizziNellaRisposta(Table table)
    {
        var espectedAddresses = table.CreateSet<Address>();
        var actualAddresses = _scenarioContext.Addresses;
        espectedAddresses.Should().BeEquivalentTo(actualAddresses);
    }

    [Given(@"il seguente utente '(.*)' e il seguente orario '(.*)'")]
    public void GivenIlSeguenteUtenteEIlSeguenteOrario(string user, DateTime data)
    {
        var systemInfoService = new Mock<ISystemInfoService>();
        systemInfoService.Setup(x => x.GetCurrentUser()).Returns(user);
        systemInfoService.Setup(x => x.GetCurrentDate()).Returns(data);
        _scenarioContext.SystemInfoService = systemInfoService;
    }
}

public class CSharpContext
{
    public DatabaseContext DbContext { get; set; }
    public IReadOnlyCollection<Address> Addresses { get; set; }
    
    public Mock<ISystemInfoService> SystemInfoService { get; set; }
}