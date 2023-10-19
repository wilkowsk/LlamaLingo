using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class ViewPodBase
{
    public int PodId { get; set; }

    public int LocationIdFk { get; set; }

    public string LocationLabel { get; set; }

    public string LocationDescription { get; set; }

    public string PersonFirst { get; set; }

    public string PersonLast { get; set; }

    public string PodLabel { get; set; }

    public string PodDescription { get; set; }

    public string PodChannel { get; set; }
}
