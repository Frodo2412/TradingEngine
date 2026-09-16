using System.Threading.Tasks.Dataflow;
using Microsoft.Extensions.Options;
using TradingEngine.Logger.Configuration;

namespace TradingEngine.Logger;

public class TextLogger : AbstractLogger, ITextLogger
{
    private readonly LoggerConfiguration _config;
    private readonly BufferBlock<LogInformation> _logQueue = new();
    private readonly CancellationTokenSource _tokenSource = new();
    private readonly Lock _lock = new();
    private bool _disposed;

    public TextLogger(IOptions<LoggerConfiguration> loggingConfiguration)
    {
        _config = loggingConfiguration.Value ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        if (loggingConfiguration.Value.LoggerType != LoggerType.Text)
        {
            throw new InvalidOperationException("Invalid logging configuration");
        }

        var filepath = LogsFilepath();
        _ = Task.Run(() => LogAsync(filepath, _logQueue, _tokenSource.Token));
    }

    ~TextLogger()
    {
        Dispose(false);
    }

    private string LogsFilepath()
    {
        var logDirectory = Path.Combine(_config.TextLoggerConfiguration.Directory, $"{DateTime.Now:yyyy-MM-dd}");
        Directory.CreateDirectory(logDirectory);
        var baseLogName = Path.ChangeExtension(_config.TextLoggerConfiguration.FileName,
            _config.TextLoggerConfiguration.FileExtension);
        var filepath = Path.Combine(logDirectory, baseLogName);
        return filepath;
    }

    private static async void LogAsync(string filepath, BufferBlock<LogInformation> logQueue, CancellationToken token)
    {
        await using var fs = new FileStream(filepath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
        await using var sw = new StreamWriter(fs);

        try
        {
            while (true)
            {
                var logItem = await logQueue.ReceiveAsync(token).ConfigureAwait(false);
                var formattedMessage = logItem.FormattedMessage();
                await sw.WriteLineAsync(formattedMessage).ConfigureAwait(false);
            }
        }
        finally
        {
            sw.Close();
            fs.Close();
        }
    }

    protected override void Log(LogLevel level, string module, string message)
    {
        _logQueue.Post(new LogInformation(level, module, message, DateTime.Now, Thread.CurrentThread.ManagedThreadId,
            Thread.CurrentThread.Name!));
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        lock (_lock)
        {
            if (_disposed) return;
            _disposed = true;
        }

        if (disposing)
        {
            _tokenSource.Cancel();
            _tokenSource.Dispose();
        }
    }
}