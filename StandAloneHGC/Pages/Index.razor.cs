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
using StandAloneHGC.Shared;
using Radzen.Blazor;
using Radzen;
using StandAloneHGC.Core;

namespace StandAloneHGC.Pages
{
    public partial class Index
    {
        private int want = 0;
        private HyperResult? hyperResult;
        private void HandleHyperResults(ValueTuple<int, HyperResult> results)
        {
            want = results.Item1;
            hyperResult = results.Item2;
            StateHasChanged();
                
        }
    }
}