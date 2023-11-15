using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using global::Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using LlamaLingo;
using LlamaLingo.Shared;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Gantt;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Navigations;
using LlamaLingo.Models;
using System.Data.SqlClient;
using System.Data;

namespace LlamaLingo.Pages
{
    public partial class Menu_engr
    {
        [Parameter]
        [SupplyParameterFromQuery]
        public int? pod { get; set; }

        [Parameter]
        [SupplyParameterFromQuery]
        public int? pid { get; set; }
    }
}