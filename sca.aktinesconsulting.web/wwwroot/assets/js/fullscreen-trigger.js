﻿"use strict"; $(function () { $("#fullscreen-trigger").on("click", function () { $("body").data("fullscreen-active") ? document.exitFullscreen() : document.documentElement.requestFullscreen() }), document.onfullscreenchange = function () { document.fullscreenElement ? ($("body").addClass("fullscreen-active"), $("body").data("fullscreen-active", !0)) : ($("body").removeClass("fullscreen-active"), $("body").data("fullscreen-active", !1)) } });