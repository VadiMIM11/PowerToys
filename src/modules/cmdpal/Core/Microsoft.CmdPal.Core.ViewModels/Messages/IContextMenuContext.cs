// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel;
using Microsoft.CommandPalette.Extensions;

namespace Microsoft.CmdPal.Core.ViewModels.Messages;

public interface IContextMenuContext : INotifyPropertyChanged
{
    public IEnumerable<IContextItemViewModel> MoreCommands { get; }

    public bool HasMoreCommands { get; }

    public List<IContextItemViewModel> AllCommands { get; }

    /// <summary>
    /// Generates a mapping of key -> command item for this particular item's
    /// MoreCommands. (This won't include the primary Command, but it will
    /// include the secondary one). This map can be used to quickly check if a
    /// shortcut key was pressed
    /// </summary>
    /// <returns>a dictionary of KeyChord -> Context commands, for all commands
    /// that have a shortcut key set.</returns>
    public Dictionary<KeyChord, CommandContextItemViewModel> Keybindings()
    {
        var result = new Dictionary<KeyChord, CommandContextItemViewModel>();

        var menu = MoreCommands;
        if (menu is null)
        {
            return result;
        }

        foreach (var item in menu)
        {
            if (item is CommandContextItemViewModel cmd && cmd.HasRequestedShortcut)
            {
                var key = cmd.RequestedShortcut ?? new KeyChord(0, 0, 0);
                var added = result.TryAdd(key, cmd);
            }
        }

        return result;
    }
}
