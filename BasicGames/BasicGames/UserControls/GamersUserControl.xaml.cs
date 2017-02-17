using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BasicGames.UserControls
{
    /// <summary>
    /// Interaction logic for GamersUserControl.xaml
    /// </summary>
    public partial class GamersUserControl : UserControl
    {
        public GamersUserControl()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {
            GamerUserControl.Visibility = Visibility.Visible;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddGamerUserControl.Visibility = Visibility.Visible;
        }
    }
}
