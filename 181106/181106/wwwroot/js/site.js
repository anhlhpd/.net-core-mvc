// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$.validator.addMethod('cantbeme',
    function (value, element, ignorename) {
        if (value.indexOf(ignoreName) >= 0) {
            return false;
        }
        return true;
    }
)

$.validator.unobtrusive.adapters.add('cantbeme', ['ignorename']
    function (options) {
        var txtFirstName = $(options.form).find('input#FirstName')[0];
        options.rules['cantbeme'] = [options.params['ignorename']];
        options.message['cantbeme'] = options.message;
    }
)