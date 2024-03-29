﻿namespace IconInfo.Internal;

/// <summary>
/// For folders that have subfolders in it
/// </summary>
public interface IFolder
{
#nullable enable
    /// <summary>
    /// If the folder field is null, that's mean it was in a folder, not under DLC folder
    /// </summary>
    string? Folder { get; set; }
#nullable disable
}
