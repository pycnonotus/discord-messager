namespace Pycnonotus.DiscordBot;

public  class  DiscordBotConfig : IDiscordBotConfig
{
	public DiscordBotConfig()
	{
		
	}
	public DiscordBotConfig(ulong notificationUserId,string discordToken)
	{
		Token = discordToken;
		NotificationUserId = notificationUserId;
	}

	public string Token { get; set; }
	public ulong NotificationUserId { get; set; }
}
