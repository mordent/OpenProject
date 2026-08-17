using System.Text;

namespace ThiRA.Base.Forms
{
    public partial class MessageModal : BaseForm
    {
        private StringBuilder message = new StringBuilder();
        public MessageModal()
        {
            InitializeComponent();
        }

        public string Title
        {
            get
            {
                return textBoxTitle.Text;
            }
            set
            {
                textBoxTitle.Text = value; ;
            }
        }

        public string Message
        {
            get
            {
                return message.ToString();
            }
            set
            {
                textBoxMessage.Text = message.Clear().Append(value).ToString();
            }
        }

        public string AppendMessage
        {
            get
            {
                return message.ToString();
            }
            set
            {
                textBoxMessage.Text = message.Append(value).ToString();
            }
        }
    }
}
