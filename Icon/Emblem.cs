using CommunityToolkit.Mvvm.ComponentModel;


namespace IconPack.Icon
{
    public partial class Emblem : ObservableObject, IBasic
    {
        [ObservableProperty]
        string file;

        [ObservableProperty]
        string name;
    }
}
