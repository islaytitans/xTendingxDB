using System;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Elements;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Elements
{
    [Serializable]
    public class BrochureDownload : Sitecore.Analytics.Model.Framework.Element, IBrochureDownload
    {
        private const string IdName = "Id";
        private const string TitleName = "Title";
        private const string ProductTitleName = "ProductTitle";
        private const string ProductSkuName = "ProductSku";

        public BrochureDownload()
        {
            EnsureAttribute<string>(IdName);
            EnsureAttribute<string>(TitleName);
            EnsureAttribute<string>(ProductTitleName);
            EnsureAttribute<string>(ProductSkuName);
        }

        public string Id
        {
            get { return GetAttribute<string>(IdName); }
            set { SetAttribute(IdName, value); }
        }

        public string Title
        {
            get { return GetAttribute<string>(TitleName); }
            set { SetAttribute(TitleName, value); }
        }

        public string ProductTitle
        {
            get { return GetAttribute<string>(ProductTitleName); }
            set { SetAttribute(ProductTitleName, value); }
        }

        public string ProductSku
        {
            get { return GetAttribute<string>(ProductSkuName); }
            set { SetAttribute(ProductSkuName, value); }
        }
    }
}
