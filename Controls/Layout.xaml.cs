using Agents.Classes;
using Agents.Windows;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Agents.Controls
{
    public partial class Layout : UserControl
    {
        public Layout()
        {
            InitializeComponent();
        }
        public Main Main; 

        private void Edit_Click(object sender, RoutedEventArgs e) //открытие формы Редактирование
        {
            Edit edit = new Edit();
            edit.Name.Text = (string)Name.Content;
            edit.Type.Text = (string)Type.Content;
            edit.Priority.Text = Priority.Content.ToString();
            edit.Phone.Text = (string)Phone.Content;
            edit.ProductCount.Text = (string)ProductCount.Content.ToString();
            edit.Phone.Text = Phone.Content.ToString();
            edit.Logo.Source = Logo.Source;
            edit.Adress.Text = (string)Adress.Content;
            edit.INN.Text = (string)INN.Content;
            edit.KPP.Text = (string)KPP.Content;
            edit.DirectorName.Text = (string)DirectorName.Content;
            edit.Email.Text = (string)Email.Content;
            edit.Main = Main;
            Main.Hide();
            edit.ShowDialog();

           
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                if (MessageBox.Show("Удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"Delete FROM Agent WHERE ID = {ID.Content}", connection);
                    command.ExecuteNonQuery();
                    Main.Load_data("");
                }
                else
                {

                }
            }
        }

        private void Email_Loaded(object sender, RoutedEventArgs e)
        {
            if (int.Parse(ProductCount.Content.ToString()) < 5)
            {
                Discount.Content = "0%";
            }
            else if (int.Parse(ProductCount.Content.ToString()) >= 5 && int.Parse(ProductCount.Content.ToString()) < 10)
            {
                Discount.Content = "5%";
            }
            else if (int.Parse(ProductCount.Content.ToString()) >= 10 && int.Parse(ProductCount.Content.ToString()) < 20)
            {
                Discount.Content = "10%";
            }
            else if (int.Parse(ProductCount.Content.ToString()) >= 20 && int.Parse(ProductCount.Content.ToString()) < 25)
            {
                Discount.Content = "20%";
            }
            else
            {
                Discount.Content = "25%";
            }
        }
    }
}
