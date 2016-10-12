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

})(jQuery);

jQuery(document).ready(function () {
    XX.app.init();
});

// Ensures using console.log doesn't cause errors in browsers that do not support it
if (typeof console === "undefined") {
    window.console = {
        log: function () { }
    };
}