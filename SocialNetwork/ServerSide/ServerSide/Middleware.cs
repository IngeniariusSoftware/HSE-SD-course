
namespace ServerSide
{
    using System;
    using System.Net;

    using ServerSide.Handling;
    using ServerSide.Logging;
    using ServerSide.Networking;
    using ServerSide.Properties;
    using ServerSide.Servicing;
    using ServerSide.UI;

    public class Middleware
    {
        private ServerPanelForm _serverPanelForm;

        private IServer _server;

        public Middleware(ServerPanelForm serverPanelForm)
        {
            _serverPanelForm = serverPanelForm;
            _server = new Server(IPAddress.Any, 904, 100000, 1024);
            _server.ModuleChangeState += StatusTracking;
            _server.Subscribing();
            _server.Log.OperationCompleted += _serverPanelForm.ConsoleLogWrite;
            serverPanelForm.Closing += ServerClosing;
        }

        public string ServerManage(string command)
        {
            return _server.Manage(command);
        }

        public void ServerClosing(object sender, EventArgs args)
        {
            _server.End();
        }

        private void StatusTracking(object sender, EventArgs args)
        {
            switch (true)
            {
                case true when sender is IServer server:
                    {
                        _serverPanelForm.ServerLogo.Image =
                            server.IsActive ? Resources.ServerOnIcon : Resources.ServerOffIcon;

                        break;
                    }

                case true when sender is ConnectionReceiver connectionReceiver:
                    {
                        _serverPanelForm.MessageSenderLogo.Image =
                            connectionReceiver.IsActive ? Resources.HandlerOnIcon : Resources.HandlerOffIcon;

                        break;
                    }

                case true when sender is ConnectionSender connectionSender:
                    {
                        _serverPanelForm.ConnectionLogo.Image =
                            connectionSender.IsActive ? Resources.ConnectionOnIcon : Resources.ConnectionOffIcon;

                        break;
                    }

                case true when sender is MessageHandler handler:
                    {
                        _serverPanelForm.MessageHandlerLogo.Image =
                            handler.IsActive ? Resources.DatabaseOnIcon : Resources.DatabaseOffIcon;

                        break;
                    }

                case true when sender is ILog log:
                    {
                        _serverPanelForm.LogLogo.Image = log.IsActive ? Resources.LogOnIcon : Resources.LogOffIcon;

                        break;
                    }
            }
        }
    }
}