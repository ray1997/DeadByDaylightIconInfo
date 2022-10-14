using CommunityToolkit.Mvvm.ComponentModel;
using IconInfo.Internal;

namespace IconInfo.Information;
public partial class MainFolder : ObservableObject
{
    [ObservableProperty]
    string folder;

    [ObservableProperty]
    string? name;
}
