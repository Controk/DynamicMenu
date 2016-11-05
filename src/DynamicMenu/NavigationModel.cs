using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicMenu
{
    public class NavigationModel
    {
        public string Title { get; set; }
        public string Resource { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }

        public IEnumerable<NavigationModel> Nodes { get; set; }
    }
}
