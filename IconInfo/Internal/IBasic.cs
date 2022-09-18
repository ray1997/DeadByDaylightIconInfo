﻿namespace IconInfo.Internal;

public interface IBasic
{
    /// <summary>
    /// File name
    /// </summary>
    string File
    {
        get; set;
    }
    /// <summary>
    /// Display name in-game
    /// </summary>
    string Name
    {
        get; set;
    }
}
