using WorkerService.Example;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<IFileData, FileData>();

var host = builder.Build();
host.Run();
