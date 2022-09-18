using CommunityToolkit.Mvvm.ComponentModel;
using IconInfo.Internal;

namespace IconPack.Icon;

public partial class Addon : ObservableObject, IBasic, IFolder
{
#nullable enable
    [ObservableProperty]
    private string? folder;
#nullable disable

    [ObservableProperty]
    private string file;

    //Power name
    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private string _for;

#nullable enable
    [ObservableProperty]
    private string? owner;
#nullable disable
}
