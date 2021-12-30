(function($){"use strict";$(".menu-toggle").on('click',function(){$("#resmenu").addClass('open')
$("body").addClass("resmenu-overlay");});$(".resmenu-close").on('click',function(){$("#resmenu").removeClass('open')
$("body").removeClass("resmenu-overlay");});$(".res-submenu > a").on('click',function(e){e.preventDefault();$(this).next().slideToggle();});})(jQuery);