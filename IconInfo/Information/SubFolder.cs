using CommunityToolkit.Mvvm.ComponentModel;

namespace IconInfo.Information;
public partial class SubFolder : ObservableObject
{
    [ObservableProperty]
    string folder;

    [ObservableProperty]
    string name;
}
