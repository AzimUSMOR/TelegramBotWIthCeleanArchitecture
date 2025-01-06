using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Application.Services
{
    public class TelegramService : ITelegramService
    {
        public TelegramService()
        {

        }

        public async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Обязательно ставим блок try-catch, чтобы наш бот не "падал" в случае каких-либо ошибок
            try
            {
                // Сразу же ставим конструкцию switch, чтобы обрабатывать приходящие Update
                switch (update.Type)
                {
                    case UpdateType.Message:
                        {
                            // эта переменная будет содержать в себе все связанное с сообщениями
                            var message = update.Message;

                            // From - это от кого пришло сообщение (или любой другой Update)
                            var user = message.From;

                            // Выводим на экран то, что пишут нашему боту, а также небольшую информацию об отправителе
                            System.Console.WriteLine($"{user.FirstName} ({user.Id}) написал сообщение: {message.Text}");

                            var chat = message.Chat;

                            if (message.Text == "Привет, я Алима")
                            {
                                await botClient.SendTextMessageAsync(
                                    chat.Id,
                                    "Привет Алима, это я бот" // Текст сообщения
                                );

                                return;
                            }

                            // Chat - содержит всю информацию о чате
                            await botClient.SendTextMessageAsync(
                                chat.Id,
                                message.Text // Текст сообщения
                            );

                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        public Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
        {
            // Тут создадим переменную, в которую поместим код ошибки и её сообщение 
            var ErrorMessage = error switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => error.ToString()
            };

            System.Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}