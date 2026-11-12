using NextDevWPF.UI.Models;
using NextDevWPF.UI.Resources.LookUp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Windows;

namespace NextDevWPF.UI.ViewModel;
public class MainViewModel : ViewModelBase
{
    #region ::: Fields
    private FrameworkElement? _container;
    private ObservableCollection<CommandViewModel>? _sideNavigationMenu;
    #endregion

    public MainViewModel()
    {
        
    }

    #region ::: Properties
    public DateTime DateTimeNow { get; set; } = DateTime.Now;
    public FrameworkElement? Container
    {
        get { return _container; }
        set
        {
            if (value == _container) return;
            _container = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<CommandViewModel>? SideNavigationMenu
    {
        get
        {
            if (_sideNavigationMenu == null)
            {
                _sideNavigationMenu = new ObservableCollection<CommandViewModel>()
                    {
                        new CommandViewModel(
                            System.Windows.Media.Geometry.Parse(IconLookUp.DashboardIcon),
                            StringLookUp.DashobardStr,
                            new RelayCommand(param => ShowCardControl(param), param => true),
                            true
                            ),
                        new CommandViewModel(
                            System.Windows.Media.Geometry.Parse(IconLookUp.InventoryIcon),
                            StringLookUp.InventoryStr,
                            new RelayCommand(param => ShowCardControl(param), param => true),
                            false
                            ),
                        new CommandViewModel(
                            System.Windows.Media.Geometry.Parse(IconLookUp.ReportIcon),
                            StringLookUp.ReportStr,
                            new RelayCommand(param => ShowCardControl(param), param => true),
                            false
                            ),
                        new CommandViewModel(
                            System.Windows.Media.Geometry.Parse(IconLookUp.ContactIcon),
                            StringLookUp.ContactMgntStr,
                            new RelayCommand(param => ShowCardControl(param), param => true),
                            false
                            ),
                        new CommandViewModel(
                            System.Windows.Media.Geometry.Parse(IconLookUp.NotificationIcon),
                            StringLookUp.NotificationStr,
                            new RelayCommand(param => ShowCardControl(param), param => true),
                            false
                            ),
                        new CommandViewModel(
                            System.Windows.Media.Geometry.Parse(IconLookUp.ChatIcon),
                            StringLookUp.ChatStr,
                            new RelayCommand(param => ShowCardControl(param), param => true),
                            false
                            ),
                        new CommandViewModel(
                            System.Windows.Media.Geometry.Parse(IconLookUp.SettingIcon),
                            StringLookUp.AppSettingStr,
                            new RelayCommand(param => ShowCardControl(param), param => true),
                            false
                            ),
                        new CommandViewModel(
                            System.Windows.Media.Geometry.Parse(IconLookUp.CovidIcon),
                            StringLookUp.CovidStr,
                            new RelayCommand(param => ShowCardControl(param), param => true),
                            false
                            ),
                        new CommandViewModel(
                            System.Windows.Media.Geometry.Parse(IconLookUp.HelpIcon),
                            StringLookUp.HelpStr,
                            new RelayCommand(param => ShowCardControl(param), param => true),
                            false
                            ),
                    };
            }
            return _sideNavigationMenu;
        }
    }

    #endregion

    private void ShowCardControl(object? param)
    {
        string? parameter = param as string;
        //MessageBox.Show(parameter);
        SwitchView(parameter);
    }
    public void SwitchView(string? viewName)
    {
        if(viewName == StringLookUp.DashobardStr)
        {
            MessageBox.Show(viewName);
        }
        //switch (viewName)
        //{
        //    case "DashboardView":
        //        //DashboardViewModel Nvm = new DashboardViewModel();
        //        //Container = new DashBoardComponent();
        //        break;
        //    case "NfcCardView":
        //        //NfcEnrollViewModel Rvm = new NfcEnrollViewModel();
        //        //Container = new UserView();
        //        break;
        //    default:
        //        break;
        //}
    }
}
