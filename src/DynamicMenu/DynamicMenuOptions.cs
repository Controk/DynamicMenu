using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicMenu
{
    public class DynamicMenuOptions
    {
        /// <summary>
        /// Optional. The HTML Skeleton to menu
        /// </summary>
        /// <example>
        ///   &lt;nav class="navbar-default navbar-static-side" role="navigation"&gt;
        ///     &lt;ul&gt;{0}&lt;/ul&gt;
        ///   &lt;/nav&gt;
        /// </example>
        public static string MenuSkel;

        /// <summary>
        /// The HTML Skeleton to item in menu (without nodes)
        /// </summary>
        /// <example>
        ///   &lt;li&gt;
        ///     &lt;a href="{1}"&gt;{2} {0}&lt;/a&gt;
        ///   &lt;/li&gt;
        /// </example>
        public static string ItemMenuSkel;

        /// <summary>
        /// The HTML Skeleton to icons
        /// </summary>
        /// <example>
        ///   &lt;i class="fa {0}"&gt;&lt;/i&gt;
        /// </example>
        public static string IconSkel;

        /// <summary>
        /// </summary>
        /// <example>
        ///   &lt;span class="fa arrow"&gt;&lt;/span&gt;
        /// </example>
        public static string ArrowIconToItemMenuWithNodes { get; set; }

        /// <summary>
        /// The HTML Skeleton to item with nodes
        /// </summary>
        /// <example>
        ///   &lt;li&gt;
        ///     &lt;a href="{1}"&gt;{2} &lt;span class="nav-label"&gt;{0}&lt;/span&gt; {3}&lt;/a&gt;
        ///     &lt;ul class="nav nav-second-level collapse"&gt;{4}&lt;/ul&gt;
        ///   &lt;/li&gt;
        /// </example>
        public static string ItemMenuWithNodesSkel;

        /// <summary>
        /// The HTML Skeleton to node item
        /// </summary>
        /// <example>
        ///   &lt;li&gt;&lt;a href="{1}"&gt;{2} {0}&lt;/a&gt;&lt;/li&gt;
        /// </example>
        public static string ItemNodesSkel;


        public static IEnumerable<NavigationModel> NavigationModel;
        public static IEnumerable<RestrictedItemMenuModel> MenuResctrictions;

        public DynamicMenuOptions(IEnumerable<NavigationModel> navigationModel, IEnumerable<RestrictedItemMenuModel> menuResctrictions = null)
        {
            NavigationModel = navigationModel;
            MenuResctrictions = menuResctrictions;
        }
    }
}
