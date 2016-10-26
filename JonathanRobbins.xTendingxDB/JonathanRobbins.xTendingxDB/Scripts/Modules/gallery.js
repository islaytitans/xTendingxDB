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
            });
        }
    };

    var _toggleGallery = function ($el) {

        var $productGallery = $el.closest('.product-detail').find('.product-detail__gallery');

        $productGallery.toggleClass('product-detail__gallery--open');

    };

    return {
        init: init
    };

})(jQuery);
