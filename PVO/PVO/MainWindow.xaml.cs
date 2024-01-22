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


namespace PVO
{
    
    public partial class MainWindow : Window
    {
        string solutionDir = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string testimg = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FirstIcon.Source = new BitmapImage(new Uri(testimg + "\\img\\World.png"));
            SecondIcon.Source = new BitmapImage(new Uri(testimg + "\\img\\icons8-web-shield-48.png"));
            ThirdIcon.Source = new BitmapImage(new Uri(testimg + "\\img\\icons8-local-network-64.png"));
            FourthIcon.Source = new BitmapImage(new Uri(testimg + "\\img\\icons8-security-configuration-48.png"));
            ShutDown.Source = new BitmapImage(new Uri(testimg + "\\img\\off.png"));



        }
        private void Close_App(object sender, RoutedEventArgs e)
        {
            Close();
            

        }


        public class Person
        {
            public string? FirstName { get; set; } 
            public string? LastName { get; set; }
            public string? JobTitle { get; set; }



        }



        public static void Test()
            {
            string fileName = "person.json";
            string path = Path.Combine(Environment.CurrentDirectory, @"Json\", fileName);
            string text = File.ReadAllText(path);
                var person = JsonSerializer.Deserialize<Person>(text);

            Console.WriteLine($"First name: {person.FirstName}");
                Console.WriteLine($"Last name: {person.LastName}");
                Console.WriteLine($"Job title: {person.JobTitle}");
                Trace.WriteLine($"First name: {person.FirstName}");
            

        }


        public void Internet(object sender, RoutedEventArgs e)
        {

            string text = File.ReadAllText(solutionDir  +"\\Json\\person.json");

            var person = JsonSerializer.Deserialize<Person>(text);

            this.MainText.Text = person.FirstName + Environment.NewLine + person.JobTitle ;



        }

        public void Security(object sender, RoutedEventArgs e)
        {
            string text = File.ReadAllText(solutionDir + "\\Json\\person.json");

            var person = JsonSerializer.Deserialize<Person>(text);

            this.MainText.Text = person.LastName;

        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                chatr();




            }
        }


        public async Task chatr()
        {

            string user_input = UserInput.Text;

            //authApi
            var authentication = new APIAuthentication("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");
            var api = new OpenAIAPI(authentication);

            // Start a neew chat
            var conversation = api.Chat.CreateConversation();

            // Add user input and receive a reply from ChatGPT
            conversation.AppendUserInput(user_input);

            var response = await conversation.GetResponseFromChatbot();
            
            Chatbox.Text = response;



        }
        private void Icons(object sender, RoutedEventArgs e)
        {
            
            FirstIcon.Source = new BitmapImage(new Uri(testimg));


        }


    }



}
