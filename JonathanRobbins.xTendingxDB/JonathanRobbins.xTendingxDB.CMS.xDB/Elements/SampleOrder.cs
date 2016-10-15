using System;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Elements;
using Sitecore.Analytics.Model.Framework;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Elements
{
    [Serializable]
    public class SampleOrder : Element, ISampleOrder
    {
        private const string TitleName = "Title";
        private const string SkuName = "Sku";
        private const string TypeName = "Type";

        public SampleOrder()
        {
            EnsureAttribute<string>(TitleName);
            EnsureAttribute<string>(SkuName);
            EnsureAttribute<string>(TypeName);
        }

        public string Title
        {
            get { return GetAttribute<string>(TitleName); }
            set { SetAttribute(TitleName, value); }
        }

        public string Sku
        {
            get { return GetAttribute<string>(SkuName); }
            set { SetAttribute(SkuName, value); }
        }

        public string Type
        {
            get { return GetAttribute<string>(TypeName); }
            set { SetAttribute(TypeName, value); }
        }
    }
}
