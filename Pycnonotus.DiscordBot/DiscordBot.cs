using Discord;
using Discord.Rest;
using Discord.WebSocket;
using Pycnonotus.Application;

namespace Pycnonotus.DiscordBot;

public class DiscordBot : IDiscordBot
{
	private readonly IDiscordBotConfig _discordBotConfig;
	private readonly DiscordSocketClient _client;
	private readonly Lazy<Task<RestUser>> _lazyUser;

	public DiscordBot(IDiscordBotConfig discordBotConfig)
	{
		_discordBotConfig = discordBotConfig;
		_client = new DiscordSocketClient();
		_client.Log += LogAsync;
		_client.MessageReceived += OnMessageReceivedAsync;
		_client.Connected += ClientConnectedAsync;

		_lazyUser = new Lazy<Task<RestUser>>(() => _client.Rest.GetUserAsync(_discordBotConfig.NotificationUserId));

		InitializeClientAsync(_discordBotConfig.Token).GetAwaiter().GetResult();
	}

	async private Task InitializeClientAsync(string token)
	{
		await _client.LoginAsync(TokenType.Bot, token);
		await _client.StartAsync();
	}

	private Task ClientConnectedAsync()
	{
		return NotifyAsync(new Message("Client connected"));
	}

	public async Task NotifyAsync(Message message)
	{
		while (true)
		{
			if (_client.ConnectionState == ConnectionState.Connected) break; // TODO: Change this horrible implementation of wait/retry, maybe to move this to the InitializeClientAsync
			await Task.Delay(100);
		}
		
		var user = await _lazyUser.Value;
		await user.SendMessageAsync(message.Text);
	}


	async private static Task OnMessageReceivedAsync(SocketMessage messageReceived)
	{
		if (messageReceived.Author.IsBot)
			return;

		await messageReceived.Author.SendMessageAsync("don't message me you fool!!!");
	}

	private static Task LogAsync(LogMessage message)
	{
		Console.WriteLine(message.ToString());
		return Task.CompletedTask;
	}
}
