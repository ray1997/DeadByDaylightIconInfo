using CommunityToolkit.Mvvm.ComponentModel;
using IconInfo.Internal;

#nullable enable
namespace IconInfo.Icon;

public partial class Power : ObservableObject, IBasic, IFolder
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

    //Killer name that use this power
    [ObservableProperty]
    private string owner;
}