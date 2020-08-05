using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FreshMvvm;
using PropertyChanged;
using Services.Cache;

namespace SampleApp.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class BasePageModel : FreshBasePageModel
    {
        protected string PageModelName;
        protected bool IsSaveState;
        public string Data;
        ICacheService _cacheService;


        public BasePageModel(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            IsSaveState = true;
            PageModelName = GetType().ToString();
            base.ViewIsAppearing(sender, e);
        }

        protected async override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
            if (!string.IsNullOrEmpty(PageModelName) && IsSaveState)
                await _cacheService.SaveCachedDataAsync(PageDataState.GetState(PageModelName, Data));
        }

        public async Task NavigateToPage(Type type, bool forcePushPage = false)
        {
            Type pageModelType = Type.GetType(type?.ToString());
            if (pageModelType == null)
                return;

            var methods = typeof(PageModelCoreMethods).GetTypeInfo().GetDeclaredMethods("PushPageModel").ToList();
            MethodInfo generic = methods.FirstOrDefault(m => m.GetGenericArguments().Count() == 1 && m.GetParameters().Count() == 1)?.MakeGenericMethod(pageModelType);
            generic?.Invoke(CoreMethods, new object[] { true });
        }
    }

    [AddINotifyPropertyChangedInterface]
    public class BaseDataModel
    {

    }


}
