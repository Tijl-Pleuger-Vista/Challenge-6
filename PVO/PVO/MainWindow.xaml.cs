using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Diagnostics;
using OpenAI_API;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.Metadata;
using Path = System.IO.Path;
using System.Reflection;
using static PVO.MainWindow;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Windows.Controls.Primitives;
using System.Diagnostics.Metrics;

namespace PVO
{
    public partial class MainWindow : Window
    {
        string imgs = "C:\\Users\\jeera\\Documents\\GitHub\\project-6\\PVO\\PVO\\";
        string solutionDir = "C:\\Users\\jeera\\Documents\\GitHub\\project-6\\PVO\\PVO\\";
        int? Arraylength = 0;
        string? clickedsubject;

    





        //On App load
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FirstIcon.Source = new BitmapImage(new Uri(imgs + "\\img\\World.png"));
            SecondIcon.Source = new BitmapImage(new Uri(imgs + "\\img\\icons8-web-shield-48.png"));
            ThirdIcon.Source = new BitmapImage(new Uri(imgs + "\\img\\icons8-local-network-64.png"));
            FourthIcon.Source = new BitmapImage(new Uri(imgs + "\\img\\icons8-security-configuration-48.png"));
            LoginLogo.Source = new BitmapImage(new Uri("C:\\Users\\jeera\\Documents\\GitHub\\project-6\\app\\assets\\content\\logo\\init\\original.png"));
            this.Sidebar.Visibility = Visibility.Hidden;
            this.UserIcon.Visibility = Visibility.Hidden;
            this.Chat.Visibility = Visibility.Hidden;
            this.MainText.Visibility = Visibility.Hidden;







        }

        /*Json names (firstlayer)*/
        public class Subjects
        {
            public Info[]? Subject { get; set; }

        }

        /*Json names (Secondlayer)*/
        public class Info
        {
            public string? title { get; set; }
            public string? level { get; set; }
            public string? risk { get; set; }
            public string? xp { get; set; }
            public string? summary { get; set; }
            public string? problem { get; set; }
            public string? solution { get; set; }
            public string? examples { get; set; }
            public string? resources { get; set; }

        }

        public void Internet(object sender, RoutedEventArgs e)
        {
            var trying = e.Source.ToString;
            clickedsubject = ((System.Windows.Controls.HeaderedItemsControl)trying.Target).Header.ToString();

            ClearMainText();
            LevelCount();

            if(Arraylength == 1) {

                this.Chatbox.Visibility = Visibility.Hidden;
                this.Level1.Visibility = Visibility.Visible;
                this.Level2.Visibility = Visibility.Hidden;
                this.Level3.Visibility = Visibility.Hidden;
                this.OpeningMessage.Text = "Please choose a level";

            } else if (Arraylength == 2)
            {

                this.Chatbox.Visibility = Visibility.Hidden;
                this.Level1.Visibility = Visibility.Visible;
                this.Level2.Visibility = Visibility.Visible;
                this.Level3.Visibility = Visibility.Hidden;
                this.OpeningMessage.Text = "Please choose a level";

            } else if (Arraylength == 3)
            {

                this.Chatbox.Visibility = Visibility.Hidden;
                this.Level1.Visibility = Visibility.Visible;
                this.Level2.Visibility = Visibility.Visible;
                this.Level3.Visibility = Visibility.Visible;
                this.OpeningMessage.Text = "Please choose a level";
                

            };




        }

        public void Security(object sender, RoutedEventArgs e)
        {
            ClearMainText();

            this.Chatbox.Visibility = Visibility.Hidden;
            this.Level1.Visibility = Visibility.Visible;
            this.Level2.Visibility = Visibility.Visible;
            this.Level3.Visibility = Visibility.Visible;
            this.OpeningMessage.Text = "Please choose a level";


        }

        //Enter key does something
        public async void OnKeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                if (this.UserInput.IsKeyboardFocusWithin == true)
                {
                    await chatr();
                }
                else if (this.UserInputLoginPassword.IsKeyboardFocused == true)
                {
                    string url = "https://pvo-limburg.nl/";

                    try
                    {
                        Process.Start(url);
                    }
                    catch
                    {
                        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        {
                            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                        }
                        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                        {
                            Process.Start("xdg-open", url);
                        }
                        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                        {
                            Process.Start("open", url);
                        }
                        else
                        {
                            this.MainText.Text = "Your browser is not currently supported.";
                        }
                    }
                }
            }

        }

        //ChatBot
        public async Task chatr()
        {
            try
            {
                string user_input = UserInput.Text;

                //authApi
                var authentication = new APIAuthentication("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");
                var api = new OpenAIAPI(authentication);

                // Start a new chat
                var conversation = api.Chat.CreateConversation();

                // Add user input and receive a reply from ChatBot
                conversation.AppendUserInput(user_input);

                var response = await conversation.GetResponseFromChatbotAsync();

                Chatbox.Text = response;
            } catch {
                Chatbox.Text = "Sorry at this moment in time i am not available. Please contact an admin";
            }


        }

        public void ClearMainText()
        {
            this.OpeningMessage.Text = null;
            this.MainTitleText.Text = null;
            this.InfoText.Text = null;
            this.ProblemText.Text = null;
            this.SolutionText.Text = null;
            this.ExamplesText.Text = null;
            this.ResourcesText.Text = null;
            this.MainTitle.Text = null;
            this.InfoTitle.Text = null;
            this.ProblemTitle.Text = null;
            this.SolutionTitle.Text = null;
            this.ExamplesTitle.Text = null;
            this.ResourcesTitle.Text = null;
        }



        private void Level1_Click(object sender, RoutedEventArgs e)
        {

            //read the json
            
            string text = File.ReadAllText(solutionDir + "\\Json\\" + clickedsubject + ".json");
           

            //deserialise(make it into string for the person class variables)
            var InfoArray = JsonSerializer.Deserialize<Subjects>(text)!;

            string? level = InfoArray.Subject![0].level;
            ClearMainText();


            //fills MainText
            this.MainWindowView.Visibility = Visibility.Visible;
            this.login.Visibility = Visibility.Hidden;
            this.MainTitleText.Text = InfoArray.Subject[0].title;
            this.InfoText.Text = InfoArray.Subject[0].summary;
            this.ProblemText.Text = InfoArray.Subject[0].problem;
            this.SolutionText.Text = InfoArray.Subject[0].solution;
            this.ExamplesText.Text = InfoArray.Subject[0].examples;
            this.ResourcesText.Text = InfoArray.Subject[0].resources;
            

            this.MainTitle.Text = "Title";
            this.InfoTitle.Text = "Summary";
            this.ProblemTitle.Text = "Problem";
            this.SolutionTitle.Text = "Solution";
            this.ExamplesTitle.Text = "Examples";
            this.ResourcesTitle.Text = "Resources";

            this.Chatbox.Visibility = Visibility.Visible;
            this.Level1.Visibility = Visibility.Hidden;
            this.Level2.Visibility = Visibility.Hidden;
            this.Level3.Visibility = Visibility.Hidden;


        }

        private void Level2_Click(object sender, RoutedEventArgs e)
        {
            //read the json
            string text = File.ReadAllText(solutionDir + "\\Json\\SQLinjection.json");

            //deserialise(make it into string for the person class variables)
            var InfoArray = JsonSerializer.Deserialize<Subjects>(text)!;

            string? level = InfoArray.Subject![1].level;

            ClearMainText();


            //clears and fills MainText
            this.MainWindowView.Visibility = Visibility.Visible;
            this.login.Visibility = Visibility.Hidden;
            this.MainTitleText.Text = InfoArray.Subject[1].title;
            this.InfoText.Text = InfoArray.Subject[1].summary;
            this.ProblemText.Text = InfoArray.Subject[1].problem;
            this.SolutionText.Text = InfoArray.Subject[1].solution;
            this.ExamplesText.Text = InfoArray.Subject[1].examples;
            this.ResourcesText.Text = InfoArray.Subject[1].resources;


            this.MainTitle.Text = "Title";
            this.InfoTitle.Text = "Summary";
            this.ProblemTitle.Text = "Problem";
            this.SolutionTitle.Text = "Solution";
            this.ExamplesTitle.Text = "Examples";
            this.ResourcesTitle.Text = "Resources";

            this.Chatbox.Visibility = Visibility.Visible;
            this.Level1.Visibility = Visibility.Hidden;
            this.Level2.Visibility = Visibility.Hidden;
            this.Level3.Visibility = Visibility.Hidden;


        }

        private void Level3_Click(object sender, RoutedEventArgs e)
        {

            //read the json
            string text = File.ReadAllText(solutionDir + "\\Json\\SQLinjection.json");

            //deserialise(make it into string for the person class variables)
            var InfoArray = JsonSerializer.Deserialize<Subjects>(text)!;

            string? level = InfoArray.Subject![2].level;

            ClearMainText();


            //clears and fills MainText
            this.MainWindowView.Visibility = Visibility.Visible;
            this.login.Visibility = Visibility.Hidden;
            this.MainTitleText.Text = InfoArray.Subject[2].title;
            this.InfoText.Text = InfoArray.Subject[2].summary;
            this.ProblemText.Text = InfoArray.Subject[2].problem;
            this.SolutionText.Text = InfoArray.Subject[2].solution;
            this.ExamplesText.Text = InfoArray.Subject[2].examples;
            this.ResourcesText.Text = InfoArray.Subject[2].resources;


            this.MainTitle.Text = "Title";
            this.InfoTitle.Text = "Summary";
            this.ProblemTitle.Text = "Problem";
            this.SolutionTitle.Text = "Solution";
            this.ExamplesTitle.Text = "Examples";
            this.ResourcesTitle.Text = "Resources";

            this.Chatbox.Visibility = Visibility.Visible;
            this.Level1.Visibility = Visibility.Hidden;
            this.Level2.Visibility = Visibility.Hidden;
            this.Level3.Visibility = Visibility.Hidden;


        }

        public void LevelCount()
        {
            string text = File.ReadAllText(solutionDir + "\\Json\\SQLInjection.json");
            var InfoArray = JsonSerializer.Deserialize<Subjects>(text)!;
            Arraylength = InfoArray.Subject!.Length;

        }

        private void UserLogin(object sender, RoutedEventArgs e)
        {
            if (this.login.Visibility == Visibility.Hidden)
            {
                this.MainWindowView.Visibility = Visibility.Hidden;
                this.login.Visibility = Visibility.Visible;
            } else
            {
                this.MainWindowView.Visibility = Visibility.Visible;
                this.login.Visibility = Visibility.Hidden;
            }

            this.OfflineWarningGrid.Visibility = Visibility.Hidden;
            this.Sidebar.Visibility = Visibility.Visible;
            this.UserIcon.Visibility = Visibility.Visible;
            this.Chat.Visibility = Visibility.Visible;
            this.MainText.Visibility = Visibility.Visible;

        }

        private void CreateAcc(object sender, RoutedEventArgs e)
        {
            string url = "https://pvo-limburg.nl/";

            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    this.MainText.Text = "Your browser is not currently supported.";
                }
            }

        }

        private void OfflineWarning(object sender, RoutedEventArgs e)
        {
           this.OfflineWarningGrid.Visibility = Visibility.Visible;

        }



    }

}
