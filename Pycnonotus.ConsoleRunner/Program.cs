// See https://aka.ms/new-console-template for more information

using Discord;
using Discord.WebSocket;
using Pycnonotus.DiscordBot;

Console.WriteLine("Hello, World!");

var client = new DiscordSocketClient();

client = new DiscordSocketClient();

ulong userId = 1;
const string token = "";

var discorConfig = new DiscordBotConfig(userId,token);

var discordBot = new DiscordBot(discorConfig);

await Task.Delay(-1);



