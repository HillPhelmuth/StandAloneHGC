using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using StandAloneHGC;
using StandAloneHGC.Core;
using StandAloneHGC.Shared;
using Radzen.Blazor;
using Radzen;

namespace StandAloneHGC.Components
{
    public partial class CalcResult
    {
        [Parameter]
        [EditorRequired]
        public HyperResult HyperResult { get; set; } = default!;
        [Parameter]
        [EditorRequired]
        public int NumberYouWant { get; set; }
    }
}