using System;
using System.Windows.Forms;

namespace PoeHelper.GUI
{
	public partial class AlertForm : Form
	{
		private Timer timer;

		public AlertForm()
		{
			InitializeComponent();
			timer = new Timer {Interval = 5000};
			timer.Tick += (sender, args) => Close();
		}

		public void ShowMessage(string text)
		{
			label1.Text = text;
			Show();
			timer.Start();
		}
	}
}
