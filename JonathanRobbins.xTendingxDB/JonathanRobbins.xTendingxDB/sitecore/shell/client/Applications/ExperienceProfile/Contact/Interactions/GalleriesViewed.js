define(["sitecore", "/-/speak/v1/experienceprofile/DataProviderHelper.js"], function (sc, providerHelper) {
    var app = sc.Definitions.App.extend({
        initialized: function () {
            var tableName = "galleryviewed";
            var localUrl = /intel/ + tableName;

            providerHelper.setupHeaders([
              { urlKey: localUrl + "?", headerValue: tableName }
            ]);
            var url = sc.Contact.baseUrl + localUrl;

            providerHelper.initProvider(this.GalleriesViewedDataProvider, tableName, url, this.GalleriesViewedTabMessageBar);
            providerHelper.subscribeSorting(this.GalleriesViewedDataProvider, this.GalleriesViewedList);
            providerHelper.setDefaultSorting(this.GalleriesViewedDataProvider, "ConversionDateTime", true);
            providerHelper.getListData(this.GalleriesViewedDataProvider);

            providerHelper.subscribeAccordionHeader(this.GalleriesViewedDataProvider, this.GalleriesViewedAccordion);

            sc.Contact.subscribeVisitDialog(this.GalleriesViewedList);
        }
    });
    return app;
});