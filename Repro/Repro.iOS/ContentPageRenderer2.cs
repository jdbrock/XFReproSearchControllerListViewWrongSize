using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Repro.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ContentPage), typeof(ContentPageRenderer2))]
namespace Repro.iOS
{
    public class ContentPageRenderer2 : PageRenderer, IUISearchResultsUpdating, IUISearchBarDelegate
    {
        private UISearchController _searchController;

        public override void WillMoveToParentViewController(UIViewController parent)
        {
            base.WillMoveToParentViewController(parent);

            if (_searchController == null)
            {
                _searchController = new UISearchController(searchResultsController: null)
                {
                    HidesNavigationBarDuringPresentation = false,
                    DimsBackgroundDuringPresentation = false
                };

                _searchController.SearchResultsUpdater = this;

                parent.NavigationItem.SearchController = _searchController;
                parent.NavigationItem.HidesSearchBarWhenScrolling = false;
            }
        }

        public void UpdateSearchResultsForSearchController(UISearchController searchController) { }
    }
}