// custom.js - js code
(function () {
    let custom = $app.custom = {}, util = custom.util = {}, user = custom.user = {}, ui = custom.ui = {};
    // current agent = IE browser?
    util.isBrowserIE = function () {
        return navigator.userAgent.indexOf('MSIE') !== -1 || navigator.appVersion.indexOf('Trident/') > 0
    };
    // get user info
    user.getProfileInfo = function () {
        let username = $app.userName();
        if (username.length) {
            return eval('$app.AccountManager.list().' + username);
        }
    };
    // get user picture
    user.getProfilePicture = function () {
        let user = $app.custom.user.getProfileInfo();
        if (typeof user !== 'undefined') {
            if (typeof user.Handler !== 'undefined')
                return user.picture;
            else {
                let localUserPicture = eval('$app.AccountManager._avatars.' + user.name);
                if (typeof localUserPicture !== 'undefined')
                    return localUserPicture;
            }
            return 'text:' + user.name.substr(0, 1).toUpperCase();
        }
        return '';
    };
    user.sync = function (reloadPage) {
        if (typeof reloadPage === 'undefined') reloadPage = true;
        let user = $app.custom.user.getProfileInfo();
        if (typeof user !== 'undefined') {
            $app.refreshUserToken($app.custom.user.getProfileInfo());
            if (reloadPage) window.location.reload();
        }
    };
    // refresh layout alignment
    ui.refreshAlignment = function () {
        if ($app.custom.util.isBrowserIE()) {
            let evt = document.createEvent('UIEvents');
            evt.initUIEvent('resize', true, false, window, 0);
            window.dispatchEvent(evt);
        } else {
            window.dispatchEvent(new Event('resize'));
        }
    }
    // dynamic Logo
    ui.refreshLogo = function () {
        let appLogo = $('.app-bar-toolbar .app-logo');
        if (appLogo.length) {
            let appTitle = __settings.appName, appLogoPath = __settings.splash.logo;
            if (appLogoPath.length) {
                appLogo.html('<img src="' + appLogoPath + '" title="' + appTitle + '" />');
                $app.custom.ui.refreshAlignment();
            }
            else {
                appLogo.html('<span>' + appTitle + '</span>');
            }
        }
    };
    // switch theme
    ui.switchTheme = function (name, accent) {
        accent = typeof name !== 'undefined' && typeof accent === 'undefined' && name.toLowerCase() != 'light' && name.toLowerCase() != 'dark' ? name : typeof accent !== 'undefined' ? accent[0].toUpperCase() + accent.slice(1).toLowerCase() : $app.touch.settings('ui.theme.accent');
        name = typeof name !== 'undefined' && (name.toLowerCase() == 'light' || name.toLowerCase() == 'dark') ? name[0].toUpperCase() + name.slice(1).toLowerCase() : $app.touch.settings('ui.theme.name');
        $app.touch._changeThemeLink(name + '.' + accent, name + '.' + accent, function () {
            $app.touch.settings('ui.theme.name', name);
            $app.touch.settings('ui.theme.accent', accent);
        });
    };
    // customize behaviours
    $(document).on('click touchstart', '.ui-popup-container.ui-popup-active a.app-avatar.app-item-selected, #app-panel-menu-scope [data-panel="#app-panel-profile-context"] a.app-avatar.app-item-selected', function () {
        // Customize behavior #1 - Perhaps open a modal box
        return false;
    }).on('click touchstart', '.app-bar-toolbar .app-logo > *', function () {
// Customize behavior #2 - Add hyperlink to logo
        setTimeout(function () {
            $app._navigated = true;
            var returnUrl = window.location.href.match(/\?ReturnUrl=(.+)$/);
            window.location.replace(returnUrl && decodeURIComponent(returnUrl[1]) || __baseUrl);
        });
        return false;
    }).ready(function () {
        $app.custom.ui.refreshLogo();
    });
})();
