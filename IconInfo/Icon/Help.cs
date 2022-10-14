using CommunityToolkit.Mvvm.ComponentModel;
using IconInfo.Internal;

namespace IconInfo.Icon;

public partial class Help : ObservableObject, IBasic
{
    [ObservableProperty]
    private string file;

    //Power name
    [ObservableProperty]
    private string name;
}
