using DESTRY.IO.Debuging;
using DESTRY.Net.Emails;
using NFSU2_ExOpts.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace NFSU2_ExOpts.ViewModels
{
    class ContactsViewModel : BaseViewModel
    {
        private string userEmail;
        private string userComment;
        private string sendingState = "";
        private Brush sendingStateColor = Brushes.White;


        public string UserEmail
        {
            get
            {
                return userEmail;
            }
            set
            {
                userEmail = value;
                OnPropertyChanged();
            }
        }
        public string UserComment
        {
            get
            {
                return userComment;
            }
            set
            {
                userComment = value;
                OnPropertyChanged();
            }
        }
        public string SendingState
        {
            get
            {
                return sendingState;
            }
            set
            {
                sendingState = value;
                OnPropertyChanged();
            }
        }
        public Brush SendingStateColor
        {
            get
            {
                return sendingStateColor;
            }
            set
            {
                sendingStateColor = value;
                OnPropertyChanged();
            }
        }

        public ICommand SendEmailCommand => new BaseCommand(obj => SendEmail());
        public ICommand OpenLinkCommand => new BaseCommand(link => Process.Start((string)link));

        private void SendEmail()
        {
            try
            {
                SupportMessage message = new SupportMessage("Help! Bugs in \"NFSU2 ExOpts-UI\" application!", userEmail, userComment);
                message.OnMailSendingStarted += StartSending;
                message.OnMailSendingEnded += SendingEnded;
                message.OnExceptionCatched += SendingError;

                string[] files = Directory.GetFiles(App.ApplicationDataFolder, "*.*", SearchOption.AllDirectories);
                message.AddFiles(files);

                message.SendAsync();
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }

        private void ChangeState(string message, string colorKey)
        {
            var colorStyle = Application.Current.TryFindResource(colorKey);

            SendingState = message;
            SendingStateColor = (Brush)colorStyle;
        }
        private void StartSending(object sender)
        {
            ChangeState("Email sending...", "WhiteBrush");
        }
        private void SendingEnded(object sender)
        {
            ChangeState("Email sended successfully!", "MainBrush");
            Logs.WriteLog($"Mail sended from:{userEmail} with \"{userComment}\" comment.", "INFO");
        }
        private void SendingError(object sender, Exception error)
        {
            ChangeState("Email not sended! Error :(", "RedBrush");
            Logs.WriteLog("Email not sended! Error :(", "ERROR");
            Errors.WriteError(error);
        }
    }
}
