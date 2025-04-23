using System.Security.Cryptography.X509Certificates;

namespace Sales.Test.Entities;

public class CustomerTest
{
    private const string Name = "Teste";
    
    [Fact]
    public void CustomerNameInWrite()
    {
        var customer = new Sales.Domain.Entities.Customer(string.Empty);
        Assert.Empty(customer.Name);
    }
    
    [Fact]
    public void CustomerOk()
    {
        var customer = new Sales.Domain.Entities.Customer(string.Empty);
        Assert.NotNull(customer);
    }
}