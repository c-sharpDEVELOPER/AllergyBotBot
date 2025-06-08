using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.VisualBasic;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using File = System.IO.File;
using NodaTime;
using Telegram.Bot.Args;
using System.Globalization;
using NodaTime.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Numerics;
using System.Net;
using System.Text.Json;








internal class Program
{

    public class UserData
    {
        public List<int> Numbers { get; set; } = new();
    }
    private static readonly TimeSpan CoolDownTime = TimeSpan.FromMinutes(5);
    private static readonly TimeSpan CoolDownIo = TimeSpan.FromHours(2);
    private static readonly TimeSpan CoolDownInfo = TimeSpan.FromDays(1);
    private static readonly ConcurrentDictionary<long, (DateTime TimeUses, float gata)> userINFOcool = new();
    private static readonly ConcurrentDictionary<long, (DateTime TimeUse, int lata)> userIOcool = new();
    private static readonly ConcurrentDictionary<long, (DateTime TimeUsed, string labuba)> userCoolDowns = new();
    private static readonly ConcurrentDictionary<long, string[]> userPhraseHistory = new();
    private static readonly ConcurrentDictionary<long, UserData> userIOhistory = new();
    private static readonly ConcurrentDictionary<long, string[]> userBonusHistory = new();
    private static Dictionary<long, float> userTotals = new();
    static Dictionary<string, long> usernameToId = new();
    private static readonly ConcurrentDictionary<long, int> userInfoHistory = new();






    private static void Main()
    {

        Host g4bot = new Host("8054474965:AAFaeGiAGNTjf8qXSyDJmfhZkjVvqvYhWCg");
        g4bot.Start();
        g4bot.OnMessage += OnMessage;
        Console.ReadLine();


    }

    static string ImagesPath = @"C:\Users\79375\OneDrive\Рабочий стол\images\";
    static List<string> images = new List<string>
    {
        "webp.webp",
        "lower.webp",
        "zeroa.webp",
        "dagestam.jpg"
    };

    private bool IsCommand(string message)
    {
        return message.StartsWith("/") || message.StartsWith(".");
    }



    private static async void OnMessage(ITelegramBotClient client, Update update)
    {

        try
        {
            Dictionary<long, bool> ждемОтвет = new();

            var commands = new List<BotCommand>
            {
                new BotCommand { Command = "start", Description = "Запустить бота" },
                new BotCommand { Command = "help", Description = "Помощь по командам" },
                new BotCommand { Command = "obnova", Description = "Проверить, какое обновление" },
                new BotCommand { Command = "tochat", Description = "Добавить меня в чат" }
            };

            var inlineKeyboard = new InlineKeyboardMarkup(
                InlineKeyboardButton.WithUrl(
                text: "➕ * Добавить в чат",
                url: "https://t.me/AllergyBotBot?startgroup=start" // Заменить на имя твоего бота!
                )
            );

            await client.SetMyCommandsAsync(
                commands,
                scope: new BotCommandScopeDefault(),
                languageCode: "ru"
            );

            await client.SetMyCommandsAsync(
                commands,
                scope: new BotCommandScopeAllGroupChats()
            );

            if (update.Type != UpdateType.Message || update.Message?.Text == null || update.Message.From == null)
                return;

            switch (update.Message?.Text)
            {

                case "/secret":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "НУ МАЛАДЕЖ\nРАЗВИЛА ПАГАНЫЙ НОС\nСРОНЯ КАТЯ ВСЕМ ПРИВЕТ!\nЭТО ВАШ ДОМОСЕД!");
                        break;
                    }
                case "I love u":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "i love u too!!:)", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "Крокодилдо пенисини":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "crocodildo penissini\npeperroni masturbini\ntrippi troppa crocodini\ndildo dildo dildodini", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/райка":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "райка пр ты афигенная\nкороче спасибо что тестишь бота!", replyToMessageId: update.Message?.MessageId);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "предлагай тут идеи для комманд, я почитаю", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/кикко":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "ЙА ТВОЙ ФАНАТ ПРОСТО\n АВТОГРАФ ДАЙЙ", replyToMessageId: update.Message?.MessageId);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "СПАСИБО ЧТО БОТА ИСПОЛЬЗУЕШЬ", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/dem":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "ДЕМОН БЕЗЫМЯШКА\nВОТ ТАКАЯ КАКАШКА\n\nМНЕ МЕНТАЛЬНО 9 ЛЕТ\nДЕМОНЮШКА БЕЗЫМЮШКА", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/ks":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "я со своей влв девушкой\nв нашем влв лесбийском доме\nпойдем пить влв чаек\nс влв печеньками а потом\nпойдем спаать\nв нашу влв кровать", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/esse":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "напиши отзыв о боте: хороший он или нет, а также что добавить или убрать. я почитаю потом", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/suka":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "сука блять\nЯ ЮЗАЮ МАТЫ ПРИКИНЬ\nЯ БОТ И ЮЗАЮ МАТЫ\nОК", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/parappa":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "без щей - пропаганда здоровья\n\nэто знает каждый, кто юзает <он/они>!\n\nда даже пусть юзает <оно/нЕо/такого>, все равно он знает, что это здоровье!\n\nпараппа воевал за наших!\nвсегда защищал от фашизма\n\nтеперь он не любит нас и юзает <ОНА>😭😭😭😭O_O", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/nepridumal":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "я еще не придумал, что написать...", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "тунг тунг сахур":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "TUNG TUNG TUNG SAHUR\nETOSHPIONIROgOluBiNa\nTUNG TUNG TUNG SAHUR\nYA TAKAYA TU-TUPAYA!", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case ".minet":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "Okey Zapuskayu .minet", replyToMessageId: update.Message?.MessageId);
                        Thread.Sleep(5000);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, ".minet Zapushen.", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case ".anal":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "Okey Zapuskayu .anal", replyToMessageId: update.Message?.MessageId);
                        Thread.Sleep(6000);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, ".anal Zapushen", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/лемо":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "лем привет короче ну ладно пока ну привет ну пока ну короче пока привет", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "ты как тралалело тралала":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "ты как тралалело тралала\nдал мне уюта и тепла", replyToMessageId: update.Message?.MessageId);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "ты как балерина капучина\nнас соединила паутина", replyToMessageId: update.Message?.MessageId);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "чипи тропа\nтропа трипы", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/analnui terrorist":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "кто жто блять писал\nмне откуда знать, что это значит", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/minet2":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "Когда мне было двенадцать лет, я сделал как-то сам себе минет.\nЯ изогнулся, что было сил, и за хуй больно я себя укусил.\nМой хуй разбух как огурец, и я считал, что мне уже пиздец.\nНо долго не пришлось страдать и хуй мой начал быстро заживать.", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/pikmi":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "я.. дазай.. МАНИПУЛЯТОР!!..\nбб-бойтесь меня... сейчас...\nпридет мой альфач....\nАХ АХ АХ....\nНУ НЕ НА УЛИЦЕ ЖЕ....", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/slova":
                    {

                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "Хорошо! Введи любое слово. Мы начнем игру!", replyToMessageId: update.Message?.MessageId);
                        string slovatext = update.Message?.Text;
                        Thread.Sleep(8000);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"извини, команда пока не доработана. Слово {slovatext} наверняка существует! но я не могу это проверить...", replyToMessageId: update.Message?.MessageId);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"ИЗВИНЯЮСЬ! Вообще ниче тут не получилось, но пусть останется. Будет доработано в 2.5 omega", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/chickenjockey":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "do you want fight a chicken?", replyToMessageId: update.Message?.MessageId);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "tintintin....", replyToMessageId: update.Message?.MessageId);
                        Thread.Sleep(1150);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "CHICKEN JOCKEY!!", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/helprefix":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "Внимание, команды указанные ниже используются только с указанием ника!", replyToMessageId: update.Message?.MessageId);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "префиксы: . , *", replyToMessageId: update.Message?.MessageId);
                        Thread.Sleep(1100);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, ".поцеловать - вы можете поцеловать кого-либо!\n.обнять - обнимите любимого вам человека!\n.ударить - если вам кто-то не угодил, вы можете его ударить!", replyToMessageId: update.Message?.MessageId);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "В этой версии команды еще не доработаны!", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/shar":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "Привет, это шар удачи! Загадай вопрос в голове, а я тебе отвечу!\n\nот 1 до 12 - да\nот 12 до 25 - нет\nот 25 до 38 - возможно\nот 38 до 52 - скорее да\nот 52 до 73 - скорее нет\nот 73 до 88 - попробуй задать вопрос позже\nот 88 до 100 - все зависит от тебя", replyToMessageId: update.Message?.MessageId);
                        Thread.Sleep(5000);
                        Random choice = new Random();
                        var choices = choice.Next(1, 101);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Тебе выпало число: {choices}", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/policeparappa":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "Даже параппа уже сдал на права, а ты нет. А ну ка!\n\nесли выпало от 1 до 3 то попробуй позже\nот 3 до 7 - сдал!\nот 7 до 10 - не сдал (сучара)", replyToMessageId: update.Message?.MessageId);
                        Thread.Sleep(2500);
                        Random pravo = new Random();
                        var prava = pravo.Next(1, 11);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Тебе выпало число: {prava}, а дальше суди сам сдал или нет.", replyToMessageId: update.Message?.MessageId);

                        if (prava == 1 || prava == 2 || prava == 3)
                        {
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Тебе выпало {prava}, а это что значит???!!!", replyToMessageId: update.Message?.MessageId);
                            Thread.Sleep(1000);
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Это значит, что ПОПРОБУЙ ПОЗЖЕ!!!", replyToMessageId: update.Message?.MessageId);
                        }
                        else if (prava == 4 || prava == 5 || prava == 6 || prava == 7)
                        {
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Тебе выпало {prava}, а это что значит???!!!", replyToMessageId: update.Message?.MessageId);
                            Thread.Sleep(1000);
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Это значит, что сдал... блин", replyToMessageId: update.Message?.MessageId);
                        }
                        else if (prava == 8 || prava == 9 || prava == 10)
                        {
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Тебе выпало {prava}, а это что значит???!!!", replyToMessageId: update.Message?.MessageId);
                            Thread.Sleep(1000);
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Это значит, что НЕ СДАЛ АХАХАХА ЛОХХХ", replyToMessageId: update.Message?.MessageId);
                        }
                        break;
                    }
                case ".правасдать":
                    {

                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Если ты зашел в эту команду, видимо в прошлой ты не сдал права...\nладно, я помогу..\n\n(дам бесплатно)", replyToMessageId: update.Message?.MessageId);
                        Random rnd = new Random();
                        var nomerprav = rnd.Next(1111111, 9999999);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Права: сданы\n  Номер прав: <b>{nomerprav}</b>\nДействует до: 19.09.2030 ", replyToMessageId: update.Message?.MessageId, parseMode: Telegram.Bot.Types.Enums.ParseMode.Html);
                        break;
                    }

                case "/masti":
                    {
                        bool Card = false;
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Привет! Давай сыграем в масти!\n\nМасти - игра, придуманная моим создателем. В ней есть 16 карт (4 масти по 4 карты).\nМасти\n\n1. Чередка\n2. Галетья\n3. Древо\n4. Знание\n\nЧередка побеждает Галетью, Древо побеждает Чередку, Знание побеждает Древо, Галетья побеждает Знание\n\nВиды карт:\n\n1. Дева\n2. Кегля\n3. Скорпион\n4.Шар\nДева побеждает Скорпиона, Кегля побеждает Шар, Скорпион побеждает Кеглю, Шар побеждает Деву\n\nЧто же, начнём?", replyToMessageId: update.Message?.MessageId);
                        var cards = ("Дева Чередки", "Дева Галетия", "Дева Древа", "Дева Знания", "Кегля Чередки", "Кегля Галетия", "Кегля Древа", "Кегля Знания", "Скорпион Чередки", "Скорпион Галетия", "Скорпион Древа", "Скорпион Знания", "Шар Чередки", "Шар Галетия", "Шар Древа", "Шар Знания");
                        Message message = await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Пришли карту, которую ты выбрал. Пиши так, как в примере (Дева Чередки, Кегля Галетия, Скорпион Древа, Шар Знания)", replyToMessageId: update.Message?.MessageId);
                        Card = true;
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Упс! Твоя карта: {message} не распознана! Попробуй поиграть в эту игру в следующем обновлении!", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case "/ss":
                    {
                        string[] actions = { "🕵🏿 * Вы попали в ловушку!", "🫢 * Вы взломали Пентагон...", "😊 * Вы вступили в ЛГБТ! (in honor of pride-month)", "😢 * Вас заблокировал РосКомНадзор..." };
                        int RandomIndex = new Random().Next(actions.Length);
                        string action = actions[RandomIndex];
                        if (RandomIndex == 0)
                        {

                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"{action} Что будем делать?\n\n\n   ВАРИАНТЫ ОТВЕТА:\n1. ничего не делать\n2. попытаться выйти\n3. уе того, кто поставил ловушку\n\n\nПример: .я лов действие 1", replyToMessageId: update.Message?.MessageId);

                            switch (update.Message?.Text)
                            {
                                case ".я лов действие 1":
                                    {
                                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🫢😭 * ты весь истек кровью и умер...", replyToMessageId: update.Message?.MessageId);
                                        break;
                                    }

                                case ".я лов действие 2":
                                    {
                                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🫢😢 * у тебя не получилось и это еще больше усугубило твои травмы.. ты умер...", replyToMessageId: update.Message?.MessageId);
                                        break;
                                    }

                                case ".я лов действие 3":
                                    {
                                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🫢😊 * у тебя получилось выбраться из ловушки и уе того, кто ее поставил!", replyToMessageId: update.Message?.MessageId);
                                        break;
                                    }

                                default:
                                    {
                                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Извините, но такой команды не существует. Попробуйте запустить команду позже, верно вписав команду.", replyToMessageId: update.Message?.MessageId);
                                        break;
                                    }

                            }
                        }
                        else if (RandomIndex == 1)
                        {
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"{action} Что будем делать?\n\n\n   ВАРИАНТЫ ОТВЕТА:\n1. ничего не делать\n2. написать пентагону на почту и попытаться вернуть\n3. по-быстренькому вернуть им доступ к пентагону.\n\n\nПример: .я пент действие 1", replyToMessageId: update.Message?.MessageId);

                            switch (update.Message?.Text)
                            {
                                case ".я пент действие 1":
                                    {
                                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🫢😭 * все заметили, что доступ к пентагону закрыт и на тебя подали в суд (403 года тюрьмы)", replyToMessageId: update.Message?.MessageId);
                                        break;
                                    }

                                case ".я пент действие 2":
                                    {
                                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🫢😢 * они отреагировали и ты им вернул доступ, но на тебя подали в суд (303 года тюрьмы)", replyToMessageId: update.Message?.MessageId);
                                        break;
                                    }

                                case ".я пент действие 3":
                                    {
                                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🫢😊 * у тебя все получилось и на тебя не подали в суд!", replyToMessageId: update.Message?.MessageId);
                                        break;
                                    }

                                default:
                                    {
                                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Извините, но такой команды не существует. Попробуйте запустить команду позже, верно вписав команду.", replyToMessageId: update.Message?.MessageId);
                                        break;
                                    }

                            }
                        }
                        else if (RandomIndex == 2)
                        {


                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"{action} Что будем делать?\n\n\n   ВАРИАНТЫ ОТВЕТА:\n1. ничего не делать\n2. попытаться выйти\n3. уе их\n\n\nПример: .я лгбт действие 1", replyToMessageId: update.Message?.MessageId);

                            switch (update.Message?.Text)
                            {
                                case ".я лгбт действие 1":
                                    {
                                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🫢😊 * самое правильное решение! ведь от ориентации невозможно отказаться...", replyToMessageId: update.Message?.MessageId);
                                        break;
                                    }

                                case ".я лгбт действие 2":
                                    {
                                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🫢😢 * мой дорогой, от этого невозможно избавиться...", replyToMessageId: update.Message?.MessageId);
                                        break;
                                    }

                                case ".я лгбт действие 3":
                                    {
                                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🫢😭 * все веллвеллвеллщики гордятся тобой, но это точно не правильное решение...", replyToMessageId: update.Message?.MessageId);
                                        break;
                                    }
                                default:
                                    {
                                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Извините, но такой команды не существует. Попробуйте запустить команду позже, верно вписав команду.", replyToMessageId: update.Message?.MessageId);
                                        break;
                                    }
                            }
                        }
                        else if (RandomIndex == 3)
                        {
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"{action} Что будем делать?\n\n\n    ВАРИАНТЫ ОТВЕТА:\n1.ничего не делать\n2.написать жалобу\n3.уе их\n\nПример: .я ркн действие 1 ", replyToMessageId: update.Message?.MessageId);

                            switch (update.Message?.Text)
                            {
                                case ".я ркн действие 1":
                                    {
                                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🫢😭 * ты ничего не сделал и начал гнить без интернета...", replyToMessageId: update.Message?.MessageId);
                                        break;
                                    }

                                case ".я ркн действие 2":
                                    {
                                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🫢😭 * ты подал жалобу, но РКН никак не отреагировал. ты начал гнить без интернета...", replyToMessageId: update.Message?.MessageId);
                                        break;
                                    }

                                case ".я ркн действие 3":
                                    {
                                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🫢😊 * правильное решение! теперь вся молодежь россии гордится тобой!", replyToMessageId: update.Message?.MessageId);
                                        break;
                                    }

                                default:
                                    {
                                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Извините, но такой команды не существует. Попробуйте запустить команду позже, верно вписав команду.", replyToMessageId: update.Message?.MessageId);
                                        break;
                                    }
                            }

                        }

                        break;

                    }
                case ".орелирешка":
                    {
                        Random rand = new Random();
                        string[] orelreh = { "орёл", "решка" };
                        int ind = new Random().Next(orelreh.Length);
                        string action = orelreh[ind];

                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Сейчас...", replyToMessageId: update.Message?.MessageId);
                        Thread.Sleep(1500);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"вам выпал/а: {action}!", replyToMessageId: update.Message?.MessageId);
                        break;
                    }

                case ".лабубу фарма":
                    {

                        if (userCoolDowns.TryGetValue(update.Message.From.Id, out var cooldownData))
                        {
                            var timeSince = DateTime.UtcNow - cooldownData.TimeUsed;
                            if (timeSince < CoolDownTime)
                            {
                                var remaining = CoolDownTime - timeSince;
                                string waitmess = $"⌚⌛ * Подожди! Повторно команду лабубу ты сможешь использовать через {remaining.Minutes:D2}:{remaining.Seconds:D2}❗❗";
                                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, waitmess, replyToMessageId: update.Message?.MessageId);
                                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"❗✨ * Напоминаю, @{update.Message.From.Username} (ты) получил/а {cooldownData.labuba}/yю лабубу!", replyToMessageId: update.Message?.MessageId);
                                return;
                            }
                        }


                        Random rand = new Random();
                        Random chance = new Random();

                        string[] labubu = { "черная", "розовая", "синяя", "голубая", "серая", "пальная", "желтая" };
                        int index = new Random().Next(labubu.Length);
                        string act = labubu[index];

                        userCoolDowns[update.Message.From.Id] = (DateTime.UtcNow, act);


                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"😊🧸 * вам выпала {act} лабубу!", replyToMessageId: update.Message?.MessageId);

                        int ind = new Random().Next(1, 101);
                        if (ind <= 15)
                        {
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"😁✨ * бонус: тебе выпала еще и редкая лабубу!", replyToMessageId: update.Message?.MessageId);
                            string bonus = "редкая лабубу";

                            if (!userBonusHistory.TryGetValue(update.Message.From.Id, out var olddArray) || olddArray == null)
                            {
                                olddArray = Array.Empty<string>();
                            }

                            var newwArray = new string[olddArray.Length + 1];
                            olddArray.CopyTo(newwArray, 0);
                            newwArray[^1] = bonus;
                            userBonusHistory[update.Message.From.Id] = newwArray;
                        }
                        else if (ind <= 45)
                        {
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🫢🔏 * бонус: тебе положили пластиковую защиту для лабубу!", replyToMessageId: update.Message?.MessageId);
                            string bonus = "пластиковая защита";

                            if (!userBonusHistory.TryGetValue(update.Message.From.Id, out var olddArray) || olddArray == null)
                            {
                                olddArray = Array.Empty<string>();
                            }

                            var newwArray = new string[olddArray.Length + 1];
                            olddArray.CopyTo(newwArray, 0);
                            newwArray[^1] = bonus;
                            userBonusHistory[update.Message.From.Id] = newwArray;
                        }
                        else if (ind <= 62)
                        {
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🫢🔏 * бонус: тебе положили разную одежду для лабубу!", replyToMessageId: update.Message?.MessageId);
                            string bonus = "разная одежда";

                            if (!userBonusHistory.TryGetValue(update.Message.From.Id, out var olddArray) || olddArray == null)
                            {
                                olddArray = Array.Empty<string>();
                            }

                            var newwArray = new string[olddArray.Length + 1];
                            olddArray.CopyTo(newwArray, 0);
                            newwArray[^1] = bonus;
                            userBonusHistory[update.Message.From.Id] = newwArray;
                        }
                        else
                        {
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"😭😢 * бонус: нету", replyToMessageId: update.Message?.MessageId);
                        }

                        if (!userPhraseHistory.TryGetValue(update.Message.From.Id, out var oldArray) || oldArray == null)
                        {
                            oldArray = Array.Empty<string>();
                        }



                        var newArray = new string[oldArray.Length + 1];
                        oldArray.CopyTo(newArray, 0);
                        newArray[^1] = act;
                        userPhraseHistory[update.Message.From.Id] = newArray;



                        break;
                    }
                case ".лабубу я":
                    {
                        if (userPhraseHistory.TryGetValue(update.Message.From.Id, out var catets) && catets.Length > 0)
                        {
                            string response = $"📋🍃 * @{update.Message.From.Username} уже получил/a такие лабубу:\n 💠 " + string.Join("\n 💠 ", catets.Distinct());
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, response, replyToMessageId: update.Message?.MessageId);
                        }
                        else
                        {
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🕵🏿😑 * @{update.Message.From.Username} не получал/a ни одной лабубу!", replyToMessageId: update.Message?.MessageId);
                        }
                        break;
                    }
                case ".лабубу я бонус":
                    {
                        if (userBonusHistory.TryGetValue(update.Message.From.Id, out var catets) && catets.Length > 0)
                        {
                            string response = $"📋🍃 * @{update.Message.From.Username} уже получил/a такие бонусы к лабубу:\n 💠 " + string.Join("\n 💠 ", catets.Distinct());
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, response, replyToMessageId: update.Message?.MessageId);
                        }
                        else
                        {
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🕵🏿😑 * @{update.Message.From.Username} еще не получал/a бонусов к лабубу!", replyToMessageId: update.Message?.MessageId);
                        }


                        break;
                    }

                case ".лабубу команды":
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"📋❗ * Все команды плагина .лабубу:\n 💠 .лабубу фарма - получить лабубу с бонусом\n 💠 .лабубу я - просмотреть все свои полученные лабубу\n 💠 .лабубу я бонус - просмотреть все свои полученные бонусы\n ❗💠 .лабубу команды - просмотреть все команды для плагина .лабубу\n 💠 .лабубу подарить (id лабубу) @юзер - подарить свою лабубу кому-нибудь!\n 💠 .лабубу удалить все - удалить все свои лабубу из '.лабубу я'\n 💠 .лабубу удалить все бонусы - удалить все бонусы из '.лабубу я бонус' ", replyToMessageId: update.Message?.MessageId);
                        break;
                    }
                case ".лабубу удалить все":
                    {
                        if (userPhraseHistory.ContainsKey(update.Message.From.Id))
                        {
                            userPhraseHistory.TryRemove(update.Message.From.Id, out _);
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🗑️🙄 * @{update.Message.From.Username} удалил/а все свои лабубу!", replyToMessageId: update.Message?.MessageId);
                        }
                        else
                        {
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"😁😑 * @{update.Message.From.Username}, у тебя я не наблюдаю лабубу!", replyToMessageId: update.Message?.MessageId);
                        }
                        break;
                    }
                case ".лабубу удалить все бонусы":
                    {
                        if (userBonusHistory.ContainsKey(update.Message.From.Id))
                        {
                            userBonusHistory.TryRemove(update.Message.From.Id, out _);
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🗑️🙄 * @{update.Message.From.Username} удалил/а все свои лабубу!", replyToMessageId: update.Message?.MessageId);
                        }
                        else
                        {
                            await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"😁😑 * @{update.Message.From.Username}, у тебя я не наблюдаю лабубу!", replyToMessageId: update.Message?.MessageId);
                        }
                        break;
                    }

            }



            if (update.Message?.Text == "/help" || update.Message?.Text == "/help@AllergyBotBot")
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "/start - начните диалог с ботом!\n/help - попросить возможные команды у бота\n/secret - это секрет!\n/obnova - какое обновление стоит у данного бота на данный момент\nКрокодилдо пенисини - специально для райки выведет полную версию\nI love u - пока не попробуете отправить = не узнаете!\n/райка - команда исключительно для райки\n/кикко - команда только для кикко\n/лемо - команада исключительно для лемо\n/dem - секретная команда для киллсоульников\n/ks - исключительно для асников\n/esse - ну напиши письмо там, нравится бот или нет, что добавить или убрать...\n/suka - эм... ну нажмите???\n/parappa - локальный мем, только для подписчиков кикко\n/nepridumal - я пока не придумал, но вы все равно введите\nтунг тунг сахур - бот вам споет песню пон\n.minet - команда для запуска фрэймворка .minet\n.anal - команда для запуска фрэймворка .anal\n/analnui terrorist - секрет команда ок\n/minet2 - стих, сочиненный паймоной\n/pikmi - эм....\n/slova - поиграйте с ботом в слова!\n/chickenjockey - полная версия легендарной фразы из фильма Майнкрафт, а именно чикен жокей.\n/shar - погадаем на шаре;)\n/policeparappa - даже параппа сдал на права, а ты нет... иди сдавай, нажав на команду!\n.орелирешка - бот вам выдаст орла или решку рандомно!\n\n.факт - выдаст рандомный факт\n.вер (что-нибудь) - проверить вероятность события\n.вики (что-то) - найти ваш запрос в википедии!\n.погода (город) - предоставит вам погоду в вашем городе!\n\n                СПЕЦИАЛЬНЫЕ КОМАНДЫ\n\nSpasibo или spasibo - исключительно для райки команда\nты как тралалело тралала - полная версия песни\nПапиросик или папиросик или Papirosik или papirosik - команда, которая воспроизводит полную версию песни 'ананасик'\n.правасдать - у тебя остался шанс на сдачу прав, кто-то тебе поможет...\n/img(...) - бот пришлет тебе картинку: цветок, webp или озеро. (впишите в скобки, как в примере: img(webp) )\n/gpt - ДОЛГОЖДАННАЯ КОММАНДА! Обратитесь к OpenAI за вопросом! --Chat GPT 3.5-4.0 (не работает)\n\nКОМАНДЫ С ПРЕФИКСАМИ ВЫ НАЙДЕТЕ ПО КОММАНДЕ /helprefix\n.рандом - выдает рандомное сообщение!\n\n.лабубу команды - просмотреть все команды для плагина '.лабубу'\n\n.айо инфа - узнать все команды для валюты io.");


            if (update.Message?.Text == "/start" || update.Message?.Text == "/start@AllergyBotBot")
            {
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "привет.. наверное тебя зовут... не вспомню..");
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "но всё равно, привет мой друг!");
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "воспользуйся командой /help либо /help@AllergyBotBot, чтобы узнать все доступные команды!", replyToMessageId: update.Message?.MessageId);
            }

            if (update.Message?.Text == "/obnova" || update.Message?.Text == "/obnova@AllergyBotBot")
            {
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "текущее обновление: 3.8 omega");
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "Telegram.Bot - 19.0.0 ver.", replyToMessageId: update.Message?.MessageId);
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "net 6.0\nnet framework - 4.8 ver.\n  lang of programming - c#", replyToMessageId: update.Message?.MessageId);
            }
            else if (update.Message?.Text == "/tochat" || update.Message?.Text == "/tochat")
            {
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "❓✨ * Добавить меня в чат можно, нажав на кнопку!", replyMarkup: inlineKeyboard);
            }
            else if (update.Message?.Text == "Бот" || update.Message?.Text == "бот")
            {
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "✅✔️ * На месте!");
            }
            else if (update.Message?.Text == ".айо фарма" || update.Message?.Text == ".Айо фарма" || update.Message?.Text == ". Айо фарма" || update.Message?.Text == ". айо фарма")
            {

                if (userIOcool.TryGetValue(update.Message.From.Id, out var data))
                {
                    TimeSpan timeSince = DateTime.UtcNow - data.TimeUse;
                    if (timeSince < CoolDownIo)
                    {
                        var remaining = CoolDownIo - timeSince;
                        string waitmess = $"⌚⌛ * НЕЗАЧЁТ! Подожди {remaining.Hours:D2}:{remaining.Minutes:D2}:{remaining.Seconds:D2}❗❗";
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, waitmess, replyToMessageId: update.Message?.MessageId);
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"❗✨ * Напоминаю, @{update.Message.From.Username} (ты) получил/а {data.lata} io!", replyToMessageId: update.Message?.MessageId);
                        return;
                    }
                }
                Random random = new Random();
                int io = random.Next(1, 111);

                userIOcool[update.Message.From.Id] = (DateTime.UtcNow, io);

                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"✅✔️ * ЗАЧЁТ! Ты нафармил {io} io!");

                if (!userTotals.ContainsKey(update.Message.From.Id))
                    userTotals[update.Message.From.Id] = 0;

                userTotals[update.Message.From.Id] += io;
            }
            else if (update.Message?.Text == ".айо я" || update.Message?.Text == ".Айо я" || update.Message?.Text == ". Айо я" || update.Message?.Text == ". айо я")
            {

                if (userTotals.TryGetValue(update.Message.From.Id, out var total))
                {
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"💯📑 * Ты нафармил всего {total} io!");
                }
                else
                {
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "💯📑🤔 * Ты еще не фармил io либо их всех потратил..");
                }
            }
            else if (update.Message?.Text == ".айо список" || update.Message?.Text == ".Айо список" || update.Message?.Text == ". Айо список" || update.Message?.Text == ". айо список")
            {
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"📑➕ * @{update.Message.From.Username}, вот список продуктов, куда можно потратить io\n💠огурцы - вкусные и свежие огурцы. 45 io\n💠телевизор - прекрасный телевизор. 345 io\n💠компьютер - ПК, который собирал профессионал. 329 io\n\nПример: .айо купить ПК");
            }
            else if (update.Message?.Text == ".айо купить огурцы" || update.Message?.Text == ".Айо купить огурцы" || update.Message?.Text == ". Айо купить огурцы" || update.Message?.Text == ". айо купить огурцы")
            {
                if (userTotals.TryGetValue(update.Message.From.Id, out float total))
                {
                    if (userTotals[update.Message.From.Id] >= 45)
                    {
                        int number = 45;
                        userTotals[update.Message.From.Id] -= number;
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"🥒😁 * ты поел огурцы и твой голод убрался.\nУ тебя осталось: {userTotals[update.Message.From.Id]} io!");
                    }
                    else
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"😭🫢 * У тебя не хватает io на покупку!\nКоличество io у тебя: {userTotals[update.Message.From.Id]}");
                    }
                }

            }
            else if (update.Message?.Text == ".айо купить телевизор" || update.Message?.Text == ".Айо купить телевизор" || update.Message?.Text == ". Айо купить телевизор" || update.Message?.Text == ". айо купить телевизор")
            {
                if (userTotals.TryGetValue(update.Message.From.Id, out float total))
                {
                    if (userTotals[update.Message.From.Id] >= 345)
                    {
                        int number = 345;
                        userTotals[update.Message.From.Id] -= number;
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"📺😁 * ты купил телевизор в МВидео!\nУ тебя осталось: {userTotals[update.Message.From.Id]} io!");
                    }
                    else
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"😭🫢 * У тебя не хватает io на покупку!\nКоличество io у тебя: {userTotals[update.Message.From.Id]}");
                    }
                }


            }
            else if (update.Message?.Text == ".айо купить ПК" || update.Message?.Text == ".Айо купить ПК" || update.Message?.Text == ". Айо купить ПК" || update.Message?.Text == ". айо купить ПК")
            {
                if (userTotals.TryGetValue(update.Message.From.Id, out float total))
                {
                    if (userTotals[update.Message.From.Id] >= 329)
                    {
                        int number = 329;
                        userTotals[update.Message.From.Id] -= number;
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"📺😁 * ты купил телевизор в МВидео!\nУ тебя осталось: {userTotals[update.Message.From.Id]} io!");
                    }
                    else
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"😭🫢 * У тебя не хватает io на покупку!\nКоличество io у тебя: {userTotals[update.Message.From.Id]}");
                    }
                }

            }
            else if (update.Message?.Text == ".айо инфа" || update.Message?.Text == ".Айо инфа" || update.Message?.Text == ". Айо инфа" || update.Message?.Text == ". айо инфа")
            {
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"💯📑 * Комманды для фарма айо:\n 💠 .айо фарма - рандомное кол-во io от 1 до 110.\n 💠 .айо я - узнать кол-во io у себя на данный момент\n 💠 .айо список - узнать список продуктов, которые покупаются с помощью io\n 💠 .айо купить (ПК) - купить любой продукт из списка\n 💯💠 .айо инфа - узнать все комманды для фарма валюты io.\n 💠 .айо бонус - получить бонус на все свои доходы!");
            }
            else if (update.Message?.Text == ".айо бонус" || update.Message?.Text == ".Айо бонус" || update.Message?.Text == ". Айо бонус" || update.Message?.Text == ". айо бонус")
            {
                if (userINFOcool.TryGetValue(update.Message.From.Id, out var data))
                {
                    TimeSpan timeSince = DateTime.UtcNow - data.TimeUses;
                    if (timeSince < CoolDownIo)
                    {
                        var remaining = CoolDownInfo - timeSince;
                        string waitmess = $"⌚⌛ * Ты уже получил бонус! До следующего применения осталось: {remaining.Days:D2}:{remaining.Hours:D2}:{remaining.Minutes:D2}:{remaining.Seconds:D2}❗❗";
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, waitmess, replyToMessageId: update.Message?.MessageId);

                        return;
                    }
                }

                Random random = new Random();
                float rand = random.Next(1, 3);

                userINFOcool[update.Message.From.Id] = (DateTime.UtcNow, rand);

                userTotals[update.Message.From.Id] = userTotals[update.Message.From.Id] * rand;
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Твои доходы io умножились на {rand}! Кол-во io у @{update.Message?.From.Username}: {userTotals[update.Message.From.Id]!}", replyToMessageId: update.Message?.MessageId);
            }
            else if (update.Message?.Text == ".факт" || update.Message?.Text == ". факт" || update.Message?.Text == ".Факт" || update.Message?.Text == ". Факт")
            {
                string[] facts = { "Мозг чувствует боль хуже всего — но сам мозг не чувствует боли! Хирурги могут оперировать мозг пациента, пока он в сознании.", "Ось Земли колеблется — полюса 'дрейфуют' со временем, и на это может влиять даже таяние ледников!", "Вода бывает 'горячим льдом' — существует фаза воды, называемая 'лед-VII', которая может образоваться при экстремальном давлении и температуре.", "Осьминоги имеют три сердца и синюю кровь, потому что у них в крови — медь, а не железо.", "Космос воняет — астронавты говорят, что после выхода в открытый космос скафандры пахнут… прожаренным мясом и сварочным дымом!", "Ты — живой космос — 93% массы человеческого тела состоит из тех же элементов, что и звёзды (углерод, водород, кислород, азот).", "Ты каждый день немного другой — клетки в твоём теле обновляются постоянно. Например, клетки кожи полностью меняются примерно за месяц.", "Пальцы морщатся в воде не просто так — это эволюционный механизм для лучшего сцепления с мокрыми поверхностями. Как шины!", "У улитки может быть более 14 000 зубов — и они находятся на её 'языке'!", "Нарвалы — это не выдумка — у них реально есть длинный 'рог', который на самом деле — это их зуб!", "Пингвины делают 'предложения' камушками — самец дарит камень самке, если она принимает — они становятся парой.", "Клеопатра ближе к iPhone, чем к строительству пирамид — она жила за 1300 лет до нашей эры, а пирамиды — за 2500 лет!", "Шахматы были когда-то модным спортом аристократов, а теперь доступны каждому. Некоторые ходы, как «рокировка», появились спустя века после изобретения игры.", "Пчёлы могут распознавать лица — они запоминают образы как мы: по глазам, носу и рту!", "На Уране и Нептуне могут идти алмазные дожди 💎🌧️ — под огромным давлением метан расщепляется и углерод превращается в кристаллы!" };
                Random rand = new Random();
                Random chance = new Random();

                int index = new Random().Next(facts.Length);
                string act = facts[index];

                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"{act}", replyToMessageId: update.Message?.MessageId);
            }
            else if (update.Message.Text.StartsWith(".вер") || update.Message.Text.StartsWith(". вер") || update.Message.Text.StartsWith(".Вер") || update.Message.Text.StartsWith(". Вер"))
            {
                Random rand = new Random();
                var ver = rand.Next(1, 101);

                if (ver >= 1 && ver <= 15)
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Вероятность этого события: {ver} (нет)!", replyToMessageId: update.Message?.MessageId);
                else if (ver >= 15 && ver <= 30)
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Вероятность этого события: {ver} (скорее всего нет)!", replyToMessageId: update.Message?.MessageId);
                else if (ver >= 30 && ver <= 50)
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Вероятность этого события: {ver} (не точно)!", replyToMessageId: update.Message?.MessageId);
                else if (ver >= 50 && ver <= 80)
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Вероятность этого события: {ver} (наверно)!", replyToMessageId: update.Message?.MessageId);
                else if (ver >= 80 && ver <= 90)
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Вероятность этого события: {ver} (скорее всего да)!", replyToMessageId: update.Message?.MessageId);
                else if (ver >= 90 && ver <= 100)
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Вероятность этого события: {ver} (точно да)!", replyToMessageId: update.Message?.MessageId);
                else
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "Вероятность не найдена. Попробуйте еще раз!", replyToMessageId: update.Message?.MessageId);

            }
            else if (update.Message.Text.StartsWith(".вики") || update.Message.Text.StartsWith(". вики") || update.Message.Text.StartsWith(".Вики") || update.Message.Text.StartsWith(". Вики"))
            {
                string запрос = update.Message.Text.Substring(5).Trim();

                if (string.IsNullOrEmpty(запрос))
                {
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"Напиши запрос по примеру: .вики Telegram !", replyToMessageId: update.Message?.MessageId);
                    return;
                }

                string url = $"https://ru.wikipedia.org/api/rest_v1/page/summary/{Uri.EscapeDataString(запрос)}";

                using HttpClient client1 = new HttpClient();
                try
                {
                    var response = await client1.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();

                        using JsonDocument doc = JsonDocument.Parse(json);
                        var root = doc.RootElement;

                        string title = root.GetProperty("title").GetString();
                        string extract = root.GetProperty("extract").GetString();
                        string link = root.GetProperty("content_urls").GetProperty("desktop").GetProperty("page").GetString();

                        await client.SendTextMessageAsync(
                            update.Message?.Chat.Id ?? 7062178966,
                            $"📖 *{title}*\n\n{extract}\n\n[Источник]({link})",
                            parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown
                        );
                    }
                    else
                    {
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "Не нашёл такую статью 🤷");
                    }
                }
                catch
                {
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "Произошла ошибка при обращении к Википедии 😢");
                }
            }
            else if (update.Message.Text.StartsWith(".погода") || update.Message.Text.StartsWith(". погода") || update.Message.Text.StartsWith(".Погода") || update.Message.Text.StartsWith(". Погода"))
            {
                var msg = update.Message;
                string sity = msg.Text.Substring(7).Trim();

                var chatid = update.Message?.Chat.Id ?? 7062178966;

                if (string.IsNullOrEmpty(sity))
                {

                    await client.SendTextMessageAsync(chatid, "Введи свой город, как на примере: .погода Волгоград");
                }

                string apiKey = "a8a9bacef1ed40fbb5b201021250706";
                string url = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={Uri.EscapeDataString(sity)}&lang=ru";

                using var client12 = new HttpClient();
                HttpResponseMessage response;
                try
                {
                    response = await client12.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                    {
                        await client.SendTextMessageAsync(chatid, "Не удалось узнать погоду. Проверь название города!");
                        return;
                    }
                }
                catch
                {
                    await client.SendTextMessageAsync(chatid, "Ошибка при подключении к WeatherApi.");
                    return;
                }

                string json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                string SityName = root.GetProperty("location").GetProperty("name").GetString();
                string country = root.GetProperty("location").GetProperty("country").GetString();

                var current = root.GetProperty("current");
                double temp = current.GetProperty("temp_c").GetDouble();
                double feels = current.GetProperty("feelslike_c").GetDouble();
                double wind = current.GetProperty("wind_kph").GetDouble();
                string condition = current.GetProperty("condition").GetProperty("text").GetString();

                string result = $"🌍 * Погода в {SityName}, {country}:\n" +
                    $"🌡 * Температура: {temp:+0;-0}°C\n" +
                    $"🤔 * Ощущается как: {feels:+0;-0}°C\n" +
                    $"💨 * Ветер: {wind} км/ч\n" +
                    $"🌤 * Условие: {condition}\n\n";

                await client.SendTextMessageAsync(chatid, result);
                
                
            }
                else if (update.Message?.Photo != null)
                {
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "📸😁 * О, фотка! Она такая крутая!", replyToMessageId: update.Message?.MessageId);
                }
                else if (update.Message?.Animation != null)
                {
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "📸😁 * Гифка? Ну я думаю, что она крутая!", replyToMessageId: update.Message?.MessageId);
                }
                else if (update.Message?.Audio != null)
                {
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "🎙️😁 * О, прикольный музон)", replyToMessageId: update.Message?.MessageId);
                }
                else if (update.Message?.Document != null)
                {
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "🤔📃 * Ты прислал документ? Хм, все так серьезно...", replyToMessageId: update.Message?.MessageId);
                }
                else if (update.Message?.Sticker != null)
                {
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "📑😁 * Прикольный стикер!", replyToMessageId: update.Message?.MessageId);
                }
                else if (update.Message?.Voice != null)
                {
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "🎤🥱 * у тебя такой спокойный голос...", replyToMessageId: update.Message?.MessageId);
                }





            if (update.Message.Text.StartsWith("/img("))
            {
                var query = update.Message.Text.Split('(')[1].Split(')')[0];

                if (query == "Webp" || query == "webp")
                {
                    using (var stream = File.OpenRead(ImagesPath + images[0]))
                    {
                        InputFileStream inputfile = new InputFileStream(stream);
                        await client.SendPhotoAsync(update.Message?.Chat.Id ?? 7062178966, inputfile, replyToMessageId: update.Message?.MessageId);
                    }
                }
                else if (query == "озеро" || query == "Озеро")
                {
                    using (var stream = File.OpenRead(ImagesPath + images[2]))
                    {
                        InputFileStream inputfile = new InputFileStream(stream);
                        await client.SendPhotoAsync(update.Message?.Chat.Id ?? 7062178966, inputfile, replyToMessageId: update.Message?.MessageId);
                    }
                }
                else if (query == "цветок" || query == "Цветок")
                {
                    using (var stream = File.OpenRead(ImagesPath + images[1]))
                    {
                        InputFileStream inputfile = new InputFileStream(stream);
                        await client.SendPhotoAsync(update.Message?.Chat.Id ?? 7062178966, inputfile, replyToMessageId: update.Message?.MessageId);
                    }
                }
                else
                {
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, $"такой картинки в базе данных я не нашел. возможно, она скоро появится!", replyToMessageId: update.Message?.MessageId);
                }

            }

            var text = update.Message.Text;
            var botClient = client;
            var chatId = update.Message.Chat.Id;
            var userId = update.Message.From.Id;
            var fromUser = update.Message.From;

            if (update.Message.Text.StartsWith(".лабубу подарить", StringComparison.OrdinalIgnoreCase))
            {
                var parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 4 || !int.TryParse(parts[2], out int giftIndex) || giftIndex < 1 || !parts[3].StartsWith("@"))
                {
                    await botClient.SendTextMessageAsync(chatId, "❗😁 * пример: .лабубу подарить 2 @username");
                    return;
                }

                if (!userPhraseHistory.TryGetValue(userId, out var senderPhrases) || giftIndex > senderPhrases.Length)
                {
                    await botClient.SendTextMessageAsync(chatId, "❌🫢 * у тебя нет такой лабубу.");
                    return;
                }

                string phrase = senderPhrases[giftIndex - 1];
                string fromMention = !string.IsNullOrEmpty(fromUser.Username) ? $"@{fromUser.Username}" : fromUser.FirstName;
                string toUsername = parts[3];

                if (!usernameToId.TryGetValue(toUsername.TrimStart('@'), out long targetId))
                {
                    await botClient.SendTextMessageAsync(chatId, "❓😑 * Я не могу найти пользователя. Убедись, что он взаимодействовал со мной!");
                    return;
                }

                var updated = (userPhraseHistory.TryGetValue(targetId, out var targetPhrases) ? targetPhrases : Array.Empty<string>())
                    .Append($"{phrase} (подарок от {fromMention})").ToArray();
                userPhraseHistory[targetId] = updated;

                await botClient.SendTextMessageAsync(chatId, $"🎁😁 * лабубу подарена {toUsername}!");
            }


            if (update.Message?.Text == ".рандом")
            {
                string[] frazs = { "я мужик!!!", "ноуп", "ты че, быканула?", "б", "без б", "иди агород купай, а не фигней тут занимася!", "ты как тралалело тралалал", "ИЗВИНИ МАКАН ПЖ", "Машера лучший рэпер ну сами посудите", "жлппппппаапааааа", "мне лень", "да", "нет", "сейчасссссс", "фублин", "иу ит ис со кринж ыхыхых", "достала уже", "пидиди", "кринжатина лютая", "НУ ВОТ ЭТО СИГМА БРАТОК ПРОСТО☠️☠️☠️☠️УРЫЛ ЭТУ ВУМЕН☠️☠️☠️☠️☠️(ЧЕРЕПОК ЧЕРЕПОК)☠️☠️☠️☠️ВКЛЮЧАЙТЕ СИГМА ФОНК☠️☠️☠️", "моя хорошая ты не офигела", "бляяять", "иди домашку делать" };
                int RandomIndex = new Random().Next(frazs.Length);
                string response = frazs[RandomIndex];
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, response);
            }

            if (update.Message?.Text == "блять" || update.Message?.Text == "Блять" || update.Message?.Text == "сука" || update.Message?.Text == "Сука" || update.Message?.Text == "ебать" || update.Message?.Text == "Ебать" || update.Message?.Text == "Иди нахуй" || update.Message?.Text == "иди нахуй" || update.Message?.Text == "иди газуй" || update.Message?.Text == "Иди газуй" || update.Message?.Text == "Хуй" || update.Message?.Text == "хуй")
            {
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "извени браточик но только ЙА магу йузать маты\nСОРИ BABY😭😭🧑🏿‍🦱🧑🏿‍🦱😘😘😂😂", replyToMessageId: update.Message?.MessageId);
            }
            else if (update.Message?.Text == "Spasibo" || update.Message?.Text == "spasibo")
            {
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "СПОСИБО СПОСИБО ", replyToMessageId: update.Message?.MessageId);
                Thread.Sleep(4000);
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "SUKA ESHE RAZ SPASIBO", replyToMessageId: update.Message?.MessageId);
            }
            else if (update.Message?.Text == "папиросик" || update.Message?.Text == "Папиросик" || update.Message?.Text == "papirosik" || update.Message?.Text == "Papirosik")
            {
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "papirosik papirosik", replyToMessageId: update.Message?.MessageId);
                Thread.Sleep(700);
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "pipka pachnie yak Bigosik!", replyToMessageId: update.Message?.MessageId);
                Thread.Sleep(700);
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "Ananasik, ananasik", replyToMessageId: update.Message?.MessageId);
                Thread.Sleep(500);
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "Ana", replyToMessageId: update.Message?.MessageId);
                Thread.Sleep(350);
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "Ana", replyToMessageId: update.Message?.MessageId);
                Thread.Sleep(350);
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "Ananasik!", replyToMessageId: update.Message?.MessageId);
            }

            /*if (update.Message?.Text != null)
           {
               string chatId = update.Message?.Chat.Id.ToString();

               if (update.Message?.Text.ToLower() == "/gpt")
               {
                   while (true)
                   {
                       var response = await client.SendTextMessageAsync(chatId, "Введите ваш запрос или напишите 'стоп' для завершения");
                       string userInput = response.Text; // Здесь мы используем Message.Text

                       if (userInput.ToLower() == "стоп")
                       {
                           await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 7062178966, "Окей, вы можете обратиться к чату GPT позже!", replyToMessageId: update.Message?.MessageId);
                           break;
                       }

                       string responseFromGPT = await SendToGPT(userInput);
                       await client.SendTextMessageAsync(chatId, responseFromGPT);
                   }
               }
           }
       }

       static async Task<string> SendToGPT(string input)
       {
           // Здесь должна быть ваша реализация вызова ChatGPT
           // Пример с OpenAI (используйте свой API ключ)
           string apiKey = "sk-5678mnopqrstuvwx5678mnopqrstuvwx5678mnop";
           string baseUrl = "https://api.openai.com/v1/responses";

           using (var httpClient = new HttpClient())
           {
               httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

               // Создаем контент для запроса
               string jsonContent = $"{{\"message\":\"{input}\"}}";
               var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

               // Отправляем запрос
               HttpResponseMessage response = await httpClient.PostAsync(baseUrl, content);

               // Проверяем статус ответа
               if (response.StatusCode == System.Net.HttpStatusCode.OK)
               {
                   string responseContent = await response.Content.ReadAsStringAsync();
                   return responseContent;
               }
               else
               {
                   throw new Exception($"Ошибка HTTP: {response.StatusCode}");
               }
           }
       } */
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("⌛⌚ * Ошибка: Запрос занял слишком много времени!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⛔  * Ошибка: {ex.Message}");
        }


    }

}
