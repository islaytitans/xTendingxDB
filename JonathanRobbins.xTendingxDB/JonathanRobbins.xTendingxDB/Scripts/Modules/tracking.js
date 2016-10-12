var XX = XX || {};

XX.tracking = (function ($) {

    var trackingGoalClass = '.js-goal-tracking';
    var trackingBrochureClass = '.js-brochure-tracking';
    var trackingController = 'tracking';
    var registerGoalAction = 'registergoal';
    var registerBrochureDownloadAction = 'registerBrochureDownload';

    var bindTrackingEvents = function () {
        $(document).on('click', trackingBrochureClass, function () {
            var $el = $(this);
            registerBrochureDownload($el);
        });

        // To register goals add '.js-tracking' class to trigger the post event
        $(document).on('click', trackingGoalClass, function () {
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

        var body = JSON.stringify({ id: brochureId, title: brochureTitle, productTitle: productTitle, productSku: productSku });

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