var e, t;
t = this, e = function (e) {
    "use strict";

    function M(e) {
        if (e && e.__esModule) return e;
        var t, i = Object.create(null, {
            [Symbol.toStringTag]: {
                value: "Module"
            }
        });
        if (e)
            for (const s in e) "default" !== s && (t = Object.getOwnPropertyDescriptor(e, s), Object.defineProperty(i, s, t.get ? t : {
                enumerable: !0,
                get: () => e[s]
            }));
        return i.default = e, Object.freeze(i)
    }
    const i = M(e),
        z = 1e3,
        q = "transitionend",
        H = t => {
            let i = t.getAttribute("data-bs-target");
            if (!i || "#" === i) {
                let e = t.getAttribute("href");
                if (!e || !e.includes("#") && !e.startsWith(".")) return null;
                e.includes("#") && !e.startsWith("#") && (e = "#" + e.split("#")[1]), i = e && "#" !== e ? e.trim() : null
            }
            return i
        },
        F = e => {
            e = H(e);
            return e && document.querySelector(e) ? e : null
        },
        n = e => {
            e = H(e);
            return e ? document.querySelector(e) : null
        },
        B = e => {
            e.dispatchEvent(new Event(q))
        },
        o = e => !(!e || "object" != typeof e) && void 0 !== (e = void 0 !== e.jquery ? e[0] : e).nodeType,
        s = e => o(e) ? e.jquery ? e[0] : e : "string" == typeof e && 0 < e.length ? document.querySelector(e) : null,
        r = e => {
            if (!o(e) || 0 === e.getClientRects().length) return !1;
            var t = "visible" === getComputedStyle(e).getPropertyValue("visibility"),
                i = e.closest("details:not([open])");
            if (i && i !== e) {
                e = e.closest("summary");
                if (e && e.parentNode !== i) return !1;
                if (null === e) return !1
            }
            return t
        },
        a = e => !e || e.nodeType !== Node.ELEMENT_NODE || !!e.classList.contains("disabled") || (void 0 !== e.disabled ? e.disabled : e.hasAttribute("disabled") && "false" !== e.getAttribute("disabled")),
        W = e => {
            var t;
            return document.documentElement.attachShadow ? "function" == typeof e.getRootNode ? (t = e.getRootNode()) instanceof ShadowRoot ? t : null : e instanceof ShadowRoot ? e : e.parentNode ? W(e.parentNode) : null : null
        },
        $ = () => { },
        c = e => {
            e.offsetHeight
        },
        Q = () => window.jQuery && !document.body.hasAttribute("data-bs-no-jquery") ? window.jQuery : null,
        R = [],
        l = () => "rtl" === document.documentElement.dir;
    e = s => {
        var e;
        e = () => {
            const e = Q();
            if (e) {
                const t = s.NAME,
                    i = e.fn[t];
                e.fn[t] = s.jQueryInterface, e.fn[t].Constructor = s, e.fn[t].noConflict = () => (e.fn[t] = i, s.jQueryInterface)
            }
        }, "loading" === document.readyState ? (R.length || document.addEventListener("DOMContentLoaded", () => {
            for (const e of R) e()
        }), R.push(e)) : e()
    };
    const h = e => {
        "function" == typeof e && e()
    },
        V = (i, s, e = !0) => {
            if (e) {
                e = (e => {
                    if (!e) return 0;
                    let {
                        transitionDuration: t,
                        transitionDelay: i
                    } = window.getComputedStyle(e);
                    var e = Number.parseFloat(t),
                        s = Number.parseFloat(i);
                    return e || s ? (t = t.split(",")[0], i = i.split(",")[0], (Number.parseFloat(t) + Number.parseFloat(i)) * z) : 0
                })(s) + 5;
                let t = !1;
                const n = ({
                    target: e
                }) => {
                    e === s && (t = !0, s.removeEventListener(q, n), h(i))
                };
                s.addEventListener(q, n), setTimeout(() => {
                    t || B(s)
                }, e)
            } else h(i)
        },
        K = (e, t, i, s) => {
            var n = e.length;
            let o = e.indexOf(t);
            return -1 === o ? !i && s ? e[n - 1] : e[0] : (o += i ? 1 : -1, s && (o = (o + n) % n), e[Math.max(0, Math.min(o, n - 1))])
        },
        X = /[^.]*(?=\..*)\.|.*/,
        Y = /\..*/,
        U = /::\d+$/,
        J = {};
    let G = 1;
    const Z = {
        mouseenter: "mouseover",
        mouseleave: "mouseout"
    },
        ee = new Set(["click", "dblclick", "mouseup", "mousedown", "contextmenu", "mousewheel", "DOMMouseScroll", "mouseover", "mouseout", "mousemove", "selectstart", "selectend", "keydown", "keypress", "keyup", "orientationchange", "touchstart", "touchmove", "touchend", "touchcancel", "pointerdown", "pointermove", "pointerup", "pointerleave", "pointercancel", "gesturestart", "gesturechange", "gestureend", "focus", "blur", "change", "reset", "select", "submit", "focusin", "focusout", "load", "unload", "beforeunload", "resize", "move", "DOMContentLoaded", "readystatechange", "error", "abort", "scroll"]);

    function te(e, t) {
        return t && t + "::" + G++ || e.uidEvent || G++
    }

    function ie(e) {
        var t = te(e);
        return e.uidEvent = t, J[t] = J[t] || {}, J[t]
    }

    function se(e, t, i = null) {
        return Object.values(e).find(e => e.callable === t && e.delegationSelector === i)
    }

    function ne(e, t, i) {
        var s = "string" == typeof t,
            t = !s && t || i;
        let n = ae(e);
        return [s, t, n = ee.has(n) ? n : e]
    }

    function oe(s, n, o, r, a) {
        if ("string" == typeof n && s) {
            let [e, t, i] = ne(n, o, r);
            n in Z && (t = (l = t, function (e) {
                if (!e.relatedTarget || e.relatedTarget !== e.delegateTarget && !e.delegateTarget.contains(e.relatedTarget)) return l.call(this, e)
            }));
            var l, c, h, d, u, m, r = ie(s),
                r = r[i] || (r[i] = {}),
                g = se(r, t, e ? o : null);
            g ? g.oneOff = g.oneOff && a : (g = te(t, n.replace(X, "")), (n = e ? (d = s, u = o, m = t, function t(i) {
                var s = d.querySelectorAll(u);
                for (let e = i["target"]; e && e !== this; e = e.parentNode)
                    for (const n of s)
                        if (n === e) return le(i, {
                            delegateTarget: e
                        }), t.oneOff && f.off(d, i.type, u, m), m.apply(e, [i])
            }) : (c = s, h = t, function e(t) {
                return le(t, {
                    delegateTarget: c
                }), e.oneOff && f.off(c, t.type, h), h.apply(c, [t])
            })).delegationSelector = e ? o : null, n.callable = t, n.oneOff = a, r[n.uidEvent = g] = n, s.addEventListener(i, n, e))
        }
    }

    function re(e, t, i, s, n) {
        s = se(t[i], s, n);
        s && (e.removeEventListener(i, s, Boolean(n)), delete t[i][s.uidEvent])
    }

    function ae(e) {
        return e = e.replace(Y, ""), Z[e] || e
    }
    const f = {
        on(e, t, i, s) {
            oe(e, t, i, s, !1)
        },
        one(e, t, i, s) {
            oe(e, t, i, s, !0)
        },
        off(e, t, i, s) {
            if ("string" == typeof t && e) {
                var [s, n, o] = ne(t, i, s), r = o !== t, a = ie(e), l = a[o] || {}, c = t.startsWith(".");
                if (void 0 !== n) return Object.keys(l).length ? void re(e, a, o, n, s ? i : null) : void 0;
                if (c)
                    for (const _ of Object.keys(a)) {
                        h = f = g = m = u = d = void 0;
                        var h, d = e,
                            u = a,
                            m = _,
                            g = t.slice(1),
                            f = u[m] || {};
                        for (const b of Object.keys(f)) b.includes(g) && re(d, u, m, (h = f[b]).callable, h.delegationSelector)
                    }
                for (const v of Object.keys(l)) {
                    var p = v.replace(U, "");
                    r && !t.includes(p) || re(e, a, o, (p = l[v]).callable, p.delegationSelector)
                }
            }
        },
        trigger(e, t, i) {
            if ("string" != typeof t || !e) return null;
            var s = Q();
            let n = null,
                o = !0,
                r = !0,
                a = !1;
            t !== ae(t) && s && (n = s.Event(t, i), s(e).trigger(n), o = !n.isPropagationStopped(), r = !n.isImmediatePropagationStopped(), a = n.isDefaultPrevented());
            s = le(s = new Event(t, {
                bubbles: o,
                cancelable: !0
            }), i);
            return a && s.preventDefault(), r && e.dispatchEvent(s), s.defaultPrevented && n && n.preventDefault(), s
        }
    };

    function le(t, e) {
        for (const [i, s] of Object.entries(e || {})) try {
            t[i] = s
        } catch (e) {
            Object.defineProperty(t, i, {
                configurable: !0,
                get() {
                    return s
                }
            })
        }
        return t
    }
    const d = new Map,
        ce = {
            set(e, t, i) {
                d.has(e) || d.set(e, new Map);
                e = d.get(e);
                e.has(t) || 0 === e.size ? e.set(t, i) : console.error(`Bootstrap doesn't allow more than one instance per element. Bound instance: ${Array.from(e.keys())[0]}.`)
            },
            get(e, t) {
                return d.has(e) && d.get(e).get(t) || null
            },
            remove(e, t) {
                var i;
                d.has(e) && ((i = d.get(e)).delete(t), 0 === i.size) && d.delete(e)
            }
        };

    function he(t) {
        if ("true" === t) return !0;
        if ("false" === t) return !1;
        if (t === Number(t).toString()) return Number(t);
        if ("" === t || "null" === t) return null;
        if ("string" != typeof t) return t;
        try {
            return JSON.parse(decodeURIComponent(t))
        } catch (e) {
            return t
        }
    }

    function de(e) {
        return e.replace(/[A-Z]/g, e => "-" + e.toLowerCase())
    }
    const u = {
        setDataAttribute(e, t, i) {
            e.setAttribute("data-bs-" + de(t), i)
        },
        removeDataAttribute(e, t) {
            e.removeAttribute("data-bs-" + de(t))
        },
        getDataAttributes(t) {
            if (!t) return {};
            var i = {};
            for (const s of Object.keys(t.dataset).filter(e => e.startsWith("bs") && !e.startsWith("bsConfig"))) {
                let e = s.replace(/^bs/, "");
                i[e = e.charAt(0).toLowerCase() + e.slice(1, e.length)] = he(t.dataset[s])
            }
            return i
        },
        getDataAttribute(e, t) {
            return he(e.getAttribute("data-bs-" + de(t)))
        }
    };
    class t {
        static get Default() {
            return {}
        }
        static get DefaultType() {
            return {}
        }
        static get NAME() {
            throw new Error('You have to implement the static method "NAME", for each component!')
        }
        _getConfig(e) {
            return e = this._mergeConfigObj(e), e = this._configAfterMerge(e), this._typeCheckConfig(e), e
        }
        _configAfterMerge(e) {
            return e
        }
        _mergeConfigObj(e, t) {
            var i = o(t) ? u.getDataAttribute(t, "config") : {};
            return {
                ...this.constructor.Default,
                ..."object" == typeof i ? i : {},
                ...o(t) ? u.getDataAttributes(t) : {},
                ..."object" == typeof e ? e : {}
            }
        }
        _typeCheckConfig(e, t = this.constructor.DefaultType) {
            for (const n of Object.keys(t)) {
                var i = t[n],
                    s = e[n],
                    s = o(s) ? "element" : null == (s = s) ? "" + s : Object.prototype.toString.call(s).match(/\s([a-z]+)/i)[1].toLowerCase();
                if (!new RegExp(i).test(s)) throw new TypeError(`${this.constructor.NAME.toUpperCase()}: Option "${n}" provided type "${s}" but expected type "${i}".`)
            }
        }
    }
    class m extends t {
        constructor(e, t) {
            super(), (e = s(e)) && (this._element = e, this._config = this._getConfig(t), ce.set(this._element, this.constructor.DATA_KEY, this))
        }
        dispose() {
            ce.remove(this._element, this.constructor.DATA_KEY), f.off(this._element, this.constructor.EVENT_KEY);
            for (const e of Object.getOwnPropertyNames(this)) this[e] = null
        }
        _queueCallback(e, t, i = !0) {
            V(e, t, i)
        }
        _getConfig(e) {
            return e = this._mergeConfigObj(e, this._element), e = this._configAfterMerge(e), this._typeCheckConfig(e), e
        }
        static getInstance(e) {
            return ce.get(s(e), this.DATA_KEY)
        }
        static getOrCreateInstance(e, t = {}) {
            return this.getInstance(e) || new this(e, "object" == typeof t ? t : null)
        }
        static get VERSION() {
            return "5.2.3"
        }
        static get DATA_KEY() {
            return "bs." + this.NAME
        }
        static get EVENT_KEY() {
            return "." + this.DATA_KEY
        }
        static eventName(e) {
            return "" + e + this.EVENT_KEY
        }
    }
    var ue = (t, i = "hide") => {
        var e = "click.dismiss" + t.EVENT_KEY;
        const s = t.NAME;
        f.on(document, e, `[data-bs-dismiss="${s}"]`, function (e) {
            ["A", "AREA"].includes(this.tagName) && e.preventDefault(), a(this) || (e = n(this) || this.closest("." + s), t.getOrCreateInstance(e)[i]())
        })
    };
    class me extends m {
        static get NAME() {
            return "alert"
        }
        close() {
            var e;
            f.trigger(this._element, "close.bs.alert").defaultPrevented || (this._element.classList.remove("show"), e = this._element.classList.contains("fade"), this._queueCallback(() => this._destroyElement(), this._element, e))
        }
        _destroyElement() {
            this._element.remove(), f.trigger(this._element, "closed.bs.alert"), this.dispose()
        }
        static jQueryInterface(t) {
            return this.each(function () {
                var e = me.getOrCreateInstance(this);
                if ("string" == typeof t) {
                    if (void 0 === e[t] || t.startsWith("_") || "constructor" === t) throw new TypeError(`No method named "${t}"`);
                    e[t](this)
                }
            })
        }
    }
    ue(me, "close"), e(me);
    const ge = '[data-bs-toggle="button"]';
    class fe extends m {
        static get NAME() {
            return "button"
        }
        toggle() {
            this._element.setAttribute("aria-pressed", this._element.classList.toggle("active"))
        }
        static jQueryInterface(t) {
            return this.each(function () {
                var e = fe.getOrCreateInstance(this);
                "toggle" === t && e[t]()
            })
        }
    }
    f.on(document, "click.bs.button.data-api", ge, e => {
        e.preventDefault();
        e = e.target.closest(ge);
        fe.getOrCreateInstance(e).toggle()
    }), e(fe);
    const g = {
        find(e, t = document.documentElement) {
            return [].concat(...Element.prototype.querySelectorAll.call(t, e))
        },
        findOne(e, t = document.documentElement) {
            return Element.prototype.querySelector.call(t, e)
        },
        children(e, t) {
            return [].concat(...e.children).filter(e => e.matches(t))
        },
        parents(e, t) {
            var i = [];
            let s = e.parentNode.closest(t);
            for (; s;) i.push(s), s = s.parentNode.closest(t);
            return i
        },
        prev(e, t) {
            let i = e.previousElementSibling;
            for (; i;) {
                if (i.matches(t)) return [i];
                i = i.previousElementSibling
            }
            return []
        },
        next(e, t) {
            let i = e.nextElementSibling;
            for (; i;) {
                if (i.matches(t)) return [i];
                i = i.nextElementSibling
            }
            return []
        },
        focusableChildren(e) {
            var t = ["a", "button", "input", "textarea", "select", "details", "[tabindex]", '[contenteditable="true"]'].map(e => e + ':not([tabindex^="-"])').join(",");
            return this.find(t, e).filter(e => !a(e) && r(e))
        }
    },
        p = ".bs.swipe",
        pe = (p, p, p, p, p, {
            endCallback: null,
            leftCallback: null,
            rightCallback: null
        }),
        _e = {
            endCallback: "(function|null)",
            leftCallback: "(function|null)",
            rightCallback: "(function|null)"
        };
    class be extends t {
        constructor(e, t) {
            super(), (this._element = e) && be.isSupported() && (this._config = this._getConfig(t), this._deltaX = 0, this._supportPointerEvents = Boolean(window.PointerEvent), this._initEvents())
        }
        static get Default() {
            return pe
        }
        static get DefaultType() {
            return _e
        }
        static get NAME() {
            return "swipe"
        }
        dispose() {
            f.off(this._element, p)
        }
        _start(e) {
            this._supportPointerEvents ? this._eventIsPointerPenTouch(e) && (this._deltaX = e.clientX) : this._deltaX = e.touches[0].clientX
        }
        _end(e) {
            this._eventIsPointerPenTouch(e) && (this._deltaX = e.clientX - this._deltaX), this._handleSwipe(), h(this._config.endCallback)
        }
        _move(e) {
            this._deltaX = e.touches && 1 < e.touches.length ? 0 : e.touches[0].clientX - this._deltaX
        }
        _handleSwipe() {
            var e = Math.abs(this._deltaX);
            e <= 40 || (e = e / this._deltaX, this._deltaX = 0, e && h(0 < e ? this._config.rightCallback : this._config.leftCallback))
        }
        _initEvents() {
            this._supportPointerEvents ? (f.on(this._element, "pointerdown.bs.swipe", e => this._start(e)), f.on(this._element, "pointerup.bs.swipe", e => this._end(e)), this._element.classList.add("pointer-event")) : (f.on(this._element, "touchstart.bs.swipe", e => this._start(e)), f.on(this._element, "touchmove.bs.swipe", e => this._move(e)), f.on(this._element, "touchend.bs.swipe", e => this._end(e)))
        }
        _eventIsPointerPenTouch(e) {
            return this._supportPointerEvents && ("pen" === e.pointerType || "touch" === e.pointerType)
        }
        static isSupported() {
            return "ontouchstart" in document.documentElement || 0 < navigator.maxTouchPoints
        }
    }
    var _ = ".bs.carousel";
    const b = "next",
        v = "prev",
        y = "left",
        ve = "right",
        ye = "slid" + _;
    const we = "carousel",
        Ce = "active",
        Ae = ".active",
        Te = ".carousel-item";
    Ae, Te;
    const Ee = {
        ArrowLeft: ve,
        ArrowRight: y
    },
        ke = {
            interval: 5e3,
            keyboard: !0,
            pause: "hover",
            ride: !1,
            touch: !0,
            wrap: !0
        },
        Le = {
            interval: "(number|boolean)",
            keyboard: "boolean",
            pause: "(string|boolean)",
            ride: "(boolean|string)",
            touch: "boolean",
            wrap: "boolean"
        };
    class w extends m {
        constructor(e, t) {
            super(e, t), this._interval = null, this._activeElement = null, this._isSliding = !1, this.touchTimeout = null, this._swipeHelper = null, this._indicatorsElement = g.findOne(".carousel-indicators", this._element), this._addEventListeners(), this._config.ride === we && this.cycle()
        }
        static get Default() {
            return ke
        }
        static get DefaultType() {
            return Le
        }
        static get NAME() {
            return "carousel"
        }
        next() {
            this._slide(b)
        }
        nextWhenVisible() {
            !document.hidden && r(this._element) && this.next()
        }
        prev() {
            this._slide(v)
        }
        pause() {
            this._isSliding && B(this._element), this._clearInterval()
        }
        cycle() {
            this._clearInterval(), this._updateInterval(), this._interval = setInterval(() => this.nextWhenVisible(), this._config.interval)
        }
        _maybeEnableCycle() {
            this._config.ride && (this._isSliding ? f.one(this._element, ye, () => this.cycle()) : this.cycle())
        }
        to(e) {
            var t, i = this._getItems();
            e > i.length - 1 || e < 0 || (this._isSliding ? f.one(this._element, ye, () => this.to(e)) : (t = this._getItemIndex(this._getActive())) !== e && (t = t < e ? b : v, this._slide(t, i[e])))
        }
        dispose() {
            this._swipeHelper && this._swipeHelper.dispose(), super.dispose()
        }
        _configAfterMerge(e) {
            return e.defaultInterval = e.interval, e
        }
        _addEventListeners() {
            this._config.keyboard && f.on(this._element, "keydown.bs.carousel", e => this._keydown(e)), "hover" === this._config.pause && (f.on(this._element, "mouseenter.bs.carousel", () => this.pause()), f.on(this._element, "mouseleave.bs.carousel", () => this._maybeEnableCycle())), this._config.touch && be.isSupported() && this._addTouchEventListeners()
        }
        _addTouchEventListeners() {
            for (const t of g.find(".carousel-item img", this._element)) f.on(t, "dragstart.bs.carousel", e => e.preventDefault());
            var e = {
                leftCallback: () => this._slide(this._directionToOrder(y)),
                rightCallback: () => this._slide(this._directionToOrder(ve)),
                endCallback: () => {
                    "hover" === this._config.pause && (this.pause(), this.touchTimeout && clearTimeout(this.touchTimeout), this.touchTimeout = setTimeout(() => this._maybeEnableCycle(), 500 + this._config.interval))
                }
            };
            this._swipeHelper = new be(this._element, e)
        }
        _keydown(e) {
            var t;
            /input|textarea/i.test(e.target.tagName) || (t = Ee[e.key]) && (e.preventDefault(), this._slide(this._directionToOrder(t)))
        }
        _getItemIndex(e) {
            return this._getItems().indexOf(e)
        }
        _setActiveIndicatorElement(e) {
            var t;
            this._indicatorsElement && ((t = g.findOne(Ae, this._indicatorsElement)).classList.remove(Ce), t.removeAttribute("aria-current"), t = g.findOne(`[data-bs-slide-to="${e}"]`, this._indicatorsElement)) && (t.classList.add(Ce), t.setAttribute("aria-current", "true"))
        }
        _updateInterval() {
            var e = this._activeElement || this._getActive();
            e && (e = Number.parseInt(e.getAttribute("data-bs-interval"), 10), this._config.interval = e || this._config.defaultInterval)
        }
        _slide(t, e = null) {
            if (!this._isSliding) {
                const s = this._getActive();
                var i = t === b;
                const n = e || K(this._getItems(), s, i, this._config.wrap);
                if (n !== s) {
                    const o = this._getItemIndex(n),
                        r = e => f.trigger(this._element, e, {
                            relatedTarget: n,
                            direction: this._orderToDirection(t),
                            from: this._getItemIndex(s),
                            to: o
                        });
                    e = r("slide.bs.carousel");
                    if (!e.defaultPrevented && s && n) {
                        e = Boolean(this._interval);
                        this.pause(), this._isSliding = !0, this._setActiveIndicatorElement(o), this._activeElement = n;
                        const a = i ? "carousel-item-start" : "carousel-item-end",
                            l = i ? "carousel-item-next" : "carousel-item-prev";
                        n.classList.add(l), c(n), s.classList.add(a), n.classList.add(a);
                        this._queueCallback(() => {
                            n.classList.remove(a, l), n.classList.add(Ce), s.classList.remove(Ce, l, a), this._isSliding = !1, r(ye)
                        }, s, this._isAnimated()), e && this.cycle()
                    }
                }
            }
        }
        _isAnimated() {
            return this._element.classList.contains("slide")
        }
        _getActive() {
            return g.findOne(".active.carousel-item", this._element)
        }
        _getItems() {
            return g.find(Te, this._element)
        }
        _clearInterval() {
            this._interval && (clearInterval(this._interval), this._interval = null)
        }
        _directionToOrder(e) {
            return l() ? e === y ? v : b : e === y ? b : v
        }
        _orderToDirection(e) {
            return l() ? e === v ? y : ve : e === v ? ve : y
        }
        static jQueryInterface(t) {
            return this.each(function () {
                var e = w.getOrCreateInstance(this, t);
                if ("number" == typeof t) e.to(t);
                else if ("string" == typeof t) {
                    if (void 0 === e[t] || t.startsWith("_") || "constructor" === t) throw new TypeError(`No method named "${t}"`);
                    e[t]()
                }
            })
        }
    }
    f.on(document, "click.bs.carousel.data-api", "[data-bs-slide], [data-bs-slide-to]", function (e) {
        var t = n(this);
        t && t.classList.contains(we) && (e.preventDefault(), e = w.getOrCreateInstance(t), (t = this.getAttribute("data-bs-slide-to")) ? e.to(t) : "next" === u.getDataAttribute(this, "slide") ? e.next() : e.prev(), e._maybeEnableCycle())
    }), f.on(window, "load.bs.carousel.data-api", () => {
        for (const e of g.find('[data-bs-ride="carousel"]')) w.getOrCreateInstance(e)
    }), e(w);
    const De = "show",
        C = "collapse",
        Oe = "collapsing",
        Se = (C, C, '[data-bs-toggle="collapse"]'),
        Ie = {
            parent: null,
            toggle: !0
        },
        Ne = {
            parent: "(null|element)",
            toggle: "boolean"
        };
    class A extends m {
        constructor(e, t) {
            super(e, t), this._isTransitioning = !1, this._triggerArray = [];
            for (const n of g.find(Se)) {
                var i = F(n),
                    s = g.find(i).filter(e => e === this._element);
                null !== i && s.length && this._triggerArray.push(n)
            }
            this._initializeChildren(), this._config.parent || this._addAriaAndCollapsedClass(this._triggerArray, this._isShown()), this._config.toggle && this.toggle()
        }
        static get Default() {
            return Ie
        }
        static get DefaultType() {
            return Ne
        }
        static get NAME() {
            return "collapse"
        }
        toggle() {
            this._isShown() ? this.hide() : this.show()
        }
        show() {
            if (!this._isTransitioning && !this._isShown()) {
                let e = [];
                if (!(e = this._config.parent ? this._getFirstLevelChildren(".collapse.show, .collapse.collapsing").filter(e => e !== this._element).map(e => A.getOrCreateInstance(e, {
                    toggle: !1
                })) : e).length || !e[0]._isTransitioning) {
                    var t = f.trigger(this._element, "show.bs.collapse");
                    if (!t.defaultPrevented) {
                        for (const s of e) s.hide();
                        const i = this._getDimension();
                        this._element.classList.remove(C), this._element.classList.add(Oe), this._element.style[i] = 0, this._addAriaAndCollapsedClass(this._triggerArray, !0), this._isTransitioning = !0;
                        t = "scroll" + (i[0].toUpperCase() + i.slice(1));
                        this._queueCallback(() => {
                            this._isTransitioning = !1, this._element.classList.remove(Oe), this._element.classList.add(C, De), this._element.style[i] = "", f.trigger(this._element, "shown.bs.collapse")
                        }, this._element, !0), this._element.style[i] = this._element[t] + "px"
                    }
                }
            }
        }
        hide() {
            if (!this._isTransitioning && this._isShown()) {
                var e = f.trigger(this._element, "hide.bs.collapse");
                if (!e.defaultPrevented) {
                    e = this._getDimension();
                    this._element.style[e] = this._element.getBoundingClientRect()[e] + "px", c(this._element), this._element.classList.add(Oe), this._element.classList.remove(C, De);
                    for (const i of this._triggerArray) {
                        var t = n(i);
                        t && !this._isShown(t) && this._addAriaAndCollapsedClass([i], !1)
                    }
                    this._isTransitioning = !0;
                    this._element.style[e] = "", this._queueCallback(() => {
                        this._isTransitioning = !1, this._element.classList.remove(Oe), this._element.classList.add(C), f.trigger(this._element, "hidden.bs.collapse")
                    }, this._element, !0)
                }
            }
        }
        _isShown(e = this._element) {
            return e.classList.contains(De)
        }
        _configAfterMerge(e) {
            return e.toggle = Boolean(e.toggle), e.parent = s(e.parent), e
        }
        _getDimension() {
            return this._element.classList.contains("collapse-horizontal") ? "width" : "height"
        }
        _initializeChildren() {
            if (this._config.parent)
                for (const t of this._getFirstLevelChildren(Se)) {
                    var e = n(t);
                    e && this._addAriaAndCollapsedClass([t], this._isShown(e))
                }
        }
        _getFirstLevelChildren(e) {
            const t = g.find(":scope .collapse .collapse", this._config.parent);
            return g.find(e, this._config.parent).filter(e => !t.includes(e))
        }
        _addAriaAndCollapsedClass(e, t) {
            if (e.length)
                for (const i of e) i.classList.toggle("collapsed", !t), i.setAttribute("aria-expanded", t)
        }
        static jQueryInterface(t) {
            const i = {};
            return "string" == typeof t && /show|hide/.test(t) && (i.toggle = !1), this.each(function () {
                var e = A.getOrCreateInstance(this, i);
                if ("string" == typeof t) {
                    if (void 0 === e[t]) throw new TypeError(`No method named "${t}"`);
                    e[t]()
                }
            })
        }
    }
    f.on(document, "click.bs.collapse.data-api", Se, function (e) {
        ("A" === e.target.tagName || e.delegateTarget && "A" === e.delegateTarget.tagName) && e.preventDefault();
        e = F(this);
        for (const t of g.find(e)) A.getOrCreateInstance(t, {
            toggle: !1
        }).toggle()
    }), e(A);
    const xe = "dropdown";
    var _ = ".bs.dropdown",
        T = ".data-api";
    const Pe = "ArrowDown";
    var je = "click" + _ + T,
        _ = "keydown" + _ + T;
    const E = "show",
        k = '[data-bs-toggle="dropdown"]:not(.disabled):not(:disabled)',
        Me = (k, ".dropdown-menu"),
        ze = l() ? "top-end" : "top-start",
        qe = l() ? "top-start" : "top-end",
        He = l() ? "bottom-end" : "bottom-start",
        Fe = l() ? "bottom-start" : "bottom-end",
        Be = l() ? "left-start" : "right-start",
        We = l() ? "right-start" : "left-start",
        $e = {
            autoClose: !0,
            boundary: "clippingParents",
            display: "dynamic",
            offset: [0, 2],
            popperConfig: null,
            reference: "toggle"
        },
        Qe = {
            autoClose: "(boolean|string)",
            boundary: "(string|element)",
            display: "string",
            offset: "(array|string|function)",
            popperConfig: "(null|object|function)",
            reference: "(string|element|object)"
        };
    class L extends m {
        constructor(e, t) {
            super(e, t), this._popper = null, this._parent = this._element.parentNode, this._menu = g.next(this._element, Me)[0] || g.prev(this._element, Me)[0] || g.findOne(Me, this._parent), this._inNavbar = this._detectNavbar()
        }
        static get Default() {
            return $e
        }
        static get DefaultType() {
            return Qe
        }
        static get NAME() {
            return xe
        }
        toggle() {
            return this._isShown() ? this.hide() : this.show()
        }
        show() {
            if (!a(this._element) && !this._isShown()) {
                var e = {
                    relatedTarget: this._element
                },
                    t = f.trigger(this._element, "show.bs.dropdown", e);
                if (!t.defaultPrevented) {
                    if (this._createPopper(), "ontouchstart" in document.documentElement && !this._parent.closest(".navbar-nav"))
                        for (const i of [].concat(...document.body.children)) f.on(i, "mouseover", $);
                    this._element.focus(), this._element.setAttribute("aria-expanded", !0), this._menu.classList.add(E), this._element.classList.add(E), f.trigger(this._element, "shown.bs.dropdown", e)
                }
            }
        }
        hide() {
            var e;
            !a(this._element) && this._isShown() && (e = {
                relatedTarget: this._element
            }, this._completeHide(e))
        }
        dispose() {
            this._popper && this._popper.destroy(), super.dispose()
        }
        update() {
            this._inNavbar = this._detectNavbar(), this._popper && this._popper.update()
        }
        _completeHide(e) {
            var t = f.trigger(this._element, "hide.bs.dropdown", e);
            if (!t.defaultPrevented) {
                if ("ontouchstart" in document.documentElement)
                    for (const i of [].concat(...document.body.children)) f.off(i, "mouseover", $);
                this._popper && this._popper.destroy(), this._menu.classList.remove(E), this._element.classList.remove(E), this._element.setAttribute("aria-expanded", "false"), u.removeDataAttribute(this._menu, "popper"), f.trigger(this._element, "hidden.bs.dropdown", e)
            }
        }
        _getConfig(e) {
            if ("object" != typeof (e = super._getConfig(e)).reference || o(e.reference) || "function" == typeof e.reference.getBoundingClientRect) return e;
            throw new TypeError(xe.toUpperCase() + ': Option "reference" provided type "object" without a required "getBoundingClientRect" method.')
        }
        _createPopper() {
            if (void 0 === i) throw new TypeError("Bootstrap's dropdowns require Popper (https://popper.js.org)");
            let e = this._element;
            "parent" === this._config.reference ? e = this._parent : o(this._config.reference) ? e = s(this._config.reference) : "object" == typeof this._config.reference && (e = this._config.reference);
            var t = this._getPopperConfig();
            this._popper = i.createPopper(e, this._menu, t)
        }
        _isShown() {
            return this._menu.classList.contains(E)
        }
        _getPlacement() {
            var e, t = this._parent;
            return t.classList.contains("dropend") ? Be : t.classList.contains("dropstart") ? We : t.classList.contains("dropup-center") ? "top" : t.classList.contains("dropdown-center") ? "bottom" : (e = "end" === getComputedStyle(this._menu).getPropertyValue("--bs-position").trim(), t.classList.contains("dropup") ? e ? qe : ze : e ? Fe : He)
        }
        _detectNavbar() {
            return null !== this._element.closest(".navbar")
        }
        _getOffset() {
            const t = this._config["offset"];
            return "string" == typeof t ? t.split(",").map(e => Number.parseInt(e, 10)) : "function" == typeof t ? e => t(e, this._element) : t
        }
        _getPopperConfig() {
            var e = {
                placement: this._getPlacement(),
                modifiers: [{
                    name: "preventOverflow",
                    options: {
                        boundary: this._config.boundary
                    }
                }, {
                    name: "offset",
                    options: {
                        offset: this._getOffset()
                    }
                }]
            };
            return !this._inNavbar && "static" !== this._config.display || (u.setDataAttribute(this._menu, "popper", "static"), e.modifiers = [{
                name: "applyStyles",
                enabled: !1
            }]), {
                ...e,
                ..."function" == typeof this._config.popperConfig ? this._config.popperConfig(e) : this._config.popperConfig
            }
        }
        _selectMenuItem({
            key: e,
            target: t
        }) {
            var i = g.find(".dropdown-menu .dropdown-item:not(.disabled):not(:disabled)", this._menu).filter(e => r(e));
            i.length && K(i, t, e === Pe, !i.includes(t)).focus()
        }
        static jQueryInterface(t) {
            return this.each(function () {
                var e = L.getOrCreateInstance(this, t);
                if ("string" == typeof t) {
                    if (void 0 === e[t]) throw new TypeError(`No method named "${t}"`);
                    e[t]()
                }
            })
        }
        static clearMenus(e) {
            if (2 !== e.button && ("keyup" !== e.type || "Tab" === e.key))
                for (const n of g.find('[data-bs-toggle="dropdown"]:not(.disabled):not(:disabled).show')) {
                    var t, i, s = L.getInstance(n);
                    s && !1 !== s._config.autoClose && (t = (i = e.composedPath()).includes(s._menu), i.includes(s._element) || "inside" === s._config.autoClose && !t || "outside" === s._config.autoClose && t || s._menu.contains(e.target) && ("keyup" === e.type && "Tab" === e.key || /input|select|option|textarea|form/i.test(e.target.tagName)) || (i = {
                        relatedTarget: s._element
                    }, "click" === e.type && (i.clickEvent = e), s._completeHide(i)))
                }
        }
        static dataApiKeydownHandler(e) {
            var t = /input|textarea/i.test(e.target.tagName),
                i = "Escape" === e.key,
                s = ["ArrowUp", Pe].includes(e.key);
            !s && !i || t && !i || (e.preventDefault(), t = this.matches(k) ? this : g.prev(this, k)[0] || g.next(this, k)[0] || g.findOne(k, e.delegateTarget.parentNode), i = L.getOrCreateInstance(t), s ? (e.stopPropagation(), i.show(), i._selectMenuItem(e)) : i._isShown() && (e.stopPropagation(), i.hide(), t.focus()))
        }
    }
    f.on(document, _, k, L.dataApiKeydownHandler), f.on(document, _, Me, L.dataApiKeydownHandler), f.on(document, je, L.clearMenus), f.on(document, "keyup.bs.dropdown.data-api", L.clearMenus), f.on(document, je, k, function (e) {
        e.preventDefault(), L.getOrCreateInstance(this).toggle()
    }), e(L);
    const Re = ".fixed-top, .fixed-bottom, .is-fixed, .sticky-top",
        Ve = ".sticky-top",
        Ke = "padding-right",
        Xe = "margin-right";
    class Ye {
        constructor() {
            this._element = document.body
        }
        getWidth() {
            var e = document.documentElement.clientWidth;
            return Math.abs(window.innerWidth - e)
        }
        hide() {
            const t = this.getWidth();
            this._disableOverFlow(), this._setElementAttributes(this._element, Ke, e => e + t), this._setElementAttributes(Re, Ke, e => e + t), this._setElementAttributes(Ve, Xe, e => e - t)
        }
        reset() {
            this._resetElementAttributes(this._element, "overflow"), this._resetElementAttributes(this._element, Ke), this._resetElementAttributes(Re, Ke), this._resetElementAttributes(Ve, Xe)
        }
        isOverflowing() {
            return 0 < this.getWidth()
        }
        _disableOverFlow() {
            this._saveInitialAttribute(this._element, "overflow"), this._element.style.overflow = "hidden"
        }
        _setElementAttributes(e, i, s) {
            const n = this.getWidth();
            this._applyManipulationCallback(e, e => {
                var t;
                e !== this._element && window.innerWidth > e.clientWidth + n || (this._saveInitialAttribute(e, i), t = window.getComputedStyle(e).getPropertyValue(i), e.style.setProperty(i, s(Number.parseFloat(t)) + "px"))
            })
        }
        _saveInitialAttribute(e, t) {
            var i = e.style.getPropertyValue(t);
            i && u.setDataAttribute(e, t, i)
        }
        _resetElementAttributes(e, i) {
            this._applyManipulationCallback(e, e => {
                var t = u.getDataAttribute(e, i);
                null === t ? e.style.removeProperty(i) : (u.removeDataAttribute(e, i), e.style.setProperty(i, t))
            })
        }
        _applyManipulationCallback(e, t) {
            if (o(e)) t(e);
            else
                for (const i of g.find(e, this._element)) t(i)
        }
    }
    const Ue = "backdrop",
        Je = "mousedown.bs." + Ue,
        Ge = {
            className: "modal-backdrop",
            clickCallback: null,
            isAnimated: !1,
            isVisible: !0,
            rootElement: "body"
        },
        Ze = {
            className: "string",
            clickCallback: "(function|null)",
            isAnimated: "boolean",
            isVisible: "boolean",
            rootElement: "(element|string)"
        };
    class et extends t {
        constructor(e) {
            super(), this._config = this._getConfig(e), this._isAppended = !1, this._element = null
        }
        static get Default() {
            return Ge
        }
        static get DefaultType() {
            return Ze
        }
        static get NAME() {
            return Ue
        }
        show(e) {
            var t;
            this._config.isVisible ? (this._append(), t = this._getElement(), this._config.isAnimated && c(t), t.classList.add("show"), this._emulateAnimation(() => {
                h(e)
            })) : h(e)
        }
        hide(e) {
            this._config.isVisible ? (this._getElement().classList.remove("show"), this._emulateAnimation(() => {
                this.dispose(), h(e)
            })) : h(e)
        }
        dispose() {
            this._isAppended && (f.off(this._element, Je), this._element.remove(), this._isAppended = !1)
        }
        _getElement() {
            var e;
            return this._element || ((e = document.createElement("div")).className = this._config.className, this._config.isAnimated && e.classList.add("fade"), this._element = e), this._element
        }
        _configAfterMerge(e) {
            return e.rootElement = s(e.rootElement), e
        }
        _append() {
            var e;
            this._isAppended || (e = this._getElement(), this._config.rootElement.append(e), f.on(e, Je, () => {
                h(this._config.clickCallback)
            }), this._isAppended = !0)
        }
        _emulateAnimation(e) {
            V(e, this._getElement(), this._config.isAnimated)
        }
    }
    const tt = ".bs.focustrap",
        it = (tt, tt, "backward"),
        st = {
            autofocus: !0,
            trapElement: null
        },
        nt = {
            autofocus: "boolean",
            trapElement: "element"
        };
    class ot extends t {
        constructor(e) {
            super(), this._config = this._getConfig(e), this._isActive = !1, this._lastTabNavDirection = null
        }
        static get Default() {
            return st
        }
        static get DefaultType() {
            return nt
        }
        static get NAME() {
            return "focustrap"
        }
        activate() {
            this._isActive || (this._config.autofocus && this._config.trapElement.focus(), f.off(document, tt), f.on(document, "focusin.bs.focustrap", e => this._handleFocusin(e)), f.on(document, "keydown.tab.bs.focustrap", e => this._handleKeydown(e)), this._isActive = !0)
        }
        deactivate() {
            this._isActive && (this._isActive = !1, f.off(document, tt))
        }
        _handleFocusin(e) {
            var t = this._config["trapElement"];
            e.target === document || e.target === t || t.contains(e.target) || (0 === (e = g.focusableChildren(t)).length ? t : this._lastTabNavDirection === it ? e[e.length - 1] : e[0]).focus()
        }
        _handleKeydown(e) {
            "Tab" === e.key && (this._lastTabNavDirection = e.shiftKey ? it : "forward")
        }
    }
    const D = ".bs.modal";
    D, D;
    const rt = "hidden" + D,
        at = "show" + D;
    D, D, D, D, D;
    D;
    const lt = "modal-open",
        ct = "modal-static";
    const ht = {
        backdrop: !0,
        focus: !0,
        keyboard: !0
    },
        dt = {
            backdrop: "(boolean|string)",
            focus: "boolean",
            keyboard: "boolean"
        };
    class O extends m {
        constructor(e, t) {
            super(e, t), this._dialog = g.findOne(".modal-dialog", this._element), this._backdrop = this._initializeBackDrop(), this._focustrap = this._initializeFocusTrap(), this._isShown = !1, this._isTransitioning = !1, this._scrollBar = new Ye, this._addEventListeners()
        }
        static get Default() {
            return ht
        }
        static get DefaultType() {
            return dt
        }
        static get NAME() {
            return "modal"
        }
        toggle(e) {
            return this._isShown ? this.hide() : this.show(e)
        }
        show(e) {
            this._isShown || this._isTransitioning || f.trigger(this._element, at, {
                relatedTarget: e
            }).defaultPrevented || (this._isShown = !0, this._isTransitioning = !0, this._scrollBar.hide(), document.body.classList.add(lt), this._adjustDialog(), this._backdrop.show(() => this._showElement(e)))
        }
        hide() {
            !this._isShown || this._isTransitioning || f.trigger(this._element, "hide.bs.modal").defaultPrevented || (this._isShown = !1, this._isTransitioning = !0, this._focustrap.deactivate(), this._element.classList.remove("show"), this._queueCallback(() => this._hideModal(), this._element, this._isAnimated()))
        }
        dispose() {
            for (const e of [window, this._dialog]) f.off(e, D);
            this._backdrop.dispose(), this._focustrap.deactivate(), super.dispose()
        }
        handleUpdate() {
            this._adjustDialog()
        }
        _initializeBackDrop() {
            return new et({
                isVisible: Boolean(this._config.backdrop),
                isAnimated: this._isAnimated()
            })
        }
        _initializeFocusTrap() {
            return new ot({
                trapElement: this._element
            })
        }
        _showElement(e) {
            document.body.contains(this._element) || document.body.append(this._element), this._element.style.display = "block", this._element.removeAttribute("aria-hidden"), this._element.setAttribute("aria-modal", !0), this._element.setAttribute("role", "dialog"), this._element.scrollTop = 0;
            var t = g.findOne(".modal-body", this._dialog);
            t && (t.scrollTop = 0), c(this._element), this._element.classList.add("show");
            this._queueCallback(() => {
                this._config.focus && this._focustrap.activate(), this._isTransitioning = !1, f.trigger(this._element, "shown.bs.modal", {
                    relatedTarget: e
                })
            }, this._dialog, this._isAnimated())
        }
        _addEventListeners() {
            f.on(this._element, "keydown.dismiss.bs.modal", e => {
                "Escape" === e.key && (this._config.keyboard ? (e.preventDefault(), this.hide()) : this._triggerBackdropTransition())
            }), f.on(window, "resize.bs.modal", () => {
                this._isShown && !this._isTransitioning && this._adjustDialog()
            }), f.on(this._element, "mousedown.dismiss.bs.modal", t => {
                f.one(this._element, "click.dismiss.bs.modal", e => {
                    this._element === t.target && this._element === e.target && ("static" === this._config.backdrop ? this._triggerBackdropTransition() : this._config.backdrop && this.hide())
                })
            })
        }
        _hideModal() {
            this._element.style.display = "none", this._element.setAttribute("aria-hidden", !0), this._element.removeAttribute("aria-modal"), this._element.removeAttribute("role"), this._isTransitioning = !1, this._backdrop.hide(() => {
                document.body.classList.remove(lt), this._resetAdjustments(), this._scrollBar.reset(), f.trigger(this._element, rt)
            })
        }
        _isAnimated() {
            return this._element.classList.contains("fade")
        }
        _triggerBackdropTransition() {
            var e = f.trigger(this._element, "hidePrevented.bs.modal");
            if (!e.defaultPrevented) {
                e = this._element.scrollHeight > document.documentElement.clientHeight;
                const t = this._element.style.overflowY;
                "hidden" === t || this._element.classList.contains(ct) || (e || (this._element.style.overflowY = "hidden"), this._element.classList.add(ct), this._queueCallback(() => {
                    this._element.classList.remove(ct), this._queueCallback(() => {
                        this._element.style.overflowY = t
                    }, this._dialog)
                }, this._dialog), this._element.focus())
            }
        }
        _adjustDialog() {
            var e, t = this._element.scrollHeight > document.documentElement.clientHeight,
                i = this._scrollBar.getWidth(),
                s = 0 < i;
            s && !t && (e = l() ? "paddingLeft" : "paddingRight", this._element.style[e] = i + "px"), !s && t && (e = l() ? "paddingRight" : "paddingLeft", this._element.style[e] = i + "px")
        }
        _resetAdjustments() {
            this._element.style.paddingLeft = "", this._element.style.paddingRight = ""
        }
        static jQueryInterface(t, i) {
            return this.each(function () {
                var e = O.getOrCreateInstance(this, t);
                if ("string" == typeof t) {
                    if (void 0 === e[t]) throw new TypeError(`No method named "${t}"`);
                    e[t](i)
                }
            })
        }
    }
    f.on(document, "click.bs.modal.data-api", '[data-bs-toggle="modal"]', function (e) {
        const t = n(this);
        ["A", "AREA"].includes(this.tagName) && e.preventDefault(), f.one(t, at, e => {
            e.defaultPrevented || f.one(t, rt, () => {
                r(this) && this.focus()
            })
        });
        e = g.findOne(".modal.show");
        e && O.getInstance(e).hide(), O.getOrCreateInstance(t).toggle(this)
    }), ue(O), e(O);
    T = ".bs.offcanvas";
    const ut = "showing",
        mt = ".offcanvas.show",
        gt = "hidePrevented" + T,
        ft = "hidden" + T;
    const pt = {
        backdrop: !0,
        keyboard: !0,
        scroll: !1
    },
        _t = {
            backdrop: "(boolean|string)",
            keyboard: "boolean",
            scroll: "boolean"
        };
    class S extends m {
        constructor(e, t) {
            super(e, t), this._isShown = !1, this._backdrop = this._initializeBackDrop(), this._focustrap = this._initializeFocusTrap(), this._addEventListeners()
        }
        static get Default() {
            return pt
        }
        static get DefaultType() {
            return _t
        }
        static get NAME() {
            return "offcanvas"
        }
        toggle(e) {
            return this._isShown ? this.hide() : this.show(e)
        }
        show(e) {
            this._isShown || f.trigger(this._element, "show.bs.offcanvas", {
                relatedTarget: e
            }).defaultPrevented || (this._isShown = !0, this._backdrop.show(), this._config.scroll || (new Ye).hide(), this._element.setAttribute("aria-modal", !0), this._element.setAttribute("role", "dialog"), this._element.classList.add(ut), this._queueCallback(() => {
                this._config.scroll && !this._config.backdrop || this._focustrap.activate(), this._element.classList.add("show"), this._element.classList.remove(ut), f.trigger(this._element, "shown.bs.offcanvas", {
                    relatedTarget: e
                })
            }, this._element, !0))
        }
        hide() {
            this._isShown && !f.trigger(this._element, "hide.bs.offcanvas").defaultPrevented && (this._focustrap.deactivate(), this._element.blur(), this._isShown = !1, this._element.classList.add("hiding"), this._backdrop.hide(), this._queueCallback(() => {
                this._element.classList.remove("show", "hiding"), this._element.removeAttribute("aria-modal"), this._element.removeAttribute("role"), this._config.scroll || (new Ye).reset(), f.trigger(this._element, ft)
            }, this._element, !0))
        }
        dispose() {
            this._backdrop.dispose(), this._focustrap.deactivate(), super.dispose()
        }
        _initializeBackDrop() {
            var e = Boolean(this._config.backdrop);
            return new et({
                className: "offcanvas-backdrop",
                isVisible: e,
                isAnimated: !0,
                rootElement: this._element.parentNode,
                clickCallback: e ? () => {
                    "static" === this._config.backdrop ? f.trigger(this._element, gt) : this.hide()
                } : null
            })
        }
        _initializeFocusTrap() {
            return new ot({
                trapElement: this._element
            })
        }
        _addEventListeners() {
            f.on(this._element, "keydown.dismiss.bs.offcanvas", e => {
                "Escape" === e.key && (this._config.keyboard ? this.hide() : f.trigger(this._element, gt))
            })
        }
        static jQueryInterface(t) {
            return this.each(function () {
                var e = S.getOrCreateInstance(this, t);
                if ("string" == typeof t) {
                    if (void 0 === e[t] || t.startsWith("_") || "constructor" === t) throw new TypeError(`No method named "${t}"`);
                    e[t](this)
                }
            })
        }
    }
    f.on(document, "click.bs.offcanvas.data-api", '[data-bs-toggle="offcanvas"]', function (e) {
        var t = n(this);
        ["A", "AREA"].includes(this.tagName) && e.preventDefault(), a(this) || (f.one(t, ft, () => {
            r(this) && this.focus()
        }), (e = g.findOne(mt)) && e !== t && S.getInstance(e).hide(), S.getOrCreateInstance(t).toggle(this))
    }), f.on(window, "load.bs.offcanvas.data-api", () => {
        for (const e of g.find(mt)) S.getOrCreateInstance(e).show()
    }), f.on(window, "resize.bs.offcanvas", () => {
        for (const e of g.find("[aria-modal][class*=show][class*=offcanvas-]")) "fixed" !== getComputedStyle(e).position && S.getOrCreateInstance(e).hide()
    }), ue(S), e(S);
    const bt = new Set(["background", "cite", "href", "itemtype", "longdesc", "poster", "src", "xlink:href"]);
    const vt = /^(?:(?:https?|mailto|ftp|tel|file|sms):|[^#&/:?]*(?:[#/?]|$))/i,
        yt = /^data:(?:image\/(?:bmp|gif|jpeg|jpg|png|tiff|webp)|video\/(?:mpeg|mp4|ogg|webm)|audio\/(?:mp3|oga|ogg|opus));base64,[\d+/a-z]+=*$/i;
    _ = {
        "*": ["class", "dir", "id", "lang", "role", /^aria-[\w-]*$/i],
        a: ["target", "href", "title", "rel"],
        area: [],
        b: [],
        br: [],
        col: [],
        code: [],
        div: [],
        em: [],
        hr: [],
        h1: [],
        h2: [],
        h3: [],
        h4: [],
        h5: [],
        h6: [],
        i: [],
        img: ["src", "srcset", "alt", "title", "width", "height"],
        li: [],
        ol: [],
        p: [],
        pre: [],
        s: [],
        small: [],
        span: [],
        sub: [],
        sup: [],
        strong: [],
        u: [],
        ul: []
    };

    function wt(e, t, i) {
        if (!e.length) return e;
        if (i && "function" == typeof i) return i(e);
        i = (new window.DOMParser).parseFromString(e, "text/html");
        for (const r of [].concat(...i.body.querySelectorAll("*"))) {
            var s = r.nodeName.toLowerCase();
            if (Object.keys(t).includes(s)) {
                var n = [].concat(...r.attributes),
                    o = [].concat(t["*"] || [], t[s] || []);
                for (const a of n) ((e, t) => {
                    const i = e.nodeName.toLowerCase();
                    return t.includes(i) ? !bt.has(i) || Boolean(vt.test(e.nodeValue) || yt.test(e.nodeValue)) : t.filter(e => e instanceof RegExp).some(e => e.test(i))
                })(a, o) || r.removeAttribute(a.nodeName)
            } else r.remove()
        }
        return i.body.innerHTML
    }
    const Ct = {
        allowList: _,
        content: {},
        extraClass: "",
        html: !1,
        sanitize: !0,
        sanitizeFn: null,
        template: "<div></div>"
    },
        At = {
            allowList: "object",
            content: "object",
            extraClass: "(string|function)",
            html: "boolean",
            sanitize: "boolean",
            sanitizeFn: "(null|function)",
            template: "string"
        },
        Tt = {
            entry: "(string|element|function|null)",
            selector: "(string|element)"
        };
    class Et extends t {
        constructor(e) {
            super(), this._config = this._getConfig(e)
        }
        static get Default() {
            return Ct
        }
        static get DefaultType() {
            return At
        }
        static get NAME() {
            return "TemplateFactory"
        }
        getContent() {
            return Object.values(this._config.content).map(e => this._resolvePossibleFunction(e)).filter(Boolean)
        }
        hasContent() {
            return 0 < this.getContent().length
        }
        changeContent(e) {
            return this._checkContent(e), this._config.content = {
                ...this._config.content,
                ...e
            }, this
        }
        toHtml() {
            var e, t, i = document.createElement("div");
            i.innerHTML = this._maybeSanitize(this._config.template);
            for ([e, t] of Object.entries(this._config.content)) this._setContent(i, t, e);
            var s = i.children[0],
                n = this._resolvePossibleFunction(this._config.extraClass);
            return n && s.classList.add(...n.split(" ")), s
        }
        _typeCheckConfig(e) {
            super._typeCheckConfig(e), this._checkContent(e.content)
        }
        _checkContent(e) {
            for (var [t, i] of Object.entries(e)) super._typeCheckConfig({
                selector: t,
                entry: i
            }, Tt)
        }
        _setContent(e, t, i) {
            i = g.findOne(i, e);
            i && ((t = this._resolvePossibleFunction(t)) ? o(t) ? this._putElementInTemplate(s(t), i) : this._config.html ? i.innerHTML = this._maybeSanitize(t) : i.textContent = t : i.remove())
        }
        _maybeSanitize(e) {
            return this._config.sanitize ? wt(e, this._config.allowList, this._config.sanitizeFn) : e
        }
        _resolvePossibleFunction(e) {
            return "function" == typeof e ? e(this) : e
        }
        _putElementInTemplate(e, t) {
            this._config.html ? (t.innerHTML = "", t.append(e)) : t.textContent = e.textContent
        }
    }
    const kt = new Set(["sanitize", "allowList", "sanitizeFn"]),
        Lt = "fade";
    const Dt = "show",
        Ot = "hide.bs.modal",
        I = "hover",
        St = "focus",
        It = {
            AUTO: "auto",
            TOP: "top",
            RIGHT: l() ? "left" : "right",
            BOTTOM: "bottom",
            LEFT: l() ? "right" : "left"
        },
        Nt = {
            allowList: _,
            animation: !0,
            boundary: "clippingParents",
            container: !1,
            customClass: "",
            delay: 0,
            fallbackPlacements: ["top", "right", "bottom", "left"],
            html: !1,
            offset: [0, 0],
            placement: "top",
            popperConfig: null,
            sanitize: !0,
            sanitizeFn: null,
            selector: !1,
            template: '<div class="tooltip" role="tooltip"><div class="tooltip-arrow"></div><div class="tooltip-inner"></div></div>',
            title: "",
            trigger: "hover focus"
        },
        xt = {
            allowList: "object",
            animation: "boolean",
            boundary: "(string|element)",
            container: "(string|element|boolean)",
            customClass: "(string|function)",
            delay: "(number|object)",
            fallbackPlacements: "array",
            html: "boolean",
            offset: "(array|string|function)",
            placement: "(string|function)",
            popperConfig: "(null|object|function)",
            sanitize: "boolean",
            sanitizeFn: "(null|function)",
            selector: "(string|boolean)",
            template: "string",
            title: "(string|element|function)",
            trigger: "string"
        };
    class N extends m {
        constructor(e, t) {
            if (void 0 === i) throw new TypeError("Bootstrap's tooltips require Popper (https://popper.js.org)");
            super(e, t), this._isEnabled = !0, this._timeout = 0, this._isHovered = null, this._activeTrigger = {}, this._popper = null, this._templateFactory = null, this._newContent = null, this.tip = null, this._setListeners(), this._config.selector || this._fixTitle()
        }
        static get Default() {
            return Nt
        }
        static get DefaultType() {
            return xt
        }
        static get NAME() {
            return "tooltip"
        }
        enable() {
            this._isEnabled = !0
        }
        disable() {
            this._isEnabled = !1
        }
        toggleEnabled() {
            this._isEnabled = !this._isEnabled
        }
        toggle() {
            this._isEnabled && (this._activeTrigger.click = !this._activeTrigger.click, this._isShown() ? this._leave() : this._enter())
        }
        dispose() {
            clearTimeout(this._timeout), f.off(this._element.closest(".modal"), Ot, this._hideModalHandler), this._element.getAttribute("data-bs-original-title") && this._element.setAttribute("title", this._element.getAttribute("data-bs-original-title")), this._disposePopper(), super.dispose()
        }
        show() {
            if ("none" === this._element.style.display) throw new Error("Please use show on visible elements");
            if (this._isWithContent() && this._isEnabled) {
                var e = f.trigger(this._element, this.constructor.eventName("show")),
                    t = (W(this._element) || this._element.ownerDocument.documentElement).contains(this._element);
                if (!e.defaultPrevented && t) {
                    this._disposePopper();
                    e = this._getTipElement(), t = (this._element.setAttribute("aria-describedby", e.getAttribute("id")), this._config)["container"];
                    if (this._element.ownerDocument.documentElement.contains(this.tip) || (t.append(e), f.trigger(this._element, this.constructor.eventName("inserted"))), this._popper = this._createPopper(e), e.classList.add(Dt), "ontouchstart" in document.documentElement)
                        for (const i of [].concat(...document.body.children)) f.on(i, "mouseover", $);
                    this._queueCallback(() => {
                        f.trigger(this._element, this.constructor.eventName("shown")), !1 === this._isHovered && this._leave(), this._isHovered = !1
                    }, this.tip, this._isAnimated())
                }
            }
        }
        hide() {
            if (this._isShown()) {
                var e = f.trigger(this._element, this.constructor.eventName("hide"));
                if (!e.defaultPrevented) {
                    if (this._getTipElement().classList.remove(Dt), "ontouchstart" in document.documentElement)
                        for (const t of [].concat(...document.body.children)) f.off(t, "mouseover", $);
                    this._activeTrigger.click = !1, this._activeTrigger[St] = !1, this._activeTrigger[I] = !1, this._isHovered = null;
                    this._queueCallback(() => {
                        this._isWithActiveTrigger() || (this._isHovered || this._disposePopper(), this._element.removeAttribute("aria-describedby"), f.trigger(this._element, this.constructor.eventName("hidden")))
                    }, this.tip, this._isAnimated())
                }
            }
        }
        update() {
            this._popper && this._popper.update()
        }
        _isWithContent() {
            return Boolean(this._getTitle())
        }
        _getTipElement() {
            return this.tip || (this.tip = this._createTipElement(this._newContent || this._getContentForTemplate())), this.tip
        }
        _createTipElement(e) {
            e = this._getTemplateFactory(e).toHtml();
            if (!e) return null;
            e.classList.remove(Lt, Dt), e.classList.add(`bs-${this.constructor.NAME}-auto`);
            var t = (e => {
                for (; e += Math.floor(1e6 * Math.random()), document.getElementById(e););
                return e
            })(this.constructor.NAME).toString();
            return e.setAttribute("id", t), this._isAnimated() && e.classList.add(Lt), e
        }
        setContent(e) {
            this._newContent = e, this._isShown() && (this._disposePopper(), this.show())
        }
        _getTemplateFactory(e) {
            return this._templateFactory ? this._templateFactory.changeContent(e) : this._templateFactory = new Et({
                ...this._config,
                content: e,
                extraClass: this._resolvePossibleFunction(this._config.customClass)
            }), this._templateFactory
        }
        _getContentForTemplate() {
            return {
                ".tooltip-inner": this._getTitle()
            }
        }
        _getTitle() {
            return this._resolvePossibleFunction(this._config.title) || this._element.getAttribute("data-bs-original-title")
        }
        _initializeOnDelegatedTarget(e) {
            return this.constructor.getOrCreateInstance(e.delegateTarget, this._getDelegateConfig())
        }
        _isAnimated() {
            return this._config.animation || this.tip && this.tip.classList.contains(Lt)
        }
        _isShown() {
            return this.tip && this.tip.classList.contains(Dt)
        }
        _createPopper(e) {
            var t = "function" == typeof this._config.placement ? this._config.placement.call(this, e, this._element) : this._config.placement,
                t = It[t.toUpperCase()];
            return i.createPopper(this._element, e, this._getPopperConfig(t))
        }
        _getOffset() {
            const t = this._config["offset"];
            return "string" == typeof t ? t.split(",").map(e => Number.parseInt(e, 10)) : "function" == typeof t ? e => t(e, this._element) : t
        }
        _resolvePossibleFunction(e) {
            return "function" == typeof e ? e.call(this._element) : e
        }
        _getPopperConfig(e) {
            e = {
                placement: e,
                modifiers: [{
                    name: "flip",
                    options: {
                        fallbackPlacements: this._config.fallbackPlacements
                    }
                }, {
                    name: "offset",
                    options: {
                        offset: this._getOffset()
                    }
                }, {
                    name: "preventOverflow",
                    options: {
                        boundary: this._config.boundary
                    }
                }, {
                    name: "arrow",
                    options: {
                        element: `.${this.constructor.NAME}-arrow`
                    }
                }, {
                    name: "preSetPlacement",
                    enabled: !0,
                    phase: "beforeMain",
                    fn: e => {
                        this._getTipElement().setAttribute("data-popper-placement", e.state.placement)
                    }
                }]
            };
            return {
                ...e,
                ..."function" == typeof this._config.popperConfig ? this._config.popperConfig(e) : this._config.popperConfig
            }
        }
        _setListeners() {
            var e, t;
            for (const i of this._config.trigger.split(" ")) "click" === i ? f.on(this._element, this.constructor.eventName("click"), this._config.selector, e => {
                this._initializeOnDelegatedTarget(e).toggle()
            }) : "manual" !== i && (e = i === I ? this.constructor.eventName("mouseenter") : this.constructor.eventName("focusin"), t = i === I ? this.constructor.eventName("mouseleave") : this.constructor.eventName("focusout"), f.on(this._element, e, this._config.selector, e => {
                var t = this._initializeOnDelegatedTarget(e);
                t._activeTrigger["focusin" === e.type ? St : I] = !0, t._enter()
            }), f.on(this._element, t, this._config.selector, e => {
                var t = this._initializeOnDelegatedTarget(e);
                t._activeTrigger["focusout" === e.type ? St : I] = t._element.contains(e.relatedTarget), t._leave()
            }));
            this._hideModalHandler = () => {
                this._element && this.hide()
            }, f.on(this._element.closest(".modal"), Ot, this._hideModalHandler)
        }
        _fixTitle() {
            var e = this._element.getAttribute("title");
            e && (this._element.getAttribute("aria-label") || this._element.textContent.trim() || this._element.setAttribute("aria-label", e), this._element.setAttribute("data-bs-original-title", e), this._element.removeAttribute("title"))
        }
        _enter() {
            this._isShown() || this._isHovered ? this._isHovered = !0 : (this._isHovered = !0, this._setTimeout(() => {
                this._isHovered && this.show()
            }, this._config.delay.show))
        }
        _leave() {
            this._isWithActiveTrigger() || (this._isHovered = !1, this._setTimeout(() => {
                this._isHovered || this.hide()
            }, this._config.delay.hide))
        }
        _setTimeout(e, t) {
            clearTimeout(this._timeout), this._timeout = setTimeout(e, t)
        }
        _isWithActiveTrigger() {
            return Object.values(this._activeTrigger).includes(!0)
        }
        _getConfig(e) {
            var t = u.getDataAttributes(this._element);
            for (const i of Object.keys(t)) kt.has(i) && delete t[i];
            return e = {
                ...t,
                ..."object" == typeof e && e ? e : {}
            }, e = this._mergeConfigObj(e), e = this._configAfterMerge(e), this._typeCheckConfig(e), e
        }
        _configAfterMerge(e) {
            return e.container = !1 === e.container ? document.body : s(e.container), "number" == typeof e.delay && (e.delay = {
                show: e.delay,
                hide: e.delay
            }), "number" == typeof e.title && (e.title = e.title.toString()), "number" == typeof e.content && (e.content = e.content.toString()), e
        }
        _getDelegateConfig() {
            var e = {};
            for (const t in this._config) this.constructor.Default[t] !== this._config[t] && (e[t] = this._config[t]);
            return e.selector = !1, e.trigger = "manual", e
        }
        _disposePopper() {
            this._popper && (this._popper.destroy(), this._popper = null), this.tip && (this.tip.remove(), this.tip = null)
        }
        static jQueryInterface(t) {
            return this.each(function () {
                var e = N.getOrCreateInstance(this, t);
                if ("string" == typeof t) {
                    if (void 0 === e[t]) throw new TypeError(`No method named "${t}"`);
                    e[t]()
                }
            })
        }
    }
    e(N);
    const Pt = {
        ...N.Default,
        content: "",
        offset: [0, 8],
        placement: "right",
        template: '<div class="popover" role="tooltip"><div class="popover-arrow"></div><h3 class="popover-header"></h3><div class="popover-body"></div></div>',
        trigger: "click"
    },
        jt = {
            ...N.DefaultType,
            content: "(null|string|element|function)"
        };
    class Mt extends N {
        static get Default() {
            return Pt
        }
        static get DefaultType() {
            return jt
        }
        static get NAME() {
            return "popover"
        }
        _isWithContent() {
            return this._getTitle() || this._getContent()
        }
        _getContentForTemplate() {
            return {
                ".popover-header": this._getTitle(),
                ".popover-body": this._getContent()
            }
        }
        _getContent() {
            return this._resolvePossibleFunction(this._config.content)
        }
        static jQueryInterface(t) {
            return this.each(function () {
                var e = Mt.getOrCreateInstance(this, t);
                if ("string" == typeof t) {
                    if (void 0 === e[t]) throw new TypeError(`No method named "${t}"`);
                    e[t]()
                }
            })
        }
    }
    e(Mt);
    je = ".bs.scrollspy";
    const zt = "click" + je;
    const x = "active",
        qt = "[href]";
    const Ht = {
        offset: null,
        rootMargin: "0px 0px -25%",
        smoothScroll: !1,
        target: null,
        threshold: [.1, .5, 1]
    },
        Ft = {
            offset: "(number|null)",
            rootMargin: "string",
            smoothScroll: "boolean",
            target: "element",
            threshold: "array"
        };
    class Bt extends m {
        constructor(e, t) {
            super(e, t), this._targetLinks = new Map, this._observableSections = new Map, this._rootElement = "visible" === getComputedStyle(this._element).overflowY ? null : this._element, this._activeTarget = null, this._observer = null, this._previousScrollData = {
                visibleEntryTop: 0,
                parentScrollTop: 0
            }, this.refresh()
        }
        static get Default() {
            return Ht
        }
        static get DefaultType() {
            return Ft
        }
        static get NAME() {
            return "scrollspy"
        }
        refresh() {
            this._initializeTargetsAndObservables(), this._maybeEnableSmoothScroll(), this._observer ? this._observer.disconnect() : this._observer = this._getNewObserver();
            for (const e of this._observableSections.values()) this._observer.observe(e)
        }
        dispose() {
            this._observer.disconnect(), super.dispose()
        }
        _configAfterMerge(e) {
            return e.target = s(e.target) || document.body, e.rootMargin = e.offset ? e.offset + "px 0px -30%" : e.rootMargin, "string" == typeof e.threshold && (e.threshold = e.threshold.split(",").map(e => Number.parseFloat(e))), e
        }
        _maybeEnableSmoothScroll() {
            this._config.smoothScroll && (f.off(this._config.target, zt), f.on(this._config.target, zt, qt, e => {
                var t = this._observableSections.get(e.target.hash);
                t && (e.preventDefault(), e = this._rootElement || window, t = t.offsetTop - this._element.offsetTop, e.scrollTo ? e.scrollTo({
                    top: t,
                    behavior: "smooth"
                }) : e.scrollTop = t)
            }))
        }
        _getNewObserver() {
            var e = {
                root: this._rootElement,
                threshold: this._config.threshold,
                rootMargin: this._config.rootMargin
            };
            return new IntersectionObserver(e => this._observerCallback(e), e)
        }
        _observerCallback(e) {
            const t = e => this._targetLinks.get("#" + e.target.id);
            var i = e => {
                this._previousScrollData.visibleEntryTop = e.target.offsetTop, this._process(t(e))
            },
                s = (this._rootElement || document.documentElement).scrollTop,
                n = s >= this._previousScrollData.parentScrollTop;
            this._previousScrollData.parentScrollTop = s;
            for (const r of e)
                if (r.isIntersecting) {
                    var o = r.target.offsetTop >= this._previousScrollData.visibleEntryTop;
                    if (n && o) {
                        if (i(r), s) continue;
                        return
                    }
                    n || o || i(r)
                } else this._activeTarget = null, this._clearActiveClass(t(r))
        }
        _initializeTargetsAndObservables() {
            var e;
            this._targetLinks = new Map, this._observableSections = new Map;
            for (const t of g.find(qt, this._config.target)) t.hash && !a(t) && (e = g.findOne(t.hash, this._element), r(e)) && (this._targetLinks.set(t.hash, t), this._observableSections.set(t.hash, e))
        }
        _process(e) {
            this._activeTarget !== e && (this._clearActiveClass(this._config.target), (this._activeTarget = e).classList.add(x), this._activateParents(e), f.trigger(this._element, "activate.bs.scrollspy", {
                relatedTarget: e
            }))
        }
        _activateParents(e) {
            if (e.classList.contains("dropdown-item")) g.findOne(".dropdown-toggle", e.closest(".dropdown")).classList.add(x);
            else
                for (const t of g.parents(e, ".nav, .list-group"))
                    for (const i of g.prev(t, ".nav-link, .nav-item > .nav-link, .list-group-item")) i.classList.add(x)
        }
        _clearActiveClass(e) {
            e.classList.remove(x);
            for (const t of g.find(qt + "." + x, e)) t.classList.remove(x)
        }
        static jQueryInterface(t) {
            return this.each(function () {
                var e = Bt.getOrCreateInstance(this, t);
                if ("string" == typeof t) {
                    if (void 0 === e[t] || t.startsWith("_") || "constructor" === t) throw new TypeError(`No method named "${t}"`);
                    e[t]()
                }
            })
        }
    }
    f.on(window, "load.bs.scrollspy.data-api", () => {
        for (const e of g.find('[data-bs-spy="scroll"]')) Bt.getOrCreateInstance(e)
    }), e(Bt);
    const Wt = "ArrowRight",
        $t = "ArrowDown",
        P = "active",
        Qt = "show";
    T = '[data-bs-toggle="tab"], [data-bs-toggle="pill"], [data-bs-toggle="list"]';
    const Rt = '.nav-link:not(.dropdown-toggle), .list-group-item:not(.dropdown-toggle), [role="tab"]:not(.dropdown-toggle), ' + T;
    P, P, P;
    class j extends m {
        constructor(e) {
            super(e), this._parent = this._element.closest('.list-group, .nav, [role="tablist"]'), this._parent && (this._setInitialAttributes(this._parent, this._getChildren()), f.on(this._element, "keydown.bs.tab", e => this._keydown(e)))
        }
        static get NAME() {
            return "tab"
        }
        show() {
            var e, t, i = this._element;
            this._elemIsActive(i) || (t = (e = this._getActiveElem()) ? f.trigger(e, "hide.bs.tab", {
                relatedTarget: i
            }) : null, f.trigger(i, "show.bs.tab", {
                relatedTarget: e
            }).defaultPrevented) || t && t.defaultPrevented || (this._deactivate(e, i), this._activate(i, e))
        }
        _activate(e, t) {
            e && (e.classList.add(P), this._activate(n(e)), this._queueCallback(() => {
                "tab" !== e.getAttribute("role") ? e.classList.add(Qt) : (e.removeAttribute("tabindex"), e.setAttribute("aria-selected", !0), this._toggleDropDown(e, !0), f.trigger(e, "shown.bs.tab", {
                    relatedTarget: t
                }))
            }, e, e.classList.contains("fade")))
        }
        _deactivate(e, t) {
            e && (e.classList.remove(P), e.blur(), this._deactivate(n(e)), this._queueCallback(() => {
                "tab" !== e.getAttribute("role") ? e.classList.remove(Qt) : (e.setAttribute("aria-selected", !1), e.setAttribute("tabindex", "-1"), this._toggleDropDown(e, !1), f.trigger(e, "hidden.bs.tab", {
                    relatedTarget: t
                }))
            }, e, e.classList.contains("fade")))
        }
        _keydown(e) {
            var t;
            ["ArrowLeft", Wt, "ArrowUp", $t].includes(e.key) && (e.stopPropagation(), e.preventDefault(), t = [Wt, $t].includes(e.key), e = K(this._getChildren().filter(e => !a(e)), e.target, t, !0)) && (e.focus({
                preventScroll: !0
            }), j.getOrCreateInstance(e).show())
        }
        _getChildren() {
            return g.find(Rt, this._parent)
        }
        _getActiveElem() {
            return this._getChildren().find(e => this._elemIsActive(e)) || null
        }
        _setInitialAttributes(e, t) {
            this._setAttributeIfNotExists(e, "role", "tablist");
            for (const i of t) this._setInitialAttributesOnChild(i)
        }
        _setInitialAttributesOnChild(e) {
            e = this._getInnerElement(e);
            var t = this._elemIsActive(e),
                i = this._getOuterElement(e);
            e.setAttribute("aria-selected", t), i !== e && this._setAttributeIfNotExists(i, "role", "presentation"), t || e.setAttribute("tabindex", "-1"), this._setAttributeIfNotExists(e, "role", "tab"), this._setInitialAttributesOnTargetPanel(e)
        }
        _setInitialAttributesOnTargetPanel(e) {
            var t = n(e);
            t && (this._setAttributeIfNotExists(t, "role", "tabpanel"), e.id) && this._setAttributeIfNotExists(t, "aria-labelledby", "#" + e.id)
        }
        _toggleDropDown(e, i) {
            const s = this._getOuterElement(e);
            s.classList.contains("dropdown") && ((e = (e, t) => {
                e = g.findOne(e, s);
                e && e.classList.toggle(t, i)
            })(".dropdown-toggle", P), e(".dropdown-menu", Qt), s.setAttribute("aria-expanded", i))
        }
        _setAttributeIfNotExists(e, t, i) {
            e.hasAttribute(t) || e.setAttribute(t, i)
        }
        _elemIsActive(e) {
            return e.classList.contains(P)
        }
        _getInnerElement(e) {
            return e.matches(Rt) ? e : g.findOne(Rt, e)
        }
        _getOuterElement(e) {
            return e.closest(".nav-item, .list-group-item") || e
        }
        static jQueryInterface(t) {
            return this.each(function () {
                var e = j.getOrCreateInstance(this);
                if ("string" == typeof t) {
                    if (void 0 === e[t] || t.startsWith("_") || "constructor" === t) throw new TypeError(`No method named "${t}"`);
                    e[t]()
                }
            })
        }
    }
    f.on(document, "click.bs.tab", T, function (e) {
        ["A", "AREA"].includes(this.tagName) && e.preventDefault(), a(this) || j.getOrCreateInstance(this).show()
    }), f.on(window, "load.bs.tab", () => {
        for (const e of g.find('.active[data-bs-toggle="tab"], .active[data-bs-toggle="pill"], .active[data-bs-toggle="list"]')) j.getOrCreateInstance(e)
    }), e(j);
    const Vt = "show",
        Kt = "showing",
        Xt = {
            animation: "boolean",
            autohide: "boolean",
            delay: "number"
        },
        Yt = {
            animation: !0,
            autohide: !0,
            delay: 5e3
        };
    class Ut extends m {
        constructor(e, t) {
            super(e, t), this._timeout = null, this._hasMouseInteraction = !1, this._hasKeyboardInteraction = !1, this._setListeners()
        }
        static get Default() {
            return Yt
        }
        static get DefaultType() {
            return Xt
        }
        static get NAME() {
            return "toast"
        }
        show() {
            f.trigger(this._element, "show.bs.toast").defaultPrevented || (this._clearTimeout(), this._config.animation && this._element.classList.add("fade"), this._element.classList.remove("hide"), c(this._element), this._element.classList.add(Vt, Kt), this._queueCallback(() => {
                this._element.classList.remove(Kt), f.trigger(this._element, "shown.bs.toast"), this._maybeScheduleHide()
            }, this._element, this._config.animation))
        }
        hide() {
            this.isShown() && !f.trigger(this._element, "hide.bs.toast").defaultPrevented && (this._element.classList.add(Kt), this._queueCallback(() => {
                this._element.classList.add("hide"), this._element.classList.remove(Kt, Vt), f.trigger(this._element, "hidden.bs.toast")
            }, this._element, this._config.animation))
        }
        dispose() {
            this._clearTimeout(), this.isShown() && this._element.classList.remove(Vt), super.dispose()
        }
        isShown() {
            return this._element.classList.contains(Vt)
        }
        _maybeScheduleHide() {
            !this._config.autohide || this._hasMouseInteraction || this._hasKeyboardInteraction || (this._timeout = setTimeout(() => {
                this.hide()
            }, this._config.delay))
        }
        _onInteraction(e, t) {
            switch (e.type) {
                case "mouseover":
                case "mouseout":
                    this._hasMouseInteraction = t;
                    break;
                case "focusin":
                case "focusout":
                    this._hasKeyboardInteraction = t
            }
            t ? this._clearTimeout() : (e = e.relatedTarget, this._element === e || this._element.contains(e) || this._maybeScheduleHide())
        }
        _setListeners() {
            f.on(this._element, "mouseover.bs.toast", e => this._onInteraction(e, !0)), f.on(this._element, "mouseout.bs.toast", e => this._onInteraction(e, !1)), f.on(this._element, "focusin.bs.toast", e => this._onInteraction(e, !0)), f.on(this._element, "focusout.bs.toast", e => this._onInteraction(e, !1))
        }
        _clearTimeout() {
            clearTimeout(this._timeout), this._timeout = null
        }
        static jQueryInterface(t) {
            return this.each(function () {
                var e = Ut.getOrCreateInstance(this, t);
                if ("string" == typeof t) {
                    if (void 0 === e[t]) throw new TypeError(`No method named "${t}"`);
                    e[t](this)
                }
            })
        }
    }
    return ue(Ut), e(Ut), {
        Alert: me,
        Button: fe,
        Carousel: w,
        Collapse: A,
        Dropdown: L,
        Modal: O,
        Offcanvas: S,
        Popover: Mt,
        ScrollSpy: Bt,
        Tab: j,
        Toast: Ut,
        Tooltip: N
    }
}, "object" == typeof exports && "undefined" != typeof module ? module.exports = e(require("@popperjs/core")) : "function" == typeof define && define.amd ? define(["@popperjs/core"], e) : (t = "undefined" != typeof globalThis ? globalThis : t || self).bootstrap = e(t.Popper), e = function (a) {
    "use strict";
    a.fn.menu = function (t) {
        var n = a.extend({}, {
            element: {
                main: ".menu-item",
                toggle: ".menu-item-toggle",
                link: ".menu-item-link",
                menu: ".menu-submenu"
            },
            data: {
                activated: "menu-activated",
                numParent: "menu-num-parent",
                height: "menu-height",
                path: "menu-path"
            },
            activeClass: "active"
        }, a.fn.menu.defaults),
            e = [{
                event: "init",
                action: function () {
                    var e = a("body").hasClass("aside-minimized"),
                        t = window.location.pathname,
                        i = 0;
                    e && a("body").removeClass("aside-minimized"), a(n.element.main).each(function () {
                        var e = a(this).parents(n.element.menu).length;
                        i < e && (i = e), a(this).data(n.data.numParent, e)
                    }), a(n.element.link).each(function () {
                        a(this).data(n.data.path) == t && (a(this).addClass(n.activeClass), a(this).parents(n.element.main).each(function () {
                            var e = a(this).children(n.element.menu);
                            e.length && o(e)
                        }))
                    });
                    for (var s = i; 0 <= s; s--) a(n.element.main).each(function () {
                        var e, t = a(this).data(n.data.numParent),
                            i = a(this).children(n.element.menu);
                        t == s && (a(this).data(n.data.activated, !0), 0 != i.length) && (e = (t = i).outerHeight(), t.data(n.data.height, e), (a(this).children(n.element.toggle).hasClass(n.activeClass) ? o : r)(i))
                    });
                    e && a("body").addClass("aside-minimized"), a(n.element.toggle).on("click", function () {
                        var e = a(this).siblings(n.element.menu);
                        (e.data(n.data.activated) ? r : o)(e)
                    })
                }
            }, {
                event: "show",
                action: function (e) {
                    o(e)
                }
            }, {
                event: "hide",
                action: function (e) {
                    r(e)
                }
            }];

        function o(e) {
            var t = '828px';
            var e = e.first()
            if (e.hasClass(n.element.menu.substr(1))) {
                e.css("height", t);
                e.siblings(n.element.toggle).addClass(n.activeClass), e.data(n.data.activated, !0);
            }


          /*  (e = e.first()).hasClass(n.element.menu.substr(1)), e.parents(n.element.menu).each(function () {*/
            //(e = e.first()).hasClass(n.element.menu.substr(1)) && (t = e.data(n.data.height), e.parent(n.element.main).data(n.data.numParent), e.css("height", t), e.parents(n.element.menu).each(function () {
            //    var e = a(this).data(n.data.height) + t;
            //    a(this).css("height", e), a(this).data(n.data.height, e)
            //}), e.siblings(n.element.toggle).addClass(n.activeClass), e.data(n.data.activated, !0))
        }

        function r(e) {
            var t;
            (e = e.first()).hasClass(n.element.menu.substr(1)) && (t = e.data(n.data.height), e.css("height", 0), e.parents(n.element.menu).each(function () {
                var e = a(this).data(n.data.height) - t;
                a(this).data(n.data.height, e), a(this).css("height", e)
            }), e.siblings(n.element.toggle).removeClass(n.activeClass), e.data(n.data.activated, !1))
        }
        var i = a(this);
        return "string" == typeof t && e.forEach(function (e) {
            t == e.event && e.action(i)
        }), this
    }, a(function () {
        a().menu("init")
    })
}, "function" == typeof define && define.amd ? define(["jquery"], e) : "object" == typeof module && module.exports ? module.exports = e(require("jquery")) : e(jQuery), t = function (r) {
    "use strict";
    r.fn.portlet = function (t) {
        var i = r.extend({}, {
            element: {
                main: ".portlet",
                body: ".portlet-body"
            },
            data: {
                hidden: "portlet-hidden"
            },
            collapsedClass: "portlet-collapsed",
            destroyMethod: "fade",
            easing: "linear",
            transitionDuration: 200
        }, r.fn.portlet.defaults),
            e = [{
                event: "collapse",
                action: function (e) {
                    s(e)
                }
            }, {
                event: "uncollapse",
                action: function (e) {
                    n(e)
                }
            }, {
                event: "toggleCollapse",
                action: function (e) {
                    ((e = e).data(i.data.hidden) ? n : s)(e)
                }
            }, {
                event: "destroy",
                action: function (e) {
                    var t;
                    e.hasClass(i.element.main.substr(1)) && ("fade" !== (t = i.destroyMethod) && "slide" === t ? e.slideUp(i.transitionDuration) : e.fadeOut(i.transitionDuration))
                }
            }];

        function s(e) {
            e.hasClass(i.element.main.substr(1)) && e.find(i.element.body).slideUp({
                duration: i.transitionDuration,
                easing: i.easing,
                complete: function () {
                    e.data(i.data.hidden, !0), e.addClass(i.collapsedClass)
                }
            })
        }

        function n(e) {
            e.hasClass(i.element.main.substr(1)) && e.find(i.element.body).slideDown({
                duration: i.transitionDuration,
                easing: i.easing,
                complete: function () {
                    e.data(i.data.hidden, !1)
                }
            }).removeClass(i.collapsedClass)
        }
        var o = r(this);
        return "string" == typeof t && e.forEach(function (e) {
            t == e.event && e.action(o)
        }), this
    }
}, "function" == typeof define && define.amd ? define(["jquery"], t) : "object" == typeof module && module.exports ? module.exports = t(require("jquery")) : t(jQuery), e = function (i) {
    "use strict";
    i.scrollToTop = function () {
        var e = i.extend({}, {
            element: ".scrolltop",
            activeClass: "active",
            scrollHeight: 200,
            transitionDuration: 500
        }, i.scrollToTop.defaults);

        function t() {
            i(e.element).addClass(e.activeClass)
        }
        i(window).scrollTop() >= e.scrollHeight && t(), i(window).scroll(function () {
            i(this).scrollTop() >= e.scrollHeight ? t() : i(e.element).removeClass(e.activeClass)
        }), i(e.element).on("click", function () {
            i("html").animate({
                scrollTop: 0
            }, e.transitionDuration)
        })
    }, i(function () {
        i.scrollToTop()
    })
}, "function" == typeof define && define.amd ? define(["jquery"], e) : "object" == typeof module && module.exports ? module.exports = e(require("jquery")) : e(jQuery), t = function (u) {
    "use strict";
    u.aside = function (t) {
        var s = u.extend({}, {
            element: {
                main: ".aside",
                backdrop: "#aside-backdrop",
                toggle: '[data-toggle="aside"]'
            },
            breakpoint: 1025,
            class: {
                minimizedDesktop: "aside-desktop-minimized",
                minimizedMobile: "aside-mobile-minimized",
                maximizedDesktop: "aside-desktop-maximized",
                maximizedMobile: "aside-mobile-maximized",
                hover: "aside-hover"
            },
            localStorage: "aside-storage",
            transitionDuration: 200,
            easing: "linear"
        }, u.aside.defaults),
            e = [{
                event: "init",
                action: function (e) {
                    var t = u(s.element.toggle),
                        i = localStorage.getItem(s.localStorage);
                    i ? (i = JSON.parse(i).minimized, u(window).width() >= s.breakpoint && (i ? (c(), setTimeout(function () {
                        u(".aside, .wrapper").css("transition", "")
                    }, s.transitionDuration)) : (h(), u(".aside, .wrapper").css("transition", "")))) : (u("body").hasClass(s.class.minimizedDesktop) && u(s.element.main).addClass(s.class.hover), u(".aside, .wrapper").css("transition", "")), t.on("click", function () {
                        var e = u(t.data("target"));
                        0 < e.length || u(s.element.main);
                        n()
                    })
                }
            }, {
                event: "toggle",
                action: function () {
                    n()
                }
            }, {
                event: "minimize",
                action: function () {
                    i()
                }
            }, {
                event: "maximize",
                action: function () {
                    o()
                }
            }];

        function n() {
            var e;
            0 < u(s.element.main).length && (e = u(window).width() >= s.breakpoint ? s.class.minimizedDesktop : s.class.minimizedMobile, (u("body").hasClass(e) ? o : i)())
        }

        function i() {
            0 < u(s.element.main).length && (u(window).width() >= s.breakpoint ? c : l)()
        }

        function o() {
            var e;
            0 < u(s.element.main).length && (u(window).width() >= s.breakpoint ? h() : (e = '<div id="' + s.element.backdrop.substr(1) + '"></div>', a(), (e = u(e).appendTo("body")).addClass("fade"), e.addClass("show"), e.on("click", function () {
                l()
            })))
        }

        function r() {
            var e, t = u(window).width() >= s.breakpoint ? (e = s.class.minimizedDesktop, s.class.maximizedDesktop) : (e = s.class.minimizedMobile, s.class.maximizedMobile);
            u("body").addClass(e), u("body").removeClass(t)
        }

        function a() {
            var e, t = u(window).width() >= s.breakpoint ? (e = s.class.maximizedDesktop, s.class.minimizedDesktop) : (e = s.class.maximizedMobile, s.class.minimizedMobile);
            u("body").addClass(e), u("body").removeClass(t)
        }

        function l() {
            r();
            var e = u(s.element.backdrop);
            e.removeClass("show"), e.off(), e.remove()
        }

        function c() {
            var e = u(s.element.main);
            r(), localStorage.setItem(s.localStorage, JSON.stringify({
                minimized: !0
            })), setTimeout(function () {
                e.first().addClass(s.class.hover)
            }, s.transitionDuration), u(window).trigger("resize")
        }

        function h() {
            var e = u(s.element.main);
            a(), localStorage.setItem(s.localStorage, JSON.stringify({
                minimized: !1
            })), e.first().removeClass(s.class.hover), u(window).trigger("resize")
        }
        var d = u(this);
        return "string" == typeof t && e.forEach(function (e) {
            t == e.event && e.action(d)
        }), this
    }, 1025 <= u(window).width() && u(".aside, .wrapper").css("transition", "none"), u(function () {
        u.aside("init")
    })
}, "function" == typeof define && define.amd ? define(["jquery"], t) : "object" == typeof module && module.exports ? module.exports = t(require("jquery")) : t(jQuery), e = function (n) {
    "use strict";
    n.headerNav = function () {
        var i = n.extend({}, {
            headerNavElement: '[data-toggle*="header-nav"]',
            headerTabElement: '[data-toggle*="header-tab"]',
            headerLinkElement: "[data-href]",
            navLinkElement: ".nav-link",
            activeClass: "active"
        }, n.headerNav.defaults),
            s = !1;
        n(i.headerNavElement).find(i.headerTabElement).each(function () {
            var e = n(this),
                t = window.location.pathname;
            if (e.find(i.headerLinkElement).each(function () {
                if (n(this).data("href") == t) return n(i.headerTabElement).removeClass(i.activeClass), e.find(i.navLinkElement).addClass(i.activeClass), !(s = !0)
            }), s) return !1
        })
    }, n(function () {
        n.headerNav()
    })
}, "function" == typeof define && define.amd ? define(["jquery"], e) : "object" == typeof module && module.exports ? module.exports = e(require("jquery")) : e(jQuery), t = function (n) {
    "use strict";
    n.preload = function (t) {
        var e = n.extend({}, {
            bodyHideClass: "preload-hide",
            bodyActiveClass: "preload-active"
        }, n.preload.defaults),
            i = [{
                event: "show",
                action: function () {
                    n("body").removeClass(e.bodyHideClass), n("body").addClass(e.bodyActiveClass)
                }
            }, {
                event: "hide",
                action: function () {
                    n("body").addClass(e.bodyHideClass), n("body").removeClass(e.bodyActiveClass)
                }
            }];
        var s = n(this);
        return "string" == typeof t && i.forEach(function (e) {
            t == e.event && e.action(s)
        }), this
    }, setTimeout(function () {
        n.preload("hide")
    }, 6e3), n(function () {
        n.preload("hide")
    })
}, "function" == typeof define && define.amd ? define(["jquery"], t) : "object" == typeof module && module.exports ? module.exports = t(require("jquery")) : t(jQuery);