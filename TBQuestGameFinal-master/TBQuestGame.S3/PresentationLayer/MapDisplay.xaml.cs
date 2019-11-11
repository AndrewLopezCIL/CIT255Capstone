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
using System.Windows.Shapes;
using TBQuestGame.BusinessLayer;
using TBQuestGame.DataLayer;
using TBQuestGame.Properties;
using TBQuestGame.Models;
namespace TBQuestGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for MapDisplay.xaml
    /// </summary>
    public partial class MapDisplay : Window
    {  
        public MapDisplay()
        { 
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
