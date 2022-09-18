using CommunityToolkit.Mvvm.ComponentModel;
using IconInfo.Internal;

namespace IconPack.Icon;

public partial class Emblem : ObservableObject, IBasic
{
    [ObservableProperty]
    private string file;

    [ObservableProperty]
    private string name;
}
