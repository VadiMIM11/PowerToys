// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CmdPal.UI.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Navigation;

namespace Microsoft.CmdPal.UI.Settings;

public sealed partial class ExtensionPage : Page
{
    public ProviderSettingsViewModel? ViewModel { get; private set; }

    public ExtensionPage(ContentPage contentPage)
    {
        this.InitializeComponent();

        var contentBinding = new Binding()
        {
            Source = ViewModel?.SettingsPage,
            Mode = BindingMode.OneWay,
        };
        contentPage.SetBinding(
            Microsoft.UI.Xaml.Controls.Control.DataContextProperty,
            contentBinding);

        SettingsContentFrame.Content = contentPage;
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        ViewModel = e.Parameter is ProviderSettingsViewModel vm
            ? vm
            : throw new ArgumentException($"{nameof(ExtensionPage)} navigation args should be passed a {nameof(ProviderSettingsViewModel)}");
    }
}
