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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Google.Cloud.Firestore;
using System.Security.Cryptography;
using DocumentReference = Google.Cloud.Firestore.DocumentReference;

namespace PVO
{
    public partial class MainWindow : Window
    {
        string imgs = "C:\\Users\\jeera\\Documents\\GitHub\\project-6\\PVO\\PVO\\";
        string solutionDir = "C:\\Users\\jeera\\Documents\\GitHub\\project-6\\PVO\\PVO\\";
        int? Arraylength = 0;
        string? clickedsubject;
        public string Usericon = "https://beyond-medtech.com/wp-content/uploads/2019/08/Vista-Thumbnail.png";

        //database conn
         internal static class Firestorehelper
        {
            static string fireconfig = @"{
            ""type"": ""service_account"",
              ""project_id"": ""vista-400927"",
              ""private_key_id"": ""156fbe61e8767f37306f2bdb67163cb1c3c171f1"",
              ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC9x8ZwyY84khvO\nAnjur8CrYBr8zESK9Hhq/z2hNX6eHZD8xYeLZxOixX41f0uXrWjJ8Pk9Uw/3BaLr\nA7XKK1tACRAIQuypFn4QfGIeqm89c1mcDvZt1Ug1syJ3rNy3+HfN7Qprqn+n+m69\n3IeIxP3mu0ntmdWU8Iu8tdDUJEnS4YPCzgKRs2ZwjSaS3pbQGGFdwt26DT9MuKrN\njTgIYbAqYvZ2EoaZ/c+KVNlNo7JDVoecVc2w1pXk5L8bu5xLiXHUIN8RFwFXVM+i\nC3IGCRl22x8iZ56MBO33fA6S0MiM8S2Ei0VMl3QMejA/RObqzpUXbZntzjx/5rCK\nUatg6U1hAgMBAAECggEAHKCsIItnHWN86kCZOXgtmixvJb8yf7uNBqbmBxFovjU7\nj8XEQpUT8zPTbAJ9xq2T5xKApm2HNP4Wq1jt7UdJBonXb0eZJ5CLB7Wbn4CaMyzZ\nUZ84MS1BLUiOZHsg+Gd0uw2Mytz3UMGIPv+rOkhs/Ic4Ca1w+Hyot5i9naKzuCml\neavszaFNX53rHYUwP4PKOFwiXl5TD6VMigxoLzDR4l6ga6v1gZOCTGP7tC/hZk2X\n98vduGJcrj82SGvSalt9WLzHw9GrC+1DFa7yrc2go0x8aQNJzlFq5zKI85/JqekM\nq4f1JF+P8abAaNiQzp/c7NkGVyC9IP73HM3jPUV+eQKBgQD8P/Ygvr9Yd+rWyOa4\n8IFqFTj11fLNYDsBlYz0j3T6o0TIsLQ+kRDZ2wTSlC7c9dw+w0Dt4q0osharO3Jf\ncSKGCKIQn323mu4FruZp09KL/eLBMk7DCRqVLSW9HZRMJhZloxQRzeTXXpNcR3XZ\nnAoCntS5K1Sctw+fBbcu8AztdwKBgQDAmg+Yp9xpg0uYdyXCTXzsF74x/XZwhrag\nLB3UcbMkYVl1VmxjwTiuN3ZZRiFBEuCDBj9AVg7HWYwH+UxSzsBsLW1+04yTtADk\nFFdqKgWz7ce+R/ECaorQToVXDBUkx7xqpJh8JfZlwAKjS6HZEndqhbOSMI22UfqK\nw+rP2F7x5wKBgH7zVdS/Cx/kIj18mJmk+QzBp4wZ4/u2nZu7f1gpxs7JUrnKLLx8\nV8W8s52jVD6CQhkYPVo7xbgAgOYmofYkwyI/wAirrCK2h2o2zuGd6I3p9bATuI3x\ny/4d3ati8pqsZIM8YsJfI/e8Ml+z2zzsiiEtfJPAmfHRM7xtrPaje24bAoGAKhD8\nGxF+uKTum+xaGOgnwsEkz3JWrhkeRjmcgkwbHnUMvu4TWm5XXOXMOY9xr+7ZjoSM\nyBaDv9K1HQC8RNHXgUkiwzKdX51PHIG83fkzqarjl5HK+AYhL4IW6X5AF/pwErLE\ng0kfWfXoHZZlUS4RWvi80c89BHc/S5Oi86aEhj0CgYEAlmittIQ7diQ0BeUEWm8I\nFJjuMLT7vK/BXGW9PNNEFAyulXB+Io/F2hbncbHajE71eLVWbWxq1RfsdJOqFaqN\nvdQFrVzpMLUreETVqzLZ5PN7uBcCCwb4Xfi0IaLJBJ14Iw8xrnG6aHCRB7C3SJ5s\nCABT6qp+qWXUo1txy2YOw9Y=\n-----END PRIVATE KEY-----\n"",
              ""client_email"": ""firebase-adminsdk-wsylq@vista-400927.iam.gserviceaccount.com"",
              ""client_id"": ""105360489942787503600"",
              ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
              ""token_uri"": ""https://oauth2.googleapis.com/token"",
              ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
              ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-wsylq%40vista-400927.iam.gserviceaccount.com"",
              ""universe_domain"": ""googleapis.com""
            }";

            static string filepath = "";
            public static FirestoreDb? database { get; private set; }

            public static void SetEnviromentVariable()
            {
                filepath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())) + ".json";
                File.WriteAllText(filepath, fireconfig);
                File.SetAttributes(filepath, FileAttributes.Hidden);
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
                database = FirestoreDb.Create("vista-400927");
                File.Delete(filepath);
            }

        }

        [FirestoreData]
        class UserData
        {
            [FirestoreProperty]
            public string? UserName { get; set; }
            [FirestoreProperty]
            public string? PassWord { get; set; }

            [FirestoreProperty]
            public int? XP { get; set; }
        }


        //On App load
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //FirstIcon.Source = new BitmapImage(new Uri(imgs + "\\img\\World.png"));
            //SecondIcon.Source = new BitmapImage(new Uri(imgs + "\\img\\icons8-web-shield-48.png"));
            //ThirdIcon.Source = new BitmapImage(new Uri(imgs + "\\img\\icons8-local-network-64.png"));
            //FourthIcon.Source = new BitmapImage(new Uri(imgs + "\\img\\icons8-security-configuration-48.png"));

            LoginLogo.Source = new BitmapImage(new Uri("C:\\Users\\jeera\\Documents\\GitHub\\project-6\\app\\assets\\content\\logo\\init\\original.png"));
            UserIMG.Source = new BitmapImage(new Uri(imgs + "\\img\\profile-default.png"));
            this.Sidebar.Visibility = Visibility.Hidden;
            this.UserIcon.Visibility = Visibility.Hidden;
            this.Chat.Visibility = Visibility.Hidden;
            this.MainText.Visibility = Visibility.Hidden;
                 //= new BitmapImage(new Uri(imgs + "\\img\\1.webp"));
            Firestorehelper.SetEnviromentVariable();

        }




        public static string Encrypt(string text)
        {
            var b = Encoding.UTF8.GetBytes(text);
            var encrypted = getAes().CreateEncryptor().TransformFinalBlock(b, 0, b.Length);
            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string encrypted)
        {
            var b = Convert.FromBase64String(encrypted);
            var decrypted = getAes().CreateDecryptor().TransformFinalBlock(b, 0, b.Length);
            return Encoding.UTF8.GetString(decrypted);
        }

        static Aes getAes()
        {
            var keyBytes = new byte[16];
            var skeyBytes = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
            Array.Copy(skeyBytes, keyBytes, Math.Min(keyBytes.Length, skeyBytes.Length));

            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;
            aes.Key = keyBytes;
            aes.IV = keyBytes;

            return aes;
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

            var src = e.Source.ToString;

            if (((System.Windows.Controls.HeaderedItemsControl)src.Target).Header.ToString() == "SQL Injection")
            {
                clickedsubject = "SQLInjection";
            } 
            else if (((System.Windows.Controls.HeaderedItemsControl)src.Target).Header.ToString() == "Data Base")
            {
                clickedsubject = "DataBase";
            }

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
                    string username = UserInputLoginUser.Text.Trim();
                    string password = UserInputLoginPassword.Password;
                    var db = Firestorehelper.database;
                    DocumentReference docRef = db.Collection("UserData").Document(username);
                    UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();

                    if (password != null)
                    {
                        if (password == Decrypt(data.PassWord))
                        {
                            if (this.login.Visibility == Visibility.Hidden)
                            {
                                this.MainWindowView.Visibility = Visibility.Hidden;
                                this.login.Visibility = Visibility.Visible;
                            }
                            else
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
                        else
                        {
                            MessageBox.Show("failed");

                        }
                    }
                    else
                    {
                        MessageBox.Show("failed");
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

            if (UserInputLoginUser.Text != "")
            {
                //fils xp if user logged in
                string username = UserInputLoginUser.Text.Trim();
                var db = Firestorehelper.database;
                DocumentReference docRef = db.Collection("UserData").Document(username);
                UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();

                data.XP = Int32.Parse(this.ResourcesText.Text = InfoArray.Subject[0].xp);
            }




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


            if (UserInputLoginUser.Text != "")
            {
                //fils xp if user logged in
                string username = UserInputLoginUser.Text.Trim();
                var db = Firestorehelper.database;
                DocumentReference docRef = db.Collection("UserData").Document(username);
                UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();

                data.XP = Int32.Parse(this.ResourcesText.Text = InfoArray.Subject[0].xp);
            }
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

            if (UserInputLoginUser.Text != "")
            {
                //fils xp if user logged in
                string username = UserInputLoginUser.Text.Trim();
                var db = Firestorehelper.database;
                DocumentReference docRef = db.Collection("UserData").Document(username);
                UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();

                data.XP = Int32.Parse(this.ResourcesText.Text = InfoArray.Subject[0].xp);
            }


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

            if (CheckIfUserExsist())
            {
                MessageBox.Show("User already exsist");
            }

            var db = Firestorehelper.database;
            var data = GetWriteData();
            DocumentReference docRef = db.Collection("UserData").Document(data.UserName);
            docRef.SetAsync(data);
            MessageBox.Show("Success");



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

        private UserData GetWriteData()
        {



            string username = UserInputLoginUser.Text.Trim();
            string password = Encrypt(UserInputLoginPassword.Password);

            return new UserData()
            {
                UserName = username,
                PassWord = password
                
            };
        }

        private void loginbtn(object sender, RoutedEventArgs e)
        {
            string username = UserInputLoginUser.Text.Trim();
            string password = UserInputLoginPassword.Password;
            var db = Firestorehelper.database;
            DocumentReference docRef = db.Collection("UserData").Document(username);
            UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();

            if(password != null)
            {
                if(password == Decrypt(data.PassWord))
                {
                    if (this.login.Visibility == Visibility.Hidden)
                    {
                        this.MainWindowView.Visibility = Visibility.Hidden;
                        this.login.Visibility = Visibility.Visible;
                    }
                    else
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
                else
                {
                    MessageBox.Show("failed");

                }
            } else
            {
                MessageBox.Show("failed");
            }

        }


        private bool CheckIfUserExsist() {

            string username = UserInputLoginUser.Text.Trim();
            var db = Firestorehelper.database;
            DocumentReference docRef = db.Collection("UserData").Document(username);
            UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();
            

            if (data != null)
            {
                return true;
            }

            return false;   

        }
    }

}
