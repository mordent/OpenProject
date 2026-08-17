using System.Text;

namespace ThiRA.Base.Infos
{
    public class MessageInfo
    {
        private MessageType messageType;
        private string message;
        private string stacktrace;

        public MessageInfo(string message)
        {
            this.messageType = MessageType.Info;
            this.message = message;
            this.stacktrace = string.Empty;
        }
        public MessageInfo(MessageType messageType, string message)
        {
            this.messageType = messageType;
            this.message = message;
            this.stacktrace = string.Empty;
        }

        public MessageInfo(string message, string stacktrace)
        {
            this.messageType = MessageType.Error;
            this.message = message;
            this.stacktrace = stacktrace;
        }
        public MessageInfo(MessageType messageType, string message, string stacktrace)
        {
            this.messageType = messageType;
            this.message = message;
            this.stacktrace = stacktrace;
        }

        public MessageInfo(Exception e)
        {
            this.messageType = MessageType.Error;
            this.message = e.Message;
            this.stacktrace = e.ToString();
        }

        public MessageType MessageType { get { return messageType; } }
        public string Message { get { return message; } }
        public string FullMessage { get {switch (messageType){ 
                    case MessageType.Info: return new StringBuilder().AppendLine(message).ToString();
                    default: return new StringBuilder().AppendLine(message).AppendLine(stacktrace).ToString();
        }}}
        public string Stacktrace { get { return stacktrace; } }
    }
}
