using CommunityToolkit.Mvvm.ComponentModel;
using IconInfo.Internal;

namespace IconInfo.Icon;

public partial class Archive : ObservableObject, IBasic, IFolder
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
}
