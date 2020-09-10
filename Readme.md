# XAF for Blazor - How to show the number of a nested ListView's items in tab captions

>At the moment, tab captions are not updated immediately after the ListView item count is modified.

In this example, we demonstrate how to show the number of nested ListViews' items in tab captions. This is done in the following controller: [EmployeeDetailViewController.cs](./CS/ListViewCountInTab.Module.Blazor/Controllers/EmployeeDetailViewController.cs). Follow the steps listed below to accomplish this task:
1. Create a controllers in the Blazor module project.
2. Set the **TargetViewType** property to the **DetailView** and the **TargetObjectType** to your business object type in the controller. As a result, the controller will only be activated in detail forms for your business objects.
3. In the **OnActivated** method, set the [CompositeView.DelayedItemsInitialization](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.CompositeView.DelayedItemsInitialization) to **false** to initialize all View Item controls immediately when the Detail View is created. This will allow you to obtain the number of ListView items.
8. Loop through the [View Items](https://docs.devexpress.com/eXpressAppFramework/112612/concepts/ui-construction/view-items) in the **CompositeView.ViewControlsCreated** event handler to access *BlazorListPropertyEditors*. Then, use the **BlazorListPropertyEditor.MemberInfo.GetValue** to get the collection of editor's items and evaluate the nubmer of items. Finally, update tab captions in the editors accordingly. For more details, review the implementations of the following method in this example: [RefreshTabCaptions](./CS/ListViewCountInTab.Module.Blazor/Controllers/EmployeeDetailViewController.cs#L36).

<!-- default file list -->
*Files to look at*:

* [EmployeeDetailViewController.cs](./CS/ListViewCountInTab.Module.Blazor/Controllers/EmployeeDetailViewController.cs)
<!-- default file list end -->