using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mnuAbout(object sender, RoutedEventArgs e)
        {
            string aboutMessage = "This project is a simple chat app made in WPF & C# by Faith Madore" +
            "\nfor PROG2121 - Windows & Mobile Programming.";
            string boxTitle = "About this project";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBox.Show(aboutMessage, boxTitle, button);
        }

        string inputIPAddress;
        TcpClient client;
        Thread thread;
        NetworkStream stream;

        private void connect_Click(object sender, RoutedEventArgs e)
        {
            // Get users display name
            inputUserName = displayNameInput.Text;

            NetworkStream nameStream;

            inputIPAddress = IPInput.Text;
            
            if (String.IsNullOrEmpty(displayNameInput.Text))
            {
                this.Dispatcher.Invoke(() =>
                {
                    chatBox.Text += "ERROR: Please enter a display name!\n";
                });
            }
            else
            {
                try
                {
                    IPAddress ip = IPAddress.Parse(inputIPAddress);
                    int port = 5000;

                    client = new TcpClient();
                    client.Connect(ip, port);
                    stream = client.GetStream();
                    thread = new Thread(o => ReceiveData((TcpClient)o));

                    thread.Start(client);

                    // Send the display name to Server
                    nameStream = client.GetStream();
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(inputUserName);

                    //---send the text---
                    nameStream.Write(bytesToSend, 0, bytesToSend.Length);
                }
                catch
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        chatBox.Text += "ERROR: No valid IP Address Specified - Cannot connect to Server!\n";
                    });
                }
            }
        }

        private void ReceiveData(TcpClient o)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;

            try
            {
                while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        chatBox.Text += Encoding.ASCII.GetString(receivedBytes, 0, byte_count);
                    });
                }
            }
            catch
            {
                this.Dispatcher.Invoke(() =>
                {
                    chatBox.Text += "Connection to the server has been lost!";
                });
            }
        }

        private void disconnect_Click(object sender, RoutedEventArgs e)
        {
            // message to server to close client
        }

        string inputMessage;
        string inputUserName;

        private void sendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            // Get users display name
            inputUserName = displayNameInput.Text;

            // Get text from messagebox
            inputMessage = messageText.Text;

            // Send a message log to Server
            stream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(inputUserName + ": " + inputMessage);

            //---send the text---
            stream.Write(bytesToSend, 0, bytesToSend.Length);

            messageText.Text = String.Empty;
        }

        private void server_StatusUpdate(object sender, RoutedEventArgs e)
        {
            lblServerStatus.Text = "Waiting...";
        }
    }
}