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

namespace StandAloneHGC.Components
{
    public partial class CalcInputs
    {
        [Parameter]
        public EventCallback<ValueTuple<int, HyperResult>> OnHyperResultCalc { get; set; }
        private class FunctionModel
        {
            public int Want { get; set; } = 1;
            public int Total { get; set; } = 45;
            public int Success { get; set; } = 9;
            public int Attempts { get; set; } = 2;
        }
        private FunctionModel functionModel = new();
        private void HandleValidSubmit(FunctionModel data)
        {
            var result = HyperGeometricCalc.GetHyperResult(data.Want, data.Total, data.Success, data.Attempts);
            OnHyperResultCalc.InvokeAsync((data.Want, result));
        }
    }
}