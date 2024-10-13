var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Microservice_AzureSQL>("microservice-azuresql");
builder.AddProject<Projects.BlazorWebAssemblyUI>("blazorwebassemblyui");

builder.Build().Run();
