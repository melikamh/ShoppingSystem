using Scrutor;
using ShoppingSystem.Infrastructure.Commands;
using ShoppingSystem.Infrastructure.Services;
using ShoppingSystem.Persistence;
using ShoppingSystem.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.Scan(
        selector => selector
            .FromAssemblies(
                ShoppingSystem.Infrastructure.AssemblyReference.Assembly,
                ShoppingSystem.Persistence.AssemblyReference.Assembly)
            .AddClasses(false)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ShoppingSystem.Application.AssemblyReference)));
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

builder.Services.AddDbContext<ShoppingSystemDbContext>();

builder.Services
    .AddControllers()
    .AddApplicationPart(ShoppingSystem.Persistence.AssemblyReference.Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
