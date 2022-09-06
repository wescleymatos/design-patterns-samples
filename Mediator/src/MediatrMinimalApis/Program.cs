using Microsoft.AspNetCore.Http.HttpResults;
using MediatrMinimalApis.Persistence;
using MediatR;
using MediatrMinimalApis.Mediator.Commands;
using MediatrMinimalApis.Extensions;
using MediatrMinimalApis.Requests;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<InMemoryDbContext>();
builder.Services.AddMediatR(x => x.AsScoped(), typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MediatRGet<GetAllPaymentsRequest>("/payments");

app.MapGet("/payments/", async (IMediator mediator) =>
{
    return Results.Ok(await mediator.Send(new GetAllPaymentsCommand()));
})
.WithName("GetAllPayments")
.WithOpenApi();

app.MapGet("/payments/{id}", async (Guid id, IMediator mediator) =>
{
    var payment = await mediator.Send(new GetPaymentCommand(id));

    if (payment == null)
        return Results.NotFound();

    return Results.Ok(payment);
})
.WithName("GetPayment")
.WithOpenApi();

app.MapPut("/payments/{id}/pay", async (Guid id, IMediator mediator) =>
{
    var result = await mediator.Send(new PayCommand(id));

    return result ? Results.NoContent() : Results.NotFound();
})
.WithName("Pay")
.WithOpenApi();

app.Run();
