using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string LocationLabel { get; set; }

    public string LocationDescription { get; set; }

    public string LocationType { get; set; }

    public string LocationStatus { get; set; }

    public int PersonFkAdmn { get; set; }

    public int PersonFkEngr { get; set; }

    public int PersonFkXprt { get; set; }

    public int PersonFkAcad { get; set; }

    public int PersonFkNnai { get; set; }
}
