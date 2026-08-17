using System.Windows.Forms;

namespace ThiRA.Base.Util
{
    public static class ControlUtility
    {
        public static void SetValue(ComboBox comboBox, string value)
        {
            for(int index = 0; comboBox.Items.Count > index; index++)
            {
                if (string.Equals(comboBox.Items[index].ToString(), value))
                {
                    comboBox.SelectedIndex = index;
                    break;
                }
            }
        }

        public static bool Confirm(Form form, string messageText, string selectText)
        {
            DialogResult dialogResult = MessageBox.Show(form, messageText, selectText, MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
    }
}
