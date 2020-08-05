using System;
using System.Linq;
using Services.Cache;
using Xamarin.Forms;

namespace SampleApp.PageModels
{
    public class HomePageModel : BasePageModel
    {
        ICacheService _cacheService;
        public Command NextPageCommand { get; set; }


        public HomePageModel(ICacheService cacheService) : base(cacheService)
        {
            _cacheService = cacheService;
            NextPageCommand = new Command(NextPageAction);
        }

        private async void NextPageAction(object obj)
        {
           await CoreMethods.PushPageModel<SecondPageModel>();
        }

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            IsSaveState = false;
            var dataStates = await _cacheService.GetAllPagesAsync();
            if (dataStates != null && dataStates.Any())
            {
                Type pageModelType = Type.GetType(dataStates.LastOrDefault());
                if (pageModelType != null && !pageModelType.ToString().Contains(PageModelName))
                {
                    await NavigateToPage(pageModelType);
                }
            }
        }

    }
}
