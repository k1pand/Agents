using Agents.Classes;
using Agents.Controls;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Agents.Windows
{

    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        internal void Load_data(string s)
        {
            list.Children.Clear(); //очищение формы
            using (SqlConnection connection = new SqlConnection(Connection.String)) 
            {
                connection.Open(); //открытие соединения с БД
                SqlCommand command = new SqlCommand($@"SELECT AgentType.Title, 
                                                              Agent.Title AS Expr1, 
                                                              ProductSale.ProductCount, 
                                                              Agent.Phone, 
                                                              Agent.Priority,
                                                              Agent.Logo
                                                         FROM Agent INNER JOIN
                                                              AgentType ON Agent.AgentTypeID = AgentType.ID INNER JOIN
                                                              ProductSale ON Agent.ID = ProductSale.AgentID 
                                                              WHERE Agent.Title like '%{Search.Text}%' or Agent.Phone like '{Search.Text}%' ORDER BY NEWID()" + s, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Layout agent = new Layout();
                        agent.Type.Content = reader[0] + " | ";
                        agent.Name.Content= reader[1].ToString();
                        agent.ProductCount.Content = reader[2] + " продаж за год";
                        agent.Phone.Content = reader[3];
                        agent.Priority.Content = reader[4];
                        agent.Logo.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\" + reader[5].ToString().Replace(" agents", "agents")));
                        agent.Main = this;
                        list.Children.Add(agent);
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) //загрузка объекта Load_data
        {
            Load_data("");
        }

        private void Add_Click(object sender, RoutedEventArgs e) //открытие формы
        {
            Edit open = new Edit();
            open.Main = this;
            open.Show();
            this.Hide();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e) //поиск по изменению текста
        {
            Load_data("");
        }

        private void Filtr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Filtr.Text.ToString() == "МФО")
            {
                list.Visibility = System.Windows.Visibility.Collapsed;
            }
   
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Sort.Text)
            {
                case "Наименование":

                    break;
            }
        }
    }
}
