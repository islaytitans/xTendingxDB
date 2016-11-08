var XX = XX || {};

XX.gallery = (function ($, undefined) {
    'use strict';

    var init = function () {
        _bindEvents();
    };

    var _bindEvents = function () {
        var $galleryButton = $('.product-detail__btn');
        if ($galleryButton.length) {
            $galleryButton.off().on('click', function (e) {
                e.preventDefault();
                _toggleGallery($galleryButton);
                registerGalleryView($galleryButton);
            });
        }
    };

    var _toggleGallery = function ($el) {

        var $productGallery = $el.closest('.product-detail').find('.product-detail__gallery');

        $productGallery.toggleClass('product-detail__gallery--open');

    };

    var trackingController = 'Tracking';
    var registerGalleryViewedAction = 'RegisterGalleryViewed';
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

    return {
        init: init
    };

})(jQuery);
