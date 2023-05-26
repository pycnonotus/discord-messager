namespace Pycnonotus.DiscordBot;

public interface IDiscordBotConfig
{
	public string Token { get;  }
	public ulong NotificationUserId { get;  }
}