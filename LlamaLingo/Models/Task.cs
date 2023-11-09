using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string TaskLabel { get; set; }

    public string TaskType { get; set; }

    public string TaskStatus { get; set; }

    public string TaskDescription { get; set; }

    public DateTime TaskStartDate { get; set; }

    public DateTime TaskFinishDate { get; set; }

    public DateTime TaskEntryDate { get; set; }

    public short TaskLevel { get; set; }

    public string TaskDuration { get; set; }

    public int TaskProgress { get; set; }

    public int ParentIdFk { get; set; }

    public int NovaIdFk { get; set; }

    public int PersonIdFk { get; set; }
}
