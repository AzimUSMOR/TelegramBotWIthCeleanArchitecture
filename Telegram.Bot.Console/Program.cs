using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Application.Extensions;
using Telegram.Bot.Application.Services;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

class Program
{
    static async Task Main()
    {
        var services = new ServiceCollection();
        services.AddApplicationServices();
        var provider = services
            .AddSingleton<Executor, Executor>()
            .BuildServiceProvider();

        var executor = provider.GetService<Executor>();
        if (executor != null)
        {
            await executor.Execute(); // Ожидаем выполнения асинхронного метода
        }

    }
}

public class Executor
{
    private readonly ITelegramService _telegramService;

    private static ITelegramBotClient _botClient;

    private static ReceiverOptions _receiverOptions;

    public Executor(ITelegramService telegramService)
    {
        _telegramService = telegramService;
    }

    public async Task Execute()
    {
        _botClient = new TelegramBotClient("8038450505:AAFtWmzW0-q7iJdzxiFeorFxmV80FtWvlh4"); // Присваиваем нашей переменной значение, в параметре передаем Token, полученный от BotFather
        _receiverOptions = new ReceiverOptions // Также присваем значение настройкам бота
        {
            AllowedUpdates = new[] // Тут указываем типы получаемых Update`ов, о них подробнее расказано тут https://core.telegram.org/bots/api#update
            {
                UpdateType.Message, // Сообщения (текст, фото/видео, голосовые/видео сообщения и т.д.)
                UpdateType.CallbackQuery
            },
            // Параметр, отвечающий за обработку сообщений, пришедших за то время, когда ваш бот был оффлайн
            // True - не обрабатывать, False (стоит по умолчанию) - обрабаывать
            DropPendingUpdates = true,
        };

        using var cts = new CancellationTokenSource();

        // UpdateHander - обработчик приходящих Update`ов
        // ErrorHandler - обработчик ошибок, связанных с Bot API
        _botClient.StartReceiving(_telegramService.UpdateHandler, _telegramService.ErrorHandler, _receiverOptions, cts.Token); // Запускаем бота

        var me = await _botClient.GetMeAsync(); // Создаем переменную, в которую помещаем информацию о нашем боте.
        Console.WriteLine($"{me.FirstName} запущен!");
        Console.WriteLine($"{me.FirstName} запущен!");

        await Task.Delay(-1); // Устанавливаем бесконечную задержку, чтобы наш бот работал постоянно
    }
}