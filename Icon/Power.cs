﻿using CommunityToolkit.Mvvm.ComponentModel;

using IconPack.Internal;

#nullable enable
namespace IconPack.Icon
{
    public partial class Power : ObservableObject, IBasic, IFolder
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

        //Killer name that use this power
        [ObservableProperty]
        string owner;
    }
}