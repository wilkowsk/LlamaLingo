using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string PersonFirst { get; set; }

    public string PersonLast { get; set; }

    public string PersonLabel { get; set; }

    public string PersonType { get; set; }

    public string PersonStatus { get; set; }

    public string PersonRole { get; set; }

    public DateTime PersonDatetime { get; set; }

    public int PodIdFk { get; set; }

    public int LocationIdFk { get; set; }
}
