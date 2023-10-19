using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class Pod
{
    public int PodId { get; set; }

    public string PodLabel { get; set; }

    public string PodDescription { get; set; }

    public string PodType { get; set; }

    public string PodStatus { get; set; }

    public string PodChannel { get; set; }

    public string PodUrlBase { get; set; }

    public int PersonIdFk { get; set; }

    public int LocationIdFk { get; set; }
}
