using WithoutLibs.Base;
using WithoutLibs.Commands;
using WithoutLibs.Handlers;
using WithoutLibs.Persistence;
using WithoutLibs.Persistence.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<InMemoryDbContext>();

builder.Services.AddScoped<ICommandHandler<GetAllPaymentsCommand, List<Payment>>, GetAllPaymentsHandler>();
builder.Services.AddScoped<ICommandMediator, CommandMediator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Calma!

app.MapGet("/payments/", (ICommandMediator mediator) =>
{
    return Results.Ok(mediator.Send<GetAllPaymentsCommand, List<Payment>>(new GetAllPaymentsCommand()));
})
.WithName("GetAllPayments")
.WithOpenApi();

#endregion

//app.MapGet("/payments/", (InMemoryDbContext dbContext) =>
//{
//    return Results.Ok(dbContext.Payments);
//})
//.WithName("GetAllPayments")
//.WithOpenApi();

app.MapGet("/payments/{id}", (Guid id, InMemoryDbContext dbContext) =>
{
    var payment = dbContext.Payments.FirstOrDefault(p => p.Id == id);

    if (payment == null)
        return Results.NotFound();

    return Results.Ok(payment);
})
.WithName("GetPayment")
.WithOpenApi();

app.MapPut("/payments/{id}/pay", (Guid id, InMemoryDbContext dbContext) =>
{
    var payment = dbContext.Payments.FirstOrDefault(p => p.Id == id);

    if (payment == null)
        return Results.NotFound();

    if (payment.Paid)
        return Results.BadRequest($"Payment {id} already paid!");

    payment.Pay();

    return Results.NoContent();
})
.WithName("Pay")
.WithOpenApi();

app.Run();
