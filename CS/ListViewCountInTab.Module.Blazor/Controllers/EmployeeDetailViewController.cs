using System.Collections;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Layout;
using ListViewCountInTab.Module.BusinessObjects;

namespace ListViewCountInTab.Module.Blazor.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class EmployeeDetailViewController : ViewController<DetailView>
    {
        public EmployeeDetailViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(Employee);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            View.DelayedItemsInitialization = false;
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
            RefreshTabCaptions();
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void RefreshTabCaptions()
        {
            foreach (var item in View.Items)
            {
                var listPropertyEditor = item as DevExpress.ExpressApp.Blazor.Editors.BlazorListPropertyEditor;
                if (listPropertyEditor != null)
                {
                    var collection = listPropertyEditor.MemberInfo.GetValue(item.CurrentObject);
                    if (collection != null && collection is ICollection)
                    {
                        listPropertyEditor.Caption = ClearItemCountInTabCaption(listPropertyEditor.Caption);
                        int count = (collection as ICollection).Count;

                        if (count > 0)
                        {
                            listPropertyEditor.Caption = $"{item.Caption} ({count})";
                        }
                    }
                }
            }
        }

        private string ClearItemCountInTabCaption(string caption)
        {
            if (caption.Contains("("))
            {
                var captionSplitByDash = caption.Split('(');
                return captionSplitByDash[0].Trim();
            }
            return caption;
        }
    }
}
