using System;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Elements;
using Sitecore.Analytics.Model.Framework;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Elements
{
    [Serializable]
    public class GalleryViewed : Element, IGalleryViewed
    {
        private const string IdName = "Id";
        private const string ProductTitleName = "ProductTitle";
        private const string ProductSkuName = "ProductSku";
        private const string FactionsName = "Factions";
        private const string ProductTypeName = "ProductType";

        public GalleryViewed()
        {
            EnsureAttribute<string>(IdName);
            EnsureAttribute<string>(ProductTitleName);
            EnsureAttribute<string>(ProductSkuName);
            EnsureAttribute<string>(FactionsName);
            EnsureAttribute<string>(ProductTypeName);
        }

        public string Id
        {
            get { return GetAttribute<string>(IdName); }
            set { SetAttribute(IdName, value); }
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

        public string Factions
        {
            get { return GetAttribute<string>(FactionsName); }
            set { SetAttribute(FactionsName, value); }
        }

        public string ProductType
        {
            get { return GetAttribute<string>(ProductTypeName); }
            set { SetAttribute(ProductTypeName, value); }
        }
    }
}
