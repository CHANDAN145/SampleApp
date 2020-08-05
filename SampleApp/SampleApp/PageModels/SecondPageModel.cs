using System;
using Newtonsoft.Json;
using Services.Cache;
using Xamarin.Forms;

namespace SampleApp.PageModels
{
    public class SecondPageModel : BasePageModel
    {
        ICacheService _cacheService;
        public SecondPageDataModel DataModel { get; set; }

        public Command SubmitCommand { get; set; }

        public Command EntryChangedCommand { get; set; }

        public SecondPageModel(ICacheService cacheService) : base(cacheService)
        {
            _cacheService = cacheService;
            SubmitCommand = new Command(SubmitAction);
            EntryChangedCommand = new Command(EntryChangedAction);
        }

        private void EntryChangedAction(object obj)
        {
            //
        }

        private async void SubmitAction(object obj)
        {
            await CoreMethods.PushPageModel<FirstPageModel>();
        }

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            Data = await _cacheService.GetCachedDataAsync(PageModelName);

            if (string.IsNullOrEmpty(Data))
                DataModel = new SecondPageDataModel();
            else
                DataModel = JsonConvert.DeserializeObject<SecondPageDataModel>(Data);
        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            Data = JsonConvert.SerializeObject(DataModel);
            base.ViewIsDisappearing(sender, e);
        }
    }

    public class SecondPageDataModel : BaseDataModel
    {
        public int NumberOfCartons { get; set; }

        public int NumberOfShelves { get; set; }

        public TimeSpan SelectedTime { get; set; }
    }
}
