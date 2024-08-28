namespace WorkerService.Example
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private string _path = Directory.GetCurrentDirectory() + @"\Files\";
        private IFileData _fileData;
        private int _count = 0;

        public Worker(ILogger<Worker> logger, IFileData fileData)
        {
            _logger = logger;
            _fileData = fileData;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await _fileData.Create($"{_path}{_count++}.txt");
            }
        }
    }
}
