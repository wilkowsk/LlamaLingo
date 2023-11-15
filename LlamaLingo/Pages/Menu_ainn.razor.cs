using Microsoft.AspNetCore.Components;

namespace LlamaLingo.Pages
{
    public partial class Menu_ainn
    {
        [Parameter]
        [SupplyParameterFromQuery]
        public int? pod { get; set; }

        [Parameter]
        [SupplyParameterFromQuery]
        public int? pid { get; set; }
    }
}