var XX = XX || {};

XX.tracking = (function ($) {

    var trackingGoalClass = '.js-goal-tracking';
    var trackingBrochureClass = '.js-brochure-tracking';
    var trackingImageGalleryClass = '.js-image-gallery-tracking';
    var trackingController = 'Tracking';
    var registerGoalAction = 'RegisterGoal';
    var registerBrochureDownloadAction = 'RegisterBrochureDownload';
    var registerGalleryViewedAction = 'RegisterGalleryViewed';

    var bindTrackingEvents = function () {
        $(trackingImageGalleryClass).off().on('click', function (e) {
            var $el = $(this);
            registerGalleryView($el);
        });

        $(trackingBrochureClass).off().on('click', function () {
            var $el = $(this);
            registerBrochureDownload($el);
        });

        // To register goals add '.js-tracking' class to trigger the post event
        $(document).off().on('click', trackingGoalClass, function (e) {
            var $el = $(this);
            registerGoal($el);
        });
    };

    var registerBrochureDownload = function($el) {
        var elData = $el.data();

        var productTitle = elData.productTitle;
        var productSku = elData.productSku;
        var brochureTitle = elData.brochureTitle;
        var brochureId = elData.brochureId;

        var url = window.location.protocol + '//' + window.location.host + '/' + trackingController + '/' + registerBrochureDownloadAction;

        var body = { Id: brochureId, Title: brochureTitle, ProductTitle: productTitle, ProductSku: productSku};

        postBodyData(url, body);
    }

    var registerGalleryView = function ($el) {
        var elData = $el.data();

        var productTitle = elData.productTitle;
        var productSku = elData.productSku;
        var galleryId = elData.galleryId;
        var factions = elData.factions;
        var productType = elData.productType;

        var url = window.location.protocol + '//' + window.location.host + '/' + trackingController + '/' + registerGalleryViewedAction;

        var body = { Id: galleryId, ProductTitle: productTitle, ProductSku: productSku, Factions: factions.split(','), ProductType: productType };

        postBodyData(url, body);
    }

    var registerGoal = function ($el) {
        var elData = $el.data();

        var goalId = elData.goalId;
        var goalDescription = elData.goalDescription;

        var url = window.location.protocol + '//' + window.location.host + '/' + trackingController + '/' + registerGoalAction + '?id=' + goalId + '&description=' + goalDescription;

        postData(url);
    };

    var postData = function (url) {
        $.ajax({
            type: 'POST',
            url: url,
            dataType: 'json',
            success: function () {
                console.log('Tracking data succesfully posted to the server');
            },
            error: function () {
                console.error('Tracking data could not be sent to the server');
            }
        });
    };

    var postBodyData = function (url, body) {
        $.ajax({
            type: 'POST',
            url: url,
            dataType: 'json',
            data: body,
            success: function () {
                console.log('Tracking data succesfully posted to the server');
            },
            error: function () {
                console.error('Tracking data could not be sent to the server');
            }
        });
    };

    var bindEvents = function () {
        bindTrackingEvents();
    };

    var init = function () {
        bindEvents();
    };

    return {
        init: init
    };

})(jQuery);