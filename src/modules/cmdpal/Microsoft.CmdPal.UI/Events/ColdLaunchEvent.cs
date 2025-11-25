// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using Microsoft.CmdPal.Core.Common.Services.Telemetry;
using Microsoft.PowerToys.Telemetry;

namespace Microsoft.CmdPal.UI.Events;

[EventData]
[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)]
public class ColdLaunchEvent : TelemetryEventBase
{
    public override PartA_PrivTags PartA_PrivTags => PartA_PrivTags.ProductAndServiceUsage;

    public ColdLaunchEvent()
    {
        EventName = "CmdPal_ColdLaunch";
    }
}
