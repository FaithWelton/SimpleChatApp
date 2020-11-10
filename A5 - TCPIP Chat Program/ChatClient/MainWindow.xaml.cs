using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            inputIPAddress = IPInput.Text;
            IPAddress ip = IPAddress.Parse(inputIPAddress);
            int port = 5000;
            client = new TcpClient();
            client.Connect(ip, port);
            stream = client.GetStream();
            thread = new Thread(o => ReceiveData((TcpClient)o));

            thread.Start(client);

            string s;
            while (!string.IsNullOrEmpty((s = Console.ReadLine())))
            {
                byte[] buffer = Encoding.ASCII.GetBytes(s);
                stream.Write(buffer, 0, buffer.Length);
            }
        }

        private void ReceiveData(TcpClient o)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;

            while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                Console.WriteLine("Server: " + Encoding.ASCII.GetString(receivedBytes, 0, byte_count) + "\n");
            }
        }

        private void disconnect_Click(object sender, RoutedEventArgs e)
        {
            client.Client.Shutdown(SocketShutdown.Send); // ?
            thread.Join();
            stream.Close();
            client.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (Selected colour is ... ) {
            // Change userName to that colour
            //}
        }

        string inputMessage;
        string inputUserName;

        private void sendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            // Get users display name
            inputUserName = displayNameInput.Text;

            // Get text from messagebox
            inputMessage = messageText.Text;

            // Display message in chatbox
            chatBox.Text += inputUserName + ": " + inputMessage + "\n";

            // Send a message log to Server
            stream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(inputUserName + ": " + inputMessage);

            //---send the text---
            stream.Write(bytesToSend, 0, bytesToSend.Length);
        }

        private void server_StatusUpdate(object sender, RoutedEventArgs e)
        {
            lblServerStatus.Text = "Waiting...";
        }
    }
}