using System;
using DevExpress.ExpressApp.Xpo;

namespace ListViewCountInTab.Blazor.Server.Services {
    public class XpoDataStoreProviderAccessor {
        public IXpoDataStoreProvider DataStoreProvider { get; set; }
    }
}
