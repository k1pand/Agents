using Agents.Windows;
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
            Edit open = new Edit();
            open.Main = Main;
            Main.Hide();
            open.ShowDialog();
        }
    }
}
