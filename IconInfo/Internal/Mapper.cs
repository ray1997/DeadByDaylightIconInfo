﻿using CsvHelper.Configuration;
using IconInfo.Icon;

namespace IconInfo.Internal;

internal class GenericMapper<T> : ClassMap<IBasic> where T : IBasic
{
    public GenericMapper()
    {
        Map(m => m.File).Name("File");
        Map(m => m.Name).Name("Name");
    }
}

internal class GenericWithFolderMapper<T> : ClassMap<T> where T : IBasic, IFolder
{
    public GenericWithFolderMapper()
    {
        Map(m => m.Folder).Name("Folder");
        Map(m => m.File).Name("File");
        Map(m => m.Name).Name("Name");
    }
}

internal class PowerMapper : ClassMap<Power>
{
    public PowerMapper()
    {
        Map(m => m.Folder).Name("Folder");
        Map(m => m.File).Name("File");
        Map(m => m.Name).Name("Name");
        Map(m => m.Owner).Name("Owner");
    }
}

internal class AddonMapper : ClassMap<Addon>
{
    public AddonMapper()
    {
        Map(m => m.Folder).Name("Folder");
        Map(m => m.File).Name("File");
        Map(m => m.Name).Name("Name");
        Map(m => m.For).Name("For");
        Map(m => m.Owner).Name("Owner");
    }
}
internal class PerkMapper : ClassMap<Perk>
{
    public PerkMapper()
    {
        Map(m => m.Folder).Name("Folder");
        Map(m => m.File).Name("File");
        Map(m => m.Name).Name("Name");
        Map(m => m.Owner).Name("Owner");
    }
}

