var XX = XX || {};

XX.gallery = (function($, undefined) {
    'use strict';

    var init = function() {
        _bindEvents();
    };

    var _bindEvents = function () {
      var $galleryButton = $('.product-detail__btn');
      if (galleryButton.length){
        $galleryButton.on('click', function () {
          _openImageGallery();
        });
      }
    };

    var _openImageGallery = function () {
      console.log('hi friends');
    };

    return {
        init: init
    }

}(jQuery))
