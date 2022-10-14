using CommunityToolkit.Mvvm.ComponentModel;
using IconInfo.Internal;

namespace IconInfo.Icon;

public partial class StoreBackground : ObservableObject, IFolder, IBasic
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
