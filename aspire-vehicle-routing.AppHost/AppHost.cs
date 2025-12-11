var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.aspire_vehicle_routing_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.aspire_vehicle_routing_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
