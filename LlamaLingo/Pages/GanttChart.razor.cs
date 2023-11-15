using System.Collections.Generic;
using System.Linq;

namespace LlamaLingo.Pages
{
    public partial class GanttChart
    {
        IEnumerable<LlamaLingo.Models.Task> TaskList;
        protected override void OnInitialized()
        {
            TaskList = db.Set<LlamaLingo.Models.Task>().ToList();
        }

        public string[] Searchfields = new string[]
        {
            "TaskId",
            "TaskLabel",
            "TaskStartDate",
            "TaskFinishDate",
            "TaskDuration",
            "TaskProgress",
            "ParentIdFk"
        };
    }
}