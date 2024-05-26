using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.IO;
using Formatting = Newtonsoft.Json.Formatting;
using TechLibrary;
using System.Drawing;
using System.Windows.Media;
using ColorConverter = System.Windows.Media.ColorConverter;


namespace WPF
{
    public class Serialize
    {
        //USER
        public static void Registration(TextBox login, PasswordBox password)
        {
            Entity userLog;
            string filePath = "DB.json";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            string json = File.ReadAllText(filePath);
            userLog = JsonConvert.DeserializeObject<Entity>(json) ?? new Entity();

            if (login.Text.Length > 10)
            {
                MessageBox.Show("The login must not exceed 10 characters");
                return;
            }

            if (!login.Text.Contains("admin"))
            {
                userLog.Users.Add(new Users(login.Text, password.Password));
                MessageBox.Show("The user has been created");
            }
            else
            {
                userLog.Admins.Add(new Admins(login.Text, password.Password));
                MessageBox.Show("The administrator has been created");
            }

            string reg = JsonConvert.SerializeObject(userLog, Formatting.Indented);
            File.WriteAllText(filePath, reg);
        }
        public static bool CheckUser(TextBox login, PasswordBox password)
        {
            string filePath = "DB.json";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            string json = File.ReadAllText(filePath);
            Entity userLog = JsonConvert.DeserializeObject<Entity>(json) ?? new Entity();

            bool userExists = false;
            bool adminExists = false;

            foreach (var user in userLog.Users)
            {
                if (user.UserName == login.Text && user.Password == password.Password)
                {
                    userExists = true;
                    break;
                }
            }

            foreach (var admin in userLog.Admins)
            {
                if (admin.UserName == login.Text && admin.Password == password.Password)
                {
                    adminExists = true;
                    break;
                }
            }

            if (userExists || adminExists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //DISPLAY
        public static void DisplayServices(StackPanel serviceStackPanel)
        {
            string json = File.ReadAllText("DB.json");
            Entity _entity = JsonConvert.DeserializeObject<Entity>(json) ?? new Entity();

            foreach (Services service in _entity.Services)
            {
                StackPanel serviceCard = new StackPanel()
                {
                    Margin = new Thickness(30)
                };

                Border border = new Border()
                {
                    Background = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString("#32373B")),
                    CornerRadius = new CornerRadius(10),
                    Margin = new Thickness(0, 0, 0, 20)
                };

                TextBlock nameTextBlock = new TextBlock()
                {
                    Foreground = Brushes.White,
                    Margin = new Thickness(0, 0, 0, 10),
                    TextWrapping = TextWrapping.WrapWithOverflow,
                    Text = service.ServiceName,
                    FontWeight = FontWeights.DemiBold,
                    FontSize = 20,
                };
                serviceCard.Children.Add(nameTextBlock);

                TextBlock descriptionTextBlock = new TextBlock()
                {
                    Foreground = Brushes.White,
                    Margin = new Thickness(0, 0, 0, 10),
                    TextWrapping = TextWrapping.WrapWithOverflow,
                    Text = service.Description,
                    FontStyle = FontStyles.Italic,
                    FontSize = 16,
                };
                serviceCard.Children.Add(descriptionTextBlock);

                TextBlock costTextBlock = new TextBlock()
                {
                    Foreground = Brushes.White,
                    Text = "Cost: $" + service.Cost.ToString(),
                    FontWeight = FontWeights.DemiBold,
                    FontSize = 16
                };
                serviceCard.Children.Add(costTextBlock);

                border.Child = serviceCard;
                serviceStackPanel.Children.Insert(0, border);
            }
        }
        public static void DisplayRequest(StackPanel serviceStackPanel)
        {
            string filePath = "DB.json";
            string json = File.ReadAllText(filePath);
            Entity _entity = JsonConvert.DeserializeObject<Entity>(json) ?? new Entity();

            foreach (Request request in _entity.Requests)
            {
                if (request.Status == false)
                {
                    StackPanel requestCard = new StackPanel()
                    {
                        Margin = new Thickness(30)
                    };

                    Border border = new Border()
                    {
                        Background = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString("#32373B")),
                        CornerRadius = new CornerRadius(10),
                        Margin = new Thickness(0, 0, 0, 20)
                    };

                    TextBlock clientTextBlock = new TextBlock()
                    {
                        Foreground = Brushes.White,
                        Margin = new Thickness(0, 0, 0, 10),
                        TextWrapping = TextWrapping.WrapWithOverflow,
                        Text = request.Client,
                        FontWeight = FontWeights.DemiBold,
                        FontSize = 20,
                    };
                    requestCard.Children.Add(clientTextBlock);

                    TextBlock descriptionTextBlock = new TextBlock()
                    {
                        Foreground = Brushes.White,
                        Margin = new Thickness(0, 0, 0, 10),
                        TextWrapping = TextWrapping.WrapWithOverflow,
                        Text = request.Comment,
                        FontStyle = FontStyles.Italic,
                        FontSize = 16,
                    };
                    requestCard.Children.Add(descriptionTextBlock);

                    TextBlock typeTextBlock = new TextBlock()
                    {
                        Foreground = Brushes.White,
                        Margin = new Thickness(0, 0, 0, 10),
                        Text = request.TypeOfService,
                        FontWeight = FontWeights.DemiBold,
                        FontSize = 16
                    };
                    requestCard.Children.Add(typeTextBlock);

                    Button statusBtn = new Button()
                    {
                        Style = (Style)Application.Current.Resources["ButtonStyleRadius"],
                        Content = "Done",
                        Foreground = Brushes.White,
                        FontSize = 20,
                        FontWeight = FontWeights.Bold
                    };
                    statusBtn.Click += (s, e) =>
                    {
                        request.Status = true;
                        string save = JsonConvert.SerializeObject(_entity, Formatting.Indented);
                        File.WriteAllText(filePath, save);
                    };
                    requestCard.Children.Add(statusBtn);
                    border.Child = requestCard;
                    serviceStackPanel.Children.Add(border);
                }
            }

        }
        public static void DisplayUserRequest(StackPanel serviceStackPanel, string currentUserName)
        {
            string filePath = "DB.json";
            string json = File.ReadAllText(filePath);
            Entity _entity = JsonConvert.DeserializeObject<Entity>(json) ?? new Entity();

            foreach (Request request in _entity.Requests)
            {
                if (request.Client == currentUserName)
                {
                    StackPanel requestCard = new StackPanel()
                    {
                        Margin = new Thickness(30)
                    };

                    Border border = new Border()
                    {
                        Background = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString("#32373B")),
                        CornerRadius = new CornerRadius(10),
                        Margin = new Thickness(0, 0, 0, 20)
                    };

                    TextBlock clientTextBlock = new TextBlock()
                    {
                        Foreground = Brushes.White,
                        Margin = new Thickness(0, 0, 0, 10),
                        TextWrapping = TextWrapping.WrapWithOverflow,
                        Text = request.Client,
                        FontWeight = FontWeights.DemiBold,
                        FontSize = 20,
                    };
                    requestCard.Children.Add(clientTextBlock);

                    TextBlock descriptionTextBlock = new TextBlock()
                    {
                        Foreground = Brushes.White,
                        Margin = new Thickness(0, 0, 0, 10),
                        TextWrapping = TextWrapping.WrapWithOverflow,
                        Text = request.Comment,
                        FontStyle = FontStyles.Italic,
                        FontSize = 16,
                    };
                    requestCard.Children.Add(descriptionTextBlock);

                    TextBlock typeTextBlock = new TextBlock()
                    {
                        Foreground = Brushes.White,
                        Margin = new Thickness(0, 0, 0, 10),
                        Text = request.TypeOfService,
                        FontWeight = FontWeights.DemiBold,
                        FontSize = 16
                    };
                    requestCard.Children.Add(typeTextBlock);
                    TextBlock statusTextBlock = new TextBlock()
                    {
                        Foreground = Brushes.White,
                        Margin = new Thickness(0, 0, 0, 10),
                        Text = "Status: ",
                        FontWeight = FontWeights.DemiBold,
                        FontSize = 18
                    };
                    if (request.Status)
                    {
                        statusTextBlock.Text += "DONE!";
                    }
                    else { statusTextBlock.Text += "In progress.."; }
                    requestCard.Children.Add(statusTextBlock);
                    border.Child = requestCard;
                    serviceStackPanel.Children.Insert(0, border);
                }
            }

        }
        public static void DisplayCombobox(ComboBox combobox)
        {
            string filePath = "DB.json";
            string json = File.ReadAllText(filePath);
            Entity _entity = JsonConvert.DeserializeObject<Entity>(json) ?? new Entity();
            foreach (Services services in _entity.Services)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = services.ServiceName + $" (${services.Cost})";
                combobox.Items.Add(comboBoxItem);
            }
        }

        //SERVICE
        public static void AddService(TextBox nameBox, TextBox descriptionBox, TextBox costBox)
        {
            string filePath = "DB.json";
            string json = File.ReadAllText(filePath);
            Entity _entity = JsonConvert.DeserializeObject<Entity>(json) ?? new Entity();

            if (nameBox.Text.Length > 50)
            {
                MessageBox.Show("The name of service must not exceed 20 characters");
                return;
            }
            else
            {
                _entity.Services.Add(new Services(nameBox.Text, descriptionBox.Text, int.Parse(costBox.Text)));
                MessageBox.Show("The service has been created");
            }
            string save = JsonConvert.SerializeObject(_entity, Formatting.Indented);
            File.WriteAllText(filePath, save);
        }
        public static void DeleteService(TextBox textBox)
        {
            string filePath = "DB.json";
            string json = File.ReadAllText(filePath);
            Entity _entity = JsonConvert.DeserializeObject<Entity>(json) ?? new Entity();
            _entity.Services.RemoveAll(s => s.ServiceName == textBox.Text);
            MessageBox.Show("The application has been delete!");
            string save = JsonConvert.SerializeObject(_entity, Formatting.Indented);
            File.WriteAllText(filePath, save);
        }

        //REQUEST
        public static void AddRequest(string currentUserName, TextBox descriptionBox, ComboBox comboBox)
        {
            string filePath = "DB.json";
            string json = File.ReadAllText(filePath);
            Entity _entity = JsonConvert.DeserializeObject<Entity>(json) ?? new Entity();
            _entity.Requests.Add(new Request(currentUserName, descriptionBox.Text, comboBox.Text, false));
            MessageBox.Show("The application has been left!");
            string save = JsonConvert.SerializeObject(_entity, Formatting.Indented);
            File.WriteAllText(filePath, save);
        }
        public static void DeleteRequest(TextBox textBox, ComboBox comboBox)
        {
            string filePath = "DB.json";
            string json = File.ReadAllText(filePath);
            Entity _entity = JsonConvert.DeserializeObject<Entity>(json) ?? new Entity();
            _entity.Requests.RemoveAll(r => r.Client == textBox.Text && r.TypeOfService == comboBox.Text);
            MessageBox.Show("The application has been delete!");
            string save = JsonConvert.SerializeObject(_entity, Formatting.Indented);
            File.WriteAllText(filePath, save);
        }
    }
}