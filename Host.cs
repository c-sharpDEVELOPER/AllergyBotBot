using Telegram.Bot;
using Telegram.Bot.Types;

public class Host {
    public Action<ITelegramBotClient, Update>? OnMessage;
    private TelegramBotClient _bot;

    public Host(string token) {

        _bot = new TelegramBotClient(token);


    }

    public void Start() {
        _bot.StartReceiving(UpdateHandler, ErrorHandler);
        Console.WriteLine("бот был запущен!");
    }

    private async Task ErrorHandler(ITelegramBotClient client, Exception exception, CancellationToken token)
    {
        Console.WriteLine("Ошибка: " + exception.Message);
        await Task.CompletedTask;
    }

    private async Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken token)
    {
        Console.WriteLine($"пришло сообщение: {update.Message?.Text ?? "[не текст]"}");
        
        OnMessage?.Invoke(client, update);
        await Task.CompletedTask;
    }
}