namespace Pycnonotus.Application;

public interface INotifier
{
	Task NotifyAsync(Message message);
}