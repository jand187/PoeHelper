using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using PoeHelper.GUI.Parsers;
using Timer = System.Windows.Forms.Timer;

namespace PoeHelper.GUI
{
	public partial class Form1 : Form
	{
		private const int WM_DRAWCLIPBOARD = 0x0308; // WM_DRAWCLIPBOARD message
		private readonly IntPtr _clipboardViewerNext;
		private readonly ItemParser itemParser;
		private string lastData;
		private AlertForm alert;

		public Form1()
		{
			InitializeComponent();
			itemParser = new ItemParser();
			_clipboardViewerNext = SetClipboardViewer(Handle);
		}

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);

			if (m.Msg == WM_DRAWCLIPBOARD)
			{
				var iData = Clipboard.GetDataObject();

				if (iData.GetDataPresent(DataFormats.Text))
				{
					var data = (string) iData.GetData(DataFormats.Text);
					if (data == lastData)
						return;

					lastData = data;
					logTextBox.Text = data;
					var text = itemParser.Parse(data);
					outputTextBox.Text = text;

					if (alert != null)
					{
						alert.Close();
					}

					alert = new AlertForm();
					alert.ShowMessage(text);
				}
			}
		}

		private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
		{
			ChangeClipboardChain(Handle, _clipboardViewerNext);
		}
	}
}
