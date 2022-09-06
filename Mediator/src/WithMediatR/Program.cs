using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using WithMediatR.Commands;
using WithMediatR.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<InMemoryDbContext>();
builder.Services.AddMediatR(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/payments/", async (IMediator mediator) =>
{
    var result = await mediator.Send(new GetAllPaymentsCommand());
    return Results.Ok(result);
})
.WithName("GetAllPayments")
.WithOpenApi();

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
