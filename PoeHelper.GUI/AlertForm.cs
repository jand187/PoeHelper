using System.Windows.Forms;

namespace PoeHelper.GUI
{
	public partial class AlertForm : Form
	{
		public AlertForm()
		{
			InitializeComponent();
		}

		public void ShowMessage(string text)
		{
			this.label1.Text = text;
			this.Show();
		}

		private void AlertForm_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
