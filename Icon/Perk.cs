using CommunityToolkit.Mvvm.ComponentModel;
using IconInfo.Internal;

namespace IconPack.Icon;

public partial class Perk : ObservableObject, IBasic, IFolder
{
#nullable enable
    [ObservableProperty]
    private string? folder;
#nullable disable

    [ObservableProperty]
    private string file;

    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private string owner;
}
