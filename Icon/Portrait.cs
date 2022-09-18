using CommunityToolkit.Mvvm.ComponentModel;
using IconInfo.Internal;

namespace IconPack.Icon;

public partial class Portrait : ObservableObject, IFolder, IBasic
{
#nullable enable
    [ObservableProperty]
    private string? folder;
#nullable disable

    [ObservableProperty]
    private string file;

    [ObservableProperty]
    private string name;
}
