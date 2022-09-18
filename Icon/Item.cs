using CommunityToolkit.Mvvm.ComponentModel;

using IconPack.Internal;

namespace IconPack.Icon
{
    public partial class Item : ObservableObject, IBasic, IFolder
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
    }
}
