using System;
using FreshMvvm;
using Services;
using FreshTinyIoC;
using Xamarin.Forms;
using Services.Cache;

namespace SampleApp.PageModels
{
    public class FirstPageModel : BasePageModel
    {

        ICloseApp _closeApp;
        public FirstDataModel DataModel { get; set; }
        IValidationService _validationService;
        public Command CloseCommand { get; set; }

        public FirstPageModel(ICloseApp closeApp, ICacheService cacheService) : base(cacheService)
        {
            _closeApp = closeApp;
            _validationService = FreshTinyIoCContainer.Current.Resolve<IValidationService>();
            CloseCommand = new Command(CloseAction);
        }

        private void CloseAction(object obj)
        {
            _closeApp.CloseApp();
        }

        /// <summary>
        /// A reference to the current page, that's automatically filled, on push
        /// </summary>
        public Page CurrentPage { get; set; }

        /// <summary>
        /// Core methods are basic built in methods for the App including Pushing, Pop and Alert
        /// </summary>
        public IPageModelCoreMethods CoreMethods { get; set; }

        /// <summary>
        /// This method is called when a page is Pop'd, it also allows for data to be returned.
        /// </summary>
        /// <param name="returndData">This data that's returned from </param>
        public override void ReverseInit(object returndData) { }

        /// <summary>
        /// This method is called when the PageModel is loaded, the initData is the data that's sent from pagemodel before
        /// </summary>
        /// <param name="initData">Data that's sent to this PageModel from the pusher</param>
        public override void Init(object initData) { }

        /// <summary>
        /// This method is called when the view is disappearing. 
        /// </summary>
        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This methods is called when the View is appearing
        /// </summary>
        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
        }
    }

    public class FirstDataModel
    {
        public int Name { get; set; } = 4;

    }
}
