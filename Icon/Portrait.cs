using CommunityToolkit.Mvvm.ComponentModel;


namespace IconPack.Icon
{
    public partial class Portrait : ObservableObject, IBasic
    {
        [ObservableProperty]
        string file;

        [ObservableProperty]
        string name;
    }
}
