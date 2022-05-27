var isWK = false;
try{
    isWK = wx.getSystemInfoSync().renderer == 'h5';
}catch(e){
    isWK = typeof(window)!='undefined' && window.XMLHttpRequest;
}
/******/ (function(modules) { // webpackBootstrap
    /******/ 	// The module cache
    /******/ 	var installedModules = {};

    /******/ 	// The require function
    /******/ 	function __webpack_require__(moduleId) {

        /******/ 		// Check if module is in cache
        /******/ 		if(installedModules[moduleId])
        /******/ 			return installedModules[moduleId].exports;

        /******/ 		// Create a new module (and put it into the cache)
        /******/ 		var module = installedModules[moduleId] = {
            /******/ 			exports: {},
            /******/ 			id: moduleId,
            /******/ 			loaded: false
            /******/ 		};

        /******/ 		// Execute the module function
        /******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);

        /******/ 		// Flag the module as loaded
        /******/ 		module.loaded = true;

        /******/ 		// Return the exports of the module
        /******/ 		return module.exports;
        /******/ 	}


    /******/ 	// expose the modules object (__webpack_modules__)
    /******/ 	__webpack_require__.m = modules;

    /******/ 	// expose the module cache
    /******/ 	__webpack_require__.c = installedModules;

    /******/ 	// __webpack_public_path__
    /******/ 	__webpack_require__.p = "";

    /******/ 	// Load entry module and return exports
    /******/ 	return __webpack_require__(0);
    /******/ })
/************************************************************************/
/******/ ([
    /* 0 */
    /***/ (function(module, exports, __webpack_require__) {

        'use strict';

        var _window2 = __webpack_require__(1);

        var _window = _interopRequireWildcard(_window2);

        var _HTMLElement = __webpack_require__(5);

        var _HTMLElement2 = _interopRequireDefault(_HTMLElement);

        function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

        function _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj.default = obj; return newObj; } }

        var global = GameGlobal;

        function inject() {
            _window.addEventListener = function (type, listener) {
                _window.document.addEventListener(type, listener);
            };
            _window.removeEventListener = function (type, listener) {
                _window.document.removeEventListener(type, listener);
            };

            if (_window.canvas) {
                _window.canvas.addEventListener = _window.addEventListener;
                _window.canvas.removeEventListener = _window.removeEventListener;
            }

            var _wx$getSystemInfoSync = wx.getSystemInfoSync(),
                platform = _wx$getSystemInfoSync.platform;

            // 开发者工具无法重定义 window


            if (platform === 'devtools') {
                for (var key in _window) {
                    var descriptor = Object.getOwnPropertyDescriptor(global, key);

                    if (!descriptor || descriptor.configurable === true) {
                        Object.defineProperty(window, key, {
                            value: _window[key]
                        });
                    }
                }

                for (var _key in _window.document) {
                    var _descriptor = Object.getOwnPropertyDescriptor(global.document, _key);

                    if (!_descriptor || _descriptor.configurable === true) {
                        Object.defineProperty(global.document, _key, {
                            value: _window.document[_key]
                        });
                    }
                }
                window.parent = window;
            } else {
                for (var _key2 in _window) {
                    global[_key2] = _window[_key2];
                }
                global.window = _window;
                window = global;
                window.top = window.parent = window;
            }
        }

        if (!GameGlobal.__isAdapterInjected) {
            GameGlobal.__isAdapterInjected = true;
            inject();
        }

        /***/ }),
    /* 1 */
    /***/ (function(module, exports, __webpack_require__) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.cancelAnimationFrame = exports.requestAnimationFrame = exports.clearInterval = exports.clearTimeout = exports.setInterval = exports.setTimeout = exports.canvas = exports.location = exports.localStorage = exports.HTMLElement = exports.FileReader = exports.Audio = exports.Image = exports.WebSocket = /*exports.XMLHttpRequest =*/  exports.navigator = exports.document = undefined;
        if(!isWK){
            exports.XMLHttpRequest = undefined;
        }

        var _WindowProperties = __webpack_require__(2);

        Object.keys(_WindowProperties).forEach(function (key) {
            if (key === "default" || key === "__esModule") return;
            Object.defineProperty(exports, key, {
                enumerable: true,
                get: function get() {
                    return _WindowProperties[key];
                }
            });
        });

        var _constructor = __webpack_require__(4);

        Object.keys(_constructor).forEach(function (key) {
            if (key === "default" || key === "__esModule") return;
            Object.defineProperty(exports, key, {
                enumerable: true,
                get: function get() {
                    return _constructor[key];
                }
            });
        });

        var _Canvas = __webpack_require__(10);

        var _Canvas2 = _interopRequireDefault(_Canvas);

        var _document2 = __webpack_require__(11);

        var _document3 = _interopRequireDefault(_document2);

        var _navigator2 = __webpack_require__(18);

        var _navigator3 = _interopRequireDefault(_navigator2);

        var _XMLHttpRequest2 = __webpack_require__(19);

        var _XMLHttpRequest3 = _interopRequireDefault(_XMLHttpRequest2);

        var _WebSocket2 = __webpack_require__(20);

        var _WebSocket3 = _interopRequireDefault(_WebSocket2);

        var _Image2 = __webpack_require__(12);

        var _Image3 = _interopRequireDefault(_Image2);

        var _Audio2 = __webpack_require__(13);

        var _Audio3 = _interopRequireDefault(_Audio2);

        var _FileReader2 = __webpack_require__(21);

        var _FileReader3 = _interopRequireDefault(_FileReader2);

        var _HTMLElement2 = __webpack_require__(5);

        var _HTMLElement3 = _interopRequireDefault(_HTMLElement2);

        var _localStorage2 = __webpack_require__(22);

        var _localStorage3 = _interopRequireDefault(_localStorage2);

        var _location2 = __webpack_require__(23);

        var _location3 = _interopRequireDefault(_location2);

        function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

        exports.document = _document3.default;
        exports.navigator = _navigator3.default;
        if(!isWK){
            exports.XMLHttpRequest = _XMLHttpRequest3.default;
        }
        //exports.XMLHttpRequest = _XMLHttpRequest3.default;
        exports.WebSocket = _WebSocket3.default;
        exports.Image = _Image3.default;
        exports.Audio = _Audio3.default;
        exports.FileReader = _FileReader3.default;
        exports.HTMLElement = _HTMLElement3.default;
        exports.localStorage = _localStorage3.default;
        exports.location = _location3.default;

	// 模拟web中的CustomEvent接口
	function CustomEvent(event, params) {
		params = params || {
				bubbles: false,
				cancelable: false,
				detail: undefined
		};
		var evt = {
			type: event,
			bubbles: params.bubbles,
			cancelable: params.cancelable,
			detail: params.detail
		};
		return evt;
	};

	exports.CustomEvent = CustomEvent;

        // 暴露全局的 canvas
        var canvas = new _Canvas2.default();

        exports.canvas = canvas;
        exports.setTimeout = setTimeout;
        exports.setInterval = setInterval;
        exports.clearTimeout = clearTimeout;
        exports.clearInterval = clearInterval;
        exports.requestAnimationFrame = requestAnimationFrame;
        exports.cancelAnimationFrame = cancelAnimationFrame;

        /***/ }),
    /* 2 */
    /***/ (function(module, exports, __webpack_require__) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.performance = exports.ontouchend = exports.ontouchmove = exports.ontouchstart = exports.screen = exports.devicePixelRatio = exports.innerHeight = exports.innerWidth = undefined;

        var _performance2 = __webpack_require__(3);

        var _performance3 = _interopRequireDefault(_performance2);

        function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

        var _wx$getSystemInfoSync = wx.getSystemInfoSync(),
            screenWidth = _wx$getSystemInfoSync.screenWidth,
            screenHeight = _wx$getSystemInfoSync.screenHeight,
            devicePixelRatio = _wx$getSystemInfoSync.devicePixelRatio;

        var innerWidth = exports.innerWidth = screenWidth;
        var innerHeight = exports.innerHeight = screenHeight;
        exports.devicePixelRatio = devicePixelRatio;
        var screen = exports.screen = {
            availWidth: innerWidth,
            availHeight: innerHeight
        };
        var ontouchstart = exports.ontouchstart = null;
        var ontouchmove = exports.ontouchmove = null;
        var ontouchend = exports.ontouchend = null;

        exports.performance = _performance3.default;

        /***/ }),
    /* 3 */
    /***/ (function(module, exports) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        var performance = void 0;

        if (wx.getPerformance) {
            var _wx$getSystemInfoSync = wx.getSystemInfoSync(),
                platform = _wx$getSystemInfoSync.platform;

            var wxPerf = wx.getPerformance();
            var initTime = wxPerf.now();

            var clientPerfAdapter = Object.assign({}, wxPerf, {
                now: function now() {
                    return (wxPerf.now() - initTime) / 1000;
                }
            });

            performance = platform === 'devtools' ? wxPerf : clientPerfAdapter;
        }

        exports.default = performance;

        /***/ }),
    /* 4 */
    /***/ (function(module, exports, __webpack_require__) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.HTMLCanvasElement = exports.HTMLImageElement = undefined;

        var _HTMLElement3 = __webpack_require__(5);

        var _HTMLElement4 = _interopRequireDefault(_HTMLElement3);

        function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

        function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

        function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

        function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

        var HTMLImageElement = exports.HTMLImageElement = function (_HTMLElement) {
            _inherits(HTMLImageElement, _HTMLElement);

            function HTMLImageElement() {
                _classCallCheck(this, HTMLImageElement);

                return _possibleConstructorReturn(this, (HTMLImageElement.__proto__ || Object.getPrototypeOf(HTMLImageElement)).call(this, 'img'));
            }

            return HTMLImageElement;
        }(_HTMLElement4.default);

        var HTMLCanvasElement = exports.HTMLCanvasElement = function (_HTMLElement2) {
            _inherits(HTMLCanvasElement, _HTMLElement2);

            function HTMLCanvasElement() {
                _classCallCheck(this, HTMLCanvasElement);

                return _possibleConstructorReturn(this, (HTMLCanvasElement.__proto__ || Object.getPrototypeOf(HTMLCanvasElement)).call(this, 'canvas'));
            }

            return HTMLCanvasElement;
        }(_HTMLElement4.default);

        /***/ }),
    /* 5 */
    /***/ (function(module, exports, __webpack_require__) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });

        var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

        var _Element2 = __webpack_require__(6);

        var _Element3 = _interopRequireDefault(_Element2);

        var _util = __webpack_require__(9);

        var _WindowProperties = __webpack_require__(2);

        function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

        function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

        function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

        function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

        var HTMLElement = function (_Element) {
            _inherits(HTMLElement, _Element);

            function HTMLElement() {
                var tagName = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : '';

                _classCallCheck(this, HTMLElement);

                var _this = _possibleConstructorReturn(this, (HTMLElement.__proto__ || Object.getPrototypeOf(HTMLElement)).call(this));

                _this.className = '';
                _this.childern = [];
                _this.style = {
                    width: _WindowProperties.innerWidth + 'px',
                    height: _WindowProperties.innerHeight + 'px'
                };
                _this.insertBefore = _util.noop;
                _this.innerHTML = '';

                _this.tagName = tagName.toUpperCase();
                return _this;
            }

            _createClass(HTMLElement, [{
                key: 'setAttribute',
                value: function setAttribute(name, value) {
                    this[name] = value;
                }
            }, {
                key: 'getAttribute',
                value: function getAttribute(name) {
                    return this[name];
                }
            }, {
                key: 'getBoundingClientRect',
                value: function getBoundingClientRect() {
                    return {
                        top: 0,
                        left: 0,
                        width: _WindowProperties.innerWidth,
                        height: _WindowProperties.innerHeight
                    };
                }
            }, {
                key: 'focus',
                value: function focus() {}
            }, {
                key: 'clientWidth',
                get: function get() {
                    var ret = parseInt(this.style.fontSize, 10) * this.innerHTML.length;

                    return Number.isNaN(ret) ? 0 : ret;
                }
            }, {
                key: 'clientHeight',
                get: function get() {
                    var ret = parseInt(this.style.fontSize, 10);

                    return Number.isNaN(ret) ? 0 : ret;
                }
            }]);

            return HTMLElement;
        }(_Element3.default);

        exports.default = HTMLElement;

        /***/ }),
    /* 6 */
    /***/ (function(module, exports, __webpack_require__) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });

        var _Node2 = __webpack_require__(7);

        var _Node3 = _interopRequireDefault(_Node2);

        function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

        function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

        function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

        function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

        var ELement = function (_Node) {
            _inherits(ELement, _Node);

            function ELement() {
                _classCallCheck(this, ELement);

                var _this = _possibleConstructorReturn(this, (ELement.__proto__ || Object.getPrototypeOf(ELement)).call(this));

                _this.className = '';
                _this.children = [];
                return _this;
            }

            return ELement;
        }(_Node3.default);

        exports.default = ELement;

        /***/ }),
    /* 7 */
    /***/ (function(module, exports, __webpack_require__) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });

        var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

        var _EventTarget2 = __webpack_require__(8);

        var _EventTarget3 = _interopRequireDefault(_EventTarget2);

        function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

        function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

        function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

        function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

        var Node = function (_EventTarget) {
            _inherits(Node, _EventTarget);

            function Node() {
                _classCallCheck(this, Node);

                var _this = _possibleConstructorReturn(this, (Node.__proto__ || Object.getPrototypeOf(Node)).call(this));

                _this.childNodes = [];
                return _this;
            }

            _createClass(Node, [{
                key: 'appendChild',
                value: function appendChild(node) {
                    if (node instanceof Node) {
                        this.childNodes.push(node);
                    } else {
                        throw new TypeError('Failed to executed \'appendChild\' on \'Node\': parameter 1 is not of type \'Node\'.');
                    }
                }
            }, {
                key: 'cloneNode',
                value: function cloneNode() {
                    var copyNode = Object.create(this);

                    Object.assign(copyNode, this);
                    return copyNode;
                }
            }, {
                key: 'removeChild',
                value: function removeChild(node) {
                    var index = this.childNodes.findIndex(function (child) {
                        return child === node;
                    });

                    if (index > -1) {
                        return this.childNodes.splice(index, 1);
                    }
                    return null;
                }
            }]);

            return Node;
        }(_EventTarget3.default);

        exports.default = Node;

        /***/ }),
    /* 8 */
    /***/ (function(module, exports) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });

        var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

        function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

        var _events = new WeakMap();

        var EventTarget = function () {
            function EventTarget() {
                _classCallCheck(this, EventTarget);

                _events.set(this, {});
            }

            _createClass(EventTarget, [{
                key: 'addEventListener',
                value: function addEventListener(type, listener) {
                    var options = arguments.length > 2 && arguments[2] !== undefined ? arguments[2] : {};

                    var events = _events.get(this);

                    if (!events) {
                        events = {};
                        _events.set(this, events);
                    }
                    if (!events[type]) {
                        events[type] = [];
                    }
                    events[type].push(listener);

                    if (options.capture) {
                        console.warn('EventTarget.addEventListener: options.capture is not implemented.');
                    }
                    if (options.once) {
                        console.warn('EventTarget.addEventListener: options.once is not implemented.');
                    }
                    if (options.passive) {
                        console.warn('EventTarget.addEventListener: options.passive is not implemented.');
                    }
                }
            }, {
                key: 'removeEventListener',
                value: function removeEventListener(type, listener) {
                    var listeners = _events.get(this)[type];

                    if (listeners && listeners.length > 0) {
                        for (var i = listeners.length; i--; i > 0) {
                            if (listeners[i] === listener) {
                                listeners.splice(i, 1);
                                break;
                            }
                        }
                    }
                }
            }, {
                key: 'dispatchEvent',
                value: function dispatchEvent() {
                    var event = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : {};

                    var listeners = _events.get(this)[event.type];

                    if (listeners) {
                        for (var i = 0; i < listeners.length; i++) {
                            listeners[i](event);
                        }
                    }
                }
            }]);

            return EventTarget;
        }();

        exports.default = EventTarget;

        /***/ }),
    /* 9 */
    /***/ (function(module, exports) {

        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.noop = noop;
        function noop() {}

        /***/ }),
    /* 10 */
    /***/ (function(module, exports, __webpack_require__) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = Canvas;

        var _constructor = __webpack_require__(4);

        var _HTMLElement = __webpack_require__(5);

        var _HTMLElement2 = _interopRequireDefault(_HTMLElement);

        var _document = __webpack_require__(11);

        var _document2 = _interopRequireDefault(_document);

        function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

        var hasModifiedCanvasPrototype = false;
        var hasInit2DContextConstructor = false;
        var hasInitWebGLContextConstructor = false;

        function Canvas() {
            var canvas = wx.createCanvas();

            canvas.type = 'canvas';

            canvas.__proto__.__proto__ = new _HTMLElement2.default('canvas');

            var _getContext = canvas.getContext;

            canvas.getBoundingClientRect = function () {
                var ret = {
                    top: 0,
                    left: 0,
                    width: window.innerWidth,
                    height: window.innerHeight
                };
                return ret;
            };

            return canvas;
        }

        /***/ }),
    /* 11 */
    /***/ (function(module, exports, __webpack_require__) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });

        var _window = __webpack_require__(1);

        var window = _interopRequireWildcard(_window);

        var _HTMLElement = __webpack_require__(5);

        var _HTMLElement2 = _interopRequireDefault(_HTMLElement);

        var _Image = __webpack_require__(12);

        var _Image2 = _interopRequireDefault(_Image);

        var _Audio = __webpack_require__(13);

        var _Audio2 = _interopRequireDefault(_Audio);

        var _Canvas = __webpack_require__(10);

        var _Canvas2 = _interopRequireDefault(_Canvas);

        __webpack_require__(16);

        function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

        function _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj.default = obj; return newObj; } }

        var events = {};

        var document = {
            readyState: 'complete',
            visibilityState: 'visible',
            documentElement: window,
            hidden: false,
            style: {},
            location: window.location,
            ontouchstart: null,
            ontouchmove: null,
            ontouchend: null,

            head: new _HTMLElement2.default('head'),
            body: new _HTMLElement2.default('body'),

            createElement: function createElement(tagName) {
                if (tagName === 'canvas') {
                    return new _Canvas2.default();
                } else if (tagName === 'audio') {
                    return new _Audio2.default();
                } else if (tagName === 'img') {
                    return new _Image2.default();
                }

                return new _HTMLElement2.default(tagName);
            },
            getElementById: function getElementById(id) {
                if (id === window.canvas.id) {
                    return window.canvas;
                }
                return null;
            },
            getElementsByTagName: function getElementsByTagName(tagName) {
                if (tagName === 'head') {
                    return [document.head];
                } else if (tagName === 'body') {
                    return [document.body];
                } else if (tagName === 'canvas') {
                    return [window.canvas];
                }
                return [];
            },
            getElementsByName: function getElementsByName(tagName) {
                if (tagName === 'head') {
                    return [document.head];
                } else if (tagName === 'body') {
                    return [document.body];
                } else if (tagName === 'canvas') {
                    return [window.canvas];
                }
                return [];
            },
            querySelector: function querySelector(query) {
                if (query === 'head') {
                    return document.head;
                } else if (query === 'body') {
                    return document.body;
                } else if (query === 'canvas') {
                    return window.canvas;
                } else if (query === '#' + window.canvas.id) {
                    return window.canvas;
                }
                return null;
            },
            querySelectorAll: function querySelectorAll(query) {
                if (query === 'head') {
                    return [document.head];
                } else if (query === 'body') {
                    return [document.body];
                } else if (query === 'canvas') {
                    return [window.canvas];
                }
                return [];
            },
            addEventListener: function addEventListener(type, listener) {
                if (!events[type]) {
                    events[type] = [];
                }
                events[type].push(listener);
            },
            removeEventListener: function removeEventListener(type, listener) {
                var listeners = events[type];

                if (listeners && listeners.length > 0) {
                    for (var i = listeners.length; i--; i > 0) {
                        if (listeners[i] === listener) {
                            listeners.splice(i, 1);
                            break;
                        }
                    }
                }
            },
            dispatchEvent: function dispatchEvent(event) {
                var listeners = events[event.type];

                if (listeners) {
                    for (var i = 0; i < listeners.length; i++) {
                        listeners[i](event);
                    }
                }
            }
        };

        exports.default = document;

        /***/ }),
    /* 12 */
    /***/ (function(module, exports) {

        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        exports.default = Image;
        function Image() {
            var image = wx.createImage();

            return image;
        }

        /***/ }),
    /* 13 */
    /***/ (function(module, exports, __webpack_require__) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });

        var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

        var _HTMLAudioElement2 = __webpack_require__(14);

        var _HTMLAudioElement3 = _interopRequireDefault(_HTMLAudioElement2);

        function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

        function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

        function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

        function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

        var HAVE_NOTHING = 0;
        var HAVE_METADATA = 1;
        var HAVE_CURRENT_DATA = 2;
        var HAVE_FUTURE_DATA = 3;
        var HAVE_ENOUGH_DATA = 4;

        var _innerAudioContext = new WeakMap();
        var _src = new WeakMap();
        var _loop = new WeakMap();
        var _autoplay = new WeakMap();

        var Audio = function (_HTMLAudioElement) {
            _inherits(Audio, _HTMLAudioElement);

            function Audio(url) {
                _classCallCheck(this, Audio);

                var _this = _possibleConstructorReturn(this, (Audio.__proto__ || Object.getPrototypeOf(Audio)).call(this));

                _this.HAVE_NOTHING = HAVE_NOTHING;
                _this.HAVE_METADATA = HAVE_METADATA;
                _this.HAVE_CURRENT_DATA = HAVE_CURRENT_DATA;
                _this.HAVE_FUTURE_DATA = HAVE_FUTURE_DATA;
                _this.HAVE_ENOUGH_DATA = HAVE_ENOUGH_DATA;
                _this.readyState = HAVE_NOTHING;


                _src.set(_this, '');

                var innerAudioContext = wx.createInnerAudioContext();

                _innerAudioContext.set(_this, innerAudioContext);

                innerAudioContext.onCanplay(function () {
                    _this.dispatchEvent({ type: 'load' });
                    _this.dispatchEvent({ type: 'loadend' });
                    _this.dispatchEvent({ type: 'canplay' });
                    _this.dispatchEvent({ type: 'canplaythrough' });
                    _this.dispatchEvent({ type: 'loadedmetadata' });
                    _this.readyState = HAVE_CURRENT_DATA;
                });
                innerAudioContext.onPlay(function () {
                    _this.dispatchEvent({ type: 'play' });
                });
                innerAudioContext.onPause(function () {
                    _this.dispatchEvent({ type: 'pause' });
                });
                innerAudioContext.onEnded(function () {
                    _this.dispatchEvent({ type: 'ended' });
                    _this.readyState = HAVE_ENOUGH_DATA;
                });
                innerAudioContext.onError(function () {
                    _this.dispatchEvent({ type: 'error' });
                });

                if (url) {
                    _innerAudioContext.get(_this).src = url;
                }
                return _this;
            }

            _createClass(Audio, [{
                key: 'load',
                value: function load() {
                    console.warn('HTMLAudioElement.load() is not implemented.');
                }
            }, {
                key: 'play',
                value: function play() {
                    _innerAudioContext.get(this).play();
                }
            }, {
                key: 'pause',
                value: function pause() {
                    _innerAudioContext.get(this).pause();
                }
            }, {
                key: 'canPlayType',
                value: function canPlayType() {
                    var mediaType = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : '';

                    if (typeof mediaType !== 'string') {
                        return '';
                    }

                    if (mediaType.indexOf('audio/mpeg') > -1 || mediaType.indexOf('audio/mp4')) {
                        return 'probably';
                    }
                    return '';
                }
            }, {
                key: 'cloneNode',
                value: function cloneNode() {
                    var newAudio = new Audio();
                    newAudio.loop = _innerAudioContext.get(this).loop;
                    newAudio.autoplay = _innerAudioContext.get(this).autoplay;
                    newAudio.src = this.src;
                    return newAudio;
                }
            }, {
                key: 'currentTime',
                get: function get() {
                    return _innerAudioContext.get(this).currentTime;
                },
                set: function set(value) {
                    _innerAudioContext.get(this).seek(value);
                }
            }, {
                key: 'src',
                get: function get() {
                    return _src.get(this);
                },
                set: function set(value) {
                    _src.set(this, value);
                    _innerAudioContext.get(this).src = value;
                }
            }, {
                key: 'loop',
                get: function get() {
                    return _innerAudioContext.get(this).loop;
                },
                set: function set(value) {
                    _innerAudioContext.get(this).loop = value;
                }
            }, {
                key: 'autoplay',
                get: function get() {
                    return _innerAudioContext.get(this).autoplay;
                },
                set: function set(value) {
                    _innerAudioContext.get(this).autoplay = value;
                }
            }, {
                key: 'paused',
                get: function get() {
                    return _innerAudioContext.get(this).paused;
                }
            }]);

            return Audio;
        }(_HTMLAudioElement3.default);

        exports.default = Audio;

        /***/ }),
    /* 14 */
    /***/ (function(module, exports, __webpack_require__) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });

        var _HTMLMediaElement2 = __webpack_require__(15);

        var _HTMLMediaElement3 = _interopRequireDefault(_HTMLMediaElement2);

        function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

        function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

        function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

        function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

        var HTMLAudioElement = function (_HTMLMediaElement) {
            _inherits(HTMLAudioElement, _HTMLMediaElement);

            function HTMLAudioElement() {
                _classCallCheck(this, HTMLAudioElement);

                return _possibleConstructorReturn(this, (HTMLAudioElement.__proto__ || Object.getPrototypeOf(HTMLAudioElement)).call(this, 'audio'));
            }

            return HTMLAudioElement;
        }(_HTMLMediaElement3.default);

        exports.default = HTMLAudioElement;

        /***/ }),
    /* 15 */
    /***/ (function(module, exports, __webpack_require__) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });

        var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

        var _HTMLElement2 = __webpack_require__(5);

        var _HTMLElement3 = _interopRequireDefault(_HTMLElement2);

        function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

        function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

        function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

        function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

        var HTMLMediaElement = function (_HTMLElement) {
            _inherits(HTMLMediaElement, _HTMLElement);

            function HTMLMediaElement(type) {
                _classCallCheck(this, HTMLMediaElement);

                return _possibleConstructorReturn(this, (HTMLMediaElement.__proto__ || Object.getPrototypeOf(HTMLMediaElement)).call(this, type));
            }

            _createClass(HTMLMediaElement, [{
                key: 'addTextTrack',
                value: function addTextTrack() {}
            }, {
                key: 'captureStream',
                value: function captureStream() {}
            }, {
                key: 'fastSeek',
                value: function fastSeek() {}
            }, {
                key: 'load',
                value: function load() {}
            }, {
                key: 'pause',
                value: function pause() {}
            }, {
                key: 'play',
                value: function play() {}
            }]);

            return HTMLMediaElement;
        }(_HTMLElement3.default);

        exports.default = HTMLMediaElement;

        /***/ }),
    /* 16 */
    /***/ (function(module, exports, __webpack_require__) {

        'use strict';

        __webpack_require__(17);

        /***/ }),
    /* 17 */
    /***/ (function(module, exports, __webpack_require__) {

        'use strict';

        var _window = __webpack_require__(1);

        var window = _interopRequireWildcard(_window);

        var _document = __webpack_require__(11);

        var _document2 = _interopRequireDefault(_document);

        var _util = __webpack_require__(9);

        function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

        function _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj.default = obj; return newObj; } }

        function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

        var TouchEvent = function TouchEvent(type) {
            _classCallCheck(this, TouchEvent);

            this.target = window.canvas;
            this.currentTarget = window.canvas;
            this.touches = [];
            this.targetTouches = [];
            this.changedTouches = [];
            this.preventDefault = _util.noop;
            this.stopPropagation = _util.noop;

            this.type = type;
        };

        function touchEventHandlerFactory(type) {
            return function (event) {
                var touchEvent = new TouchEvent(type);

                touchEvent.touches = event.touches;
                touchEvent.targetTouches = Array.prototype.slice.call(event.touches);
                touchEvent.changedTouches = event.changedTouches;
                touchEvent.timeStamp = event.timeStamp;
                _document2.default.dispatchEvent(touchEvent);
            };
        }

        wx.onTouchStart(touchEventHandlerFactory('touchstart'));
        wx.onTouchMove(touchEventHandlerFactory('touchmove'));
        wx.onTouchEnd(touchEventHandlerFactory('touchend'));
        wx.onTouchCancel(touchEventHandlerFactory('touchcancel'));

        /***/ }),
    /* 18 */
    /***/ (function(module, exports, __webpack_require__) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });

        var _util = __webpack_require__(9);

        // TODO 需要 wx.getSystemInfo 获取更详细信息
        var _wx$getSystemInfoSync = wx.getSystemInfoSync(),
            platform = _wx$getSystemInfoSync.platform;

        var navigator = {
            platform: platform,
            language: 'zh-cn',
            appVersion: '5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1',
            userAgent: 'Mozilla/5.0 (iPhone; CPU iPhone OS 10_3_1 like Mac OS X) AppleWebKit/603.1.30 (KHTML, like Gecko) Mobile/14E8301 MicroMessenger/6.6.0 MiniGame NetType/WIFI Language/zh_CN',
            onLine: true, // TODO 用 wx.getNetworkStateChange 和 wx.onNetworkStateChange 来返回真实的状态

            // TODO 用 wx.getLocation 来封装 geolocation
            geolocation: {
                getCurrentPosition: _util.noop,
                watchPosition: _util.noop,
                clearWatch: _util.noop
            }
        };

        exports.default = navigator;

        /***/ }),
    /* 19 */
    /***/ (function(module, exports) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });

        var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

        function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

        var _url = new WeakMap();
        var _method = new WeakMap();
        var _requestHeader = new WeakMap();
        var _responseHeader = new WeakMap();
        var _requestTask = new WeakMap();

        function _triggerEvent(type) {
            if (typeof this['on' + type] === 'function') {
                for (var _len = arguments.length, args = Array(_len > 1 ? _len - 1 : 0), _key = 1; _key < _len; _key++) {
                    args[_key - 1] = arguments[_key];
                }

                this['on' + type].apply(this, args);
            }
        }

        function _changeReadyState(readyState) {
            this.readyState = readyState;
            _triggerEvent.call(this, 'readystatechange');
        }

        var XMLHttpRequest = function () {
            // TODO 没法模拟 HEADERS_RECEIVED 和 LOADING 两个状态
            function XMLHttpRequest() {
                _classCallCheck(this, XMLHttpRequest);

                this.onabort = null;
                this.onerror = null;
                this.onload = null;
                this.onloadstart = null;
                this.onprogress = null;
                this.ontimeout = null;
                this.onloadend = null;
                this.onreadystatechange = null;
                this.readyState = 0;
                this.response = null;
                this.responseText = null;
                this.responseType = '';
                this.responseXML = null;
                this.status = 0;
                this.statusText = '';
                this.upload = {};
                this.withCredentials = false;

                _requestHeader.set(this, {
                    'content-type': 'application/x-www-form-urlencoded'
                });
                _responseHeader.set(this, {});
            }

            /*
             * TODO 这一批事件应该是在 XMLHttpRequestEventTarget.prototype 上面的
             */


            _createClass(XMLHttpRequest, [{
                key: 'abort',
                value: function abort() {
                    var myRequestTask = _requestTask.get(this);

                    if (myRequestTask) {
                        myRequestTask.abort();
                    }
                }
            }, {
                key: 'getAllResponseHeaders',
                value: function getAllResponseHeaders() {
                    var responseHeader = _responseHeader.get(this);

                    return Object.keys(responseHeader).map(function (header) {
                        return header + ': ' + responseHeader[header];
                    }).join('\n');
                }
            }, {
                key: 'getResponseHeader',
                value: function getResponseHeader(header) {
                    return _responseHeader.get(this)[header];
                }
            }, {
                key: 'open',
                value: function open(method, url /* async, user, password 这几个参数在小程序内不支持*/) {
                    _method.set(this, method);
                    _url.set(this, url);
                    _changeReadyState.call(this, XMLHttpRequest.OPENED);
                }
            }, {
                key: 'overrideMimeType',
                value: function overrideMimeType() {}
            }, {
                key: 'send',
                value: function send() {
                    var _this = this;

                    var data = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : '';

                    if (this.readyState !== XMLHttpRequest.OPENED) {
                        throw new Error("Failed to execute 'send' on 'XMLHttpRequest': The object's state must be OPENED.");
                    } else {
                        if(data instanceof Uint8Array){
                            // unity 过来的请求会出现Uint8Array的数组，而客户端这里处理有问题，先这样兼容
                            data = wx.decode({data:Uint8Array.from(data).buffer,format:"utf8"});
                        }
                        let responseType = this.responseType;
                        wx.request({
                            data: data,
                            url: _url.get(this),
                            method: _method.get(this),
                            header: _requestHeader.get(this),
                            responseType: this.responseType,
                            success: function success(_ref) {
                                var data = _ref.data,
                                    statusCode = _ref.statusCode,
                                    header = _ref.header;

                                if (typeof data !== 'string' && !(data instanceof ArrayBuffer)) {
                                    try {
                                        data = JSON.stringify(data);
                                    } catch (e) {
                                        data = data;
                                    }
                                }

                                _this.status = statusCode;
                                _responseHeader.set(_this, header);
                                _triggerEvent.call(_this, 'loadstart');
                                _changeReadyState.call(_this, XMLHttpRequest.HEADERS_RECEIVED);
                                _changeReadyState.call(_this, XMLHttpRequest.LOADING);

                                _this.response = data;

                                if(responseType === 'text'){
                                    if (data instanceof ArrayBuffer) {
                                        _this.responseText = '';
                                        var bytes = new Uint8Array(data);
                                        var len = bytes.byteLength;

                                        for (var i = 0; i < len; i++) {
                                            _this.responseText += String.fromCharCode(bytes[i]);
                                        }
                                    } else {
                                        _this.responseText = data;
                                    }
                                }

                                _changeReadyState.call(_this, XMLHttpRequest.DONE);
                                _triggerEvent.call(_this, 'load');
                                _triggerEvent.call(_this, 'loadend');
                            },
                            fail: function fail(_ref2) {
                                var errMsg = _ref2.errMsg;

                                // TODO 规范错误
                                if (errMsg.indexOf('abort') !== -1) {
                                    _triggerEvent.call(_this, 'abort');
                                } else {
                                    _triggerEvent.call(_this, 'error', errMsg);
                                }
                                _triggerEvent.call(_this, 'loadend');
                            }
                        });
                    }
                }
            }, {
                key: 'setRequestHeader',
                value: function setRequestHeader(header, value) {
                    var myHeader = _requestHeader.get(this);

                    myHeader[header] = value;
                    _requestHeader.set(this, myHeader);
                }
            }]);

            return XMLHttpRequest;
        }();

        XMLHttpRequest.UNSEND = 0;
        XMLHttpRequest.OPENED = 1;
        XMLHttpRequest.HEADERS_RECEIVED = 2;
        XMLHttpRequest.LOADING = 3;
        XMLHttpRequest.DONE = 4;
        if(!isWK){
            exports.default = XMLHttpRequest;
        }


        /***/ }),
    /* 20 */
    /***/ (function(module, exports) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });

        var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

        function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

        var _socketTask = new WeakMap();

        var WebSocket = function () {
            // TODO 更新 binaryType
            // The connection is in the process of closing.
            // The connection is not yet open.
            function WebSocket(url) {
                var _this = this;

                var protocols = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : [];

                _classCallCheck(this, WebSocket);

                this.binaryType = '';
                this.bufferedAmount = 0;
                this.extensions = '';
                this.onclose = null;
                this.onerror = null;
                this.onmessage = null;
                this.onopen = null;
                this.protocol = '';
                this.readyState = 3;

                if (typeof url !== 'string' || !/(^ws:\/\/)|(^wss:\/\/)/.test(url)) {
                    throw new TypeError('Failed to construct \'WebSocket\': The URL \'' + url + '\' is invalid');
                }

                this.url = url;
                this.readyState = WebSocket.CONNECTING;

                var socketTask = wx.connectSocket({
                    url: url,
                    protocols: Array.isArray(protocols) ? protocols : [protocols]
                });

                _socketTask.set(this, socketTask);

                socketTask.onClose(function (res) {
                    _this.readyState = WebSocket.CLOSED;
                    if (typeof _this.onclose === 'function') {
                        _this.onclose(res);
                    }
                });

                socketTask.onMessage(function (res) {
                    if (typeof _this.onmessage === 'function') {
                        _this.onmessage(res);
                    }
                });

                socketTask.onOpen(function () {
                    _this.readyState = WebSocket.OPEN;
                    if (typeof _this.onopen === 'function') {
                        _this.onopen();
                    }
                });

                socketTask.onError(function (res) {
                    if (typeof _this.onerror === 'function') {
                        _this.onerror(new Error(res.errMsg));
                    }
                });

                return this;
            } // TODO 小程序内目前获取不到，实际上需要根据服务器选择的 sub-protocol 返回
            // TODO 更新 bufferedAmount
            // The connection is closed or couldn't be opened.

            // The connection is open and ready to communicate.


            _createClass(WebSocket, [{
                key: 'close',
                value: function close(code, reason) {
                    this.readyState = WebSocket.CLOSING;
                    var socketTask = _socketTask.get(this);

                    socketTask.close({
                        code: code,
                        reason: reason
                    });
                }
            }, {
                key: 'send',
                value: function send(data) {
                    if (typeof data !== 'string' && !(data instanceof ArrayBuffer) && !((typeof data) === 'object')) {
                        throw new TypeError('Failed to send message: The data ' + data + ' is invalid');
                    }

                    var socketTask = _socketTask.get(this);

                    socketTask.send({
                        data: data
                    });
                }
            }]);

            return WebSocket;
        }();

        WebSocket.CONNECTING = 0;
        WebSocket.OPEN = 1;
        WebSocket.CLOSING = 2;
        WebSocket.CLOSED = 3;
        exports.default = WebSocket;

        /***/ }),
    /* 21 */
    /***/ (function(module, exports) {

        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });

        var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

        function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

        /*
         * TODO 使用 wx.readFile 来封装 FileReader
         */
        var FileReader = function () {
            function FileReader() {
                _classCallCheck(this, FileReader);
            }

            _createClass(FileReader, [{
                key: "construct",
                value: function construct() {}
            }]);

            return FileReader;
        }();

        exports.default = FileReader;

        /***/ }),
    /* 22 */
    /***/ (function(module, exports) {

        "use strict";

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        var localStorage = {
            get length() {
                var _wx$getStorageInfoSyn = wx.getStorageInfoSync(),
                    keys = _wx$getStorageInfoSyn.keys;

                return keys.length;
            },

            key: function key(n) {
                var _wx$getStorageInfoSyn2 = wx.getStorageInfoSync(),
                    keys = _wx$getStorageInfoSyn2.keys;

                return keys[n];
            },
            getItem: function getItem(key) {
                return wx.getStorageSync(key);
            },
            setItem: function setItem(key, value) {
                return wx.setStorageSync(key, value);
            },
            removeItem: function removeItem(key) {
                wx.removeStorageSync(key);
            },
            clear: function clear() {
                wx.clearStorageSync();
            }
        };

        exports.default = localStorage;

        /***/ }),
    /* 23 */
    /***/ (function(module, exports) {

        'use strict';

        Object.defineProperty(exports, "__esModule", {
            value: true
        });
        var location = {
            href: 'game.js',
            reload: function reload() {}
        };

        exports.default = location;

        /***/ })
    /******/ ]);
