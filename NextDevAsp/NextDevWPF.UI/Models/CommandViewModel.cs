using NextDevWPF.UI.ViewModel;
using System.Windows.Input;
using System.Windows.Media;

namespace NextDevWPF.UI.Models;
public class CommandViewModel
{
    /* This class Describ the behavior of all application
     * Button control such as Icon, displayname, action and 
     * trigger check or uncheck
     */
    public Geometry? IconData { get; set; }
    public string DisplayName { get; set; } = "";
    public ICommand? Command { get; set; }
    public bool IsCheck { get; set; }

    public CommandViewModel() { }
    public CommandViewModel(Geometry iconData, string displayName, ICommand command, bool isCheck)
    {
        IconData = iconData;
        DisplayName = displayName;
        Command = command;
        IsCheck = isCheck;
    }
    public CommandViewModel(Geometry iconData, string displayName, ICommand command)
    {
        IconData = iconData;
        DisplayName = displayName;
        Command = command;
    }
    public CommandViewModel(Geometry iconData, ICommand command)
    {
        IconData = iconData;
        Command = command;
    }
}