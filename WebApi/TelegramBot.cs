using Telegram.Bot;
using Telegram.Bot.Extensions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Exceptions;
using WebApi.Controllers;

namespace WebApi
{

    public class TelegramBot
    {
        private static int status =0;
        private static string artist = "";
        private static string title = "";
        private static LyricsController lyricsController = new LyricsController();

        TelegramBotClient botClient = new TelegramBotClient("5298590715:AAFDG61W0e6goDcCSCrx37cIDFTMhB9LeQk");
        CancellationToken cancellationToken = new CancellationToken();
        ReceiverOptions receiverOptions = new ReceiverOptions{AllowedUpdates ={} };

        public async Task Start()
        {
            Console.WriteLine("Bot started");
            botClient.StartReceiving(UpdateHandlerAsync, ErrorHandler, receiverOptions, cancellationToken);

        }

        private Task ErrorHandler(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Error in bot api:\n {apiRequestException.ErrorCode}",
                _ => exception.ToString()
            };
            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        private async Task UpdateHandlerAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if ( update.Type == UpdateType.Message && update.Message.Text == "Search Lyrics")
            {
                
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Enter artist");
                status = 1;
                return;
            }
            if (status == 1 && update.Type == UpdateType.Message && update.Message.Text != null)
            {
                artist = update.Message.Text;
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Enter title");
                status = 2;
                //await botClient.SendTextMessageAsync(update.Message.Chat.Id, lyricsController.LyricsGet(artist, title).Lyrics);
                return;
            }
            if (status == 2 && update.Type == UpdateType.Message && update.Message.Text != null)
            {
                title = update.Message.Text;
                
                status = 0;
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, lyricsController.LyricsGet(artist, title).Lyrics);
                return;
            }
            if (update.Type==UpdateType.Message&&update.Message.Text!=null)
            {
                await MessageHandlerAsync(botClient, update.Message);
            }
            if (update?.Type == UpdateType.CallbackQuery)
            {
                await CallbackQueryHandlerAsync(botClient, update.CallbackQuery);
            }
        }
        private async Task CallbackQueryHandlerAsync(ITelegramBotClient botClient, CallbackQuery? callbackQuery)
        {
           
        }
        private InlineKeyboardMarkup createInlineKeyboard()
        {
            InlineKeyboardMarkup myInlineKeyboard = new InlineKeyboardMarkup(

            new InlineKeyboardButton[][]
             {
                new InlineKeyboardButton[] // First row
                {
                    InlineKeyboardButton.WithCallbackData( // First Column
                    "option1", // Button Name
                    "CallbackQuery1" // Answer you'll recieve
                        ),
                    InlineKeyboardButton.WithCallbackData( //Second column
                    "option2", // Button Name
                    "CallbackQuery2" // Answer you'll recieve
                    )
                }
            }
            );
            Console.WriteLine("Keyboard created");
            return myInlineKeyboard;

        }

        private ReplyKeyboardMarkup createMainMenuReplyKeyboard()
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton[] { "Search Lyrics", "Search artist" },
                new KeyboardButton[] { "Text to Mp3", "Favorite songs" }
            })
            {
                ResizeKeyboard = true
            };
            return replyKeyboardMarkup;
        }
        private async Task MessageHandlerAsync(ITelegramBotClient botClient, Message message)
        {
            if(message.Text=="/start")
            { 
                Console.WriteLine("messageHandler");
                var chatID = message.Chat.Id;
                var msdgText = "What you want to do?";
                //var replyMarkup1 = createKeyboard();
                await botClient.SendTextMessageAsync(chatID, msdgText, replyMarkup: createMainMenuReplyKeyboard());
                return;
            }
            if(message.Text=="Search Lyrics")
            {
                //var chatID = message.Chat.Id;
                //var msdgText = "Enter artist and song name(ex: Manowar Manowar):";
                //status = 1;
                //await botClient.SendTextMessageAsync(chatID, msdgText);
            }
        }
    }
}
