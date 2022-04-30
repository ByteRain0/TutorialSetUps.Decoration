using DecoratorSample.Services.GenericApproach;
using DecoratorSample.Services.SimpleExample;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Simple decoration
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.Decorate<IBookRepository, BookRepositoryValidator>();
#endregion

#region Generic decoration
builder.Services.Scan(scan =>
    scan.FromAssembliesOf(typeof(IRepository<>))
        .AddClasses(classes => 
            classes.AssignableTo(typeof(IRepository<>)).Where(_ => !_.IsGenericType))
        .AsImplementedInterfaces()
        .WithTransientLifetime());
builder.Services.Decorate(typeof(IRepository<>) ,typeof(GenericRepositoryValidator<>));

//Disabled the controller level validation on purpose to demonstrate the sample validation. Avoid this in production code.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();