using NextDevWPF.UI.ViewModel;
using System.Windows;

namespace NextDevWPF.UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new MainViewModel();   
    }
}