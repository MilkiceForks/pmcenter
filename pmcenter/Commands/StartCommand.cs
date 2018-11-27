﻿using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace pmcenter.Commands
{
    internal class StartCommand : ICommand
    {
        public bool OwnerOnly => false;

        public string Prefix => "start";

        public async Task<bool> ExecuteAsync(TelegramBotClient botClient, Update update)
        {
            if (update.Message.From.Id == Vars.CurrentConf.OwnerUID)
            {
                await botClient.SendTextMessageAsync(
                    update.Message.From.Id,
                    Vars.CurrentLang.Message_OwnerStart,
                    ParseMode.Markdown,
                    false,
                    Vars.CurrentConf.DisableNotifications,
                    update.Message.MessageId);
            }
            else
            {
                await botClient.SendTextMessageAsync(
                    update.Message.From.Id,
                    Vars.CurrentLang.Message_UserStartDefault,
                    ParseMode.Markdown,
                    false,
                    false,
                    update.Message.MessageId);
            }
            return true;
        }
    }
}