using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class Noun
{
    public int NounId { get; set; }

    public string NounLabel { get; set; }

    public string NounDescription { get; set; }

    public string NounType { get; set; }

    public string NounStatus { get; set; }

    public int PodIdFk { get; set; }

    public int UrlIdPk { get; set; }
}
