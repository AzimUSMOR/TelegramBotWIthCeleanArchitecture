using Telegram.Bot.Types;

namespace Telegram.Bot.Application.Services
{
    public interface ITelegramService
    {
        /// <summary>
        /// Метод для отлавливания сообщений, которые приходят от телеграмм бота
        /// </summary>
        /// <param name="pBotClient">Клиент бота</param>
        /// <param name="pUpdate">Обновление</param>
        /// <param name="pCancellationToken">Токен отмены</param>
        /// <returns></returns>
        Task UpdateHandler(ITelegramBotClient pBotClient, Update pUpdate, CancellationToken pCancellationToken);

        /// <summary>
        /// Метод для отлавливания ошибок, которые приходят от телеграмм бота
        /// </summary>
        /// <param name="pBotClient">Клиент бота</param>
        /// <param name="pError">Ошибка</param>
        /// <param name="pCancellationToken">Токен отмены</param>
        /// <returns></returns>
        Task ErrorHandler(ITelegramBotClient pBotClient, Exception pError, CancellationToken pCancellationToken);
    }
}