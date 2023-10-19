using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class Pype
{
    public string PypeId { get; set; }

    public string PypeType { get; set; }

    public string PypeLabel { get; set; }

    public string PypeStatus { get; set; }

    public string PypeDesc { get; set; }

    public string PypeLink { get; set; }

    public int PodIdFk { get; set; }
}
