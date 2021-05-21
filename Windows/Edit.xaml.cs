using System.Windows;

namespace Agents.Windows
{

    public partial class Edit : Window
    {
        public Edit()
        {
            InitializeComponent();
        }
        public Main Main;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) //открытие главной формы при закрытии этой
        {
            Main.Show();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Будет когда-то работать");
        }
    }
}
