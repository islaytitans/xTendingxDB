// enabled jquery no conflict
jQuery.noConflict();

/*jshint -W079 */
var XX = XX || {};
XX.app = (function ($, undefined) {
    var init = function () {
        if (!$('body').hasClass('page-editor')) {
            // if body does not have page editor class
            XX.tracking.init();
        }
    };

    return {
        init: init
    };

}(jQuery));

jQuery(document).ready(function () {
    XX.app.init();
});