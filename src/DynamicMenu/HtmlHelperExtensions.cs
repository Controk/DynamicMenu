using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicMenu;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Microsoft.AspNetCore.Mvc
{
    public static partial class HtmlHelperExtensions
    {
        public static string RenderMenu(this IHtmlHelper htmlHelper)
        {
            return String.Format(DynamicMenuOptions.MenuSkel, _renderItemMenu(htmlHelper));
        }

        public static string RenderItemMenu(this IHtmlHelper htmlHelper)
        {
            return _renderItemMenu(htmlHelper);
        }

        private static string _renderItemMenu(IHtmlHelper htmlHelper)
        {
            var menuContainer = new StringBuilder();

            var navigationModel = DynamicMenuOptions.NavigationModel.OrderBy(x => x.Order);

            var urlHelper = new UrlHelper(htmlHelper.ViewContext);

            foreach (var navigationItem in navigationModel)
            {
                if (navigationItem.Nodes != null && navigationItem.Nodes.Any())
                {
                    var navigationNodeItems =
                        DynamicMenuOptions.MenuResctrictions != null && DynamicMenuOptions.MenuResctrictions.Any()
                            ? navigationItem.Nodes.Where(
                                x =>
                                    DynamicMenuOptions.MenuResctrictions.Any(
                                        y => y.Controller == x.Controller && y.Action == x.Action))
                            : navigationItem.Nodes;

                    var nodeItems = navigationNodeItems.OrderBy(x => x.Order).Select(
                        model => String.Format(
                            DynamicMenuOptions.ItemNodesSkel,
                            model.Title,
                            urlHelper.Action(model.Action, model.Controller),
                            model.Icon
                        )).ToArray();

                    if (nodeItems.Any())
                        menuContainer.Append(String.Format(
                            DynamicMenuOptions.ItemMenuWithNodesSkel,
                            navigationItem.Title,
                            urlHelper.Action(navigationItem.Action, navigationItem.Controller),
                            navigationItem.Icon,
                            DynamicMenuOptions.ArrowIconToItemMenuWithNodes,
                            String.Join("", nodeItems)
                        ));
                }
                else if (
                    DynamicMenuOptions.MenuResctrictions == null ||
                    !DynamicMenuOptions.MenuResctrictions.Any() ||
                    DynamicMenuOptions.MenuResctrictions.Any(x => x.Controller == navigationItem.Controller && x.Action == navigationItem.Action)
                )
                {
                    menuContainer.Append(String.Format(
                        DynamicMenuOptions.ItemMenuSkel,
                        navigationItem.Title,
                        urlHelper.Action(navigationItem.Action, navigationItem.Controller),
                        navigationItem.Icon
                    ));
                }
            }

            return menuContainer.ToString();
        }
    }
}
