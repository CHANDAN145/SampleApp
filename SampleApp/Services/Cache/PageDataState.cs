using System;
namespace Services.Cache
{
    public class PageDataState
    {
        public string PageName { get; private set; }           // PageName should be the exactly the name of the PageModel. Needed for navigation
        public string PageDataModel { get; private set; }      // PageData saved as json string
        public static PageDataState GetState(string pageName, string data)
        {
            PageDataState dataState = new PageDataState
            {
                PageName = pageName,
                PageDataModel = data
            };
            return dataState;
        }
    }
}
