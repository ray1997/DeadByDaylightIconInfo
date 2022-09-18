﻿using CommunityToolkit.Mvvm.ComponentModel;


namespace IconPack.Icon
{
    public partial class StatusEffect : ObservableObject, IBasic
    {
        [ObservableProperty]
        string file;

        //Power name
        [ObservableProperty]
        string name;
    }
}
