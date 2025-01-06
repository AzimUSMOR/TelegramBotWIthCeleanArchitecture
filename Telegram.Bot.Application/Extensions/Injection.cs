using Telegram.Bot.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Telegram.Bot.Application.Extensions
{
    public static class Injection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection pServices)
        {
            pServices.AddScoped<ITelegramService, TelegramService>();
            return pServices;
        }
    }
}