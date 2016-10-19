define(["sitecore", "/-/speak/v1/experienceprofile/DataProviderHelper.js"], function (sc, providerHelper) {
    var app = sc.Definitions.App.extend({
        initialized: function () {
            var tableName = "brochureDownloads";
            var localUrl = /intel/ + tableName;

            providerHelper.setupHeaders([
              { urlKey: localUrl + "?", headerValue: tableName }
            ]);
            var url = sc.Contact.baseUrl + localUrl;

            providerHelper.initProvider(this.BrochureDownloadsDataProvider, tableName, url, this.BrochureDownloadsTabMessageBar);
            providerHelper.subscribeSorting(this.BrochureDownloadsDataProvider, this.BrochureDownloadsList);
            providerHelper.setDefaultSorting(this.BrochureDownloadsDataProvider, "ConversionDateTime", true);
            providerHelper.getListData(this.BrochureDownloadsDataProvider);

            providerHelper.subscribeAccordionHeader(this.BrochureDownloadsDataProvider, this.BrochureDownloadsAccordion);

            sc.Contact.subscribeVisitDialog(this.BrochureDownloadsList);
        }
    });
    return app;
});