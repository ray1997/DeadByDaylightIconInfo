using CommunityToolkit.Mvvm.ComponentModel;
using IconInfo.Internal;

namespace IconPack.Icon;

public partial class DailyRitual : ObservableObject, IBasic
{
    [ObservableProperty]
    private string file;

    //Power name
    [ObservableProperty]
    private string name;
}
