using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Console.Extensions
{
    public static class BotHanddlers
    {
        public static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Обязательно ставим блок try-catch, чтобы наш бот не "падал" в случае каких-либо ошибок
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

                            // From - это от кого пришло сообщение
                            var user = message.From;

                            // Выводим на экран то, что пишут нашему боту, а также небольшую информацию об отправителе
                            System.Console.WriteLine($"{user.FirstName} ({user.Id}) написал сообщение: {message.Text}");

                            // Chat - содержит всю информацию о чате
                            var chat = message.Chat;

                            // Добавляем проверку на тип Message
                            switch (message.Type)
                            {
                                // Тут понятно, текстовый тип
                                case MessageType.Text:
                                    {
                                        // тут обрабатываем команду /start, остальные аналогично
                                        if (message.Text == "/start")
                                        {
                                            await botClient.SendTextMessageAsync(
                                                chat.Id,
                                                "Выбери клавиатуру:\n" +
                                                "/inline\n" +
                                                "/reply\n");
                                            return;
                                        }

                                        if (message.Text == "/inline")
                                        {
                                            // Тут создаем нашу клавиатуру
                                            var inlineKeyboard = new InlineKeyboardMarkup(
                                                new List<InlineKeyboardButton[]>() // здесь создаем лист (массив), который содрежит в себе массив из класса кнопок
                                                {
                                        // Каждый новый массив - это дополнительные строки,
                                        // а каждая дополнительная строка (кнопка) в массиве - это добавление ряда

                                        new InlineKeyboardButton[] // тут создаем массив кнопок
                                        {
                                            InlineKeyboardButton.WithUrl("Это кнопка с сайтом", "https://habr.com/"),
                                            InlineKeyboardButton.WithCallbackData("А это просто кнопка", "button1"),
                                        },
                                        new InlineKeyboardButton[]
                                        {
                                            InlineKeyboardButton.WithCallbackData("Тут еще одна", "button2"),
                                            InlineKeyboardButton.WithCallbackData("И здесь", "button3"),
                                        },
                                                });

                                            await botClient.SendTextMessageAsync(
                                                chat.Id,
                                                "Это inline клавиатура!",
                                                replyMarkup: inlineKeyboard); // Все клавиатуры передаются в параметр replyMarkup

                                            return;
                                        }

                                        if (message.Text == "/reply")
                                        {
                                            // Тут все аналогично Inline клавиатуре, только меняются классы
                                            // НО! Тут потребуется дополнительно указать один параметр, чтобы
                                            // клавиатура выглядела нормально, а не как абы что

                                            var replyKeyboard = new ReplyKeyboardMarkup(
                                                new List<KeyboardButton[]>()
                                                {
                                        new KeyboardButton[]
                                        {
                                            new KeyboardButton("Привет!"),
                                            new KeyboardButton("Пока!"),
                                        },
                                        new KeyboardButton[]
                                        {
                                            new KeyboardButton("Позвони мне!")
                                        },
                                        new KeyboardButton[]
                                        {
                                            new KeyboardButton("Напиши моему соседу!")
                                        }
                                                })
                                            {
                                                // автоматическое изменение размера клавиатуры, если не стоит true,
                                                // тогда клавиатура растягивается чуть ли не до луны,
                                                // проверить можете сами
                                                ResizeKeyboard = true,
                                            };

                                            await botClient.SendTextMessageAsync(
                                                chat.Id,
                                                "Это reply клавиатура!",
                                                replyMarkup: replyKeyboard); // опять передаем клавиатуру в параметр replyMarkup

                                            return;
                                        }

                                        return;
                                    }

                                // Добавил default , чтобы показать вам разницу типов Message
                                default:
                                    {
                                        await botClient.SendTextMessageAsync(
                                            chat.Id,
                                            "Используй только текст!");
                                        return;
                                    }
                            }

                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        public static Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
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