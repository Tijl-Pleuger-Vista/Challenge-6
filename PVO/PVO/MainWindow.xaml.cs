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

namespace PVO
{

    public partial class MainWindow : Window
    {
        string imgs = "C:\\Program Files (x86)\\Vista college\\LeenBook\\";
        string solutionDir = "C:\\Program Files (x86)\\Vista college\\LeenBook\\";





        //On App load
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FirstIcon.Source = new BitmapImage(new Uri(imgs + "\\img\\World.png"));
            SecondIcon.Source = new BitmapImage(new Uri(imgs + "\\img\\icons8-web-shield-48.png"));
            ThirdIcon.Source = new BitmapImage(new Uri(imgs + "\\img\\icons8-local-network-64.png"));
            FourthIcon.Source = new BitmapImage(new Uri(imgs + "\\img\\icons8-security-configuration-48.png"));





        }

        /*Json names (firstlayer)*/
        public class Person
        { 
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? JobTitle { get; set; }

            public Category_subcategory[]? category_subcategory { get; set; }

        }

        /*Json names (Secondlayer)*/
        public class Category_subcategory
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
            //read the json
            string text = File.ReadAllText(solutionDir  +"\\Json\\person.json");

            //deserialise(make it into string for the person class variables)
            var person = JsonSerializer.Deserialize<Person>(text);

            ClearMainText();

#pragma warning disable CS8602 // Dereference of a possibly null reference.

            this.OpeningMessage.Text = null;
            this.MainTitleText.Text = person.category_subcategory[0].title;
            this.InfoText.Text = person.category_subcategory[0].summary;
            this.ProblemText.Text = person.category_subcategory[0].problem;
            this.SolutionText.Text = person.category_subcategory[0].solution;
            this.ExamplesText.Text = person.category_subcategory[0].examples;
            this.ResourcesText.Text = person.category_subcategory[0].resources;

            this.MainTitle.Text = "Title";
            this.InfoTitle.Text = "Summary";
            this.ProblemTitle.Text = "Problem";
            this.SolutionTitle.Text = "Solution";
            this.ExamplesTitle.Text = "Examples";
            this.ResourcesTitle.Text = "Resources";



#pragma warning restore CS8602 // Dereference of a possibly null reference.



        }

        public void Security(object sender, RoutedEventArgs e)
        {
            string text = File.ReadAllText(solutionDir + "\\Json\\person.json");

            var person = JsonSerializer.Deserialize<Person>(text);

            ClearMainText();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            this.MainTitleText.Text = person.LastName;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        }

        //Enter key does something
        public async void OnKeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
               await chatr();




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

                // Add user input and receive a reply from ChatGPT
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


    }



}
