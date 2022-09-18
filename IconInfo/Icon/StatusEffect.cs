using CommunityToolkit.Mvvm.ComponentModel;
using IconInfo.Internal;

namespace IconInfo.Icon;

public partial class StatusEffect : ObservableObject, IBasic
{
    [ObservableProperty]
    private string file;

    //Power name
    [ObservableProperty]
    private string name;
}
