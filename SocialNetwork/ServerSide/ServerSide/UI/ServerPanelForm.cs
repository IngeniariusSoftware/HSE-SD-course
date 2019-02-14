
namespace ServerSide.UI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using ServerSide.Logging;
    using ServerSide.Processing;

    public partial class ServerPanelForm : Form
    {
        private Middleware _middleware;

        public ServerPanelForm()
        {
            InitializeComponent();
            _middleware = new Middleware(this);
        }

        public void CommandLogWrite(object sender, ProcessEventArgs e)
        {
            CommandLog.Text = " Командная строка. Введите команду для управления сервером...\n";
            CommandLog.AppendText("\n");
            CommandLog.AppendText("\n ");
            CommandLog.AppendText(e.OperationInfo);
            CommandLog.AppendText("\n");
        }

        public async void ConsoleLogWrite(object sender, ProcessEventArgs e)
        {
            if (((ILog)sender).IsActive)
            {
                if (ConsoleLog.InvokeRequired)
                {
                    await Task.Run(
                        () => ConsoleLog.Invoke(
                            new Action(
                                () =>
                                    {
                                        ConsoleLog.AppendText("\n");
                                        ConsoleLog.AppendText(e.OperationInfo);
                                    }),
                            null));
                }
                else
                {
                    ConsoleLog.AppendText("\n");
                    ConsoleLog.AppendText(e.OperationInfo);
                }
            }
        }

        private void LogWriter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                ConsoleLog.Text += LogWriter.Text + '\n';
                LogWriter.Text = string.Empty;
            }
        }

        private void CommandWriter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (CommandWriter.Text != string.Empty)
                {
                    CommandLogWrite(
                        CommandWriter,
                        new ProcessEventArgs(
                            CommandWriter.Text + " - " + _middleware.ServerManage(CommandWriter.Text)));
                    CommandWriter.Text = string.Empty;
                }
            }
        }
    }
}