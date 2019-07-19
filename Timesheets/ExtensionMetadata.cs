using Infrastructure;
using System.Collections.Generic;

namespace Timesheets
{
    public class ExtensionMetadata : IExtensionMetadata
    {
        public IEnumerable<StyleSheet> StyleSheets => new StyleSheet[] { };

        public IEnumerable<Script> Scripts => new Script[] { };

        public IEnumerable<MenuItem> MenuItems
        {
            get
            {
                return new MenuItem[]
                {
                    new MenuItem("/timesheet", "Timesheet", 700),
                    new MenuItem("/employeeDetail", "EmployeeDetail", 300),
                    new MenuItem("/project", "Project", 400),
                    new MenuItem("/sprint", "Sprint", 500),
                    new MenuItem("/task", "Task", 600)
                };
            }
        }
    }
}
