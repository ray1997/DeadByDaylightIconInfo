using CommunityToolkit.Mvvm.ComponentModel;

using IconPack.Internal;

namespace IconPack.Icon
{
    public partial class Addon : IBasic, IFolder
    {
#nullable enable
        [ObservableProperty]
        string? folder;
#nullable disable

        [ObservableProperty]
        string file;

        //Power name
        [ObservableProperty]
        string name;

        [ObservableProperty]
        string _for;

        [ObservableProperty]
        string owner;
    }
}
