using System.Windows;
using System.Windows.Controls;

namespace Names.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public ContentControl MainRegionControl => MainRegion;
    }
}