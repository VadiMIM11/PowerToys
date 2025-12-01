// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.Extensions.Logging;

namespace Microsoft.CmdPal.Core.ViewModels;

public partial class LoadingPageViewModel : PageViewModel
{
    public LoadingPageViewModel(IPage? model, AppExtensionHost host, ILogger logger)
        : base(model, host, logger)
    {
        ModelIsLoading = true;
        IsInitialized = false;
    }
}
