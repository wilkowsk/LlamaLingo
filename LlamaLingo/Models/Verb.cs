using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class Verb
{
    public int VerbId { get; set; }

    public string VerbLabel { get; set; }

    public string VerbDescription { get; set; }

    public string VerbType { get; set; }

    public string VerbStatus { get; set; }

    public int PodIdFk { get; set; }

    public int UrlIdPk { get; set; }
}
