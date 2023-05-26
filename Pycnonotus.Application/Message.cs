namespace Pycnonotus.Application;

public class Message
{
	private string _text;

	public Message(string text)
	{
		Text = text;
	}

	public string Text
	{
		get => _text;
		private set
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentException("Value must not be null or white space");
            
			_text = value;
		}
	}

	public static implicit operator Message(string s) => new Message(s);
	public static implicit operator string(Message m) => m._text;
}
