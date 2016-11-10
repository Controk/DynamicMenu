using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public static IEnumerable<NavigationModel> GenerateNavigationModelByFile(string filepath)
        {
            IEnumerable<NavigationModel> response = new List<NavigationModel>();

            if (File.Exists(filepath))
            {
                response = JsonConvert.DeserializeObject<NavigationModel[]>(File.ReadAllText(filepath));
            }

            return response;
        }
    }
}
