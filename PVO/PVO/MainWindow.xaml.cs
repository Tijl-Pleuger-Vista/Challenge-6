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


namespace PVO
{

    public partial class MainWindow : Window
    {



        private void Close_App(object sender, RoutedEventArgs e)
        {
            Close();
            Test();

        }


        private void TestJson(object sender, RoutedEventArgs e)
        {
            Test();

        }


        public class Person
        {
            public string? FirstName { get; set; } 
            public string? LastName { get; set; }
            public string? JobTitle { get; set; }


        }


 
            public static void Test()
            {
                string text = File.ReadAllText(@"C:\Users\Vista college\source\repos\PVO\PVO\Json\person.json");
                var person = JsonSerializer.Deserialize<Person>(text);

                Console.WriteLine($"First name: {person.FirstName}");
                Console.WriteLine($"Last name: {person.LastName}");
                Console.WriteLine($"Job title: {person.JobTitle}");
                Trace.WriteLine($"First name: {person.FirstName}");
            
        }
        

        public void Internet(object sender, RoutedEventArgs e)
        {
            
            string text = File.ReadAllText(@"C:\Users\Vista college\source\repos\PVO\PVO\Json\person.json");
            var person = JsonSerializer.Deserialize<Person>(text);

            this.MainText.Text = person.FirstName;

        }

        public void Security(object sender, RoutedEventArgs e)
        {

            string text = File.ReadAllText(@"C:\Users\Vista college\source\repos\PVO\PVO\Json\person.json");
            var person = JsonSerializer.Deserialize<Person>(text);

            this.MainText.Text = person.LastName;

        }


    }

    

}