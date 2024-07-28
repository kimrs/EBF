
// Set up the dependency injection container

using Eclipse.Domain;
using Eclipse.Domain.Dice;
using Eclipse.Domain.Ships;
using Eclipse.Domain.Ships.Parts;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
ConfigureServices(services);

// Build the service provider
var serviceProvider = services.BuildServiceProvider();

// Resolve a SpaceShip instance and use it
var damage = new Damage(1);
var die = serviceProvider.GetRequiredService<Die>();
var cannons = new List<Cannon>();
var shipParts = new List<Part>()
{
    new (
        Initiative: 1,
        Computer: 2,
        Shield: 1,
        Hull: 3
    ),
};


static void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<Die>();
}