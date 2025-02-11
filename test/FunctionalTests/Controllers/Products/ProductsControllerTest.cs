using UnitTests.Fixtures;

namespace FunctionalTests.Controllers.Products;

public class ProductsControllerTest : BaseControllersTest
{
    protected readonly ProductTestData productTestData;
    public ProductsControllerTest(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
        productTestData = new ProductTestData();
    }
}
