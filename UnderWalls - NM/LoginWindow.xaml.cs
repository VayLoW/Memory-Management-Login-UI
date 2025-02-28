using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Text.Json;
using System.Diagnostics;

namespace UnderWalls_NM
{
    public partial class LoginWindow : Window
    {
        private readonly HttpClient httpClient;
        private const string API_URL = "http://51.222.158.82:5000/api/code"; //Ici c'est la vérification du code que l'utilisateur rentre, sois sûr d'avoir une réponse en JSON sur ton site
        private const string DISCORD_URL = "https://discord.gg/qfjcts7MZx"; //Met ton lien discord ici si tu veux le changer

        public LoginWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginButton.IsEnabled = false;
                StatusText.Text = "Vérification du code...";

                var response = await httpClient.GetStringAsync(API_URL);
                var jsonResponse = JsonDocument.Parse(response);
                var validCode = jsonResponse.RootElement.GetProperty("code").GetString();

                if (CodeTextBox.Text.Trim() == validCode)
                {
                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    StatusText.Text = "Code invalide ! Le code change toutes les 10 secondes.";
                    LoginButton.IsEnabled = true;
                }
            }
            catch (Exception)
            {
                StatusText.Text = "Erreur de connexion au serveur ! Vérifiez votre connexion internet.";
                LoginButton.IsEnabled = true;
            }
        }

        private void DiscordButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = DISCORD_URL,
                UseShellExecute = true
            });
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
