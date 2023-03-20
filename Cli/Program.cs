
// Set up the dependency injection container

using Eclipse;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
ConfigureServices(services);

// Build the service provider
var serviceProvider = services.BuildServiceProvider();

// Resolve a SpaceShip instance and use it
var cannonFactory = serviceProvider.GetRequiredService<CannonFactory>();
var damage = new Damage(1);
var cannons = new List<Cannon>()
{
    cannonFactory.Create(damage),
    cannonFactory.Create(damage),
};
var shipParts = new List<ShipPart>()
{
    new ShipPart(
        new Initiative(1),
        new Computer(2),
        new Shield(1),
        Hull: 3
    ),
};


static void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<Dice>();
    services.AddSingleton<CannonFactory>();
}
