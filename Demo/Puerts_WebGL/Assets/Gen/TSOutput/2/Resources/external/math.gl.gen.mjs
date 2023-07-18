/******/ // The require scope
/******/ var __webpack_require__ = {};
/******/
/************************************************************************/
/******/ /* webpack/runtime/define property getters */
/******/ (() => {
    /******/ // define getter functions for harmony exports
    /******/ __webpack_require__.d = (exports, definition) => {
        /******/ for (var key in definition) {
            /******/ if (__webpack_require__.o(definition, key) && !__webpack_require__.o(exports, key)) {
                /******/ Object.defineProperty(exports, key, { enumerable: true, get: definition[key] });
                /******/ }
            /******/ }
        /******/ 
    };
    /******/ 
})();
/******/
/******/ /* webpack/runtime/hasOwnProperty shorthand */
/******/ (() => {
    /******/ __webpack_require__.o = (obj, prop) => (Object.prototype.hasOwnProperty.call(obj, prop));
    /******/ 
})();
/******/
/************************************************************************/
var __webpack_exports__ = {};
// EXPORTS
__webpack_require__.d(__webpack_exports__, {
    US: () => ( /* reexport */Euler),
    Vk: () => ( /* reexport */Matrix3),
    yG: () => ( /* reexport */Matrix4),
    DJ: () => ( /* reexport */Pose),
    _f: () => ( /* reexport */Quaternion),
    i1: () => ( /* reexport */SphericalCoordinates),
    FM: () => ( /* reexport */Vector2),
    P: () => ( /* reexport */Vector3),
    Lt: () => ( /* reexport */Vector4),
    RK: () => ( /* reexport */Euler),
    H7: () => ( /* reexport */math_utils),
    r9: () => ( /* reexport */Pose),
    F: () => ( /* reexport */SphericalCoordinates),
    Kh: () => ( /* reexport */acos),
    ZR: () => ( /* reexport */asin),
    hu: () => ( /* reexport */assert),
    z4: () => ( /* reexport */atan),
    uZ: () => ( /* reexport */clamp),
    d9: () => ( /* reexport */clone),
    vc: () => ( /* reexport */config),
    jQ: () => ( /* reexport */configure),
    mC: () => ( /* reexport */cos),
    RW: () => ( /* reexport */degrees),
    fS: () => ( /* reexport */equals),
    I6: () => ( /* reexport */exactEquals),
    Bw: () => ( /* reexport */formatValue),
    kJ: () => ( /* reexport */isArray),
    t7: () => ( /* reexport */lerp),
    uR: () => ( /* reexport */radians),
    O$: () => ( /* reexport */sin),
    OR: () => ( /* reexport */tan),
    Ux: () => ( /* reexport */toDegrees),
    Yr: () => ( /* reexport */toRadians),
    BJ: () => ( /* reexport */withEpsilon)
});
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/lib/assert.js
function assert(condition, message) {
    if (!condition) {
        throw new Error("math.gl assertion ".concat(message));
    }
}
//# sourceMappingURL=assert.js.map
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/lib/common.js
const RADIANS_TO_DEGREES = 1 / Math.PI * 180;
const DEGREES_TO_RADIANS = 1 / 180 * Math.PI;
const config = {
    EPSILON: 1e-12,
    debug: false,
    precision: 4,
    printTypes: false,
    printDegrees: false,
    printRowMajor: true
};
function configure(options) {
    for (const key in options) {
        assert(key in config);
        config[key] = options[key];
    }
    return config;
}
function formatValue(value, { precision = config.precision } = {}) {
    value = round(value);
    return "".concat(parseFloat(value.toPrecision(precision)));
}
function isArray(value) {
    return Array.isArray(value) || ArrayBuffer.isView(value) && !(value instanceof DataView);
}
function clone(array) {
    return 'clone' in array ? array.clone() : array.slice();
}
function toRadians(degrees) {
    return radians(degrees);
}
function toDegrees(radians) {
    return degrees(radians);
}
function radians(degrees, result) {
    return map(degrees, degrees => degrees * DEGREES_TO_RADIANS, result);
}
function degrees(radians, result) {
    return map(radians, radians => radians * RADIANS_TO_DEGREES, result);
}
function sin(radians, result) {
    return map(radians, angle => Math.sin(angle), result);
}
function cos(radians, result) {
    return map(radians, angle => Math.cos(angle), result);
}
function tan(radians, result) {
    return map(radians, angle => Math.tan(angle), result);
}
function asin(radians, result) {
    return map(radians, angle => Math.asin(angle), result);
}
function acos(radians, result) {
    return map(radians, angle => Math.acos(angle), result);
}
function atan(radians, result) {
    return map(radians, angle => Math.atan(angle), result);
}
function clamp(value, min, max) {
    return map(value, value => Math.max(min, Math.min(max, value)));
}
function lerp(a, b, t) {
    if (isArray(a)) {
        return a.map((ai, i) => lerp(ai, b[i], t));
    }
    return t * b + (1 - t) * a;
}
function equals(a, b, epsilon) {
    const oldEpsilon = config.EPSILON;
    if (epsilon) {
        config.EPSILON = epsilon;
    }
    try {
        if (a === b) {
            return true;
        }
        if (isArray(a) && isArray(b)) {
            if (a.length !== b.length) {
                return false;
            }
            for (let i = 0; i < a.length; ++i) {
                if (!equals(a[i], b[i])) {
                    return false;
                }
            }
            return true;
        }
        if (a && a.equals) {
            return a.equals(b);
        }
        if (b && b.equals) {
            return b.equals(a);
        }
        if (typeof a === 'number' && typeof b === 'number') {
            return Math.abs(a - b) <= config.EPSILON * Math.max(1, Math.abs(a), Math.abs(b));
        }
        return false;
    }
    finally {
        config.EPSILON = oldEpsilon;
    }
}
function exactEquals(a, b) {
    if (a === b) {
        return true;
    }
    if (a && typeof a === 'object' && b && typeof b === 'object') {
        if (a.constructor !== b.constructor) {
            return false;
        }
        if (a.exactEquals) {
            return a.exactEquals(b);
        }
    }
    if (isArray(a) && isArray(b)) {
        if (a.length !== b.length) {
            return false;
        }
        for (let i = 0; i < a.length; ++i) {
            if (!exactEquals(a[i], b[i])) {
                return false;
            }
        }
        return true;
    }
    return false;
}
function withEpsilon(epsilon, func) {
    const oldPrecision = config.EPSILON;
    config.EPSILON = epsilon;
    let value;
    try {
        value = func();
    }
    finally {
        config.EPSILON = oldPrecision;
    }
    return value;
}
function round(value) {
    return Math.round(value / config.EPSILON) * config.EPSILON;
}
function duplicateArray(array) {
    return array.clone ? array.clone() : new Array(array.length);
}
function map(value, func, result) {
    if (isArray(value)) {
        const array = value;
        result = result || duplicateArray(array);
        for (let i = 0; i < result.length && i < array.length; ++i) {
            result[i] = func(value[i], i, result);
        }
        return result;
    }
    return func(value);
}
//# sourceMappingURL=common.js.map
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/classes/base/math-array.js
function _extendableBuiltin(cls) {
    function ExtendableBuiltin() {
        var instance = Reflect.construct(cls, Array.from(arguments));
        Object.setPrototypeOf(instance, Object.getPrototypeOf(this));
        return instance;
    }
    ExtendableBuiltin.prototype = Object.create(cls.prototype, {
        constructor: {
            value: cls,
            enumerable: false,
            writable: true,
            configurable: true
        }
    });
    if (Object.setPrototypeOf) {
        Object.setPrototypeOf(ExtendableBuiltin, cls);
    }
    else {
        ExtendableBuiltin.__proto__ = cls;
    }
    return ExtendableBuiltin;
}
class MathArray extends _extendableBuiltin(Array) {
    clone() {
        return new this.constructor().copy(this);
    }
    fromArray(array, offset = 0) {
        for (let i = 0; i < this.ELEMENTS; ++i) {
            this[i] = array[i + offset];
        }
        return this.check();
    }
    toArray(targetArray = [], offset = 0) {
        for (let i = 0; i < this.ELEMENTS; ++i) {
            targetArray[offset + i] = this[i];
        }
        return targetArray;
    }
    from(arrayOrObject) {
        return Array.isArray(arrayOrObject) ? this.copy(arrayOrObject) : this.fromObject(arrayOrObject);
    }
    to(arrayOrObject) {
        if (arrayOrObject === this) {
            return this;
        }
        return isArray(arrayOrObject) ? this.toArray(arrayOrObject) : this.toObject(arrayOrObject);
    }
    toTarget(target) {
        return target ? this.to(target) : this;
    }
    toFloat32Array() {
        return new Float32Array(this);
    }
    toString() {
        return this.formatString(config);
    }
    formatString(opts) {
        let string = '';
        for (let i = 0; i < this.ELEMENTS; ++i) {
            string += (i > 0 ? ', ' : '') + formatValue(this[i], opts);
        }
        return "".concat(opts.printTypes ? this.constructor.name : '', "[").concat(string, "]");
    }
    equals(array) {
        if (!array || this.length !== array.length) {
            return false;
        }
        for (let i = 0; i < this.ELEMENTS; ++i) {
            if (!equals(this[i], array[i])) {
                return false;
            }
        }
        return true;
    }
    exactEquals(array) {
        if (!array || this.length !== array.length) {
            return false;
        }
        for (let i = 0; i < this.ELEMENTS; ++i) {
            if (this[i] !== array[i]) {
                return false;
            }
        }
        return true;
    }
    negate() {
        for (let i = 0; i < this.ELEMENTS; ++i) {
            this[i] = -this[i];
        }
        return this.check();
    }
    lerp(a, b, t) {
        if (t === undefined) {
            return this.lerp(this, a, b);
        }
        for (let i = 0; i < this.ELEMENTS; ++i) {
            const ai = a[i];
            this[i] = ai + t * (b[i] - ai);
        }
        return this.check();
    }
    min(vector) {
        for (let i = 0; i < this.ELEMENTS; ++i) {
            this[i] = Math.min(vector[i], this[i]);
        }
        return this.check();
    }
    max(vector) {
        for (let i = 0; i < this.ELEMENTS; ++i) {
            this[i] = Math.max(vector[i], this[i]);
        }
        return this.check();
    }
    clamp(minVector, maxVector) {
        for (let i = 0; i < this.ELEMENTS; ++i) {
            this[i] = Math.min(Math.max(this[i], minVector[i]), maxVector[i]);
        }
        return this.check();
    }
    add(...vectors) {
        for (const vector of vectors) {
            for (let i = 0; i < this.ELEMENTS; ++i) {
                this[i] += vector[i];
            }
        }
        return this.check();
    }
    subtract(...vectors) {
        for (const vector of vectors) {
            for (let i = 0; i < this.ELEMENTS; ++i) {
                this[i] -= vector[i];
            }
        }
        return this.check();
    }
    scale(scale) {
        if (typeof scale === 'number') {
            for (let i = 0; i < this.ELEMENTS; ++i) {
                this[i] *= scale;
            }
        }
        else {
            for (let i = 0; i < this.ELEMENTS && i < scale.length; ++i) {
                this[i] *= scale[i];
            }
        }
        return this.check();
    }
    multiplyByScalar(scalar) {
        for (let i = 0; i < this.ELEMENTS; ++i) {
            this[i] *= scalar;
        }
        return this.check();
    }
    check() {
        if (config.debug && !this.validate()) {
            throw new Error("math.gl: ".concat(this.constructor.name, " some fields set to invalid numbers'"));
        }
        return this;
    }
    validate() {
        let valid = this.length === this.ELEMENTS;
        for (let i = 0; i < this.ELEMENTS; ++i) {
            valid = valid && Number.isFinite(this[i]);
        }
        return valid;
    }
    sub(a) {
        return this.subtract(a);
    }
    setScalar(a) {
        for (let i = 0; i < this.ELEMENTS; ++i) {
            this[i] = a;
        }
        return this.check();
    }
    addScalar(a) {
        for (let i = 0; i < this.ELEMENTS; ++i) {
            this[i] += a;
        }
        return this.check();
    }
    subScalar(a) {
        return this.addScalar(-a);
    }
    multiplyScalar(scalar) {
        for (let i = 0; i < this.ELEMENTS; ++i) {
            this[i] *= scalar;
        }
        return this.check();
    }
    divideScalar(a) {
        return this.multiplyByScalar(1 / a);
    }
    clampScalar(min, max) {
        for (let i = 0; i < this.ELEMENTS; ++i) {
            this[i] = Math.min(Math.max(this[i], min), max);
        }
        return this.check();
    }
    get elements() {
        return this;
    }
}
//# sourceMappingURL=math-array.js.map
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/lib/validators.js
function validateVector(v, length) {
    if (v.length !== length) {
        return false;
    }
    for (let i = 0; i < v.length; ++i) {
        if (!Number.isFinite(v[i])) {
            return false;
        }
    }
    return true;
}
function checkNumber(value) {
    if (!Number.isFinite(value)) {
        throw new Error("Invalid number ".concat(value));
    }
    return value;
}
function checkVector(v, length, callerName = '') {
    if (config.debug && !validateVector(v, length)) {
        throw new Error("math.gl: ".concat(callerName, " some fields set to invalid numbers'"));
    }
    return v;
}
const validators_map = {};
function deprecated(method, version) {
    if (!validators_map[method]) {
        validators_map[method] = true;
        console.warn("".concat(method, " has been removed in version ").concat(version, ", see upgrade guide for more information"));
    }
}
//# sourceMappingURL=validators.js.map
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/classes/base/vector.js
class Vector extends MathArray {
    get x() {
        return this[0];
    }
    set x(value) {
        this[0] = checkNumber(value);
    }
    get y() {
        return this[1];
    }
    set y(value) {
        this[1] = checkNumber(value);
    }
    len() {
        return Math.sqrt(this.lengthSquared());
    }
    magnitude() {
        return this.len();
    }
    lengthSquared() {
        let length = 0;
        for (let i = 0; i < this.ELEMENTS; ++i) {
            length += this[i] * this[i];
        }
        return length;
    }
    magnitudeSquared() {
        return this.lengthSquared();
    }
    distance(mathArray) {
        return Math.sqrt(this.distanceSquared(mathArray));
    }
    distanceSquared(mathArray) {
        let length = 0;
        for (let i = 0; i < this.ELEMENTS; ++i) {
            const dist = this[i] - mathArray[i];
            length += dist * dist;
        }
        return checkNumber(length);
    }
    dot(mathArray) {
        let product = 0;
        for (let i = 0; i < this.ELEMENTS; ++i) {
            product += this[i] * mathArray[i];
        }
        return checkNumber(product);
    }
    normalize() {
        const length = this.magnitude();
        if (length !== 0) {
            for (let i = 0; i < this.ELEMENTS; ++i) {
                this[i] /= length;
            }
        }
        return this.check();
    }
    multiply(...vectors) {
        for (const vector of vectors) {
            for (let i = 0; i < this.ELEMENTS; ++i) {
                this[i] *= vector[i];
            }
        }
        return this.check();
    }
    divide(...vectors) {
        for (const vector of vectors) {
            for (let i = 0; i < this.ELEMENTS; ++i) {
                this[i] /= vector[i];
            }
        }
        return this.check();
    }
    lengthSq() {
        return this.lengthSquared();
    }
    distanceTo(vector) {
        return this.distance(vector);
    }
    distanceToSquared(vector) {
        return this.distanceSquared(vector);
    }
    getComponent(i) {
        assert(i >= 0 && i < this.ELEMENTS, 'index is out of range');
        return checkNumber(this[i]);
    }
    setComponent(i, value) {
        assert(i >= 0 && i < this.ELEMENTS, 'index is out of range');
        this[i] = value;
        return this.check();
    }
    addVectors(a, b) {
        return this.copy(a).add(b);
    }
    subVectors(a, b) {
        return this.copy(a).subtract(b);
    }
    multiplyVectors(a, b) {
        return this.copy(a).multiply(b);
    }
    addScaledVector(a, b) {
        return this.add(new this.constructor(a).multiplyScalar(b));
    }
}
//# sourceMappingURL=vector.js.map
; // CONCATENATED MODULE: ./node_modules/gl-matrix/esm/common.js
/**
 * Common utilities
 * @module glMatrix
 */
// Configuration Constants
var EPSILON = 0.000001;
var ARRAY_TYPE = typeof Float32Array !== 'undefined' ? Float32Array : Array;
var RANDOM = Math.random;
/**
 * Sets the type of array used when creating new vectors and matrices
 *
 * @param {Float32ArrayConstructor | ArrayConstructor} type Array type, such as Float32Array or Array
 */
function setMatrixArrayType(type) {
    ARRAY_TYPE = type;
}
var degree = Math.PI / 180;
/**
 * Convert Degree To Radian
 *
 * @param {Number} a Angle in Degrees
 */
function toRadian(a) {
    return a * degree;
}
/**
 * Tests whether or not the arguments have approximately the same value, within an absolute
 * or relative tolerance of glMatrix.EPSILON (an absolute tolerance is used for values less
 * than or equal to 1.0, and a relative tolerance is used for larger values)
 *
 * @param {Number} a The first number to test.
 * @param {Number} b The second number to test.
 * @returns {Boolean} True if the numbers are approximately equal, false otherwise.
 */
function common_equals(a, b) {
    return Math.abs(a - b) <= EPSILON * Math.max(1.0, Math.abs(a), Math.abs(b));
}
if (!Math.hypot)
    Math.hypot = function () {
        var y = 0, i = arguments.length;
        while (i--) {
            y += arguments[i] * arguments[i];
        }
        return Math.sqrt(y);
    };
; // CONCATENATED MODULE: ./node_modules/gl-matrix/esm/vec2.js
/**
 * 2 Dimensional Vector
 * @module vec2
 */
/**
 * Creates a new, empty vec2
 *
 * @returns {vec2} a new 2D vector
 */
function create() {
    var out = new ARRAY_TYPE(2);
    if (ARRAY_TYPE != Float32Array) {
        out[0] = 0;
        out[1] = 0;
    }
    return out;
}
/**
 * Creates a new vec2 initialized with values from an existing vector
 *
 * @param {ReadonlyVec2} a vector to clone
 * @returns {vec2} a new 2D vector
 */
function vec2_clone(a) {
    var out = new glMatrix.ARRAY_TYPE(2);
    out[0] = a[0];
    out[1] = a[1];
    return out;
}
/**
 * Creates a new vec2 initialized with the given values
 *
 * @param {Number} x X component
 * @param {Number} y Y component
 * @returns {vec2} a new 2D vector
 */
function fromValues(x, y) {
    var out = new glMatrix.ARRAY_TYPE(2);
    out[0] = x;
    out[1] = y;
    return out;
}
/**
 * Copy the values from one vec2 to another
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a the source vector
 * @returns {vec2} out
 */
function copy(out, a) {
    out[0] = a[0];
    out[1] = a[1];
    return out;
}
/**
 * Set the components of a vec2 to the given values
 *
 * @param {vec2} out the receiving vector
 * @param {Number} x X component
 * @param {Number} y Y component
 * @returns {vec2} out
 */
function set(out, x, y) {
    out[0] = x;
    out[1] = y;
    return out;
}
/**
 * Adds two vec2's
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a the first operand
 * @param {ReadonlyVec2} b the second operand
 * @returns {vec2} out
 */
function add(out, a, b) {
    out[0] = a[0] + b[0];
    out[1] = a[1] + b[1];
    return out;
}
/**
 * Subtracts vector b from vector a
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a the first operand
 * @param {ReadonlyVec2} b the second operand
 * @returns {vec2} out
 */
function subtract(out, a, b) {
    out[0] = a[0] - b[0];
    out[1] = a[1] - b[1];
    return out;
}
/**
 * Multiplies two vec2's
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a the first operand
 * @param {ReadonlyVec2} b the second operand
 * @returns {vec2} out
 */
function multiply(out, a, b) {
    out[0] = a[0] * b[0];
    out[1] = a[1] * b[1];
    return out;
}
/**
 * Divides two vec2's
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a the first operand
 * @param {ReadonlyVec2} b the second operand
 * @returns {vec2} out
 */
function divide(out, a, b) {
    out[0] = a[0] / b[0];
    out[1] = a[1] / b[1];
    return out;
}
/**
 * Math.ceil the components of a vec2
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a vector to ceil
 * @returns {vec2} out
 */
function ceil(out, a) {
    out[0] = Math.ceil(a[0]);
    out[1] = Math.ceil(a[1]);
    return out;
}
/**
 * Math.floor the components of a vec2
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a vector to floor
 * @returns {vec2} out
 */
function floor(out, a) {
    out[0] = Math.floor(a[0]);
    out[1] = Math.floor(a[1]);
    return out;
}
/**
 * Returns the minimum of two vec2's
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a the first operand
 * @param {ReadonlyVec2} b the second operand
 * @returns {vec2} out
 */
function min(out, a, b) {
    out[0] = Math.min(a[0], b[0]);
    out[1] = Math.min(a[1], b[1]);
    return out;
}
/**
 * Returns the maximum of two vec2's
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a the first operand
 * @param {ReadonlyVec2} b the second operand
 * @returns {vec2} out
 */
function max(out, a, b) {
    out[0] = Math.max(a[0], b[0]);
    out[1] = Math.max(a[1], b[1]);
    return out;
}
/**
 * Math.round the components of a vec2
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a vector to round
 * @returns {vec2} out
 */
function vec2_round(out, a) {
    out[0] = Math.round(a[0]);
    out[1] = Math.round(a[1]);
    return out;
}
/**
 * Scales a vec2 by a scalar number
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a the vector to scale
 * @param {Number} b amount to scale the vector by
 * @returns {vec2} out
 */
function scale(out, a, b) {
    out[0] = a[0] * b;
    out[1] = a[1] * b;
    return out;
}
/**
 * Adds two vec2's after scaling the second operand by a scalar value
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a the first operand
 * @param {ReadonlyVec2} b the second operand
 * @param {Number} scale the amount to scale b by before adding
 * @returns {vec2} out
 */
function scaleAndAdd(out, a, b, scale) {
    out[0] = a[0] + b[0] * scale;
    out[1] = a[1] + b[1] * scale;
    return out;
}
/**
 * Calculates the euclidian distance between two vec2's
 *
 * @param {ReadonlyVec2} a the first operand
 * @param {ReadonlyVec2} b the second operand
 * @returns {Number} distance between a and b
 */
function distance(a, b) {
    var x = b[0] - a[0], y = b[1] - a[1];
    return Math.hypot(x, y);
}
/**
 * Calculates the squared euclidian distance between two vec2's
 *
 * @param {ReadonlyVec2} a the first operand
 * @param {ReadonlyVec2} b the second operand
 * @returns {Number} squared distance between a and b
 */
function squaredDistance(a, b) {
    var x = b[0] - a[0], y = b[1] - a[1];
    return x * x + y * y;
}
/**
 * Calculates the length of a vec2
 *
 * @param {ReadonlyVec2} a vector to calculate length of
 * @returns {Number} length of a
 */
function vec2_length(a) {
    var x = a[0], y = a[1];
    return Math.hypot(x, y);
}
/**
 * Calculates the squared length of a vec2
 *
 * @param {ReadonlyVec2} a vector to calculate squared length of
 * @returns {Number} squared length of a
 */
function squaredLength(a) {
    var x = a[0], y = a[1];
    return x * x + y * y;
}
/**
 * Negates the components of a vec2
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a vector to negate
 * @returns {vec2} out
 */
function negate(out, a) {
    out[0] = -a[0];
    out[1] = -a[1];
    return out;
}
/**
 * Returns the inverse of the components of a vec2
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a vector to invert
 * @returns {vec2} out
 */
function inverse(out, a) {
    out[0] = 1.0 / a[0];
    out[1] = 1.0 / a[1];
    return out;
}
/**
 * Normalize a vec2
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a vector to normalize
 * @returns {vec2} out
 */
function normalize(out, a) {
    var x = a[0], y = a[1];
    var len = x * x + y * y;
    if (len > 0) {
        //TODO: evaluate use of glm_invsqrt here?
        len = 1 / Math.sqrt(len);
    }
    out[0] = a[0] * len;
    out[1] = a[1] * len;
    return out;
}
/**
 * Calculates the dot product of two vec2's
 *
 * @param {ReadonlyVec2} a the first operand
 * @param {ReadonlyVec2} b the second operand
 * @returns {Number} dot product of a and b
 */
function dot(a, b) {
    return a[0] * b[0] + a[1] * b[1];
}
/**
 * Computes the cross product of two vec2's
 * Note that the cross product must by definition produce a 3D vector
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec2} a the first operand
 * @param {ReadonlyVec2} b the second operand
 * @returns {vec3} out
 */
function cross(out, a, b) {
    var z = a[0] * b[1] - a[1] * b[0];
    out[0] = out[1] = 0;
    out[2] = z;
    return out;
}
/**
 * Performs a linear interpolation between two vec2's
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a the first operand
 * @param {ReadonlyVec2} b the second operand
 * @param {Number} t interpolation amount, in the range [0-1], between the two inputs
 * @returns {vec2} out
 */
function vec2_lerp(out, a, b, t) {
    var ax = a[0], ay = a[1];
    out[0] = ax + t * (b[0] - ax);
    out[1] = ay + t * (b[1] - ay);
    return out;
}
/**
 * Generates a random vector with the given scale
 *
 * @param {vec2} out the receiving vector
 * @param {Number} [scale] Length of the resulting vector. If ommitted, a unit vector will be returned
 * @returns {vec2} out
 */
function random(out, scale) {
    scale = scale || 1.0;
    var r = glMatrix.RANDOM() * 2.0 * Math.PI;
    out[0] = Math.cos(r) * scale;
    out[1] = Math.sin(r) * scale;
    return out;
}
/**
 * Transforms the vec2 with a mat2
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a the vector to transform
 * @param {ReadonlyMat2} m matrix to transform with
 * @returns {vec2} out
 */
function transformMat2(out, a, m) {
    var x = a[0], y = a[1];
    out[0] = m[0] * x + m[2] * y;
    out[1] = m[1] * x + m[3] * y;
    return out;
}
/**
 * Transforms the vec2 with a mat2d
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a the vector to transform
 * @param {ReadonlyMat2d} m matrix to transform with
 * @returns {vec2} out
 */
function transformMat2d(out, a, m) {
    var x = a[0], y = a[1];
    out[0] = m[0] * x + m[2] * y + m[4];
    out[1] = m[1] * x + m[3] * y + m[5];
    return out;
}
/**
 * Transforms the vec2 with a mat3
 * 3rd vector component is implicitly '1'
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a the vector to transform
 * @param {ReadonlyMat3} m matrix to transform with
 * @returns {vec2} out
 */
function transformMat3(out, a, m) {
    var x = a[0], y = a[1];
    out[0] = m[0] * x + m[3] * y + m[6];
    out[1] = m[1] * x + m[4] * y + m[7];
    return out;
}
/**
 * Transforms the vec2 with a mat4
 * 3rd vector component is implicitly '0'
 * 4th vector component is implicitly '1'
 *
 * @param {vec2} out the receiving vector
 * @param {ReadonlyVec2} a the vector to transform
 * @param {ReadonlyMat4} m matrix to transform with
 * @returns {vec2} out
 */
function transformMat4(out, a, m) {
    var x = a[0];
    var y = a[1];
    out[0] = m[0] * x + m[4] * y + m[12];
    out[1] = m[1] * x + m[5] * y + m[13];
    return out;
}
/**
 * Rotate a 2D vector
 * @param {vec2} out The receiving vec2
 * @param {ReadonlyVec2} a The vec2 point to rotate
 * @param {ReadonlyVec2} b The origin of the rotation
 * @param {Number} rad The angle of rotation in radians
 * @returns {vec2} out
 */
function rotate(out, a, b, rad) {
    //Translate point to the origin
    var p0 = a[0] - b[0], p1 = a[1] - b[1], sinC = Math.sin(rad), cosC = Math.cos(rad); //perform rotation and translate to correct position
    out[0] = p0 * cosC - p1 * sinC + b[0];
    out[1] = p0 * sinC + p1 * cosC + b[1];
    return out;
}
/**
 * Get the angle between two 2D vectors
 * @param {ReadonlyVec2} a The first operand
 * @param {ReadonlyVec2} b The second operand
 * @returns {Number} The angle in radians
 */
function angle(a, b) {
    var x1 = a[0], y1 = a[1], x2 = b[0], y2 = b[1], 
    // mag is the product of the magnitudes of a and b
    mag = Math.sqrt(x1 * x1 + y1 * y1) * Math.sqrt(x2 * x2 + y2 * y2), 
    // mag &&.. short circuits if mag == 0
    cosine = mag && (x1 * x2 + y1 * y2) / mag; // Math.min(Math.max(cosine, -1), 1) clamps the cosine between -1 and 1
    return Math.acos(Math.min(Math.max(cosine, -1), 1));
}
/**
 * Set the components of a vec2 to zero
 *
 * @param {vec2} out the receiving vector
 * @returns {vec2} out
 */
function zero(out) {
    out[0] = 0.0;
    out[1] = 0.0;
    return out;
}
/**
 * Returns a string representation of a vector
 *
 * @param {ReadonlyVec2} a vector to represent as a string
 * @returns {String} string representation of the vector
 */
function str(a) {
    return "vec2(" + a[0] + ", " + a[1] + ")";
}
/**
 * Returns whether or not the vectors exactly have the same elements in the same position (when compared with ===)
 *
 * @param {ReadonlyVec2} a The first vector.
 * @param {ReadonlyVec2} b The second vector.
 * @returns {Boolean} True if the vectors are equal, false otherwise.
 */
function vec2_exactEquals(a, b) {
    return a[0] === b[0] && a[1] === b[1];
}
/**
 * Returns whether or not the vectors have approximately the same elements in the same position.
 *
 * @param {ReadonlyVec2} a The first vector.
 * @param {ReadonlyVec2} b The second vector.
 * @returns {Boolean} True if the vectors are equal, false otherwise.
 */
function vec2_equals(a, b) {
    var a0 = a[0], a1 = a[1];
    var b0 = b[0], b1 = b[1];
    return Math.abs(a0 - b0) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a0), Math.abs(b0)) && Math.abs(a1 - b1) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a1), Math.abs(b1));
}
/**
 * Alias for {@link vec2.length}
 * @function
 */
var len = ( /* unused pure expression or super */null && (vec2_length));
/**
 * Alias for {@link vec2.subtract}
 * @function
 */
var sub = ( /* unused pure expression or super */null && (subtract));
/**
 * Alias for {@link vec2.multiply}
 * @function
 */
var mul = ( /* unused pure expression or super */null && (multiply));
/**
 * Alias for {@link vec2.divide}
 * @function
 */
var div = ( /* unused pure expression or super */null && (divide));
/**
 * Alias for {@link vec2.distance}
 * @function
 */
var dist = ( /* unused pure expression or super */null && (distance));
/**
 * Alias for {@link vec2.squaredDistance}
 * @function
 */
var sqrDist = ( /* unused pure expression or super */null && (squaredDistance));
/**
 * Alias for {@link vec2.squaredLength}
 * @function
 */
var sqrLen = ( /* unused pure expression or super */null && (squaredLength));
/**
 * Perform some operation over an array of vec2s.
 *
 * @param {Array} a the array of vectors to iterate over
 * @param {Number} stride Number of elements between the start of each vec2. If 0 assumes tightly packed
 * @param {Number} offset Number of elements to skip at the beginning of the array
 * @param {Number} count Number of vec2s to iterate over. If 0 iterates over entire array
 * @param {Function} fn Function to call for each vector in the array
 * @param {Object} [arg] additional argument to pass to fn
 * @returns {Array} a
 * @function
 */
var forEach = function () {
    var vec = create();
    return function (a, stride, offset, count, fn, arg) {
        var i, l;
        if (!stride) {
            stride = 2;
        }
        if (!offset) {
            offset = 0;
        }
        if (count) {
            l = Math.min(count * stride + offset, a.length);
        }
        else {
            l = a.length;
        }
        for (i = offset; i < l; i += stride) {
            vec[0] = a[i];
            vec[1] = a[i + 1];
            fn(vec, vec, arg);
            a[i] = vec[0];
            a[i + 1] = vec[1];
        }
        return a;
    };
}();
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/lib/gl-matrix-extras.js
function vec2_transformMat4AsVector(out, a, m) {
    const x = a[0];
    const y = a[1];
    const w = m[3] * x + m[7] * y || 1.0;
    out[0] = (m[0] * x + m[4] * y) / w;
    out[1] = (m[1] * x + m[5] * y) / w;
    return out;
}
function vec3_transformMat4AsVector(out, a, m) {
    const x = a[0];
    const y = a[1];
    const z = a[2];
    const w = m[3] * x + m[7] * y + m[11] * z || 1.0;
    out[0] = (m[0] * x + m[4] * y + m[8] * z) / w;
    out[1] = (m[1] * x + m[5] * y + m[9] * z) / w;
    out[2] = (m[2] * x + m[6] * y + m[10] * z) / w;
    return out;
}
function vec3_transformMat2(out, a, m) {
    const x = a[0];
    const y = a[1];
    out[0] = m[0] * x + m[2] * y;
    out[1] = m[1] * x + m[3] * y;
    out[2] = a[2];
    return out;
}
function vec4_transformMat2(out, a, m) {
    const x = a[0];
    const y = a[1];
    out[0] = m[0] * x + m[2] * y;
    out[1] = m[1] * x + m[3] * y;
    out[2] = a[2];
    out[3] = a[3];
    return out;
}
function vec4_transformMat3(out, a, m) {
    const x = a[0];
    const y = a[1];
    const z = a[2];
    out[0] = m[0] * x + m[3] * y + m[6] * z;
    out[1] = m[1] * x + m[4] * y + m[7] * z;
    out[2] = m[2] * x + m[5] * y + m[8] * z;
    out[3] = a[3];
    return out;
}
//# sourceMappingURL=gl-matrix-extras.js.map
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/classes/vector2.js
class Vector2 extends Vector {
    constructor(x = 0, y = 0) {
        super(2);
        if (isArray(x) && arguments.length === 1) {
            this.copy(x);
        }
        else {
            if (config.debug) {
                checkNumber(x);
                checkNumber(y);
            }
            this[0] = x;
            this[1] = y;
        }
    }
    set(x, y) {
        this[0] = x;
        this[1] = y;
        return this.check();
    }
    copy(array) {
        this[0] = array[0];
        this[1] = array[1];
        return this.check();
    }
    fromObject(object) {
        if (config.debug) {
            checkNumber(object.x);
            checkNumber(object.y);
        }
        this[0] = object.x;
        this[1] = object.y;
        return this.check();
    }
    toObject(object) {
        object.x = this[0];
        object.y = this[1];
        return object;
    }
    get ELEMENTS() {
        return 2;
    }
    horizontalAngle() {
        return Math.atan2(this.y, this.x);
    }
    verticalAngle() {
        return Math.atan2(this.x, this.y);
    }
    transform(matrix4) {
        return this.transformAsPoint(matrix4);
    }
    transformAsPoint(matrix4) {
        transformMat4(this, this, matrix4);
        return this.check();
    }
    transformAsVector(matrix4) {
        vec2_transformMat4AsVector(this, this, matrix4);
        return this.check();
    }
    transformByMatrix3(matrix3) {
        transformMat3(this, this, matrix3);
        return this.check();
    }
    transformByMatrix2x3(matrix2x3) {
        transformMat2d(this, this, matrix2x3);
        return this.check();
    }
    transformByMatrix2(matrix2) {
        transformMat2(this, this, matrix2);
        return this.check();
    }
}
//# sourceMappingURL=vector2.js.map
; // CONCATENATED MODULE: ./node_modules/gl-matrix/esm/vec3.js
/**
 * 3 Dimensional Vector
 * @module vec3
 */
/**
 * Creates a new, empty vec3
 *
 * @returns {vec3} a new 3D vector
 */
function vec3_create() {
    var out = new ARRAY_TYPE(3);
    if (ARRAY_TYPE != Float32Array) {
        out[0] = 0;
        out[1] = 0;
        out[2] = 0;
    }
    return out;
}
/**
 * Creates a new vec3 initialized with values from an existing vector
 *
 * @param {ReadonlyVec3} a vector to clone
 * @returns {vec3} a new 3D vector
 */
function vec3_clone(a) {
    var out = new glMatrix.ARRAY_TYPE(3);
    out[0] = a[0];
    out[1] = a[1];
    out[2] = a[2];
    return out;
}
/**
 * Calculates the length of a vec3
 *
 * @param {ReadonlyVec3} a vector to calculate length of
 * @returns {Number} length of a
 */
function vec3_length(a) {
    var x = a[0];
    var y = a[1];
    var z = a[2];
    return Math.hypot(x, y, z);
}
/**
 * Creates a new vec3 initialized with the given values
 *
 * @param {Number} x X component
 * @param {Number} y Y component
 * @param {Number} z Z component
 * @returns {vec3} a new 3D vector
 */
function vec3_fromValues(x, y, z) {
    var out = new ARRAY_TYPE(3);
    out[0] = x;
    out[1] = y;
    out[2] = z;
    return out;
}
/**
 * Copy the values from one vec3 to another
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a the source vector
 * @returns {vec3} out
 */
function vec3_copy(out, a) {
    out[0] = a[0];
    out[1] = a[1];
    out[2] = a[2];
    return out;
}
/**
 * Set the components of a vec3 to the given values
 *
 * @param {vec3} out the receiving vector
 * @param {Number} x X component
 * @param {Number} y Y component
 * @param {Number} z Z component
 * @returns {vec3} out
 */
function vec3_set(out, x, y, z) {
    out[0] = x;
    out[1] = y;
    out[2] = z;
    return out;
}
/**
 * Adds two vec3's
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a the first operand
 * @param {ReadonlyVec3} b the second operand
 * @returns {vec3} out
 */
function vec3_add(out, a, b) {
    out[0] = a[0] + b[0];
    out[1] = a[1] + b[1];
    out[2] = a[2] + b[2];
    return out;
}
/**
 * Subtracts vector b from vector a
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a the first operand
 * @param {ReadonlyVec3} b the second operand
 * @returns {vec3} out
 */
function vec3_subtract(out, a, b) {
    out[0] = a[0] - b[0];
    out[1] = a[1] - b[1];
    out[2] = a[2] - b[2];
    return out;
}
/**
 * Multiplies two vec3's
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a the first operand
 * @param {ReadonlyVec3} b the second operand
 * @returns {vec3} out
 */
function vec3_multiply(out, a, b) {
    out[0] = a[0] * b[0];
    out[1] = a[1] * b[1];
    out[2] = a[2] * b[2];
    return out;
}
/**
 * Divides two vec3's
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a the first operand
 * @param {ReadonlyVec3} b the second operand
 * @returns {vec3} out
 */
function vec3_divide(out, a, b) {
    out[0] = a[0] / b[0];
    out[1] = a[1] / b[1];
    out[2] = a[2] / b[2];
    return out;
}
/**
 * Math.ceil the components of a vec3
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a vector to ceil
 * @returns {vec3} out
 */
function vec3_ceil(out, a) {
    out[0] = Math.ceil(a[0]);
    out[1] = Math.ceil(a[1]);
    out[2] = Math.ceil(a[2]);
    return out;
}
/**
 * Math.floor the components of a vec3
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a vector to floor
 * @returns {vec3} out
 */
function vec3_floor(out, a) {
    out[0] = Math.floor(a[0]);
    out[1] = Math.floor(a[1]);
    out[2] = Math.floor(a[2]);
    return out;
}
/**
 * Returns the minimum of two vec3's
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a the first operand
 * @param {ReadonlyVec3} b the second operand
 * @returns {vec3} out
 */
function vec3_min(out, a, b) {
    out[0] = Math.min(a[0], b[0]);
    out[1] = Math.min(a[1], b[1]);
    out[2] = Math.min(a[2], b[2]);
    return out;
}
/**
 * Returns the maximum of two vec3's
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a the first operand
 * @param {ReadonlyVec3} b the second operand
 * @returns {vec3} out
 */
function vec3_max(out, a, b) {
    out[0] = Math.max(a[0], b[0]);
    out[1] = Math.max(a[1], b[1]);
    out[2] = Math.max(a[2], b[2]);
    return out;
}
/**
 * Math.round the components of a vec3
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a vector to round
 * @returns {vec3} out
 */
function vec3_round(out, a) {
    out[0] = Math.round(a[0]);
    out[1] = Math.round(a[1]);
    out[2] = Math.round(a[2]);
    return out;
}
/**
 * Scales a vec3 by a scalar number
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a the vector to scale
 * @param {Number} b amount to scale the vector by
 * @returns {vec3} out
 */
function vec3_scale(out, a, b) {
    out[0] = a[0] * b;
    out[1] = a[1] * b;
    out[2] = a[2] * b;
    return out;
}
/**
 * Adds two vec3's after scaling the second operand by a scalar value
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a the first operand
 * @param {ReadonlyVec3} b the second operand
 * @param {Number} scale the amount to scale b by before adding
 * @returns {vec3} out
 */
function vec3_scaleAndAdd(out, a, b, scale) {
    out[0] = a[0] + b[0] * scale;
    out[1] = a[1] + b[1] * scale;
    out[2] = a[2] + b[2] * scale;
    return out;
}
/**
 * Calculates the euclidian distance between two vec3's
 *
 * @param {ReadonlyVec3} a the first operand
 * @param {ReadonlyVec3} b the second operand
 * @returns {Number} distance between a and b
 */
function vec3_distance(a, b) {
    var x = b[0] - a[0];
    var y = b[1] - a[1];
    var z = b[2] - a[2];
    return Math.hypot(x, y, z);
}
/**
 * Calculates the squared euclidian distance between two vec3's
 *
 * @param {ReadonlyVec3} a the first operand
 * @param {ReadonlyVec3} b the second operand
 * @returns {Number} squared distance between a and b
 */
function vec3_squaredDistance(a, b) {
    var x = b[0] - a[0];
    var y = b[1] - a[1];
    var z = b[2] - a[2];
    return x * x + y * y + z * z;
}
/**
 * Calculates the squared length of a vec3
 *
 * @param {ReadonlyVec3} a vector to calculate squared length of
 * @returns {Number} squared length of a
 */
function vec3_squaredLength(a) {
    var x = a[0];
    var y = a[1];
    var z = a[2];
    return x * x + y * y + z * z;
}
/**
 * Negates the components of a vec3
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a vector to negate
 * @returns {vec3} out
 */
function vec3_negate(out, a) {
    out[0] = -a[0];
    out[1] = -a[1];
    out[2] = -a[2];
    return out;
}
/**
 * Returns the inverse of the components of a vec3
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a vector to invert
 * @returns {vec3} out
 */
function vec3_inverse(out, a) {
    out[0] = 1.0 / a[0];
    out[1] = 1.0 / a[1];
    out[2] = 1.0 / a[2];
    return out;
}
/**
 * Normalize a vec3
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a vector to normalize
 * @returns {vec3} out
 */
function vec3_normalize(out, a) {
    var x = a[0];
    var y = a[1];
    var z = a[2];
    var len = x * x + y * y + z * z;
    if (len > 0) {
        //TODO: evaluate use of glm_invsqrt here?
        len = 1 / Math.sqrt(len);
    }
    out[0] = a[0] * len;
    out[1] = a[1] * len;
    out[2] = a[2] * len;
    return out;
}
/**
 * Calculates the dot product of two vec3's
 *
 * @param {ReadonlyVec3} a the first operand
 * @param {ReadonlyVec3} b the second operand
 * @returns {Number} dot product of a and b
 */
function vec3_dot(a, b) {
    return a[0] * b[0] + a[1] * b[1] + a[2] * b[2];
}
/**
 * Computes the cross product of two vec3's
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a the first operand
 * @param {ReadonlyVec3} b the second operand
 * @returns {vec3} out
 */
function vec3_cross(out, a, b) {
    var ax = a[0], ay = a[1], az = a[2];
    var bx = b[0], by = b[1], bz = b[2];
    out[0] = ay * bz - az * by;
    out[1] = az * bx - ax * bz;
    out[2] = ax * by - ay * bx;
    return out;
}
/**
 * Performs a linear interpolation between two vec3's
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a the first operand
 * @param {ReadonlyVec3} b the second operand
 * @param {Number} t interpolation amount, in the range [0-1], between the two inputs
 * @returns {vec3} out
 */
function vec3_lerp(out, a, b, t) {
    var ax = a[0];
    var ay = a[1];
    var az = a[2];
    out[0] = ax + t * (b[0] - ax);
    out[1] = ay + t * (b[1] - ay);
    out[2] = az + t * (b[2] - az);
    return out;
}
/**
 * Performs a hermite interpolation with two control points
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a the first operand
 * @param {ReadonlyVec3} b the second operand
 * @param {ReadonlyVec3} c the third operand
 * @param {ReadonlyVec3} d the fourth operand
 * @param {Number} t interpolation amount, in the range [0-1], between the two inputs
 * @returns {vec3} out
 */
function hermite(out, a, b, c, d, t) {
    var factorTimes2 = t * t;
    var factor1 = factorTimes2 * (2 * t - 3) + 1;
    var factor2 = factorTimes2 * (t - 2) + t;
    var factor3 = factorTimes2 * (t - 1);
    var factor4 = factorTimes2 * (3 - 2 * t);
    out[0] = a[0] * factor1 + b[0] * factor2 + c[0] * factor3 + d[0] * factor4;
    out[1] = a[1] * factor1 + b[1] * factor2 + c[1] * factor3 + d[1] * factor4;
    out[2] = a[2] * factor1 + b[2] * factor2 + c[2] * factor3 + d[2] * factor4;
    return out;
}
/**
 * Performs a bezier interpolation with two control points
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a the first operand
 * @param {ReadonlyVec3} b the second operand
 * @param {ReadonlyVec3} c the third operand
 * @param {ReadonlyVec3} d the fourth operand
 * @param {Number} t interpolation amount, in the range [0-1], between the two inputs
 * @returns {vec3} out
 */
function bezier(out, a, b, c, d, t) {
    var inverseFactor = 1 - t;
    var inverseFactorTimesTwo = inverseFactor * inverseFactor;
    var factorTimes2 = t * t;
    var factor1 = inverseFactorTimesTwo * inverseFactor;
    var factor2 = 3 * t * inverseFactorTimesTwo;
    var factor3 = 3 * factorTimes2 * inverseFactor;
    var factor4 = factorTimes2 * t;
    out[0] = a[0] * factor1 + b[0] * factor2 + c[0] * factor3 + d[0] * factor4;
    out[1] = a[1] * factor1 + b[1] * factor2 + c[1] * factor3 + d[1] * factor4;
    out[2] = a[2] * factor1 + b[2] * factor2 + c[2] * factor3 + d[2] * factor4;
    return out;
}
/**
 * Generates a random vector with the given scale
 *
 * @param {vec3} out the receiving vector
 * @param {Number} [scale] Length of the resulting vector. If ommitted, a unit vector will be returned
 * @returns {vec3} out
 */
function vec3_random(out, scale) {
    scale = scale || 1.0;
    var r = glMatrix.RANDOM() * 2.0 * Math.PI;
    var z = glMatrix.RANDOM() * 2.0 - 1.0;
    var zScale = Math.sqrt(1.0 - z * z) * scale;
    out[0] = Math.cos(r) * zScale;
    out[1] = Math.sin(r) * zScale;
    out[2] = z * scale;
    return out;
}
/**
 * Transforms the vec3 with a mat4.
 * 4th vector component is implicitly '1'
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a the vector to transform
 * @param {ReadonlyMat4} m matrix to transform with
 * @returns {vec3} out
 */
function vec3_transformMat4(out, a, m) {
    var x = a[0], y = a[1], z = a[2];
    var w = m[3] * x + m[7] * y + m[11] * z + m[15];
    w = w || 1.0;
    out[0] = (m[0] * x + m[4] * y + m[8] * z + m[12]) / w;
    out[1] = (m[1] * x + m[5] * y + m[9] * z + m[13]) / w;
    out[2] = (m[2] * x + m[6] * y + m[10] * z + m[14]) / w;
    return out;
}
/**
 * Transforms the vec3 with a mat3.
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a the vector to transform
 * @param {ReadonlyMat3} m the 3x3 matrix to transform with
 * @returns {vec3} out
 */
function vec3_transformMat3(out, a, m) {
    var x = a[0], y = a[1], z = a[2];
    out[0] = x * m[0] + y * m[3] + z * m[6];
    out[1] = x * m[1] + y * m[4] + z * m[7];
    out[2] = x * m[2] + y * m[5] + z * m[8];
    return out;
}
/**
 * Transforms the vec3 with a quat
 * Can also be used for dual quaternions. (Multiply it with the real part)
 *
 * @param {vec3} out the receiving vector
 * @param {ReadonlyVec3} a the vector to transform
 * @param {ReadonlyQuat} q quaternion to transform with
 * @returns {vec3} out
 */
function transformQuat(out, a, q) {
    // benchmarks: https://jsperf.com/quaternion-transform-vec3-implementations-fixed
    var qx = q[0], qy = q[1], qz = q[2], qw = q[3];
    var x = a[0], y = a[1], z = a[2]; // var qvec = [qx, qy, qz];
    // var uv = vec3.cross([], qvec, a);
    var uvx = qy * z - qz * y, uvy = qz * x - qx * z, uvz = qx * y - qy * x; // var uuv = vec3.cross([], qvec, uv);
    var uuvx = qy * uvz - qz * uvy, uuvy = qz * uvx - qx * uvz, uuvz = qx * uvy - qy * uvx; // vec3.scale(uv, uv, 2 * w);
    var w2 = qw * 2;
    uvx *= w2;
    uvy *= w2;
    uvz *= w2; // vec3.scale(uuv, uuv, 2);
    uuvx *= 2;
    uuvy *= 2;
    uuvz *= 2; // return vec3.add(out, a, vec3.add(out, uv, uuv));
    out[0] = x + uvx + uuvx;
    out[1] = y + uvy + uuvy;
    out[2] = z + uvz + uuvz;
    return out;
}
/**
 * Rotate a 3D vector around the x-axis
 * @param {vec3} out The receiving vec3
 * @param {ReadonlyVec3} a The vec3 point to rotate
 * @param {ReadonlyVec3} b The origin of the rotation
 * @param {Number} rad The angle of rotation in radians
 * @returns {vec3} out
 */
function rotateX(out, a, b, rad) {
    var p = [], r = []; //Translate point to the origin
    p[0] = a[0] - b[0];
    p[1] = a[1] - b[1];
    p[2] = a[2] - b[2]; //perform rotation
    r[0] = p[0];
    r[1] = p[1] * Math.cos(rad) - p[2] * Math.sin(rad);
    r[2] = p[1] * Math.sin(rad) + p[2] * Math.cos(rad); //translate to correct position
    out[0] = r[0] + b[0];
    out[1] = r[1] + b[1];
    out[2] = r[2] + b[2];
    return out;
}
/**
 * Rotate a 3D vector around the y-axis
 * @param {vec3} out The receiving vec3
 * @param {ReadonlyVec3} a The vec3 point to rotate
 * @param {ReadonlyVec3} b The origin of the rotation
 * @param {Number} rad The angle of rotation in radians
 * @returns {vec3} out
 */
function rotateY(out, a, b, rad) {
    var p = [], r = []; //Translate point to the origin
    p[0] = a[0] - b[0];
    p[1] = a[1] - b[1];
    p[2] = a[2] - b[2]; //perform rotation
    r[0] = p[2] * Math.sin(rad) + p[0] * Math.cos(rad);
    r[1] = p[1];
    r[2] = p[2] * Math.cos(rad) - p[0] * Math.sin(rad); //translate to correct position
    out[0] = r[0] + b[0];
    out[1] = r[1] + b[1];
    out[2] = r[2] + b[2];
    return out;
}
/**
 * Rotate a 3D vector around the z-axis
 * @param {vec3} out The receiving vec3
 * @param {ReadonlyVec3} a The vec3 point to rotate
 * @param {ReadonlyVec3} b The origin of the rotation
 * @param {Number} rad The angle of rotation in radians
 * @returns {vec3} out
 */
function rotateZ(out, a, b, rad) {
    var p = [], r = []; //Translate point to the origin
    p[0] = a[0] - b[0];
    p[1] = a[1] - b[1];
    p[2] = a[2] - b[2]; //perform rotation
    r[0] = p[0] * Math.cos(rad) - p[1] * Math.sin(rad);
    r[1] = p[0] * Math.sin(rad) + p[1] * Math.cos(rad);
    r[2] = p[2]; //translate to correct position
    out[0] = r[0] + b[0];
    out[1] = r[1] + b[1];
    out[2] = r[2] + b[2];
    return out;
}
/**
 * Get the angle between two 3D vectors
 * @param {ReadonlyVec3} a The first operand
 * @param {ReadonlyVec3} b The second operand
 * @returns {Number} The angle in radians
 */
function vec3_angle(a, b) {
    var ax = a[0], ay = a[1], az = a[2], bx = b[0], by = b[1], bz = b[2], mag1 = Math.sqrt(ax * ax + ay * ay + az * az), mag2 = Math.sqrt(bx * bx + by * by + bz * bz), mag = mag1 * mag2, cosine = mag && vec3_dot(a, b) / mag;
    return Math.acos(Math.min(Math.max(cosine, -1), 1));
}
/**
 * Set the components of a vec3 to zero
 *
 * @param {vec3} out the receiving vector
 * @returns {vec3} out
 */
function vec3_zero(out) {
    out[0] = 0.0;
    out[1] = 0.0;
    out[2] = 0.0;
    return out;
}
/**
 * Returns a string representation of a vector
 *
 * @param {ReadonlyVec3} a vector to represent as a string
 * @returns {String} string representation of the vector
 */
function vec3_str(a) {
    return "vec3(" + a[0] + ", " + a[1] + ", " + a[2] + ")";
}
/**
 * Returns whether or not the vectors have exactly the same elements in the same position (when compared with ===)
 *
 * @param {ReadonlyVec3} a The first vector.
 * @param {ReadonlyVec3} b The second vector.
 * @returns {Boolean} True if the vectors are equal, false otherwise.
 */
function vec3_exactEquals(a, b) {
    return a[0] === b[0] && a[1] === b[1] && a[2] === b[2];
}
/**
 * Returns whether or not the vectors have approximately the same elements in the same position.
 *
 * @param {ReadonlyVec3} a The first vector.
 * @param {ReadonlyVec3} b The second vector.
 * @returns {Boolean} True if the vectors are equal, false otherwise.
 */
function vec3_equals(a, b) {
    var a0 = a[0], a1 = a[1], a2 = a[2];
    var b0 = b[0], b1 = b[1], b2 = b[2];
    return Math.abs(a0 - b0) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a0), Math.abs(b0)) && Math.abs(a1 - b1) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a1), Math.abs(b1)) && Math.abs(a2 - b2) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a2), Math.abs(b2));
}
/**
 * Alias for {@link vec3.subtract}
 * @function
 */
var vec3_sub = ( /* unused pure expression or super */null && (vec3_subtract));
/**
 * Alias for {@link vec3.multiply}
 * @function
 */
var vec3_mul = ( /* unused pure expression or super */null && (vec3_multiply));
/**
 * Alias for {@link vec3.divide}
 * @function
 */
var vec3_div = ( /* unused pure expression or super */null && (vec3_divide));
/**
 * Alias for {@link vec3.distance}
 * @function
 */
var vec3_dist = ( /* unused pure expression or super */null && (vec3_distance));
/**
 * Alias for {@link vec3.squaredDistance}
 * @function
 */
var vec3_sqrDist = ( /* unused pure expression or super */null && (vec3_squaredDistance));
/**
 * Alias for {@link vec3.length}
 * @function
 */
var vec3_len = vec3_length;
/**
 * Alias for {@link vec3.squaredLength}
 * @function
 */
var vec3_sqrLen = ( /* unused pure expression or super */null && (vec3_squaredLength));
/**
 * Perform some operation over an array of vec3s.
 *
 * @param {Array} a the array of vectors to iterate over
 * @param {Number} stride Number of elements between the start of each vec3. If 0 assumes tightly packed
 * @param {Number} offset Number of elements to skip at the beginning of the array
 * @param {Number} count Number of vec3s to iterate over. If 0 iterates over entire array
 * @param {Function} fn Function to call for each vector in the array
 * @param {Object} [arg] additional argument to pass to fn
 * @returns {Array} a
 * @function
 */
var vec3_forEach = function () {
    var vec = vec3_create();
    return function (a, stride, offset, count, fn, arg) {
        var i, l;
        if (!stride) {
            stride = 3;
        }
        if (!offset) {
            offset = 0;
        }
        if (count) {
            l = Math.min(count * stride + offset, a.length);
        }
        else {
            l = a.length;
        }
        for (i = offset; i < l; i += stride) {
            vec[0] = a[i];
            vec[1] = a[i + 1];
            vec[2] = a[i + 2];
            fn(vec, vec, arg);
            a[i] = vec[0];
            a[i + 1] = vec[1];
            a[i + 2] = vec[2];
        }
        return a;
    };
}();
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/classes/vector3.js
const ORIGIN = [0, 0, 0];
let ZERO;
class Vector3 extends Vector {
    static get ZERO() {
        if (!ZERO) {
            ZERO = new Vector3(0, 0, 0);
            Object.freeze(ZERO);
        }
        return ZERO;
    }
    constructor(x = 0, y = 0, z = 0) {
        super(-0, -0, -0);
        if (arguments.length === 1 && isArray(x)) {
            this.copy(x);
        }
        else {
            if (config.debug) {
                checkNumber(x);
                checkNumber(y);
                checkNumber(z);
            }
            this[0] = x;
            this[1] = y;
            this[2] = z;
        }
    }
    set(x, y, z) {
        this[0] = x;
        this[1] = y;
        this[2] = z;
        return this.check();
    }
    copy(array) {
        this[0] = array[0];
        this[1] = array[1];
        this[2] = array[2];
        return this.check();
    }
    fromObject(object) {
        if (config.debug) {
            checkNumber(object.x);
            checkNumber(object.y);
            checkNumber(object.z);
        }
        this[0] = object.x;
        this[1] = object.y;
        this[2] = object.z;
        return this.check();
    }
    toObject(object) {
        object.x = this[0];
        object.y = this[1];
        object.z = this[2];
        return object;
    }
    get ELEMENTS() {
        return 3;
    }
    get z() {
        return this[2];
    }
    set z(value) {
        this[2] = checkNumber(value);
    }
    angle(vector) {
        return vec3_angle(this, vector);
    }
    cross(vector) {
        vec3_cross(this, this, vector);
        return this.check();
    }
    rotateX({ radians, origin = ORIGIN }) {
        rotateX(this, this, origin, radians);
        return this.check();
    }
    rotateY({ radians, origin = ORIGIN }) {
        rotateY(this, this, origin, radians);
        return this.check();
    }
    rotateZ({ radians, origin = ORIGIN }) {
        rotateZ(this, this, origin, radians);
        return this.check();
    }
    transform(matrix4) {
        return this.transformAsPoint(matrix4);
    }
    transformAsPoint(matrix4) {
        vec3_transformMat4(this, this, matrix4);
        return this.check();
    }
    transformAsVector(matrix4) {
        vec3_transformMat4AsVector(this, this, matrix4);
        return this.check();
    }
    transformByMatrix3(matrix3) {
        vec3_transformMat3(this, this, matrix3);
        return this.check();
    }
    transformByMatrix2(matrix2) {
        vec3_transformMat2(this, this, matrix2);
        return this.check();
    }
    transformByQuaternion(quaternion) {
        transformQuat(this, this, quaternion);
        return this.check();
    }
}
//# sourceMappingURL=vector3.js.map
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/classes/vector4.js
let vector4_ZERO;
class Vector4 extends Vector {
    static get ZERO() {
        if (!vector4_ZERO) {
            vector4_ZERO = new Vector4(0, 0, 0, 0);
            Object.freeze(vector4_ZERO);
        }
        return vector4_ZERO;
    }
    constructor(x = 0, y = 0, z = 0, w = 0) {
        super(-0, -0, -0, -0);
        if (isArray(x) && arguments.length === 1) {
            this.copy(x);
        }
        else {
            if (config.debug) {
                checkNumber(x);
                checkNumber(y);
                checkNumber(z);
                checkNumber(w);
            }
            this[0] = x;
            this[1] = y;
            this[2] = z;
            this[3] = w;
        }
    }
    set(x, y, z, w) {
        this[0] = x;
        this[1] = y;
        this[2] = z;
        this[3] = w;
        return this.check();
    }
    copy(array) {
        this[0] = array[0];
        this[1] = array[1];
        this[2] = array[2];
        this[3] = array[3];
        return this.check();
    }
    fromObject(object) {
        if (config.debug) {
            checkNumber(object.x);
            checkNumber(object.y);
            checkNumber(object.z);
            checkNumber(object.w);
        }
        this[0] = object.x;
        this[1] = object.y;
        this[2] = object.z;
        this[3] = object.w;
        return this;
    }
    toObject(object) {
        object.x = this[0];
        object.y = this[1];
        object.z = this[2];
        object.w = this[3];
        return object;
    }
    get ELEMENTS() {
        return 4;
    }
    get z() {
        return this[2];
    }
    set z(value) {
        this[2] = checkNumber(value);
    }
    get w() {
        return this[3];
    }
    set w(value) {
        this[3] = checkNumber(value);
    }
    transform(matrix4) {
        vec3_transformMat4(this, this, matrix4);
        return this.check();
    }
    transformByMatrix3(matrix3) {
        vec4_transformMat3(this, this, matrix3);
        return this.check();
    }
    transformByMatrix2(matrix2) {
        vec4_transformMat2(this, this, matrix2);
        return this.check();
    }
    transformByQuaternion(quaternion) {
        transformQuat(this, this, quaternion);
        return this.check();
    }
    applyMatrix4(m) {
        m.transform(this, this);
        return this;
    }
}
//# sourceMappingURL=vector4.js.map
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/classes/base/matrix.js
class Matrix extends MathArray {
    toString() {
        let string = '[';
        if (config.printRowMajor) {
            string += 'row-major:';
            for (let row = 0; row < this.RANK; ++row) {
                for (let col = 0; col < this.RANK; ++col) {
                    string += " ".concat(this[col * this.RANK + row]);
                }
            }
        }
        else {
            string += 'column-major:';
            for (let i = 0; i < this.ELEMENTS; ++i) {
                string += " ".concat(this[i]);
            }
        }
        string += ']';
        return string;
    }
    getElementIndex(row, col) {
        return col * this.RANK + row;
    }
    getElement(row, col) {
        return this[col * this.RANK + row];
    }
    setElement(row, col, value) {
        this[col * this.RANK + row] = checkNumber(value);
        return this;
    }
    getColumn(columnIndex, result = new Array(this.RANK).fill(-0)) {
        const firstIndex = columnIndex * this.RANK;
        for (let i = 0; i < this.RANK; ++i) {
            result[i] = this[firstIndex + i];
        }
        return result;
    }
    setColumn(columnIndex, columnVector) {
        const firstIndex = columnIndex * this.RANK;
        for (let i = 0; i < this.RANK; ++i) {
            this[firstIndex + i] = columnVector[i];
        }
        return this;
    }
}
//# sourceMappingURL=matrix.js.map
; // CONCATENATED MODULE: ./node_modules/gl-matrix/esm/mat3.js
/**
 * 3x3 Matrix
 * @module mat3
 */
/**
 * Creates a new identity mat3
 *
 * @returns {mat3} a new 3x3 matrix
 */
function mat3_create() {
    var out = new ARRAY_TYPE(9);
    if (ARRAY_TYPE != Float32Array) {
        out[1] = 0;
        out[2] = 0;
        out[3] = 0;
        out[5] = 0;
        out[6] = 0;
        out[7] = 0;
    }
    out[0] = 1;
    out[4] = 1;
    out[8] = 1;
    return out;
}
/**
 * Copies the upper-left 3x3 values into the given mat3.
 *
 * @param {mat3} out the receiving 3x3 matrix
 * @param {ReadonlyMat4} a   the source 4x4 matrix
 * @returns {mat3} out
 */
function fromMat4(out, a) {
    out[0] = a[0];
    out[1] = a[1];
    out[2] = a[2];
    out[3] = a[4];
    out[4] = a[5];
    out[5] = a[6];
    out[6] = a[8];
    out[7] = a[9];
    out[8] = a[10];
    return out;
}
/**
 * Creates a new mat3 initialized with values from an existing matrix
 *
 * @param {ReadonlyMat3} a matrix to clone
 * @returns {mat3} a new 3x3 matrix
 */
function mat3_clone(a) {
    var out = new glMatrix.ARRAY_TYPE(9);
    out[0] = a[0];
    out[1] = a[1];
    out[2] = a[2];
    out[3] = a[3];
    out[4] = a[4];
    out[5] = a[5];
    out[6] = a[6];
    out[7] = a[7];
    out[8] = a[8];
    return out;
}
/**
 * Copy the values from one mat3 to another
 *
 * @param {mat3} out the receiving matrix
 * @param {ReadonlyMat3} a the source matrix
 * @returns {mat3} out
 */
function mat3_copy(out, a) {
    out[0] = a[0];
    out[1] = a[1];
    out[2] = a[2];
    out[3] = a[3];
    out[4] = a[4];
    out[5] = a[5];
    out[6] = a[6];
    out[7] = a[7];
    out[8] = a[8];
    return out;
}
/**
 * Create a new mat3 with the given values
 *
 * @param {Number} m00 Component in column 0, row 0 position (index 0)
 * @param {Number} m01 Component in column 0, row 1 position (index 1)
 * @param {Number} m02 Component in column 0, row 2 position (index 2)
 * @param {Number} m10 Component in column 1, row 0 position (index 3)
 * @param {Number} m11 Component in column 1, row 1 position (index 4)
 * @param {Number} m12 Component in column 1, row 2 position (index 5)
 * @param {Number} m20 Component in column 2, row 0 position (index 6)
 * @param {Number} m21 Component in column 2, row 1 position (index 7)
 * @param {Number} m22 Component in column 2, row 2 position (index 8)
 * @returns {mat3} A new mat3
 */
function mat3_fromValues(m00, m01, m02, m10, m11, m12, m20, m21, m22) {
    var out = new glMatrix.ARRAY_TYPE(9);
    out[0] = m00;
    out[1] = m01;
    out[2] = m02;
    out[3] = m10;
    out[4] = m11;
    out[5] = m12;
    out[6] = m20;
    out[7] = m21;
    out[8] = m22;
    return out;
}
/**
 * Set the components of a mat3 to the given values
 *
 * @param {mat3} out the receiving matrix
 * @param {Number} m00 Component in column 0, row 0 position (index 0)
 * @param {Number} m01 Component in column 0, row 1 position (index 1)
 * @param {Number} m02 Component in column 0, row 2 position (index 2)
 * @param {Number} m10 Component in column 1, row 0 position (index 3)
 * @param {Number} m11 Component in column 1, row 1 position (index 4)
 * @param {Number} m12 Component in column 1, row 2 position (index 5)
 * @param {Number} m20 Component in column 2, row 0 position (index 6)
 * @param {Number} m21 Component in column 2, row 1 position (index 7)
 * @param {Number} m22 Component in column 2, row 2 position (index 8)
 * @returns {mat3} out
 */
function mat3_set(out, m00, m01, m02, m10, m11, m12, m20, m21, m22) {
    out[0] = m00;
    out[1] = m01;
    out[2] = m02;
    out[3] = m10;
    out[4] = m11;
    out[5] = m12;
    out[6] = m20;
    out[7] = m21;
    out[8] = m22;
    return out;
}
/**
 * Set a mat3 to the identity matrix
 *
 * @param {mat3} out the receiving matrix
 * @returns {mat3} out
 */
function identity(out) {
    out[0] = 1;
    out[1] = 0;
    out[2] = 0;
    out[3] = 0;
    out[4] = 1;
    out[5] = 0;
    out[6] = 0;
    out[7] = 0;
    out[8] = 1;
    return out;
}
/**
 * Transpose the values of a mat3
 *
 * @param {mat3} out the receiving matrix
 * @param {ReadonlyMat3} a the source matrix
 * @returns {mat3} out
 */
function transpose(out, a) {
    // If we are transposing ourselves we can skip a few steps but have to cache some values
    if (out === a) {
        var a01 = a[1], a02 = a[2], a12 = a[5];
        out[1] = a[3];
        out[2] = a[6];
        out[3] = a01;
        out[5] = a[7];
        out[6] = a02;
        out[7] = a12;
    }
    else {
        out[0] = a[0];
        out[1] = a[3];
        out[2] = a[6];
        out[3] = a[1];
        out[4] = a[4];
        out[5] = a[7];
        out[6] = a[2];
        out[7] = a[5];
        out[8] = a[8];
    }
    return out;
}
/**
 * Inverts a mat3
 *
 * @param {mat3} out the receiving matrix
 * @param {ReadonlyMat3} a the source matrix
 * @returns {mat3} out
 */
function invert(out, a) {
    var a00 = a[0], a01 = a[1], a02 = a[2];
    var a10 = a[3], a11 = a[4], a12 = a[5];
    var a20 = a[6], a21 = a[7], a22 = a[8];
    var b01 = a22 * a11 - a12 * a21;
    var b11 = -a22 * a10 + a12 * a20;
    var b21 = a21 * a10 - a11 * a20; // Calculate the determinant
    var det = a00 * b01 + a01 * b11 + a02 * b21;
    if (!det) {
        return null;
    }
    det = 1.0 / det;
    out[0] = b01 * det;
    out[1] = (-a22 * a01 + a02 * a21) * det;
    out[2] = (a12 * a01 - a02 * a11) * det;
    out[3] = b11 * det;
    out[4] = (a22 * a00 - a02 * a20) * det;
    out[5] = (-a12 * a00 + a02 * a10) * det;
    out[6] = b21 * det;
    out[7] = (-a21 * a00 + a01 * a20) * det;
    out[8] = (a11 * a00 - a01 * a10) * det;
    return out;
}
/**
 * Calculates the adjugate of a mat3
 *
 * @param {mat3} out the receiving matrix
 * @param {ReadonlyMat3} a the source matrix
 * @returns {mat3} out
 */
function adjoint(out, a) {
    var a00 = a[0], a01 = a[1], a02 = a[2];
    var a10 = a[3], a11 = a[4], a12 = a[5];
    var a20 = a[6], a21 = a[7], a22 = a[8];
    out[0] = a11 * a22 - a12 * a21;
    out[1] = a02 * a21 - a01 * a22;
    out[2] = a01 * a12 - a02 * a11;
    out[3] = a12 * a20 - a10 * a22;
    out[4] = a00 * a22 - a02 * a20;
    out[5] = a02 * a10 - a00 * a12;
    out[6] = a10 * a21 - a11 * a20;
    out[7] = a01 * a20 - a00 * a21;
    out[8] = a00 * a11 - a01 * a10;
    return out;
}
/**
 * Calculates the determinant of a mat3
 *
 * @param {ReadonlyMat3} a the source matrix
 * @returns {Number} determinant of a
 */
function determinant(a) {
    var a00 = a[0], a01 = a[1], a02 = a[2];
    var a10 = a[3], a11 = a[4], a12 = a[5];
    var a20 = a[6], a21 = a[7], a22 = a[8];
    return a00 * (a22 * a11 - a12 * a21) + a01 * (-a22 * a10 + a12 * a20) + a02 * (a21 * a10 - a11 * a20);
}
/**
 * Multiplies two mat3's
 *
 * @param {mat3} out the receiving matrix
 * @param {ReadonlyMat3} a the first operand
 * @param {ReadonlyMat3} b the second operand
 * @returns {mat3} out
 */
function mat3_multiply(out, a, b) {
    var a00 = a[0], a01 = a[1], a02 = a[2];
    var a10 = a[3], a11 = a[4], a12 = a[5];
    var a20 = a[6], a21 = a[7], a22 = a[8];
    var b00 = b[0], b01 = b[1], b02 = b[2];
    var b10 = b[3], b11 = b[4], b12 = b[5];
    var b20 = b[6], b21 = b[7], b22 = b[8];
    out[0] = b00 * a00 + b01 * a10 + b02 * a20;
    out[1] = b00 * a01 + b01 * a11 + b02 * a21;
    out[2] = b00 * a02 + b01 * a12 + b02 * a22;
    out[3] = b10 * a00 + b11 * a10 + b12 * a20;
    out[4] = b10 * a01 + b11 * a11 + b12 * a21;
    out[5] = b10 * a02 + b11 * a12 + b12 * a22;
    out[6] = b20 * a00 + b21 * a10 + b22 * a20;
    out[7] = b20 * a01 + b21 * a11 + b22 * a21;
    out[8] = b20 * a02 + b21 * a12 + b22 * a22;
    return out;
}
/**
 * Translate a mat3 by the given vector
 *
 * @param {mat3} out the receiving matrix
 * @param {ReadonlyMat3} a the matrix to translate
 * @param {ReadonlyVec2} v vector to translate by
 * @returns {mat3} out
 */
function translate(out, a, v) {
    var a00 = a[0], a01 = a[1], a02 = a[2], a10 = a[3], a11 = a[4], a12 = a[5], a20 = a[6], a21 = a[7], a22 = a[8], x = v[0], y = v[1];
    out[0] = a00;
    out[1] = a01;
    out[2] = a02;
    out[3] = a10;
    out[4] = a11;
    out[5] = a12;
    out[6] = x * a00 + y * a10 + a20;
    out[7] = x * a01 + y * a11 + a21;
    out[8] = x * a02 + y * a12 + a22;
    return out;
}
/**
 * Rotates a mat3 by the given angle
 *
 * @param {mat3} out the receiving matrix
 * @param {ReadonlyMat3} a the matrix to rotate
 * @param {Number} rad the angle to rotate the matrix by
 * @returns {mat3} out
 */
function mat3_rotate(out, a, rad) {
    var a00 = a[0], a01 = a[1], a02 = a[2], a10 = a[3], a11 = a[4], a12 = a[5], a20 = a[6], a21 = a[7], a22 = a[8], s = Math.sin(rad), c = Math.cos(rad);
    out[0] = c * a00 + s * a10;
    out[1] = c * a01 + s * a11;
    out[2] = c * a02 + s * a12;
    out[3] = c * a10 - s * a00;
    out[4] = c * a11 - s * a01;
    out[5] = c * a12 - s * a02;
    out[6] = a20;
    out[7] = a21;
    out[8] = a22;
    return out;
}
/**
 * Scales the mat3 by the dimensions in the given vec2
 *
 * @param {mat3} out the receiving matrix
 * @param {ReadonlyMat3} a the matrix to rotate
 * @param {ReadonlyVec2} v the vec2 to scale the matrix by
 * @returns {mat3} out
 **/
function mat3_scale(out, a, v) {
    var x = v[0], y = v[1];
    out[0] = x * a[0];
    out[1] = x * a[1];
    out[2] = x * a[2];
    out[3] = y * a[3];
    out[4] = y * a[4];
    out[5] = y * a[5];
    out[6] = a[6];
    out[7] = a[7];
    out[8] = a[8];
    return out;
}
/**
 * Creates a matrix from a vector translation
 * This is equivalent to (but much faster than):
 *
 *     mat3.identity(dest);
 *     mat3.translate(dest, dest, vec);
 *
 * @param {mat3} out mat3 receiving operation result
 * @param {ReadonlyVec2} v Translation vector
 * @returns {mat3} out
 */
function fromTranslation(out, v) {
    out[0] = 1;
    out[1] = 0;
    out[2] = 0;
    out[3] = 0;
    out[4] = 1;
    out[5] = 0;
    out[6] = v[0];
    out[7] = v[1];
    out[8] = 1;
    return out;
}
/**
 * Creates a matrix from a given angle
 * This is equivalent to (but much faster than):
 *
 *     mat3.identity(dest);
 *     mat3.rotate(dest, dest, rad);
 *
 * @param {mat3} out mat3 receiving operation result
 * @param {Number} rad the angle to rotate the matrix by
 * @returns {mat3} out
 */
function fromRotation(out, rad) {
    var s = Math.sin(rad), c = Math.cos(rad);
    out[0] = c;
    out[1] = s;
    out[2] = 0;
    out[3] = -s;
    out[4] = c;
    out[5] = 0;
    out[6] = 0;
    out[7] = 0;
    out[8] = 1;
    return out;
}
/**
 * Creates a matrix from a vector scaling
 * This is equivalent to (but much faster than):
 *
 *     mat3.identity(dest);
 *     mat3.scale(dest, dest, vec);
 *
 * @param {mat3} out mat3 receiving operation result
 * @param {ReadonlyVec2} v Scaling vector
 * @returns {mat3} out
 */
function fromScaling(out, v) {
    out[0] = v[0];
    out[1] = 0;
    out[2] = 0;
    out[3] = 0;
    out[4] = v[1];
    out[5] = 0;
    out[6] = 0;
    out[7] = 0;
    out[8] = 1;
    return out;
}
/**
 * Copies the values from a mat2d into a mat3
 *
 * @param {mat3} out the receiving matrix
 * @param {ReadonlyMat2d} a the matrix to copy
 * @returns {mat3} out
 **/
function fromMat2d(out, a) {
    out[0] = a[0];
    out[1] = a[1];
    out[2] = 0;
    out[3] = a[2];
    out[4] = a[3];
    out[5] = 0;
    out[6] = a[4];
    out[7] = a[5];
    out[8] = 1;
    return out;
}
/**
 * Calculates a 3x3 matrix from the given quaternion
 *
 * @param {mat3} out mat3 receiving operation result
 * @param {ReadonlyQuat} q Quaternion to create matrix from
 *
 * @returns {mat3} out
 */
function fromQuat(out, q) {
    var x = q[0], y = q[1], z = q[2], w = q[3];
    var x2 = x + x;
    var y2 = y + y;
    var z2 = z + z;
    var xx = x * x2;
    var yx = y * x2;
    var yy = y * y2;
    var zx = z * x2;
    var zy = z * y2;
    var zz = z * z2;
    var wx = w * x2;
    var wy = w * y2;
    var wz = w * z2;
    out[0] = 1 - yy - zz;
    out[3] = yx - wz;
    out[6] = zx + wy;
    out[1] = yx + wz;
    out[4] = 1 - xx - zz;
    out[7] = zy - wx;
    out[2] = zx - wy;
    out[5] = zy + wx;
    out[8] = 1 - xx - yy;
    return out;
}
/**
 * Calculates a 3x3 normal matrix (transpose inverse) from the 4x4 matrix
 *
 * @param {mat3} out mat3 receiving operation result
 * @param {ReadonlyMat4} a Mat4 to derive the normal matrix from
 *
 * @returns {mat3} out
 */
function normalFromMat4(out, a) {
    var a00 = a[0], a01 = a[1], a02 = a[2], a03 = a[3];
    var a10 = a[4], a11 = a[5], a12 = a[6], a13 = a[7];
    var a20 = a[8], a21 = a[9], a22 = a[10], a23 = a[11];
    var a30 = a[12], a31 = a[13], a32 = a[14], a33 = a[15];
    var b00 = a00 * a11 - a01 * a10;
    var b01 = a00 * a12 - a02 * a10;
    var b02 = a00 * a13 - a03 * a10;
    var b03 = a01 * a12 - a02 * a11;
    var b04 = a01 * a13 - a03 * a11;
    var b05 = a02 * a13 - a03 * a12;
    var b06 = a20 * a31 - a21 * a30;
    var b07 = a20 * a32 - a22 * a30;
    var b08 = a20 * a33 - a23 * a30;
    var b09 = a21 * a32 - a22 * a31;
    var b10 = a21 * a33 - a23 * a31;
    var b11 = a22 * a33 - a23 * a32; // Calculate the determinant
    var det = b00 * b11 - b01 * b10 + b02 * b09 + b03 * b08 - b04 * b07 + b05 * b06;
    if (!det) {
        return null;
    }
    det = 1.0 / det;
    out[0] = (a11 * b11 - a12 * b10 + a13 * b09) * det;
    out[1] = (a12 * b08 - a10 * b11 - a13 * b07) * det;
    out[2] = (a10 * b10 - a11 * b08 + a13 * b06) * det;
    out[3] = (a02 * b10 - a01 * b11 - a03 * b09) * det;
    out[4] = (a00 * b11 - a02 * b08 + a03 * b07) * det;
    out[5] = (a01 * b08 - a00 * b10 - a03 * b06) * det;
    out[6] = (a31 * b05 - a32 * b04 + a33 * b03) * det;
    out[7] = (a32 * b02 - a30 * b05 - a33 * b01) * det;
    out[8] = (a30 * b04 - a31 * b02 + a33 * b00) * det;
    return out;
}
/**
 * Generates a 2D projection matrix with the given bounds
 *
 * @param {mat3} out mat3 frustum matrix will be written into
 * @param {number} width Width of your gl context
 * @param {number} height Height of gl context
 * @returns {mat3} out
 */
function projection(out, width, height) {
    out[0] = 2 / width;
    out[1] = 0;
    out[2] = 0;
    out[3] = 0;
    out[4] = -2 / height;
    out[5] = 0;
    out[6] = -1;
    out[7] = 1;
    out[8] = 1;
    return out;
}
/**
 * Returns a string representation of a mat3
 *
 * @param {ReadonlyMat3} a matrix to represent as a string
 * @returns {String} string representation of the matrix
 */
function mat3_str(a) {
    return "mat3(" + a[0] + ", " + a[1] + ", " + a[2] + ", " + a[3] + ", " + a[4] + ", " + a[5] + ", " + a[6] + ", " + a[7] + ", " + a[8] + ")";
}
/**
 * Returns Frobenius norm of a mat3
 *
 * @param {ReadonlyMat3} a the matrix to calculate Frobenius norm of
 * @returns {Number} Frobenius norm
 */
function frob(a) {
    return Math.hypot(a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8]);
}
/**
 * Adds two mat3's
 *
 * @param {mat3} out the receiving matrix
 * @param {ReadonlyMat3} a the first operand
 * @param {ReadonlyMat3} b the second operand
 * @returns {mat3} out
 */
function mat3_add(out, a, b) {
    out[0] = a[0] + b[0];
    out[1] = a[1] + b[1];
    out[2] = a[2] + b[2];
    out[3] = a[3] + b[3];
    out[4] = a[4] + b[4];
    out[5] = a[5] + b[5];
    out[6] = a[6] + b[6];
    out[7] = a[7] + b[7];
    out[8] = a[8] + b[8];
    return out;
}
/**
 * Subtracts matrix b from matrix a
 *
 * @param {mat3} out the receiving matrix
 * @param {ReadonlyMat3} a the first operand
 * @param {ReadonlyMat3} b the second operand
 * @returns {mat3} out
 */
function mat3_subtract(out, a, b) {
    out[0] = a[0] - b[0];
    out[1] = a[1] - b[1];
    out[2] = a[2] - b[2];
    out[3] = a[3] - b[3];
    out[4] = a[4] - b[4];
    out[5] = a[5] - b[5];
    out[6] = a[6] - b[6];
    out[7] = a[7] - b[7];
    out[8] = a[8] - b[8];
    return out;
}
/**
 * Multiply each element of the matrix by a scalar.
 *
 * @param {mat3} out the receiving matrix
 * @param {ReadonlyMat3} a the matrix to scale
 * @param {Number} b amount to scale the matrix's elements by
 * @returns {mat3} out
 */
function multiplyScalar(out, a, b) {
    out[0] = a[0] * b;
    out[1] = a[1] * b;
    out[2] = a[2] * b;
    out[3] = a[3] * b;
    out[4] = a[4] * b;
    out[5] = a[5] * b;
    out[6] = a[6] * b;
    out[7] = a[7] * b;
    out[8] = a[8] * b;
    return out;
}
/**
 * Adds two mat3's after multiplying each element of the second operand by a scalar value.
 *
 * @param {mat3} out the receiving vector
 * @param {ReadonlyMat3} a the first operand
 * @param {ReadonlyMat3} b the second operand
 * @param {Number} scale the amount to scale b's elements by before adding
 * @returns {mat3} out
 */
function multiplyScalarAndAdd(out, a, b, scale) {
    out[0] = a[0] + b[0] * scale;
    out[1] = a[1] + b[1] * scale;
    out[2] = a[2] + b[2] * scale;
    out[3] = a[3] + b[3] * scale;
    out[4] = a[4] + b[4] * scale;
    out[5] = a[5] + b[5] * scale;
    out[6] = a[6] + b[6] * scale;
    out[7] = a[7] + b[7] * scale;
    out[8] = a[8] + b[8] * scale;
    return out;
}
/**
 * Returns whether or not the matrices have exactly the same elements in the same position (when compared with ===)
 *
 * @param {ReadonlyMat3} a The first matrix.
 * @param {ReadonlyMat3} b The second matrix.
 * @returns {Boolean} True if the matrices are equal, false otherwise.
 */
function mat3_exactEquals(a, b) {
    return a[0] === b[0] && a[1] === b[1] && a[2] === b[2] && a[3] === b[3] && a[4] === b[4] && a[5] === b[5] && a[6] === b[6] && a[7] === b[7] && a[8] === b[8];
}
/**
 * Returns whether or not the matrices have approximately the same elements in the same position.
 *
 * @param {ReadonlyMat3} a The first matrix.
 * @param {ReadonlyMat3} b The second matrix.
 * @returns {Boolean} True if the matrices are equal, false otherwise.
 */
function mat3_equals(a, b) {
    var a0 = a[0], a1 = a[1], a2 = a[2], a3 = a[3], a4 = a[4], a5 = a[5], a6 = a[6], a7 = a[7], a8 = a[8];
    var b0 = b[0], b1 = b[1], b2 = b[2], b3 = b[3], b4 = b[4], b5 = b[5], b6 = b[6], b7 = b[7], b8 = b[8];
    return Math.abs(a0 - b0) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a0), Math.abs(b0)) && Math.abs(a1 - b1) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a1), Math.abs(b1)) && Math.abs(a2 - b2) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a2), Math.abs(b2)) && Math.abs(a3 - b3) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a3), Math.abs(b3)) && Math.abs(a4 - b4) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a4), Math.abs(b4)) && Math.abs(a5 - b5) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a5), Math.abs(b5)) && Math.abs(a6 - b6) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a6), Math.abs(b6)) && Math.abs(a7 - b7) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a7), Math.abs(b7)) && Math.abs(a8 - b8) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a8), Math.abs(b8));
}
/**
 * Alias for {@link mat3.multiply}
 * @function
 */
var mat3_mul = ( /* unused pure expression or super */null && (mat3_multiply));
/**
 * Alias for {@link mat3.subtract}
 * @function
 */
var mat3_sub = ( /* unused pure expression or super */null && (mat3_subtract));
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/classes/matrix3.js
var INDICES;
(function (INDICES) {
    INDICES[INDICES["COL0ROW0"] = 0] = "COL0ROW0";
    INDICES[INDICES["COL0ROW1"] = 1] = "COL0ROW1";
    INDICES[INDICES["COL0ROW2"] = 2] = "COL0ROW2";
    INDICES[INDICES["COL1ROW0"] = 3] = "COL1ROW0";
    INDICES[INDICES["COL1ROW1"] = 4] = "COL1ROW1";
    INDICES[INDICES["COL1ROW2"] = 5] = "COL1ROW2";
    INDICES[INDICES["COL2ROW0"] = 6] = "COL2ROW0";
    INDICES[INDICES["COL2ROW1"] = 7] = "COL2ROW1";
    INDICES[INDICES["COL2ROW2"] = 8] = "COL2ROW2";
})(INDICES || (INDICES = {}));
const IDENTITY_MATRIX = Object.freeze([1, 0, 0, 0, 1, 0, 0, 0, 1]);
class Matrix3 extends Matrix {
    static get IDENTITY() {
        return getIdentityMatrix();
    }
    static get ZERO() {
        return getZeroMatrix();
    }
    get ELEMENTS() {
        return 9;
    }
    get RANK() {
        return 3;
    }
    get INDICES() {
        return INDICES;
    }
    constructor(array, ...args) {
        super(-0, -0, -0, -0, -0, -0, -0, -0, -0);
        if (arguments.length === 1 && Array.isArray(array)) {
            this.copy(array);
        }
        else if (args.length > 0) {
            this.copy([array, ...args]);
        }
        else {
            this.identity();
        }
    }
    copy(array) {
        this[0] = array[0];
        this[1] = array[1];
        this[2] = array[2];
        this[3] = array[3];
        this[4] = array[4];
        this[5] = array[5];
        this[6] = array[6];
        this[7] = array[7];
        this[8] = array[8];
        return this.check();
    }
    identity() {
        return this.copy(IDENTITY_MATRIX);
    }
    fromObject(object) {
        return this.check();
    }
    fromQuaternion(q) {
        fromQuat(this, q);
        return this.check();
    }
    set(m00, m10, m20, m01, m11, m21, m02, m12, m22) {
        this[0] = m00;
        this[1] = m10;
        this[2] = m20;
        this[3] = m01;
        this[4] = m11;
        this[5] = m21;
        this[6] = m02;
        this[7] = m12;
        this[8] = m22;
        return this.check();
    }
    setRowMajor(m00, m01, m02, m10, m11, m12, m20, m21, m22) {
        this[0] = m00;
        this[1] = m10;
        this[2] = m20;
        this[3] = m01;
        this[4] = m11;
        this[5] = m21;
        this[6] = m02;
        this[7] = m12;
        this[8] = m22;
        return this.check();
    }
    determinant() {
        return determinant(this);
    }
    transpose() {
        transpose(this, this);
        return this.check();
    }
    invert() {
        invert(this, this);
        return this.check();
    }
    multiplyLeft(a) {
        mat3_multiply(this, a, this);
        return this.check();
    }
    multiplyRight(a) {
        mat3_multiply(this, this, a);
        return this.check();
    }
    rotate(radians) {
        mat3_rotate(this, this, radians);
        return this.check();
    }
    scale(factor) {
        if (Array.isArray(factor)) {
            mat3_scale(this, this, factor);
        }
        else {
            mat3_scale(this, this, [factor, factor]);
        }
        return this.check();
    }
    translate(vec) {
        translate(this, this, vec);
        return this.check();
    }
    transform(vector, result) {
        let out;
        switch (vector.length) {
            case 2:
                out = transformMat3(result || [-0, -0], vector, this);
                break;
            case 3:
                out = vec3_transformMat3(result || [-0, -0, -0], vector, this);
                break;
            case 4:
                out = vec4_transformMat3(result || [-0, -0, -0, -0], vector, this);
                break;
            default:
                throw new Error('Illegal vector');
        }
        checkVector(out, vector.length);
        return out;
    }
    transformVector(vector, result) {
        return this.transform(vector, result);
    }
    transformVector2(vector, result) {
        return this.transform(vector, result);
    }
    transformVector3(vector, result) {
        return this.transform(vector, result);
    }
}
let ZERO_MATRIX3;
let IDENTITY_MATRIX3;
function getZeroMatrix() {
    if (!ZERO_MATRIX3) {
        ZERO_MATRIX3 = new Matrix3([0, 0, 0, 0, 0, 0, 0, 0, 0]);
        Object.freeze(ZERO_MATRIX3);
    }
    return ZERO_MATRIX3;
}
function getIdentityMatrix() {
    if (!IDENTITY_MATRIX3) {
        IDENTITY_MATRIX3 = new Matrix3();
        Object.freeze(IDENTITY_MATRIX3);
    }
    return IDENTITY_MATRIX3;
}
//# sourceMappingURL=matrix3.js.map
; // CONCATENATED MODULE: ./node_modules/gl-matrix/esm/mat4.js
/**
 * 4x4 Matrix<br>Format: column-major, when typed out it looks like row-major<br>The matrices are being post multiplied.
 * @module mat4
 */
/**
 * Creates a new identity mat4
 *
 * @returns {mat4} a new 4x4 matrix
 */
function mat4_create() {
    var out = new glMatrix.ARRAY_TYPE(16);
    if (glMatrix.ARRAY_TYPE != Float32Array) {
        out[1] = 0;
        out[2] = 0;
        out[3] = 0;
        out[4] = 0;
        out[6] = 0;
        out[7] = 0;
        out[8] = 0;
        out[9] = 0;
        out[11] = 0;
        out[12] = 0;
        out[13] = 0;
        out[14] = 0;
    }
    out[0] = 1;
    out[5] = 1;
    out[10] = 1;
    out[15] = 1;
    return out;
}
/**
 * Creates a new mat4 initialized with values from an existing matrix
 *
 * @param {ReadonlyMat4} a matrix to clone
 * @returns {mat4} a new 4x4 matrix
 */
function mat4_clone(a) {
    var out = new glMatrix.ARRAY_TYPE(16);
    out[0] = a[0];
    out[1] = a[1];
    out[2] = a[2];
    out[3] = a[3];
    out[4] = a[4];
    out[5] = a[5];
    out[6] = a[6];
    out[7] = a[7];
    out[8] = a[8];
    out[9] = a[9];
    out[10] = a[10];
    out[11] = a[11];
    out[12] = a[12];
    out[13] = a[13];
    out[14] = a[14];
    out[15] = a[15];
    return out;
}
/**
 * Copy the values from one mat4 to another
 *
 * @param {mat4} out the receiving matrix
 * @param {ReadonlyMat4} a the source matrix
 * @returns {mat4} out
 */
function mat4_copy(out, a) {
    out[0] = a[0];
    out[1] = a[1];
    out[2] = a[2];
    out[3] = a[3];
    out[4] = a[4];
    out[5] = a[5];
    out[6] = a[6];
    out[7] = a[7];
    out[8] = a[8];
    out[9] = a[9];
    out[10] = a[10];
    out[11] = a[11];
    out[12] = a[12];
    out[13] = a[13];
    out[14] = a[14];
    out[15] = a[15];
    return out;
}
/**
 * Create a new mat4 with the given values
 *
 * @param {Number} m00 Component in column 0, row 0 position (index 0)
 * @param {Number} m01 Component in column 0, row 1 position (index 1)
 * @param {Number} m02 Component in column 0, row 2 position (index 2)
 * @param {Number} m03 Component in column 0, row 3 position (index 3)
 * @param {Number} m10 Component in column 1, row 0 position (index 4)
 * @param {Number} m11 Component in column 1, row 1 position (index 5)
 * @param {Number} m12 Component in column 1, row 2 position (index 6)
 * @param {Number} m13 Component in column 1, row 3 position (index 7)
 * @param {Number} m20 Component in column 2, row 0 position (index 8)
 * @param {Number} m21 Component in column 2, row 1 position (index 9)
 * @param {Number} m22 Component in column 2, row 2 position (index 10)
 * @param {Number} m23 Component in column 2, row 3 position (index 11)
 * @param {Number} m30 Component in column 3, row 0 position (index 12)
 * @param {Number} m31 Component in column 3, row 1 position (index 13)
 * @param {Number} m32 Component in column 3, row 2 position (index 14)
 * @param {Number} m33 Component in column 3, row 3 position (index 15)
 * @returns {mat4} A new mat4
 */
function mat4_fromValues(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33) {
    var out = new glMatrix.ARRAY_TYPE(16);
    out[0] = m00;
    out[1] = m01;
    out[2] = m02;
    out[3] = m03;
    out[4] = m10;
    out[5] = m11;
    out[6] = m12;
    out[7] = m13;
    out[8] = m20;
    out[9] = m21;
    out[10] = m22;
    out[11] = m23;
    out[12] = m30;
    out[13] = m31;
    out[14] = m32;
    out[15] = m33;
    return out;
}
/**
 * Set the components of a mat4 to the given values
 *
 * @param {mat4} out the receiving matrix
 * @param {Number} m00 Component in column 0, row 0 position (index 0)
 * @param {Number} m01 Component in column 0, row 1 position (index 1)
 * @param {Number} m02 Component in column 0, row 2 position (index 2)
 * @param {Number} m03 Component in column 0, row 3 position (index 3)
 * @param {Number} m10 Component in column 1, row 0 position (index 4)
 * @param {Number} m11 Component in column 1, row 1 position (index 5)
 * @param {Number} m12 Component in column 1, row 2 position (index 6)
 * @param {Number} m13 Component in column 1, row 3 position (index 7)
 * @param {Number} m20 Component in column 2, row 0 position (index 8)
 * @param {Number} m21 Component in column 2, row 1 position (index 9)
 * @param {Number} m22 Component in column 2, row 2 position (index 10)
 * @param {Number} m23 Component in column 2, row 3 position (index 11)
 * @param {Number} m30 Component in column 3, row 0 position (index 12)
 * @param {Number} m31 Component in column 3, row 1 position (index 13)
 * @param {Number} m32 Component in column 3, row 2 position (index 14)
 * @param {Number} m33 Component in column 3, row 3 position (index 15)
 * @returns {mat4} out
 */
function mat4_set(out, m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33) {
    out[0] = m00;
    out[1] = m01;
    out[2] = m02;
    out[3] = m03;
    out[4] = m10;
    out[5] = m11;
    out[6] = m12;
    out[7] = m13;
    out[8] = m20;
    out[9] = m21;
    out[10] = m22;
    out[11] = m23;
    out[12] = m30;
    out[13] = m31;
    out[14] = m32;
    out[15] = m33;
    return out;
}
/**
 * Set a mat4 to the identity matrix
 *
 * @param {mat4} out the receiving matrix
 * @returns {mat4} out
 */
function mat4_identity(out) {
    out[0] = 1;
    out[1] = 0;
    out[2] = 0;
    out[3] = 0;
    out[4] = 0;
    out[5] = 1;
    out[6] = 0;
    out[7] = 0;
    out[8] = 0;
    out[9] = 0;
    out[10] = 1;
    out[11] = 0;
    out[12] = 0;
    out[13] = 0;
    out[14] = 0;
    out[15] = 1;
    return out;
}
/**
 * Transpose the values of a mat4
 *
 * @param {mat4} out the receiving matrix
 * @param {ReadonlyMat4} a the source matrix
 * @returns {mat4} out
 */
function mat4_transpose(out, a) {
    // If we are transposing ourselves we can skip a few steps but have to cache some values
    if (out === a) {
        var a01 = a[1], a02 = a[2], a03 = a[3];
        var a12 = a[6], a13 = a[7];
        var a23 = a[11];
        out[1] = a[4];
        out[2] = a[8];
        out[3] = a[12];
        out[4] = a01;
        out[6] = a[9];
        out[7] = a[13];
        out[8] = a02;
        out[9] = a12;
        out[11] = a[14];
        out[12] = a03;
        out[13] = a13;
        out[14] = a23;
    }
    else {
        out[0] = a[0];
        out[1] = a[4];
        out[2] = a[8];
        out[3] = a[12];
        out[4] = a[1];
        out[5] = a[5];
        out[6] = a[9];
        out[7] = a[13];
        out[8] = a[2];
        out[9] = a[6];
        out[10] = a[10];
        out[11] = a[14];
        out[12] = a[3];
        out[13] = a[7];
        out[14] = a[11];
        out[15] = a[15];
    }
    return out;
}
/**
 * Inverts a mat4
 *
 * @param {mat4} out the receiving matrix
 * @param {ReadonlyMat4} a the source matrix
 * @returns {mat4} out
 */
function mat4_invert(out, a) {
    var a00 = a[0], a01 = a[1], a02 = a[2], a03 = a[3];
    var a10 = a[4], a11 = a[5], a12 = a[6], a13 = a[7];
    var a20 = a[8], a21 = a[9], a22 = a[10], a23 = a[11];
    var a30 = a[12], a31 = a[13], a32 = a[14], a33 = a[15];
    var b00 = a00 * a11 - a01 * a10;
    var b01 = a00 * a12 - a02 * a10;
    var b02 = a00 * a13 - a03 * a10;
    var b03 = a01 * a12 - a02 * a11;
    var b04 = a01 * a13 - a03 * a11;
    var b05 = a02 * a13 - a03 * a12;
    var b06 = a20 * a31 - a21 * a30;
    var b07 = a20 * a32 - a22 * a30;
    var b08 = a20 * a33 - a23 * a30;
    var b09 = a21 * a32 - a22 * a31;
    var b10 = a21 * a33 - a23 * a31;
    var b11 = a22 * a33 - a23 * a32; // Calculate the determinant
    var det = b00 * b11 - b01 * b10 + b02 * b09 + b03 * b08 - b04 * b07 + b05 * b06;
    if (!det) {
        return null;
    }
    det = 1.0 / det;
    out[0] = (a11 * b11 - a12 * b10 + a13 * b09) * det;
    out[1] = (a02 * b10 - a01 * b11 - a03 * b09) * det;
    out[2] = (a31 * b05 - a32 * b04 + a33 * b03) * det;
    out[3] = (a22 * b04 - a21 * b05 - a23 * b03) * det;
    out[4] = (a12 * b08 - a10 * b11 - a13 * b07) * det;
    out[5] = (a00 * b11 - a02 * b08 + a03 * b07) * det;
    out[6] = (a32 * b02 - a30 * b05 - a33 * b01) * det;
    out[7] = (a20 * b05 - a22 * b02 + a23 * b01) * det;
    out[8] = (a10 * b10 - a11 * b08 + a13 * b06) * det;
    out[9] = (a01 * b08 - a00 * b10 - a03 * b06) * det;
    out[10] = (a30 * b04 - a31 * b02 + a33 * b00) * det;
    out[11] = (a21 * b02 - a20 * b04 - a23 * b00) * det;
    out[12] = (a11 * b07 - a10 * b09 - a12 * b06) * det;
    out[13] = (a00 * b09 - a01 * b07 + a02 * b06) * det;
    out[14] = (a31 * b01 - a30 * b03 - a32 * b00) * det;
    out[15] = (a20 * b03 - a21 * b01 + a22 * b00) * det;
    return out;
}
/**
 * Calculates the adjugate of a mat4
 *
 * @param {mat4} out the receiving matrix
 * @param {ReadonlyMat4} a the source matrix
 * @returns {mat4} out
 */
function mat4_adjoint(out, a) {
    var a00 = a[0], a01 = a[1], a02 = a[2], a03 = a[3];
    var a10 = a[4], a11 = a[5], a12 = a[6], a13 = a[7];
    var a20 = a[8], a21 = a[9], a22 = a[10], a23 = a[11];
    var a30 = a[12], a31 = a[13], a32 = a[14], a33 = a[15];
    out[0] = a11 * (a22 * a33 - a23 * a32) - a21 * (a12 * a33 - a13 * a32) + a31 * (a12 * a23 - a13 * a22);
    out[1] = -(a01 * (a22 * a33 - a23 * a32) - a21 * (a02 * a33 - a03 * a32) + a31 * (a02 * a23 - a03 * a22));
    out[2] = a01 * (a12 * a33 - a13 * a32) - a11 * (a02 * a33 - a03 * a32) + a31 * (a02 * a13 - a03 * a12);
    out[3] = -(a01 * (a12 * a23 - a13 * a22) - a11 * (a02 * a23 - a03 * a22) + a21 * (a02 * a13 - a03 * a12));
    out[4] = -(a10 * (a22 * a33 - a23 * a32) - a20 * (a12 * a33 - a13 * a32) + a30 * (a12 * a23 - a13 * a22));
    out[5] = a00 * (a22 * a33 - a23 * a32) - a20 * (a02 * a33 - a03 * a32) + a30 * (a02 * a23 - a03 * a22);
    out[6] = -(a00 * (a12 * a33 - a13 * a32) - a10 * (a02 * a33 - a03 * a32) + a30 * (a02 * a13 - a03 * a12));
    out[7] = a00 * (a12 * a23 - a13 * a22) - a10 * (a02 * a23 - a03 * a22) + a20 * (a02 * a13 - a03 * a12);
    out[8] = a10 * (a21 * a33 - a23 * a31) - a20 * (a11 * a33 - a13 * a31) + a30 * (a11 * a23 - a13 * a21);
    out[9] = -(a00 * (a21 * a33 - a23 * a31) - a20 * (a01 * a33 - a03 * a31) + a30 * (a01 * a23 - a03 * a21));
    out[10] = a00 * (a11 * a33 - a13 * a31) - a10 * (a01 * a33 - a03 * a31) + a30 * (a01 * a13 - a03 * a11);
    out[11] = -(a00 * (a11 * a23 - a13 * a21) - a10 * (a01 * a23 - a03 * a21) + a20 * (a01 * a13 - a03 * a11));
    out[12] = -(a10 * (a21 * a32 - a22 * a31) - a20 * (a11 * a32 - a12 * a31) + a30 * (a11 * a22 - a12 * a21));
    out[13] = a00 * (a21 * a32 - a22 * a31) - a20 * (a01 * a32 - a02 * a31) + a30 * (a01 * a22 - a02 * a21);
    out[14] = -(a00 * (a11 * a32 - a12 * a31) - a10 * (a01 * a32 - a02 * a31) + a30 * (a01 * a12 - a02 * a11));
    out[15] = a00 * (a11 * a22 - a12 * a21) - a10 * (a01 * a22 - a02 * a21) + a20 * (a01 * a12 - a02 * a11);
    return out;
}
/**
 * Calculates the determinant of a mat4
 *
 * @param {ReadonlyMat4} a the source matrix
 * @returns {Number} determinant of a
 */
function mat4_determinant(a) {
    var a00 = a[0], a01 = a[1], a02 = a[2], a03 = a[3];
    var a10 = a[4], a11 = a[5], a12 = a[6], a13 = a[7];
    var a20 = a[8], a21 = a[9], a22 = a[10], a23 = a[11];
    var a30 = a[12], a31 = a[13], a32 = a[14], a33 = a[15];
    var b00 = a00 * a11 - a01 * a10;
    var b01 = a00 * a12 - a02 * a10;
    var b02 = a00 * a13 - a03 * a10;
    var b03 = a01 * a12 - a02 * a11;
    var b04 = a01 * a13 - a03 * a11;
    var b05 = a02 * a13 - a03 * a12;
    var b06 = a20 * a31 - a21 * a30;
    var b07 = a20 * a32 - a22 * a30;
    var b08 = a20 * a33 - a23 * a30;
    var b09 = a21 * a32 - a22 * a31;
    var b10 = a21 * a33 - a23 * a31;
    var b11 = a22 * a33 - a23 * a32; // Calculate the determinant
    return b00 * b11 - b01 * b10 + b02 * b09 + b03 * b08 - b04 * b07 + b05 * b06;
}
/**
 * Multiplies two mat4s
 *
 * @param {mat4} out the receiving matrix
 * @param {ReadonlyMat4} a the first operand
 * @param {ReadonlyMat4} b the second operand
 * @returns {mat4} out
 */
function mat4_multiply(out, a, b) {
    var a00 = a[0], a01 = a[1], a02 = a[2], a03 = a[3];
    var a10 = a[4], a11 = a[5], a12 = a[6], a13 = a[7];
    var a20 = a[8], a21 = a[9], a22 = a[10], a23 = a[11];
    var a30 = a[12], a31 = a[13], a32 = a[14], a33 = a[15]; // Cache only the current line of the second matrix
    var b0 = b[0], b1 = b[1], b2 = b[2], b3 = b[3];
    out[0] = b0 * a00 + b1 * a10 + b2 * a20 + b3 * a30;
    out[1] = b0 * a01 + b1 * a11 + b2 * a21 + b3 * a31;
    out[2] = b0 * a02 + b1 * a12 + b2 * a22 + b3 * a32;
    out[3] = b0 * a03 + b1 * a13 + b2 * a23 + b3 * a33;
    b0 = b[4];
    b1 = b[5];
    b2 = b[6];
    b3 = b[7];
    out[4] = b0 * a00 + b1 * a10 + b2 * a20 + b3 * a30;
    out[5] = b0 * a01 + b1 * a11 + b2 * a21 + b3 * a31;
    out[6] = b0 * a02 + b1 * a12 + b2 * a22 + b3 * a32;
    out[7] = b0 * a03 + b1 * a13 + b2 * a23 + b3 * a33;
    b0 = b[8];
    b1 = b[9];
    b2 = b[10];
    b3 = b[11];
    out[8] = b0 * a00 + b1 * a10 + b2 * a20 + b3 * a30;
    out[9] = b0 * a01 + b1 * a11 + b2 * a21 + b3 * a31;
    out[10] = b0 * a02 + b1 * a12 + b2 * a22 + b3 * a32;
    out[11] = b0 * a03 + b1 * a13 + b2 * a23 + b3 * a33;
    b0 = b[12];
    b1 = b[13];
    b2 = b[14];
    b3 = b[15];
    out[12] = b0 * a00 + b1 * a10 + b2 * a20 + b3 * a30;
    out[13] = b0 * a01 + b1 * a11 + b2 * a21 + b3 * a31;
    out[14] = b0 * a02 + b1 * a12 + b2 * a22 + b3 * a32;
    out[15] = b0 * a03 + b1 * a13 + b2 * a23 + b3 * a33;
    return out;
}
/**
 * Translate a mat4 by the given vector
 *
 * @param {mat4} out the receiving matrix
 * @param {ReadonlyMat4} a the matrix to translate
 * @param {ReadonlyVec3} v vector to translate by
 * @returns {mat4} out
 */
function mat4_translate(out, a, v) {
    var x = v[0], y = v[1], z = v[2];
    var a00, a01, a02, a03;
    var a10, a11, a12, a13;
    var a20, a21, a22, a23;
    if (a === out) {
        out[12] = a[0] * x + a[4] * y + a[8] * z + a[12];
        out[13] = a[1] * x + a[5] * y + a[9] * z + a[13];
        out[14] = a[2] * x + a[6] * y + a[10] * z + a[14];
        out[15] = a[3] * x + a[7] * y + a[11] * z + a[15];
    }
    else {
        a00 = a[0];
        a01 = a[1];
        a02 = a[2];
        a03 = a[3];
        a10 = a[4];
        a11 = a[5];
        a12 = a[6];
        a13 = a[7];
        a20 = a[8];
        a21 = a[9];
        a22 = a[10];
        a23 = a[11];
        out[0] = a00;
        out[1] = a01;
        out[2] = a02;
        out[3] = a03;
        out[4] = a10;
        out[5] = a11;
        out[6] = a12;
        out[7] = a13;
        out[8] = a20;
        out[9] = a21;
        out[10] = a22;
        out[11] = a23;
        out[12] = a00 * x + a10 * y + a20 * z + a[12];
        out[13] = a01 * x + a11 * y + a21 * z + a[13];
        out[14] = a02 * x + a12 * y + a22 * z + a[14];
        out[15] = a03 * x + a13 * y + a23 * z + a[15];
    }
    return out;
}
/**
 * Scales the mat4 by the dimensions in the given vec3 not using vectorization
 *
 * @param {mat4} out the receiving matrix
 * @param {ReadonlyMat4} a the matrix to scale
 * @param {ReadonlyVec3} v the vec3 to scale the matrix by
 * @returns {mat4} out
 **/
function mat4_scale(out, a, v) {
    var x = v[0], y = v[1], z = v[2];
    out[0] = a[0] * x;
    out[1] = a[1] * x;
    out[2] = a[2] * x;
    out[3] = a[3] * x;
    out[4] = a[4] * y;
    out[5] = a[5] * y;
    out[6] = a[6] * y;
    out[7] = a[7] * y;
    out[8] = a[8] * z;
    out[9] = a[9] * z;
    out[10] = a[10] * z;
    out[11] = a[11] * z;
    out[12] = a[12];
    out[13] = a[13];
    out[14] = a[14];
    out[15] = a[15];
    return out;
}
/**
 * Rotates a mat4 by the given angle around the given axis
 *
 * @param {mat4} out the receiving matrix
 * @param {ReadonlyMat4} a the matrix to rotate
 * @param {Number} rad the angle to rotate the matrix by
 * @param {ReadonlyVec3} axis the axis to rotate around
 * @returns {mat4} out
 */
function mat4_rotate(out, a, rad, axis) {
    var x = axis[0], y = axis[1], z = axis[2];
    var len = Math.hypot(x, y, z);
    var s, c, t;
    var a00, a01, a02, a03;
    var a10, a11, a12, a13;
    var a20, a21, a22, a23;
    var b00, b01, b02;
    var b10, b11, b12;
    var b20, b21, b22;
    if (len < EPSILON) {
        return null;
    }
    len = 1 / len;
    x *= len;
    y *= len;
    z *= len;
    s = Math.sin(rad);
    c = Math.cos(rad);
    t = 1 - c;
    a00 = a[0];
    a01 = a[1];
    a02 = a[2];
    a03 = a[3];
    a10 = a[4];
    a11 = a[5];
    a12 = a[6];
    a13 = a[7];
    a20 = a[8];
    a21 = a[9];
    a22 = a[10];
    a23 = a[11]; // Construct the elements of the rotation matrix
    b00 = x * x * t + c;
    b01 = y * x * t + z * s;
    b02 = z * x * t - y * s;
    b10 = x * y * t - z * s;
    b11 = y * y * t + c;
    b12 = z * y * t + x * s;
    b20 = x * z * t + y * s;
    b21 = y * z * t - x * s;
    b22 = z * z * t + c; // Perform rotation-specific matrix multiplication
    out[0] = a00 * b00 + a10 * b01 + a20 * b02;
    out[1] = a01 * b00 + a11 * b01 + a21 * b02;
    out[2] = a02 * b00 + a12 * b01 + a22 * b02;
    out[3] = a03 * b00 + a13 * b01 + a23 * b02;
    out[4] = a00 * b10 + a10 * b11 + a20 * b12;
    out[5] = a01 * b10 + a11 * b11 + a21 * b12;
    out[6] = a02 * b10 + a12 * b11 + a22 * b12;
    out[7] = a03 * b10 + a13 * b11 + a23 * b12;
    out[8] = a00 * b20 + a10 * b21 + a20 * b22;
    out[9] = a01 * b20 + a11 * b21 + a21 * b22;
    out[10] = a02 * b20 + a12 * b21 + a22 * b22;
    out[11] = a03 * b20 + a13 * b21 + a23 * b22;
    if (a !== out) {
        // If the source and destination differ, copy the unchanged last row
        out[12] = a[12];
        out[13] = a[13];
        out[14] = a[14];
        out[15] = a[15];
    }
    return out;
}
/**
 * Rotates a matrix by the given angle around the X axis
 *
 * @param {mat4} out the receiving matrix
 * @param {ReadonlyMat4} a the matrix to rotate
 * @param {Number} rad the angle to rotate the matrix by
 * @returns {mat4} out
 */
function mat4_rotateX(out, a, rad) {
    var s = Math.sin(rad);
    var c = Math.cos(rad);
    var a10 = a[4];
    var a11 = a[5];
    var a12 = a[6];
    var a13 = a[7];
    var a20 = a[8];
    var a21 = a[9];
    var a22 = a[10];
    var a23 = a[11];
    if (a !== out) {
        // If the source and destination differ, copy the unchanged rows
        out[0] = a[0];
        out[1] = a[1];
        out[2] = a[2];
        out[3] = a[3];
        out[12] = a[12];
        out[13] = a[13];
        out[14] = a[14];
        out[15] = a[15];
    } // Perform axis-specific matrix multiplication
    out[4] = a10 * c + a20 * s;
    out[5] = a11 * c + a21 * s;
    out[6] = a12 * c + a22 * s;
    out[7] = a13 * c + a23 * s;
    out[8] = a20 * c - a10 * s;
    out[9] = a21 * c - a11 * s;
    out[10] = a22 * c - a12 * s;
    out[11] = a23 * c - a13 * s;
    return out;
}
/**
 * Rotates a matrix by the given angle around the Y axis
 *
 * @param {mat4} out the receiving matrix
 * @param {ReadonlyMat4} a the matrix to rotate
 * @param {Number} rad the angle to rotate the matrix by
 * @returns {mat4} out
 */
function mat4_rotateY(out, a, rad) {
    var s = Math.sin(rad);
    var c = Math.cos(rad);
    var a00 = a[0];
    var a01 = a[1];
    var a02 = a[2];
    var a03 = a[3];
    var a20 = a[8];
    var a21 = a[9];
    var a22 = a[10];
    var a23 = a[11];
    if (a !== out) {
        // If the source and destination differ, copy the unchanged rows
        out[4] = a[4];
        out[5] = a[5];
        out[6] = a[6];
        out[7] = a[7];
        out[12] = a[12];
        out[13] = a[13];
        out[14] = a[14];
        out[15] = a[15];
    } // Perform axis-specific matrix multiplication
    out[0] = a00 * c - a20 * s;
    out[1] = a01 * c - a21 * s;
    out[2] = a02 * c - a22 * s;
    out[3] = a03 * c - a23 * s;
    out[8] = a00 * s + a20 * c;
    out[9] = a01 * s + a21 * c;
    out[10] = a02 * s + a22 * c;
    out[11] = a03 * s + a23 * c;
    return out;
}
/**
 * Rotates a matrix by the given angle around the Z axis
 *
 * @param {mat4} out the receiving matrix
 * @param {ReadonlyMat4} a the matrix to rotate
 * @param {Number} rad the angle to rotate the matrix by
 * @returns {mat4} out
 */
function mat4_rotateZ(out, a, rad) {
    var s = Math.sin(rad);
    var c = Math.cos(rad);
    var a00 = a[0];
    var a01 = a[1];
    var a02 = a[2];
    var a03 = a[3];
    var a10 = a[4];
    var a11 = a[5];
    var a12 = a[6];
    var a13 = a[7];
    if (a !== out) {
        // If the source and destination differ, copy the unchanged last row
        out[8] = a[8];
        out[9] = a[9];
        out[10] = a[10];
        out[11] = a[11];
        out[12] = a[12];
        out[13] = a[13];
        out[14] = a[14];
        out[15] = a[15];
    } // Perform axis-specific matrix multiplication
    out[0] = a00 * c + a10 * s;
    out[1] = a01 * c + a11 * s;
    out[2] = a02 * c + a12 * s;
    out[3] = a03 * c + a13 * s;
    out[4] = a10 * c - a00 * s;
    out[5] = a11 * c - a01 * s;
    out[6] = a12 * c - a02 * s;
    out[7] = a13 * c - a03 * s;
    return out;
}
/**
 * Creates a matrix from a vector translation
 * This is equivalent to (but much faster than):
 *
 *     mat4.identity(dest);
 *     mat4.translate(dest, dest, vec);
 *
 * @param {mat4} out mat4 receiving operation result
 * @param {ReadonlyVec3} v Translation vector
 * @returns {mat4} out
 */
function mat4_fromTranslation(out, v) {
    out[0] = 1;
    out[1] = 0;
    out[2] = 0;
    out[3] = 0;
    out[4] = 0;
    out[5] = 1;
    out[6] = 0;
    out[7] = 0;
    out[8] = 0;
    out[9] = 0;
    out[10] = 1;
    out[11] = 0;
    out[12] = v[0];
    out[13] = v[1];
    out[14] = v[2];
    out[15] = 1;
    return out;
}
/**
 * Creates a matrix from a vector scaling
 * This is equivalent to (but much faster than):
 *
 *     mat4.identity(dest);
 *     mat4.scale(dest, dest, vec);
 *
 * @param {mat4} out mat4 receiving operation result
 * @param {ReadonlyVec3} v Scaling vector
 * @returns {mat4} out
 */
function mat4_fromScaling(out, v) {
    out[0] = v[0];
    out[1] = 0;
    out[2] = 0;
    out[3] = 0;
    out[4] = 0;
    out[5] = v[1];
    out[6] = 0;
    out[7] = 0;
    out[8] = 0;
    out[9] = 0;
    out[10] = v[2];
    out[11] = 0;
    out[12] = 0;
    out[13] = 0;
    out[14] = 0;
    out[15] = 1;
    return out;
}
/**
 * Creates a matrix from a given angle around a given axis
 * This is equivalent to (but much faster than):
 *
 *     mat4.identity(dest);
 *     mat4.rotate(dest, dest, rad, axis);
 *
 * @param {mat4} out mat4 receiving operation result
 * @param {Number} rad the angle to rotate the matrix by
 * @param {ReadonlyVec3} axis the axis to rotate around
 * @returns {mat4} out
 */
function mat4_fromRotation(out, rad, axis) {
    var x = axis[0], y = axis[1], z = axis[2];
    var len = Math.hypot(x, y, z);
    var s, c, t;
    if (len < glMatrix.EPSILON) {
        return null;
    }
    len = 1 / len;
    x *= len;
    y *= len;
    z *= len;
    s = Math.sin(rad);
    c = Math.cos(rad);
    t = 1 - c; // Perform rotation-specific matrix multiplication
    out[0] = x * x * t + c;
    out[1] = y * x * t + z * s;
    out[2] = z * x * t - y * s;
    out[3] = 0;
    out[4] = x * y * t - z * s;
    out[5] = y * y * t + c;
    out[6] = z * y * t + x * s;
    out[7] = 0;
    out[8] = x * z * t + y * s;
    out[9] = y * z * t - x * s;
    out[10] = z * z * t + c;
    out[11] = 0;
    out[12] = 0;
    out[13] = 0;
    out[14] = 0;
    out[15] = 1;
    return out;
}
/**
 * Creates a matrix from the given angle around the X axis
 * This is equivalent to (but much faster than):
 *
 *     mat4.identity(dest);
 *     mat4.rotateX(dest, dest, rad);
 *
 * @param {mat4} out mat4 receiving operation result
 * @param {Number} rad the angle to rotate the matrix by
 * @returns {mat4} out
 */
function fromXRotation(out, rad) {
    var s = Math.sin(rad);
    var c = Math.cos(rad); // Perform axis-specific matrix multiplication
    out[0] = 1;
    out[1] = 0;
    out[2] = 0;
    out[3] = 0;
    out[4] = 0;
    out[5] = c;
    out[6] = s;
    out[7] = 0;
    out[8] = 0;
    out[9] = -s;
    out[10] = c;
    out[11] = 0;
    out[12] = 0;
    out[13] = 0;
    out[14] = 0;
    out[15] = 1;
    return out;
}
/**
 * Creates a matrix from the given angle around the Y axis
 * This is equivalent to (but much faster than):
 *
 *     mat4.identity(dest);
 *     mat4.rotateY(dest, dest, rad);
 *
 * @param {mat4} out mat4 receiving operation result
 * @param {Number} rad the angle to rotate the matrix by
 * @returns {mat4} out
 */
function fromYRotation(out, rad) {
    var s = Math.sin(rad);
    var c = Math.cos(rad); // Perform axis-specific matrix multiplication
    out[0] = c;
    out[1] = 0;
    out[2] = -s;
    out[3] = 0;
    out[4] = 0;
    out[5] = 1;
    out[6] = 0;
    out[7] = 0;
    out[8] = s;
    out[9] = 0;
    out[10] = c;
    out[11] = 0;
    out[12] = 0;
    out[13] = 0;
    out[14] = 0;
    out[15] = 1;
    return out;
}
/**
 * Creates a matrix from the given angle around the Z axis
 * This is equivalent to (but much faster than):
 *
 *     mat4.identity(dest);
 *     mat4.rotateZ(dest, dest, rad);
 *
 * @param {mat4} out mat4 receiving operation result
 * @param {Number} rad the angle to rotate the matrix by
 * @returns {mat4} out
 */
function fromZRotation(out, rad) {
    var s = Math.sin(rad);
    var c = Math.cos(rad); // Perform axis-specific matrix multiplication
    out[0] = c;
    out[1] = s;
    out[2] = 0;
    out[3] = 0;
    out[4] = -s;
    out[5] = c;
    out[6] = 0;
    out[7] = 0;
    out[8] = 0;
    out[9] = 0;
    out[10] = 1;
    out[11] = 0;
    out[12] = 0;
    out[13] = 0;
    out[14] = 0;
    out[15] = 1;
    return out;
}
/**
 * Creates a matrix from a quaternion rotation and vector translation
 * This is equivalent to (but much faster than):
 *
 *     mat4.identity(dest);
 *     mat4.translate(dest, vec);
 *     let quatMat = mat4.create();
 *     quat4.toMat4(quat, quatMat);
 *     mat4.multiply(dest, quatMat);
 *
 * @param {mat4} out mat4 receiving operation result
 * @param {quat4} q Rotation quaternion
 * @param {ReadonlyVec3} v Translation vector
 * @returns {mat4} out
 */
function fromRotationTranslation(out, q, v) {
    // Quaternion math
    var x = q[0], y = q[1], z = q[2], w = q[3];
    var x2 = x + x;
    var y2 = y + y;
    var z2 = z + z;
    var xx = x * x2;
    var xy = x * y2;
    var xz = x * z2;
    var yy = y * y2;
    var yz = y * z2;
    var zz = z * z2;
    var wx = w * x2;
    var wy = w * y2;
    var wz = w * z2;
    out[0] = 1 - (yy + zz);
    out[1] = xy + wz;
    out[2] = xz - wy;
    out[3] = 0;
    out[4] = xy - wz;
    out[5] = 1 - (xx + zz);
    out[6] = yz + wx;
    out[7] = 0;
    out[8] = xz + wy;
    out[9] = yz - wx;
    out[10] = 1 - (xx + yy);
    out[11] = 0;
    out[12] = v[0];
    out[13] = v[1];
    out[14] = v[2];
    out[15] = 1;
    return out;
}
/**
 * Creates a new mat4 from a dual quat.
 *
 * @param {mat4} out Matrix
 * @param {ReadonlyQuat2} a Dual Quaternion
 * @returns {mat4} mat4 receiving operation result
 */
function fromQuat2(out, a) {
    var translation = new glMatrix.ARRAY_TYPE(3);
    var bx = -a[0], by = -a[1], bz = -a[2], bw = a[3], ax = a[4], ay = a[5], az = a[6], aw = a[7];
    var magnitude = bx * bx + by * by + bz * bz + bw * bw; //Only scale if it makes sense
    if (magnitude > 0) {
        translation[0] = (ax * bw + aw * bx + ay * bz - az * by) * 2 / magnitude;
        translation[1] = (ay * bw + aw * by + az * bx - ax * bz) * 2 / magnitude;
        translation[2] = (az * bw + aw * bz + ax * by - ay * bx) * 2 / magnitude;
    }
    else {
        translation[0] = (ax * bw + aw * bx + ay * bz - az * by) * 2;
        translation[1] = (ay * bw + aw * by + az * bx - ax * bz) * 2;
        translation[2] = (az * bw + aw * bz + ax * by - ay * bx) * 2;
    }
    fromRotationTranslation(out, a, translation);
    return out;
}
/**
 * Returns the translation vector component of a transformation
 *  matrix. If a matrix is built with fromRotationTranslation,
 *  the returned vector will be the same as the translation vector
 *  originally supplied.
 * @param  {vec3} out Vector to receive translation component
 * @param  {ReadonlyMat4} mat Matrix to be decomposed (input)
 * @return {vec3} out
 */
function getTranslation(out, mat) {
    out[0] = mat[12];
    out[1] = mat[13];
    out[2] = mat[14];
    return out;
}
/**
 * Returns the scaling factor component of a transformation
 *  matrix. If a matrix is built with fromRotationTranslationScale
 *  with a normalized Quaternion paramter, the returned vector will be
 *  the same as the scaling vector
 *  originally supplied.
 * @param  {vec3} out Vector to receive scaling factor component
 * @param  {ReadonlyMat4} mat Matrix to be decomposed (input)
 * @return {vec3} out
 */
function getScaling(out, mat) {
    var m11 = mat[0];
    var m12 = mat[1];
    var m13 = mat[2];
    var m21 = mat[4];
    var m22 = mat[5];
    var m23 = mat[6];
    var m31 = mat[8];
    var m32 = mat[9];
    var m33 = mat[10];
    out[0] = Math.hypot(m11, m12, m13);
    out[1] = Math.hypot(m21, m22, m23);
    out[2] = Math.hypot(m31, m32, m33);
    return out;
}
/**
 * Returns a quaternion representing the rotational component
 *  of a transformation matrix. If a matrix is built with
 *  fromRotationTranslation, the returned quaternion will be the
 *  same as the quaternion originally supplied.
 * @param {quat} out Quaternion to receive the rotation component
 * @param {ReadonlyMat4} mat Matrix to be decomposed (input)
 * @return {quat} out
 */
function getRotation(out, mat) {
    var scaling = new glMatrix.ARRAY_TYPE(3);
    getScaling(scaling, mat);
    var is1 = 1 / scaling[0];
    var is2 = 1 / scaling[1];
    var is3 = 1 / scaling[2];
    var sm11 = mat[0] * is1;
    var sm12 = mat[1] * is2;
    var sm13 = mat[2] * is3;
    var sm21 = mat[4] * is1;
    var sm22 = mat[5] * is2;
    var sm23 = mat[6] * is3;
    var sm31 = mat[8] * is1;
    var sm32 = mat[9] * is2;
    var sm33 = mat[10] * is3;
    var trace = sm11 + sm22 + sm33;
    var S = 0;
    if (trace > 0) {
        S = Math.sqrt(trace + 1.0) * 2;
        out[3] = 0.25 * S;
        out[0] = (sm23 - sm32) / S;
        out[1] = (sm31 - sm13) / S;
        out[2] = (sm12 - sm21) / S;
    }
    else if (sm11 > sm22 && sm11 > sm33) {
        S = Math.sqrt(1.0 + sm11 - sm22 - sm33) * 2;
        out[3] = (sm23 - sm32) / S;
        out[0] = 0.25 * S;
        out[1] = (sm12 + sm21) / S;
        out[2] = (sm31 + sm13) / S;
    }
    else if (sm22 > sm33) {
        S = Math.sqrt(1.0 + sm22 - sm11 - sm33) * 2;
        out[3] = (sm31 - sm13) / S;
        out[0] = (sm12 + sm21) / S;
        out[1] = 0.25 * S;
        out[2] = (sm23 + sm32) / S;
    }
    else {
        S = Math.sqrt(1.0 + sm33 - sm11 - sm22) * 2;
        out[3] = (sm12 - sm21) / S;
        out[0] = (sm31 + sm13) / S;
        out[1] = (sm23 + sm32) / S;
        out[2] = 0.25 * S;
    }
    return out;
}
/**
 * Creates a matrix from a quaternion rotation, vector translation and vector scale
 * This is equivalent to (but much faster than):
 *
 *     mat4.identity(dest);
 *     mat4.translate(dest, vec);
 *     let quatMat = mat4.create();
 *     quat4.toMat4(quat, quatMat);
 *     mat4.multiply(dest, quatMat);
 *     mat4.scale(dest, scale)
 *
 * @param {mat4} out mat4 receiving operation result
 * @param {quat4} q Rotation quaternion
 * @param {ReadonlyVec3} v Translation vector
 * @param {ReadonlyVec3} s Scaling vector
 * @returns {mat4} out
 */
function fromRotationTranslationScale(out, q, v, s) {
    // Quaternion math
    var x = q[0], y = q[1], z = q[2], w = q[3];
    var x2 = x + x;
    var y2 = y + y;
    var z2 = z + z;
    var xx = x * x2;
    var xy = x * y2;
    var xz = x * z2;
    var yy = y * y2;
    var yz = y * z2;
    var zz = z * z2;
    var wx = w * x2;
    var wy = w * y2;
    var wz = w * z2;
    var sx = s[0];
    var sy = s[1];
    var sz = s[2];
    out[0] = (1 - (yy + zz)) * sx;
    out[1] = (xy + wz) * sx;
    out[2] = (xz - wy) * sx;
    out[3] = 0;
    out[4] = (xy - wz) * sy;
    out[5] = (1 - (xx + zz)) * sy;
    out[6] = (yz + wx) * sy;
    out[7] = 0;
    out[8] = (xz + wy) * sz;
    out[9] = (yz - wx) * sz;
    out[10] = (1 - (xx + yy)) * sz;
    out[11] = 0;
    out[12] = v[0];
    out[13] = v[1];
    out[14] = v[2];
    out[15] = 1;
    return out;
}
/**
 * Creates a matrix from a quaternion rotation, vector translation and vector scale, rotating and scaling around the given origin
 * This is equivalent to (but much faster than):
 *
 *     mat4.identity(dest);
 *     mat4.translate(dest, vec);
 *     mat4.translate(dest, origin);
 *     let quatMat = mat4.create();
 *     quat4.toMat4(quat, quatMat);
 *     mat4.multiply(dest, quatMat);
 *     mat4.scale(dest, scale)
 *     mat4.translate(dest, negativeOrigin);
 *
 * @param {mat4} out mat4 receiving operation result
 * @param {quat4} q Rotation quaternion
 * @param {ReadonlyVec3} v Translation vector
 * @param {ReadonlyVec3} s Scaling vector
 * @param {ReadonlyVec3} o The origin vector around which to scale and rotate
 * @returns {mat4} out
 */
function fromRotationTranslationScaleOrigin(out, q, v, s, o) {
    // Quaternion math
    var x = q[0], y = q[1], z = q[2], w = q[3];
    var x2 = x + x;
    var y2 = y + y;
    var z2 = z + z;
    var xx = x * x2;
    var xy = x * y2;
    var xz = x * z2;
    var yy = y * y2;
    var yz = y * z2;
    var zz = z * z2;
    var wx = w * x2;
    var wy = w * y2;
    var wz = w * z2;
    var sx = s[0];
    var sy = s[1];
    var sz = s[2];
    var ox = o[0];
    var oy = o[1];
    var oz = o[2];
    var out0 = (1 - (yy + zz)) * sx;
    var out1 = (xy + wz) * sx;
    var out2 = (xz - wy) * sx;
    var out4 = (xy - wz) * sy;
    var out5 = (1 - (xx + zz)) * sy;
    var out6 = (yz + wx) * sy;
    var out8 = (xz + wy) * sz;
    var out9 = (yz - wx) * sz;
    var out10 = (1 - (xx + yy)) * sz;
    out[0] = out0;
    out[1] = out1;
    out[2] = out2;
    out[3] = 0;
    out[4] = out4;
    out[5] = out5;
    out[6] = out6;
    out[7] = 0;
    out[8] = out8;
    out[9] = out9;
    out[10] = out10;
    out[11] = 0;
    out[12] = v[0] + ox - (out0 * ox + out4 * oy + out8 * oz);
    out[13] = v[1] + oy - (out1 * ox + out5 * oy + out9 * oz);
    out[14] = v[2] + oz - (out2 * ox + out6 * oy + out10 * oz);
    out[15] = 1;
    return out;
}
/**
 * Calculates a 4x4 matrix from the given quaternion
 *
 * @param {mat4} out mat4 receiving operation result
 * @param {ReadonlyQuat} q Quaternion to create matrix from
 *
 * @returns {mat4} out
 */
function mat4_fromQuat(out, q) {
    var x = q[0], y = q[1], z = q[2], w = q[3];
    var x2 = x + x;
    var y2 = y + y;
    var z2 = z + z;
    var xx = x * x2;
    var yx = y * x2;
    var yy = y * y2;
    var zx = z * x2;
    var zy = z * y2;
    var zz = z * z2;
    var wx = w * x2;
    var wy = w * y2;
    var wz = w * z2;
    out[0] = 1 - yy - zz;
    out[1] = yx + wz;
    out[2] = zx - wy;
    out[3] = 0;
    out[4] = yx - wz;
    out[5] = 1 - xx - zz;
    out[6] = zy + wx;
    out[7] = 0;
    out[8] = zx + wy;
    out[9] = zy - wx;
    out[10] = 1 - xx - yy;
    out[11] = 0;
    out[12] = 0;
    out[13] = 0;
    out[14] = 0;
    out[15] = 1;
    return out;
}
/**
 * Generates a frustum matrix with the given bounds
 *
 * @param {mat4} out mat4 frustum matrix will be written into
 * @param {Number} left Left bound of the frustum
 * @param {Number} right Right bound of the frustum
 * @param {Number} bottom Bottom bound of the frustum
 * @param {Number} top Top bound of the frustum
 * @param {Number} near Near bound of the frustum
 * @param {Number} far Far bound of the frustum
 * @returns {mat4} out
 */
function frustum(out, left, right, bottom, top, near, far) {
    var rl = 1 / (right - left);
    var tb = 1 / (top - bottom);
    var nf = 1 / (near - far);
    out[0] = near * 2 * rl;
    out[1] = 0;
    out[2] = 0;
    out[3] = 0;
    out[4] = 0;
    out[5] = near * 2 * tb;
    out[6] = 0;
    out[7] = 0;
    out[8] = (right + left) * rl;
    out[9] = (top + bottom) * tb;
    out[10] = (far + near) * nf;
    out[11] = -1;
    out[12] = 0;
    out[13] = 0;
    out[14] = far * near * 2 * nf;
    out[15] = 0;
    return out;
}
/**
 * Generates a perspective projection matrix with the given bounds.
 * The near/far clip planes correspond to a normalized device coordinate Z range of [-1, 1],
 * which matches WebGL/OpenGL's clip volume.
 * Passing null/undefined/no value for far will generate infinite projection matrix.
 *
 * @param {mat4} out mat4 frustum matrix will be written into
 * @param {number} fovy Vertical field of view in radians
 * @param {number} aspect Aspect ratio. typically viewport width/height
 * @param {number} near Near bound of the frustum
 * @param {number} far Far bound of the frustum, can be null or Infinity
 * @returns {mat4} out
 */
function perspectiveNO(out, fovy, aspect, near, far) {
    var f = 1.0 / Math.tan(fovy / 2), nf;
    out[0] = f / aspect;
    out[1] = 0;
    out[2] = 0;
    out[3] = 0;
    out[4] = 0;
    out[5] = f;
    out[6] = 0;
    out[7] = 0;
    out[8] = 0;
    out[9] = 0;
    out[11] = -1;
    out[12] = 0;
    out[13] = 0;
    out[15] = 0;
    if (far != null && far !== Infinity) {
        nf = 1 / (near - far);
        out[10] = (far + near) * nf;
        out[14] = 2 * far * near * nf;
    }
    else {
        out[10] = -1;
        out[14] = -2 * near;
    }
    return out;
}
/**
 * Alias for {@link mat4.perspectiveNO}
 * @function
 */
var perspective = perspectiveNO;
/**
 * Generates a perspective projection matrix suitable for WebGPU with the given bounds.
 * The near/far clip planes correspond to a normalized device coordinate Z range of [0, 1],
 * which matches WebGPU/Vulkan/DirectX/Metal's clip volume.
 * Passing null/undefined/no value for far will generate infinite projection matrix.
 *
 * @param {mat4} out mat4 frustum matrix will be written into
 * @param {number} fovy Vertical field of view in radians
 * @param {number} aspect Aspect ratio. typically viewport width/height
 * @param {number} near Near bound of the frustum
 * @param {number} far Far bound of the frustum, can be null or Infinity
 * @returns {mat4} out
 */
function perspectiveZO(out, fovy, aspect, near, far) {
    var f = 1.0 / Math.tan(fovy / 2), nf;
    out[0] = f / aspect;
    out[1] = 0;
    out[2] = 0;
    out[3] = 0;
    out[4] = 0;
    out[5] = f;
    out[6] = 0;
    out[7] = 0;
    out[8] = 0;
    out[9] = 0;
    out[11] = -1;
    out[12] = 0;
    out[13] = 0;
    out[15] = 0;
    if (far != null && far !== Infinity) {
        nf = 1 / (near - far);
        out[10] = far * nf;
        out[14] = far * near * nf;
    }
    else {
        out[10] = -1;
        out[14] = -near;
    }
    return out;
}
/**
 * Generates a perspective projection matrix with the given field of view.
 * This is primarily useful for generating projection matrices to be used
 * with the still experiemental WebVR API.
 *
 * @param {mat4} out mat4 frustum matrix will be written into
 * @param {Object} fov Object containing the following values: upDegrees, downDegrees, leftDegrees, rightDegrees
 * @param {number} near Near bound of the frustum
 * @param {number} far Far bound of the frustum
 * @returns {mat4} out
 */
function perspectiveFromFieldOfView(out, fov, near, far) {
    var upTan = Math.tan(fov.upDegrees * Math.PI / 180.0);
    var downTan = Math.tan(fov.downDegrees * Math.PI / 180.0);
    var leftTan = Math.tan(fov.leftDegrees * Math.PI / 180.0);
    var rightTan = Math.tan(fov.rightDegrees * Math.PI / 180.0);
    var xScale = 2.0 / (leftTan + rightTan);
    var yScale = 2.0 / (upTan + downTan);
    out[0] = xScale;
    out[1] = 0.0;
    out[2] = 0.0;
    out[3] = 0.0;
    out[4] = 0.0;
    out[5] = yScale;
    out[6] = 0.0;
    out[7] = 0.0;
    out[8] = -((leftTan - rightTan) * xScale * 0.5);
    out[9] = (upTan - downTan) * yScale * 0.5;
    out[10] = far / (near - far);
    out[11] = -1.0;
    out[12] = 0.0;
    out[13] = 0.0;
    out[14] = far * near / (near - far);
    out[15] = 0.0;
    return out;
}
/**
 * Generates a orthogonal projection matrix with the given bounds.
 * The near/far clip planes correspond to a normalized device coordinate Z range of [-1, 1],
 * which matches WebGL/OpenGL's clip volume.
 *
 * @param {mat4} out mat4 frustum matrix will be written into
 * @param {number} left Left bound of the frustum
 * @param {number} right Right bound of the frustum
 * @param {number} bottom Bottom bound of the frustum
 * @param {number} top Top bound of the frustum
 * @param {number} near Near bound of the frustum
 * @param {number} far Far bound of the frustum
 * @returns {mat4} out
 */
function orthoNO(out, left, right, bottom, top, near, far) {
    var lr = 1 / (left - right);
    var bt = 1 / (bottom - top);
    var nf = 1 / (near - far);
    out[0] = -2 * lr;
    out[1] = 0;
    out[2] = 0;
    out[3] = 0;
    out[4] = 0;
    out[5] = -2 * bt;
    out[6] = 0;
    out[7] = 0;
    out[8] = 0;
    out[9] = 0;
    out[10] = 2 * nf;
    out[11] = 0;
    out[12] = (left + right) * lr;
    out[13] = (top + bottom) * bt;
    out[14] = (far + near) * nf;
    out[15] = 1;
    return out;
}
/**
 * Alias for {@link mat4.orthoNO}
 * @function
 */
var ortho = orthoNO;
/**
 * Generates a orthogonal projection matrix with the given bounds.
 * The near/far clip planes correspond to a normalized device coordinate Z range of [0, 1],
 * which matches WebGPU/Vulkan/DirectX/Metal's clip volume.
 *
 * @param {mat4} out mat4 frustum matrix will be written into
 * @param {number} left Left bound of the frustum
 * @param {number} right Right bound of the frustum
 * @param {number} bottom Bottom bound of the frustum
 * @param {number} top Top bound of the frustum
 * @param {number} near Near bound of the frustum
 * @param {number} far Far bound of the frustum
 * @returns {mat4} out
 */
function orthoZO(out, left, right, bottom, top, near, far) {
    var lr = 1 / (left - right);
    var bt = 1 / (bottom - top);
    var nf = 1 / (near - far);
    out[0] = -2 * lr;
    out[1] = 0;
    out[2] = 0;
    out[3] = 0;
    out[4] = 0;
    out[5] = -2 * bt;
    out[6] = 0;
    out[7] = 0;
    out[8] = 0;
    out[9] = 0;
    out[10] = nf;
    out[11] = 0;
    out[12] = (left + right) * lr;
    out[13] = (top + bottom) * bt;
    out[14] = near * nf;
    out[15] = 1;
    return out;
}
/**
 * Generates a look-at matrix with the given eye position, focal point, and up axis.
 * If you want a matrix that actually makes an object look at another object, you should use targetTo instead.
 *
 * @param {mat4} out mat4 frustum matrix will be written into
 * @param {ReadonlyVec3} eye Position of the viewer
 * @param {ReadonlyVec3} center Point the viewer is looking at
 * @param {ReadonlyVec3} up vec3 pointing up
 * @returns {mat4} out
 */
function lookAt(out, eye, center, up) {
    var x0, x1, x2, y0, y1, y2, z0, z1, z2, len;
    var eyex = eye[0];
    var eyey = eye[1];
    var eyez = eye[2];
    var upx = up[0];
    var upy = up[1];
    var upz = up[2];
    var centerx = center[0];
    var centery = center[1];
    var centerz = center[2];
    if (Math.abs(eyex - centerx) < EPSILON && Math.abs(eyey - centery) < EPSILON && Math.abs(eyez - centerz) < EPSILON) {
        return mat4_identity(out);
    }
    z0 = eyex - centerx;
    z1 = eyey - centery;
    z2 = eyez - centerz;
    len = 1 / Math.hypot(z0, z1, z2);
    z0 *= len;
    z1 *= len;
    z2 *= len;
    x0 = upy * z2 - upz * z1;
    x1 = upz * z0 - upx * z2;
    x2 = upx * z1 - upy * z0;
    len = Math.hypot(x0, x1, x2);
    if (!len) {
        x0 = 0;
        x1 = 0;
        x2 = 0;
    }
    else {
        len = 1 / len;
        x0 *= len;
        x1 *= len;
        x2 *= len;
    }
    y0 = z1 * x2 - z2 * x1;
    y1 = z2 * x0 - z0 * x2;
    y2 = z0 * x1 - z1 * x0;
    len = Math.hypot(y0, y1, y2);
    if (!len) {
        y0 = 0;
        y1 = 0;
        y2 = 0;
    }
    else {
        len = 1 / len;
        y0 *= len;
        y1 *= len;
        y2 *= len;
    }
    out[0] = x0;
    out[1] = y0;
    out[2] = z0;
    out[3] = 0;
    out[4] = x1;
    out[5] = y1;
    out[6] = z1;
    out[7] = 0;
    out[8] = x2;
    out[9] = y2;
    out[10] = z2;
    out[11] = 0;
    out[12] = -(x0 * eyex + x1 * eyey + x2 * eyez);
    out[13] = -(y0 * eyex + y1 * eyey + y2 * eyez);
    out[14] = -(z0 * eyex + z1 * eyey + z2 * eyez);
    out[15] = 1;
    return out;
}
/**
 * Generates a matrix that makes something look at something else.
 *
 * @param {mat4} out mat4 frustum matrix will be written into
 * @param {ReadonlyVec3} eye Position of the viewer
 * @param {ReadonlyVec3} center Point the viewer is looking at
 * @param {ReadonlyVec3} up vec3 pointing up
 * @returns {mat4} out
 */
function targetTo(out, eye, target, up) {
    var eyex = eye[0], eyey = eye[1], eyez = eye[2], upx = up[0], upy = up[1], upz = up[2];
    var z0 = eyex - target[0], z1 = eyey - target[1], z2 = eyez - target[2];
    var len = z0 * z0 + z1 * z1 + z2 * z2;
    if (len > 0) {
        len = 1 / Math.sqrt(len);
        z0 *= len;
        z1 *= len;
        z2 *= len;
    }
    var x0 = upy * z2 - upz * z1, x1 = upz * z0 - upx * z2, x2 = upx * z1 - upy * z0;
    len = x0 * x0 + x1 * x1 + x2 * x2;
    if (len > 0) {
        len = 1 / Math.sqrt(len);
        x0 *= len;
        x1 *= len;
        x2 *= len;
    }
    out[0] = x0;
    out[1] = x1;
    out[2] = x2;
    out[3] = 0;
    out[4] = z1 * x2 - z2 * x1;
    out[5] = z2 * x0 - z0 * x2;
    out[6] = z0 * x1 - z1 * x0;
    out[7] = 0;
    out[8] = z0;
    out[9] = z1;
    out[10] = z2;
    out[11] = 0;
    out[12] = eyex;
    out[13] = eyey;
    out[14] = eyez;
    out[15] = 1;
    return out;
}
/**
 * Returns a string representation of a mat4
 *
 * @param {ReadonlyMat4} a matrix to represent as a string
 * @returns {String} string representation of the matrix
 */
function mat4_str(a) {
    return "mat4(" + a[0] + ", " + a[1] + ", " + a[2] + ", " + a[3] + ", " + a[4] + ", " + a[5] + ", " + a[6] + ", " + a[7] + ", " + a[8] + ", " + a[9] + ", " + a[10] + ", " + a[11] + ", " + a[12] + ", " + a[13] + ", " + a[14] + ", " + a[15] + ")";
}
/**
 * Returns Frobenius norm of a mat4
 *
 * @param {ReadonlyMat4} a the matrix to calculate Frobenius norm of
 * @returns {Number} Frobenius norm
 */
function mat4_frob(a) {
    return Math.hypot(a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11], a[12], a[13], a[14], a[15]);
}
/**
 * Adds two mat4's
 *
 * @param {mat4} out the receiving matrix
 * @param {ReadonlyMat4} a the first operand
 * @param {ReadonlyMat4} b the second operand
 * @returns {mat4} out
 */
function mat4_add(out, a, b) {
    out[0] = a[0] + b[0];
    out[1] = a[1] + b[1];
    out[2] = a[2] + b[2];
    out[3] = a[3] + b[3];
    out[4] = a[4] + b[4];
    out[5] = a[5] + b[5];
    out[6] = a[6] + b[6];
    out[7] = a[7] + b[7];
    out[8] = a[8] + b[8];
    out[9] = a[9] + b[9];
    out[10] = a[10] + b[10];
    out[11] = a[11] + b[11];
    out[12] = a[12] + b[12];
    out[13] = a[13] + b[13];
    out[14] = a[14] + b[14];
    out[15] = a[15] + b[15];
    return out;
}
/**
 * Subtracts matrix b from matrix a
 *
 * @param {mat4} out the receiving matrix
 * @param {ReadonlyMat4} a the first operand
 * @param {ReadonlyMat4} b the second operand
 * @returns {mat4} out
 */
function mat4_subtract(out, a, b) {
    out[0] = a[0] - b[0];
    out[1] = a[1] - b[1];
    out[2] = a[2] - b[2];
    out[3] = a[3] - b[3];
    out[4] = a[4] - b[4];
    out[5] = a[5] - b[5];
    out[6] = a[6] - b[6];
    out[7] = a[7] - b[7];
    out[8] = a[8] - b[8];
    out[9] = a[9] - b[9];
    out[10] = a[10] - b[10];
    out[11] = a[11] - b[11];
    out[12] = a[12] - b[12];
    out[13] = a[13] - b[13];
    out[14] = a[14] - b[14];
    out[15] = a[15] - b[15];
    return out;
}
/**
 * Multiply each element of the matrix by a scalar.
 *
 * @param {mat4} out the receiving matrix
 * @param {ReadonlyMat4} a the matrix to scale
 * @param {Number} b amount to scale the matrix's elements by
 * @returns {mat4} out
 */
function mat4_multiplyScalar(out, a, b) {
    out[0] = a[0] * b;
    out[1] = a[1] * b;
    out[2] = a[2] * b;
    out[3] = a[3] * b;
    out[4] = a[4] * b;
    out[5] = a[5] * b;
    out[6] = a[6] * b;
    out[7] = a[7] * b;
    out[8] = a[8] * b;
    out[9] = a[9] * b;
    out[10] = a[10] * b;
    out[11] = a[11] * b;
    out[12] = a[12] * b;
    out[13] = a[13] * b;
    out[14] = a[14] * b;
    out[15] = a[15] * b;
    return out;
}
/**
 * Adds two mat4's after multiplying each element of the second operand by a scalar value.
 *
 * @param {mat4} out the receiving vector
 * @param {ReadonlyMat4} a the first operand
 * @param {ReadonlyMat4} b the second operand
 * @param {Number} scale the amount to scale b's elements by before adding
 * @returns {mat4} out
 */
function mat4_multiplyScalarAndAdd(out, a, b, scale) {
    out[0] = a[0] + b[0] * scale;
    out[1] = a[1] + b[1] * scale;
    out[2] = a[2] + b[2] * scale;
    out[3] = a[3] + b[3] * scale;
    out[4] = a[4] + b[4] * scale;
    out[5] = a[5] + b[5] * scale;
    out[6] = a[6] + b[6] * scale;
    out[7] = a[7] + b[7] * scale;
    out[8] = a[8] + b[8] * scale;
    out[9] = a[9] + b[9] * scale;
    out[10] = a[10] + b[10] * scale;
    out[11] = a[11] + b[11] * scale;
    out[12] = a[12] + b[12] * scale;
    out[13] = a[13] + b[13] * scale;
    out[14] = a[14] + b[14] * scale;
    out[15] = a[15] + b[15] * scale;
    return out;
}
/**
 * Returns whether or not the matrices have exactly the same elements in the same position (when compared with ===)
 *
 * @param {ReadonlyMat4} a The first matrix.
 * @param {ReadonlyMat4} b The second matrix.
 * @returns {Boolean} True if the matrices are equal, false otherwise.
 */
function mat4_exactEquals(a, b) {
    return a[0] === b[0] && a[1] === b[1] && a[2] === b[2] && a[3] === b[3] && a[4] === b[4] && a[5] === b[5] && a[6] === b[6] && a[7] === b[7] && a[8] === b[8] && a[9] === b[9] && a[10] === b[10] && a[11] === b[11] && a[12] === b[12] && a[13] === b[13] && a[14] === b[14] && a[15] === b[15];
}
/**
 * Returns whether or not the matrices have approximately the same elements in the same position.
 *
 * @param {ReadonlyMat4} a The first matrix.
 * @param {ReadonlyMat4} b The second matrix.
 * @returns {Boolean} True if the matrices are equal, false otherwise.
 */
function mat4_equals(a, b) {
    var a0 = a[0], a1 = a[1], a2 = a[2], a3 = a[3];
    var a4 = a[4], a5 = a[5], a6 = a[6], a7 = a[7];
    var a8 = a[8], a9 = a[9], a10 = a[10], a11 = a[11];
    var a12 = a[12], a13 = a[13], a14 = a[14], a15 = a[15];
    var b0 = b[0], b1 = b[1], b2 = b[2], b3 = b[3];
    var b4 = b[4], b5 = b[5], b6 = b[6], b7 = b[7];
    var b8 = b[8], b9 = b[9], b10 = b[10], b11 = b[11];
    var b12 = b[12], b13 = b[13], b14 = b[14], b15 = b[15];
    return Math.abs(a0 - b0) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a0), Math.abs(b0)) && Math.abs(a1 - b1) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a1), Math.abs(b1)) && Math.abs(a2 - b2) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a2), Math.abs(b2)) && Math.abs(a3 - b3) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a3), Math.abs(b3)) && Math.abs(a4 - b4) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a4), Math.abs(b4)) && Math.abs(a5 - b5) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a5), Math.abs(b5)) && Math.abs(a6 - b6) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a6), Math.abs(b6)) && Math.abs(a7 - b7) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a7), Math.abs(b7)) && Math.abs(a8 - b8) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a8), Math.abs(b8)) && Math.abs(a9 - b9) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a9), Math.abs(b9)) && Math.abs(a10 - b10) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a10), Math.abs(b10)) && Math.abs(a11 - b11) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a11), Math.abs(b11)) && Math.abs(a12 - b12) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a12), Math.abs(b12)) && Math.abs(a13 - b13) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a13), Math.abs(b13)) && Math.abs(a14 - b14) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a14), Math.abs(b14)) && Math.abs(a15 - b15) <= glMatrix.EPSILON * Math.max(1.0, Math.abs(a15), Math.abs(b15));
}
/**
 * Alias for {@link mat4.multiply}
 * @function
 */
var mat4_mul = ( /* unused pure expression or super */null && (mat4_multiply));
/**
 * Alias for {@link mat4.subtract}
 * @function
 */
var mat4_sub = ( /* unused pure expression or super */null && (mat4_subtract));
; // CONCATENATED MODULE: ./node_modules/gl-matrix/esm/vec4.js
/**
 * 4 Dimensional Vector
 * @module vec4
 */
/**
 * Creates a new, empty vec4
 *
 * @returns {vec4} a new 4D vector
 */
function vec4_create() {
    var out = new ARRAY_TYPE(4);
    if (ARRAY_TYPE != Float32Array) {
        out[0] = 0;
        out[1] = 0;
        out[2] = 0;
        out[3] = 0;
    }
    return out;
}
/**
 * Creates a new vec4 initialized with values from an existing vector
 *
 * @param {ReadonlyVec4} a vector to clone
 * @returns {vec4} a new 4D vector
 */
function vec4_clone(a) {
    var out = new ARRAY_TYPE(4);
    out[0] = a[0];
    out[1] = a[1];
    out[2] = a[2];
    out[3] = a[3];
    return out;
}
/**
 * Creates a new vec4 initialized with the given values
 *
 * @param {Number} x X component
 * @param {Number} y Y component
 * @param {Number} z Z component
 * @param {Number} w W component
 * @returns {vec4} a new 4D vector
 */
function vec4_fromValues(x, y, z, w) {
    var out = new ARRAY_TYPE(4);
    out[0] = x;
    out[1] = y;
    out[2] = z;
    out[3] = w;
    return out;
}
/**
 * Copy the values from one vec4 to another
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a the source vector
 * @returns {vec4} out
 */
function vec4_copy(out, a) {
    out[0] = a[0];
    out[1] = a[1];
    out[2] = a[2];
    out[3] = a[3];
    return out;
}
/**
 * Set the components of a vec4 to the given values
 *
 * @param {vec4} out the receiving vector
 * @param {Number} x X component
 * @param {Number} y Y component
 * @param {Number} z Z component
 * @param {Number} w W component
 * @returns {vec4} out
 */
function vec4_set(out, x, y, z, w) {
    out[0] = x;
    out[1] = y;
    out[2] = z;
    out[3] = w;
    return out;
}
/**
 * Adds two vec4's
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a the first operand
 * @param {ReadonlyVec4} b the second operand
 * @returns {vec4} out
 */
function vec4_add(out, a, b) {
    out[0] = a[0] + b[0];
    out[1] = a[1] + b[1];
    out[2] = a[2] + b[2];
    out[3] = a[3] + b[3];
    return out;
}
/**
 * Subtracts vector b from vector a
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a the first operand
 * @param {ReadonlyVec4} b the second operand
 * @returns {vec4} out
 */
function vec4_subtract(out, a, b) {
    out[0] = a[0] - b[0];
    out[1] = a[1] - b[1];
    out[2] = a[2] - b[2];
    out[3] = a[3] - b[3];
    return out;
}
/**
 * Multiplies two vec4's
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a the first operand
 * @param {ReadonlyVec4} b the second operand
 * @returns {vec4} out
 */
function vec4_multiply(out, a, b) {
    out[0] = a[0] * b[0];
    out[1] = a[1] * b[1];
    out[2] = a[2] * b[2];
    out[3] = a[3] * b[3];
    return out;
}
/**
 * Divides two vec4's
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a the first operand
 * @param {ReadonlyVec4} b the second operand
 * @returns {vec4} out
 */
function vec4_divide(out, a, b) {
    out[0] = a[0] / b[0];
    out[1] = a[1] / b[1];
    out[2] = a[2] / b[2];
    out[3] = a[3] / b[3];
    return out;
}
/**
 * Math.ceil the components of a vec4
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a vector to ceil
 * @returns {vec4} out
 */
function vec4_ceil(out, a) {
    out[0] = Math.ceil(a[0]);
    out[1] = Math.ceil(a[1]);
    out[2] = Math.ceil(a[2]);
    out[3] = Math.ceil(a[3]);
    return out;
}
/**
 * Math.floor the components of a vec4
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a vector to floor
 * @returns {vec4} out
 */
function vec4_floor(out, a) {
    out[0] = Math.floor(a[0]);
    out[1] = Math.floor(a[1]);
    out[2] = Math.floor(a[2]);
    out[3] = Math.floor(a[3]);
    return out;
}
/**
 * Returns the minimum of two vec4's
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a the first operand
 * @param {ReadonlyVec4} b the second operand
 * @returns {vec4} out
 */
function vec4_min(out, a, b) {
    out[0] = Math.min(a[0], b[0]);
    out[1] = Math.min(a[1], b[1]);
    out[2] = Math.min(a[2], b[2]);
    out[3] = Math.min(a[3], b[3]);
    return out;
}
/**
 * Returns the maximum of two vec4's
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a the first operand
 * @param {ReadonlyVec4} b the second operand
 * @returns {vec4} out
 */
function vec4_max(out, a, b) {
    out[0] = Math.max(a[0], b[0]);
    out[1] = Math.max(a[1], b[1]);
    out[2] = Math.max(a[2], b[2]);
    out[3] = Math.max(a[3], b[3]);
    return out;
}
/**
 * Math.round the components of a vec4
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a vector to round
 * @returns {vec4} out
 */
function vec4_round(out, a) {
    out[0] = Math.round(a[0]);
    out[1] = Math.round(a[1]);
    out[2] = Math.round(a[2]);
    out[3] = Math.round(a[3]);
    return out;
}
/**
 * Scales a vec4 by a scalar number
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a the vector to scale
 * @param {Number} b amount to scale the vector by
 * @returns {vec4} out
 */
function vec4_scale(out, a, b) {
    out[0] = a[0] * b;
    out[1] = a[1] * b;
    out[2] = a[2] * b;
    out[3] = a[3] * b;
    return out;
}
/**
 * Adds two vec4's after scaling the second operand by a scalar value
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a the first operand
 * @param {ReadonlyVec4} b the second operand
 * @param {Number} scale the amount to scale b by before adding
 * @returns {vec4} out
 */
function vec4_scaleAndAdd(out, a, b, scale) {
    out[0] = a[0] + b[0] * scale;
    out[1] = a[1] + b[1] * scale;
    out[2] = a[2] + b[2] * scale;
    out[3] = a[3] + b[3] * scale;
    return out;
}
/**
 * Calculates the euclidian distance between two vec4's
 *
 * @param {ReadonlyVec4} a the first operand
 * @param {ReadonlyVec4} b the second operand
 * @returns {Number} distance between a and b
 */
function vec4_distance(a, b) {
    var x = b[0] - a[0];
    var y = b[1] - a[1];
    var z = b[2] - a[2];
    var w = b[3] - a[3];
    return Math.hypot(x, y, z, w);
}
/**
 * Calculates the squared euclidian distance between two vec4's
 *
 * @param {ReadonlyVec4} a the first operand
 * @param {ReadonlyVec4} b the second operand
 * @returns {Number} squared distance between a and b
 */
function vec4_squaredDistance(a, b) {
    var x = b[0] - a[0];
    var y = b[1] - a[1];
    var z = b[2] - a[2];
    var w = b[3] - a[3];
    return x * x + y * y + z * z + w * w;
}
/**
 * Calculates the length of a vec4
 *
 * @param {ReadonlyVec4} a vector to calculate length of
 * @returns {Number} length of a
 */
function vec4_length(a) {
    var x = a[0];
    var y = a[1];
    var z = a[2];
    var w = a[3];
    return Math.hypot(x, y, z, w);
}
/**
 * Calculates the squared length of a vec4
 *
 * @param {ReadonlyVec4} a vector to calculate squared length of
 * @returns {Number} squared length of a
 */
function vec4_squaredLength(a) {
    var x = a[0];
    var y = a[1];
    var z = a[2];
    var w = a[3];
    return x * x + y * y + z * z + w * w;
}
/**
 * Negates the components of a vec4
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a vector to negate
 * @returns {vec4} out
 */
function vec4_negate(out, a) {
    out[0] = -a[0];
    out[1] = -a[1];
    out[2] = -a[2];
    out[3] = -a[3];
    return out;
}
/**
 * Returns the inverse of the components of a vec4
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a vector to invert
 * @returns {vec4} out
 */
function vec4_inverse(out, a) {
    out[0] = 1.0 / a[0];
    out[1] = 1.0 / a[1];
    out[2] = 1.0 / a[2];
    out[3] = 1.0 / a[3];
    return out;
}
/**
 * Normalize a vec4
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a vector to normalize
 * @returns {vec4} out
 */
function vec4_normalize(out, a) {
    var x = a[0];
    var y = a[1];
    var z = a[2];
    var w = a[3];
    var len = x * x + y * y + z * z + w * w;
    if (len > 0) {
        len = 1 / Math.sqrt(len);
    }
    out[0] = x * len;
    out[1] = y * len;
    out[2] = z * len;
    out[3] = w * len;
    return out;
}
/**
 * Calculates the dot product of two vec4's
 *
 * @param {ReadonlyVec4} a the first operand
 * @param {ReadonlyVec4} b the second operand
 * @returns {Number} dot product of a and b
 */
function vec4_dot(a, b) {
    return a[0] * b[0] + a[1] * b[1] + a[2] * b[2] + a[3] * b[3];
}
/**
 * Returns the cross-product of three vectors in a 4-dimensional space
 *
 * @param {ReadonlyVec4} result the receiving vector
 * @param {ReadonlyVec4} U the first vector
 * @param {ReadonlyVec4} V the second vector
 * @param {ReadonlyVec4} W the third vector
 * @returns {vec4} result
 */
function vec4_cross(out, u, v, w) {
    var A = v[0] * w[1] - v[1] * w[0], B = v[0] * w[2] - v[2] * w[0], C = v[0] * w[3] - v[3] * w[0], D = v[1] * w[2] - v[2] * w[1], E = v[1] * w[3] - v[3] * w[1], F = v[2] * w[3] - v[3] * w[2];
    var G = u[0];
    var H = u[1];
    var I = u[2];
    var J = u[3];
    out[0] = H * F - I * E + J * D;
    out[1] = -(G * F) + I * C - J * B;
    out[2] = G * E - H * C + J * A;
    out[3] = -(G * D) + H * B - I * A;
    return out;
}
/**
 * Performs a linear interpolation between two vec4's
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a the first operand
 * @param {ReadonlyVec4} b the second operand
 * @param {Number} t interpolation amount, in the range [0-1], between the two inputs
 * @returns {vec4} out
 */
function vec4_lerp(out, a, b, t) {
    var ax = a[0];
    var ay = a[1];
    var az = a[2];
    var aw = a[3];
    out[0] = ax + t * (b[0] - ax);
    out[1] = ay + t * (b[1] - ay);
    out[2] = az + t * (b[2] - az);
    out[3] = aw + t * (b[3] - aw);
    return out;
}
/**
 * Generates a random vector with the given scale
 *
 * @param {vec4} out the receiving vector
 * @param {Number} [scale] Length of the resulting vector. If ommitted, a unit vector will be returned
 * @returns {vec4} out
 */
function vec4_random(out, scale) {
    scale = scale || 1.0; // Marsaglia, George. Choosing a Point from the Surface of a
    // Sphere. Ann. Math. Statist. 43 (1972), no. 2, 645--646.
    // http://projecteuclid.org/euclid.aoms/1177692644;
    var v1, v2, v3, v4;
    var s1, s2;
    do {
        v1 = glMatrix.RANDOM() * 2 - 1;
        v2 = glMatrix.RANDOM() * 2 - 1;
        s1 = v1 * v1 + v2 * v2;
    } while (s1 >= 1);
    do {
        v3 = glMatrix.RANDOM() * 2 - 1;
        v4 = glMatrix.RANDOM() * 2 - 1;
        s2 = v3 * v3 + v4 * v4;
    } while (s2 >= 1);
    var d = Math.sqrt((1 - s1) / s2);
    out[0] = scale * v1;
    out[1] = scale * v2;
    out[2] = scale * v3 * d;
    out[3] = scale * v4 * d;
    return out;
}
/**
 * Transforms the vec4 with a mat4.
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a the vector to transform
 * @param {ReadonlyMat4} m matrix to transform with
 * @returns {vec4} out
 */
function vec4_transformMat4(out, a, m) {
    var x = a[0], y = a[1], z = a[2], w = a[3];
    out[0] = m[0] * x + m[4] * y + m[8] * z + m[12] * w;
    out[1] = m[1] * x + m[5] * y + m[9] * z + m[13] * w;
    out[2] = m[2] * x + m[6] * y + m[10] * z + m[14] * w;
    out[3] = m[3] * x + m[7] * y + m[11] * z + m[15] * w;
    return out;
}
/**
 * Transforms the vec4 with a quat
 *
 * @param {vec4} out the receiving vector
 * @param {ReadonlyVec4} a the vector to transform
 * @param {ReadonlyQuat} q quaternion to transform with
 * @returns {vec4} out
 */
function vec4_transformQuat(out, a, q) {
    var x = a[0], y = a[1], z = a[2];
    var qx = q[0], qy = q[1], qz = q[2], qw = q[3]; // calculate quat * vec
    var ix = qw * x + qy * z - qz * y;
    var iy = qw * y + qz * x - qx * z;
    var iz = qw * z + qx * y - qy * x;
    var iw = -qx * x - qy * y - qz * z; // calculate result * inverse quat
    out[0] = ix * qw + iw * -qx + iy * -qz - iz * -qy;
    out[1] = iy * qw + iw * -qy + iz * -qx - ix * -qz;
    out[2] = iz * qw + iw * -qz + ix * -qy - iy * -qx;
    out[3] = a[3];
    return out;
}
/**
 * Set the components of a vec4 to zero
 *
 * @param {vec4} out the receiving vector
 * @returns {vec4} out
 */
function vec4_zero(out) {
    out[0] = 0.0;
    out[1] = 0.0;
    out[2] = 0.0;
    out[3] = 0.0;
    return out;
}
/**
 * Returns a string representation of a vector
 *
 * @param {ReadonlyVec4} a vector to represent as a string
 * @returns {String} string representation of the vector
 */
function vec4_str(a) {
    return "vec4(" + a[0] + ", " + a[1] + ", " + a[2] + ", " + a[3] + ")";
}
/**
 * Returns whether or not the vectors have exactly the same elements in the same position (when compared with ===)
 *
 * @param {ReadonlyVec4} a The first vector.
 * @param {ReadonlyVec4} b The second vector.
 * @returns {Boolean} True if the vectors are equal, false otherwise.
 */
function vec4_exactEquals(a, b) {
    return a[0] === b[0] && a[1] === b[1] && a[2] === b[2] && a[3] === b[3];
}
/**
 * Returns whether or not the vectors have approximately the same elements in the same position.
 *
 * @param {ReadonlyVec4} a The first vector.
 * @param {ReadonlyVec4} b The second vector.
 * @returns {Boolean} True if the vectors are equal, false otherwise.
 */
function vec4_equals(a, b) {
    var a0 = a[0], a1 = a[1], a2 = a[2], a3 = a[3];
    var b0 = b[0], b1 = b[1], b2 = b[2], b3 = b[3];
    return Math.abs(a0 - b0) <= EPSILON * Math.max(1.0, Math.abs(a0), Math.abs(b0)) && Math.abs(a1 - b1) <= EPSILON * Math.max(1.0, Math.abs(a1), Math.abs(b1)) && Math.abs(a2 - b2) <= EPSILON * Math.max(1.0, Math.abs(a2), Math.abs(b2)) && Math.abs(a3 - b3) <= EPSILON * Math.max(1.0, Math.abs(a3), Math.abs(b3));
}
/**
 * Alias for {@link vec4.subtract}
 * @function
 */
var vec4_sub = ( /* unused pure expression or super */null && (vec4_subtract));
/**
 * Alias for {@link vec4.multiply}
 * @function
 */
var vec4_mul = ( /* unused pure expression or super */null && (vec4_multiply));
/**
 * Alias for {@link vec4.divide}
 * @function
 */
var vec4_div = ( /* unused pure expression or super */null && (vec4_divide));
/**
 * Alias for {@link vec4.distance}
 * @function
 */
var vec4_dist = ( /* unused pure expression or super */null && (vec4_distance));
/**
 * Alias for {@link vec4.squaredDistance}
 * @function
 */
var vec4_sqrDist = ( /* unused pure expression or super */null && (vec4_squaredDistance));
/**
 * Alias for {@link vec4.length}
 * @function
 */
var vec4_len = ( /* unused pure expression or super */null && (vec4_length));
/**
 * Alias for {@link vec4.squaredLength}
 * @function
 */
var vec4_sqrLen = ( /* unused pure expression or super */null && (vec4_squaredLength));
/**
 * Perform some operation over an array of vec4s.
 *
 * @param {Array} a the array of vectors to iterate over
 * @param {Number} stride Number of elements between the start of each vec4. If 0 assumes tightly packed
 * @param {Number} offset Number of elements to skip at the beginning of the array
 * @param {Number} count Number of vec4s to iterate over. If 0 iterates over entire array
 * @param {Function} fn Function to call for each vector in the array
 * @param {Object} [arg] additional argument to pass to fn
 * @returns {Array} a
 * @function
 */
var vec4_forEach = function () {
    var vec = vec4_create();
    return function (a, stride, offset, count, fn, arg) {
        var i, l;
        if (!stride) {
            stride = 4;
        }
        if (!offset) {
            offset = 0;
        }
        if (count) {
            l = Math.min(count * stride + offset, a.length);
        }
        else {
            l = a.length;
        }
        for (i = offset; i < l; i += stride) {
            vec[0] = a[i];
            vec[1] = a[i + 1];
            vec[2] = a[i + 2];
            vec[3] = a[i + 3];
            fn(vec, vec, arg);
            a[i] = vec[0];
            a[i + 1] = vec[1];
            a[i + 2] = vec[2];
            a[i + 3] = vec[3];
        }
        return a;
    };
}();
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/classes/matrix4.js
var matrix4_INDICES;
(function (INDICES) {
    INDICES[INDICES["COL0ROW0"] = 0] = "COL0ROW0";
    INDICES[INDICES["COL0ROW1"] = 1] = "COL0ROW1";
    INDICES[INDICES["COL0ROW2"] = 2] = "COL0ROW2";
    INDICES[INDICES["COL0ROW3"] = 3] = "COL0ROW3";
    INDICES[INDICES["COL1ROW0"] = 4] = "COL1ROW0";
    INDICES[INDICES["COL1ROW1"] = 5] = "COL1ROW1";
    INDICES[INDICES["COL1ROW2"] = 6] = "COL1ROW2";
    INDICES[INDICES["COL1ROW3"] = 7] = "COL1ROW3";
    INDICES[INDICES["COL2ROW0"] = 8] = "COL2ROW0";
    INDICES[INDICES["COL2ROW1"] = 9] = "COL2ROW1";
    INDICES[INDICES["COL2ROW2"] = 10] = "COL2ROW2";
    INDICES[INDICES["COL2ROW3"] = 11] = "COL2ROW3";
    INDICES[INDICES["COL3ROW0"] = 12] = "COL3ROW0";
    INDICES[INDICES["COL3ROW1"] = 13] = "COL3ROW1";
    INDICES[INDICES["COL3ROW2"] = 14] = "COL3ROW2";
    INDICES[INDICES["COL3ROW3"] = 15] = "COL3ROW3";
})(matrix4_INDICES || (matrix4_INDICES = {}));
const DEFAULT_FOVY = 45 * Math.PI / 180;
const DEFAULT_ASPECT = 1;
const DEFAULT_NEAR = 0.1;
const DEFAULT_FAR = 500;
const matrix4_IDENTITY_MATRIX = Object.freeze([1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1]);
class Matrix4 extends Matrix {
    static get IDENTITY() {
        return matrix4_getIdentityMatrix();
    }
    static get ZERO() {
        return matrix4_getZeroMatrix();
    }
    get ELEMENTS() {
        return 16;
    }
    get RANK() {
        return 4;
    }
    get INDICES() {
        return matrix4_INDICES;
    }
    constructor(array) {
        super(-0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0);
        if (arguments.length === 1 && Array.isArray(array)) {
            this.copy(array);
        }
        else {
            this.identity();
        }
    }
    copy(array) {
        this[0] = array[0];
        this[1] = array[1];
        this[2] = array[2];
        this[3] = array[3];
        this[4] = array[4];
        this[5] = array[5];
        this[6] = array[6];
        this[7] = array[7];
        this[8] = array[8];
        this[9] = array[9];
        this[10] = array[10];
        this[11] = array[11];
        this[12] = array[12];
        this[13] = array[13];
        this[14] = array[14];
        this[15] = array[15];
        return this.check();
    }
    set(m00, m10, m20, m30, m01, m11, m21, m31, m02, m12, m22, m32, m03, m13, m23, m33) {
        this[0] = m00;
        this[1] = m10;
        this[2] = m20;
        this[3] = m30;
        this[4] = m01;
        this[5] = m11;
        this[6] = m21;
        this[7] = m31;
        this[8] = m02;
        this[9] = m12;
        this[10] = m22;
        this[11] = m32;
        this[12] = m03;
        this[13] = m13;
        this[14] = m23;
        this[15] = m33;
        return this.check();
    }
    setRowMajor(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33) {
        this[0] = m00;
        this[1] = m10;
        this[2] = m20;
        this[3] = m30;
        this[4] = m01;
        this[5] = m11;
        this[6] = m21;
        this[7] = m31;
        this[8] = m02;
        this[9] = m12;
        this[10] = m22;
        this[11] = m32;
        this[12] = m03;
        this[13] = m13;
        this[14] = m23;
        this[15] = m33;
        return this.check();
    }
    toRowMajor(result) {
        result[0] = this[0];
        result[1] = this[4];
        result[2] = this[8];
        result[3] = this[12];
        result[4] = this[1];
        result[5] = this[5];
        result[6] = this[9];
        result[7] = this[13];
        result[8] = this[2];
        result[9] = this[6];
        result[10] = this[10];
        result[11] = this[14];
        result[12] = this[3];
        result[13] = this[7];
        result[14] = this[11];
        result[15] = this[15];
        return result;
    }
    identity() {
        return this.copy(matrix4_IDENTITY_MATRIX);
    }
    fromObject(object) {
        return this.check();
    }
    fromQuaternion(quaternion) {
        mat4_fromQuat(this, quaternion);
        return this.check();
    }
    frustum(view) {
        const { left, right, bottom, top, near = DEFAULT_NEAR, far = DEFAULT_FAR } = view;
        if (far === Infinity) {
            computeInfinitePerspectiveOffCenter(this, left, right, bottom, top, near);
        }
        else {
            frustum(this, left, right, bottom, top, near, far);
        }
        return this.check();
    }
    lookAt(view) {
        const { eye, center = [0, 0, 0], up = [0, 1, 0] } = view;
        lookAt(this, eye, center, up);
        return this.check();
    }
    ortho(view) {
        const { left, right, bottom, top, near = DEFAULT_NEAR, far = DEFAULT_FAR } = view;
        ortho(this, left, right, bottom, top, near, far);
        return this.check();
    }
    orthographic(view) {
        const { fovy = DEFAULT_FOVY, aspect = DEFAULT_ASPECT, focalDistance = 1, near = DEFAULT_NEAR, far = DEFAULT_FAR } = view;
        checkRadians(fovy);
        const halfY = fovy / 2;
        const top = focalDistance * Math.tan(halfY);
        const right = top * aspect;
        return this.ortho({
            left: -right,
            right,
            bottom: -top,
            top,
            near,
            far
        });
    }
    perspective(view) {
        const { fovy = 45 * Math.PI / 180, aspect = 1, near = 0.1, far = 500 } = view;
        checkRadians(fovy);
        perspective(this, fovy, aspect, near, far);
        return this.check();
    }
    determinant() {
        return mat4_determinant(this);
    }
    getScale(result = [-0, -0, -0]) {
        result[0] = Math.sqrt(this[0] * this[0] + this[1] * this[1] + this[2] * this[2]);
        result[1] = Math.sqrt(this[4] * this[4] + this[5] * this[5] + this[6] * this[6]);
        result[2] = Math.sqrt(this[8] * this[8] + this[9] * this[9] + this[10] * this[10]);
        return result;
    }
    getTranslation(result = [-0, -0, -0]) {
        result[0] = this[12];
        result[1] = this[13];
        result[2] = this[14];
        return result;
    }
    getRotation(result, scaleResult) {
        result = result || [-0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0];
        scaleResult = scaleResult || [-0, -0, -0];
        const scale = this.getScale(scaleResult);
        const inverseScale0 = 1 / scale[0];
        const inverseScale1 = 1 / scale[1];
        const inverseScale2 = 1 / scale[2];
        result[0] = this[0] * inverseScale0;
        result[1] = this[1] * inverseScale1;
        result[2] = this[2] * inverseScale2;
        result[3] = 0;
        result[4] = this[4] * inverseScale0;
        result[5] = this[5] * inverseScale1;
        result[6] = this[6] * inverseScale2;
        result[7] = 0;
        result[8] = this[8] * inverseScale0;
        result[9] = this[9] * inverseScale1;
        result[10] = this[10] * inverseScale2;
        result[11] = 0;
        result[12] = 0;
        result[13] = 0;
        result[14] = 0;
        result[15] = 1;
        return result;
    }
    getRotationMatrix3(result, scaleResult) {
        result = result || [-0, -0, -0, -0, -0, -0, -0, -0, -0];
        scaleResult = scaleResult || [-0, -0, -0];
        const scale = this.getScale(scaleResult);
        const inverseScale0 = 1 / scale[0];
        const inverseScale1 = 1 / scale[1];
        const inverseScale2 = 1 / scale[2];
        result[0] = this[0] * inverseScale0;
        result[1] = this[1] * inverseScale1;
        result[2] = this[2] * inverseScale2;
        result[3] = this[4] * inverseScale0;
        result[4] = this[5] * inverseScale1;
        result[5] = this[6] * inverseScale2;
        result[6] = this[8] * inverseScale0;
        result[7] = this[9] * inverseScale1;
        result[8] = this[10] * inverseScale2;
        return result;
    }
    transpose() {
        mat4_transpose(this, this);
        return this.check();
    }
    invert() {
        mat4_invert(this, this);
        return this.check();
    }
    multiplyLeft(a) {
        mat4_multiply(this, a, this);
        return this.check();
    }
    multiplyRight(a) {
        mat4_multiply(this, this, a);
        return this.check();
    }
    rotateX(radians) {
        mat4_rotateX(this, this, radians);
        return this.check();
    }
    rotateY(radians) {
        mat4_rotateY(this, this, radians);
        return this.check();
    }
    rotateZ(radians) {
        mat4_rotateZ(this, this, radians);
        return this.check();
    }
    rotateXYZ(angleXYZ) {
        return this.rotateX(angleXYZ[0]).rotateY(angleXYZ[1]).rotateZ(angleXYZ[2]);
    }
    rotateAxis(radians, axis) {
        mat4_rotate(this, this, radians, axis);
        return this.check();
    }
    scale(factor) {
        mat4_scale(this, this, Array.isArray(factor) ? factor : [factor, factor, factor]);
        return this.check();
    }
    translate(vector) {
        mat4_translate(this, this, vector);
        return this.check();
    }
    transform(vector, result) {
        if (vector.length === 4) {
            result = vec4_transformMat4(result || [-0, -0, -0, -0], vector, this);
            checkVector(result, 4);
            return result;
        }
        return this.transformAsPoint(vector, result);
    }
    transformAsPoint(vector, result) {
        const { length } = vector;
        let out;
        switch (length) {
            case 2:
                out = transformMat4(result || [-0, -0], vector, this);
                break;
            case 3:
                out = vec3_transformMat4(result || [-0, -0, -0], vector, this);
                break;
            default:
                throw new Error('Illegal vector');
        }
        checkVector(out, vector.length);
        return out;
    }
    transformAsVector(vector, result) {
        let out;
        switch (vector.length) {
            case 2:
                out = vec2_transformMat4AsVector(result || [-0, -0], vector, this);
                break;
            case 3:
                out = vec3_transformMat4AsVector(result || [-0, -0, -0], vector, this);
                break;
            default:
                throw new Error('Illegal vector');
        }
        checkVector(out, vector.length);
        return out;
    }
    transformPoint(vector, result) {
        return this.transformAsPoint(vector, result);
    }
    transformVector(vector, result) {
        return this.transformAsPoint(vector, result);
    }
    transformDirection(vector, result) {
        return this.transformAsVector(vector, result);
    }
    makeRotationX(radians) {
        return this.identity().rotateX(radians);
    }
    makeTranslation(x, y, z) {
        return this.identity().translate([x, y, z]);
    }
}
let matrix4_ZERO;
let IDENTITY;
function matrix4_getZeroMatrix() {
    if (!matrix4_ZERO) {
        matrix4_ZERO = new Matrix4([0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]);
        Object.freeze(matrix4_ZERO);
    }
    return matrix4_ZERO;
}
function matrix4_getIdentityMatrix() {
    if (!IDENTITY) {
        IDENTITY = new Matrix4();
        Object.freeze(IDENTITY);
    }
    return IDENTITY;
}
function checkRadians(possiblyDegrees) {
    if (possiblyDegrees > Math.PI * 2) {
        throw Error('expected radians');
    }
}
function computeInfinitePerspectiveOffCenter(result, left, right, bottom, top, near) {
    const column0Row0 = 2 * near / (right - left);
    const column1Row1 = 2 * near / (top - bottom);
    const column2Row0 = (right + left) / (right - left);
    const column2Row1 = (top + bottom) / (top - bottom);
    const column2Row2 = -1;
    const column2Row3 = -1;
    const column3Row2 = -2 * near;
    result[0] = column0Row0;
    result[1] = 0;
    result[2] = 0;
    result[3] = 0;
    result[4] = 0;
    result[5] = column1Row1;
    result[6] = 0;
    result[7] = 0;
    result[8] = column2Row0;
    result[9] = column2Row1;
    result[10] = column2Row2;
    result[11] = column2Row3;
    result[12] = 0;
    result[13] = 0;
    result[14] = column3Row2;
    result[15] = 0;
    return result;
}
//# sourceMappingURL=matrix4.js.map
; // CONCATENATED MODULE: ./node_modules/gl-matrix/esm/quat.js
/**
 * Quaternion
 * @module quat
 */
/**
 * Creates a new identity quat
 *
 * @returns {quat} a new quaternion
 */
function quat_create() {
    var out = new ARRAY_TYPE(4);
    if (ARRAY_TYPE != Float32Array) {
        out[0] = 0;
        out[1] = 0;
        out[2] = 0;
    }
    out[3] = 1;
    return out;
}
/**
 * Set a quat to the identity quaternion
 *
 * @param {quat} out the receiving quaternion
 * @returns {quat} out
 */
function quat_identity(out) {
    out[0] = 0;
    out[1] = 0;
    out[2] = 0;
    out[3] = 1;
    return out;
}
/**
 * Sets a quat from the given angle and rotation axis,
 * then returns it.
 *
 * @param {quat} out the receiving quaternion
 * @param {ReadonlyVec3} axis the axis around which to rotate
 * @param {Number} rad the angle in radians
 * @returns {quat} out
 **/
function setAxisAngle(out, axis, rad) {
    rad = rad * 0.5;
    var s = Math.sin(rad);
    out[0] = s * axis[0];
    out[1] = s * axis[1];
    out[2] = s * axis[2];
    out[3] = Math.cos(rad);
    return out;
}
/**
 * Gets the rotation axis and angle for a given
 *  quaternion. If a quaternion is created with
 *  setAxisAngle, this method will return the same
 *  values as providied in the original parameter list
 *  OR functionally equivalent values.
 * Example: The quaternion formed by axis [0, 0, 1] and
 *  angle -90 is the same as the quaternion formed by
 *  [0, 0, 1] and 270. This method favors the latter.
 * @param  {vec3} out_axis  Vector receiving the axis of rotation
 * @param  {ReadonlyQuat} q     Quaternion to be decomposed
 * @return {Number}     Angle, in radians, of the rotation
 */
function getAxisAngle(out_axis, q) {
    var rad = Math.acos(q[3]) * 2.0;
    var s = Math.sin(rad / 2.0);
    if (s > glMatrix.EPSILON) {
        out_axis[0] = q[0] / s;
        out_axis[1] = q[1] / s;
        out_axis[2] = q[2] / s;
    }
    else {
        // If s is zero, return any axis (no rotation - axis does not matter)
        out_axis[0] = 1;
        out_axis[1] = 0;
        out_axis[2] = 0;
    }
    return rad;
}
/**
 * Gets the angular distance between two unit quaternions
 *
 * @param  {ReadonlyQuat} a     Origin unit quaternion
 * @param  {ReadonlyQuat} b     Destination unit quaternion
 * @return {Number}     Angle, in radians, between the two quaternions
 */
function getAngle(a, b) {
    var dotproduct = quat_dot(a, b);
    return Math.acos(2 * dotproduct * dotproduct - 1);
}
/**
 * Multiplies two quat's
 *
 * @param {quat} out the receiving quaternion
 * @param {ReadonlyQuat} a the first operand
 * @param {ReadonlyQuat} b the second operand
 * @returns {quat} out
 */
function quat_multiply(out, a, b) {
    var ax = a[0], ay = a[1], az = a[2], aw = a[3];
    var bx = b[0], by = b[1], bz = b[2], bw = b[3];
    out[0] = ax * bw + aw * bx + ay * bz - az * by;
    out[1] = ay * bw + aw * by + az * bx - ax * bz;
    out[2] = az * bw + aw * bz + ax * by - ay * bx;
    out[3] = aw * bw - ax * bx - ay * by - az * bz;
    return out;
}
/**
 * Rotates a quaternion by the given angle about the X axis
 *
 * @param {quat} out quat receiving operation result
 * @param {ReadonlyQuat} a quat to rotate
 * @param {number} rad angle (in radians) to rotate
 * @returns {quat} out
 */
function quat_rotateX(out, a, rad) {
    rad *= 0.5;
    var ax = a[0], ay = a[1], az = a[2], aw = a[3];
    var bx = Math.sin(rad), bw = Math.cos(rad);
    out[0] = ax * bw + aw * bx;
    out[1] = ay * bw + az * bx;
    out[2] = az * bw - ay * bx;
    out[3] = aw * bw - ax * bx;
    return out;
}
/**
 * Rotates a quaternion by the given angle about the Y axis
 *
 * @param {quat} out quat receiving operation result
 * @param {ReadonlyQuat} a quat to rotate
 * @param {number} rad angle (in radians) to rotate
 * @returns {quat} out
 */
function quat_rotateY(out, a, rad) {
    rad *= 0.5;
    var ax = a[0], ay = a[1], az = a[2], aw = a[3];
    var by = Math.sin(rad), bw = Math.cos(rad);
    out[0] = ax * bw - az * by;
    out[1] = ay * bw + aw * by;
    out[2] = az * bw + ax * by;
    out[3] = aw * bw - ay * by;
    return out;
}
/**
 * Rotates a quaternion by the given angle about the Z axis
 *
 * @param {quat} out quat receiving operation result
 * @param {ReadonlyQuat} a quat to rotate
 * @param {number} rad angle (in radians) to rotate
 * @returns {quat} out
 */
function quat_rotateZ(out, a, rad) {
    rad *= 0.5;
    var ax = a[0], ay = a[1], az = a[2], aw = a[3];
    var bz = Math.sin(rad), bw = Math.cos(rad);
    out[0] = ax * bw + ay * bz;
    out[1] = ay * bw - ax * bz;
    out[2] = az * bw + aw * bz;
    out[3] = aw * bw - az * bz;
    return out;
}
/**
 * Calculates the W component of a quat from the X, Y, and Z components.
 * Assumes that quaternion is 1 unit in length.
 * Any existing W component will be ignored.
 *
 * @param {quat} out the receiving quaternion
 * @param {ReadonlyQuat} a quat to calculate W component of
 * @returns {quat} out
 */
function calculateW(out, a) {
    var x = a[0], y = a[1], z = a[2];
    out[0] = x;
    out[1] = y;
    out[2] = z;
    out[3] = Math.sqrt(Math.abs(1.0 - x * x - y * y - z * z));
    return out;
}
/**
 * Calculate the exponential of a unit quaternion.
 *
 * @param {quat} out the receiving quaternion
 * @param {ReadonlyQuat} a quat to calculate the exponential of
 * @returns {quat} out
 */
function exp(out, a) {
    var x = a[0], y = a[1], z = a[2], w = a[3];
    var r = Math.sqrt(x * x + y * y + z * z);
    var et = Math.exp(w);
    var s = r > 0 ? et * Math.sin(r) / r : 0;
    out[0] = x * s;
    out[1] = y * s;
    out[2] = z * s;
    out[3] = et * Math.cos(r);
    return out;
}
/**
 * Calculate the natural logarithm of a unit quaternion.
 *
 * @param {quat} out the receiving quaternion
 * @param {ReadonlyQuat} a quat to calculate the exponential of
 * @returns {quat} out
 */
function ln(out, a) {
    var x = a[0], y = a[1], z = a[2], w = a[3];
    var r = Math.sqrt(x * x + y * y + z * z);
    var t = r > 0 ? Math.atan2(r, w) / r : 0;
    out[0] = x * t;
    out[1] = y * t;
    out[2] = z * t;
    out[3] = 0.5 * Math.log(x * x + y * y + z * z + w * w);
    return out;
}
/**
 * Calculate the scalar power of a unit quaternion.
 *
 * @param {quat} out the receiving quaternion
 * @param {ReadonlyQuat} a quat to calculate the exponential of
 * @param {Number} b amount to scale the quaternion by
 * @returns {quat} out
 */
function pow(out, a, b) {
    ln(out, a);
    quat_scale(out, out, b);
    exp(out, out);
    return out;
}
/**
 * Performs a spherical linear interpolation between two quat
 *
 * @param {quat} out the receiving quaternion
 * @param {ReadonlyQuat} a the first operand
 * @param {ReadonlyQuat} b the second operand
 * @param {Number} t interpolation amount, in the range [0-1], between the two inputs
 * @returns {quat} out
 */
function slerp(out, a, b, t) {
    // benchmarks:
    //    http://jsperf.com/quaternion-slerp-implementations
    var ax = a[0], ay = a[1], az = a[2], aw = a[3];
    var bx = b[0], by = b[1], bz = b[2], bw = b[3];
    var omega, cosom, sinom, scale0, scale1; // calc cosine
    cosom = ax * bx + ay * by + az * bz + aw * bw; // adjust signs (if necessary)
    if (cosom < 0.0) {
        cosom = -cosom;
        bx = -bx;
        by = -by;
        bz = -bz;
        bw = -bw;
    } // calculate coefficients
    if (1.0 - cosom > EPSILON) {
        // standard case (slerp)
        omega = Math.acos(cosom);
        sinom = Math.sin(omega);
        scale0 = Math.sin((1.0 - t) * omega) / sinom;
        scale1 = Math.sin(t * omega) / sinom;
    }
    else {
        // "from" and "to" quaternions are very close
        //  ... so we can do a linear interpolation
        scale0 = 1.0 - t;
        scale1 = t;
    } // calculate final values
    out[0] = scale0 * ax + scale1 * bx;
    out[1] = scale0 * ay + scale1 * by;
    out[2] = scale0 * az + scale1 * bz;
    out[3] = scale0 * aw + scale1 * bw;
    return out;
}
/**
 * Generates a random unit quaternion
 *
 * @param {quat} out the receiving quaternion
 * @returns {quat} out
 */
function quat_random(out) {
    // Implementation of http://planning.cs.uiuc.edu/node198.html
    // TODO: Calling random 3 times is probably not the fastest solution
    var u1 = glMatrix.RANDOM();
    var u2 = glMatrix.RANDOM();
    var u3 = glMatrix.RANDOM();
    var sqrt1MinusU1 = Math.sqrt(1 - u1);
    var sqrtU1 = Math.sqrt(u1);
    out[0] = sqrt1MinusU1 * Math.sin(2.0 * Math.PI * u2);
    out[1] = sqrt1MinusU1 * Math.cos(2.0 * Math.PI * u2);
    out[2] = sqrtU1 * Math.sin(2.0 * Math.PI * u3);
    out[3] = sqrtU1 * Math.cos(2.0 * Math.PI * u3);
    return out;
}
/**
 * Calculates the inverse of a quat
 *
 * @param {quat} out the receiving quaternion
 * @param {ReadonlyQuat} a quat to calculate inverse of
 * @returns {quat} out
 */
function quat_invert(out, a) {
    var a0 = a[0], a1 = a[1], a2 = a[2], a3 = a[3];
    var dot = a0 * a0 + a1 * a1 + a2 * a2 + a3 * a3;
    var invDot = dot ? 1.0 / dot : 0; // TODO: Would be faster to return [0,0,0,0] immediately if dot == 0
    out[0] = -a0 * invDot;
    out[1] = -a1 * invDot;
    out[2] = -a2 * invDot;
    out[3] = a3 * invDot;
    return out;
}
/**
 * Calculates the conjugate of a quat
 * If the quaternion is normalized, this function is faster than quat.inverse and produces the same result.
 *
 * @param {quat} out the receiving quaternion
 * @param {ReadonlyQuat} a quat to calculate conjugate of
 * @returns {quat} out
 */
function conjugate(out, a) {
    out[0] = -a[0];
    out[1] = -a[1];
    out[2] = -a[2];
    out[3] = a[3];
    return out;
}
/**
 * Creates a quaternion from the given 3x3 rotation matrix.
 *
 * NOTE: The resultant quaternion is not normalized, so you should be sure
 * to renormalize the quaternion yourself where necessary.
 *
 * @param {quat} out the receiving quaternion
 * @param {ReadonlyMat3} m rotation matrix
 * @returns {quat} out
 * @function
 */
function fromMat3(out, m) {
    // Algorithm in Ken Shoemake's article in 1987 SIGGRAPH course notes
    // article "Quaternion Calculus and Fast Animation".
    var fTrace = m[0] + m[4] + m[8];
    var fRoot;
    if (fTrace > 0.0) {
        // |w| > 1/2, may as well choose w > 1/2
        fRoot = Math.sqrt(fTrace + 1.0); // 2w
        out[3] = 0.5 * fRoot;
        fRoot = 0.5 / fRoot; // 1/(4w)
        out[0] = (m[5] - m[7]) * fRoot;
        out[1] = (m[6] - m[2]) * fRoot;
        out[2] = (m[1] - m[3]) * fRoot;
    }
    else {
        // |w| <= 1/2
        var i = 0;
        if (m[4] > m[0])
            i = 1;
        if (m[8] > m[i * 3 + i])
            i = 2;
        var j = (i + 1) % 3;
        var k = (i + 2) % 3;
        fRoot = Math.sqrt(m[i * 3 + i] - m[j * 3 + j] - m[k * 3 + k] + 1.0);
        out[i] = 0.5 * fRoot;
        fRoot = 0.5 / fRoot;
        out[3] = (m[j * 3 + k] - m[k * 3 + j]) * fRoot;
        out[j] = (m[j * 3 + i] + m[i * 3 + j]) * fRoot;
        out[k] = (m[k * 3 + i] + m[i * 3 + k]) * fRoot;
    }
    return out;
}
/**
 * Creates a quaternion from the given euler angle x, y, z.
 *
 * @param {quat} out the receiving quaternion
 * @param {x} Angle to rotate around X axis in degrees.
 * @param {y} Angle to rotate around Y axis in degrees.
 * @param {z} Angle to rotate around Z axis in degrees.
 * @returns {quat} out
 * @function
 */
function fromEuler(out, x, y, z) {
    var halfToRad = 0.5 * Math.PI / 180.0;
    x *= halfToRad;
    y *= halfToRad;
    z *= halfToRad;
    var sx = Math.sin(x);
    var cx = Math.cos(x);
    var sy = Math.sin(y);
    var cy = Math.cos(y);
    var sz = Math.sin(z);
    var cz = Math.cos(z);
    out[0] = sx * cy * cz - cx * sy * sz;
    out[1] = cx * sy * cz + sx * cy * sz;
    out[2] = cx * cy * sz - sx * sy * cz;
    out[3] = cx * cy * cz + sx * sy * sz;
    return out;
}
/**
 * Returns a string representation of a quatenion
 *
 * @param {ReadonlyQuat} a vector to represent as a string
 * @returns {String} string representation of the vector
 */
function quat_str(a) {
    return "quat(" + a[0] + ", " + a[1] + ", " + a[2] + ", " + a[3] + ")";
}
/**
 * Creates a new quat initialized with values from an existing quaternion
 *
 * @param {ReadonlyQuat} a quaternion to clone
 * @returns {quat} a new quaternion
 * @function
 */
var quat_clone = vec4_clone;
/**
 * Creates a new quat initialized with the given values
 *
 * @param {Number} x X component
 * @param {Number} y Y component
 * @param {Number} z Z component
 * @param {Number} w W component
 * @returns {quat} a new quaternion
 * @function
 */
var quat_fromValues = vec4_fromValues;
/**
 * Copy the values from one quat to another
 *
 * @param {quat} out the receiving quaternion
 * @param {ReadonlyQuat} a the source quaternion
 * @returns {quat} out
 * @function
 */
var quat_copy = vec4_copy;
/**
 * Set the components of a quat to the given values
 *
 * @param {quat} out the receiving quaternion
 * @param {Number} x X component
 * @param {Number} y Y component
 * @param {Number} z Z component
 * @param {Number} w W component
 * @returns {quat} out
 * @function
 */
var quat_set = vec4_set;
/**
 * Adds two quat's
 *
 * @param {quat} out the receiving quaternion
 * @param {ReadonlyQuat} a the first operand
 * @param {ReadonlyQuat} b the second operand
 * @returns {quat} out
 * @function
 */
var quat_add = vec4_add;
/**
 * Alias for {@link quat.multiply}
 * @function
 */
var quat_mul = ( /* unused pure expression or super */null && (quat_multiply));
/**
 * Scales a quat by a scalar number
 *
 * @param {quat} out the receiving vector
 * @param {ReadonlyQuat} a the vector to scale
 * @param {Number} b amount to scale the vector by
 * @returns {quat} out
 * @function
 */
var quat_scale = vec4_scale;
/**
 * Calculates the dot product of two quat's
 *
 * @param {ReadonlyQuat} a the first operand
 * @param {ReadonlyQuat} b the second operand
 * @returns {Number} dot product of a and b
 * @function
 */
var quat_dot = vec4_dot;
/**
 * Performs a linear interpolation between two quat's
 *
 * @param {quat} out the receiving quaternion
 * @param {ReadonlyQuat} a the first operand
 * @param {ReadonlyQuat} b the second operand
 * @param {Number} t interpolation amount, in the range [0-1], between the two inputs
 * @returns {quat} out
 * @function
 */
var quat_lerp = vec4_lerp;
/**
 * Calculates the length of a quat
 *
 * @param {ReadonlyQuat} a vector to calculate length of
 * @returns {Number} length of a
 */
var quat_length = vec4_length;
/**
 * Alias for {@link quat.length}
 * @function
 */
var quat_len = ( /* unused pure expression or super */null && (quat_length));
/**
 * Calculates the squared length of a quat
 *
 * @param {ReadonlyQuat} a vector to calculate squared length of
 * @returns {Number} squared length of a
 * @function
 */
var quat_squaredLength = vec4_squaredLength;
/**
 * Alias for {@link quat.squaredLength}
 * @function
 */
var quat_sqrLen = ( /* unused pure expression or super */null && (quat_squaredLength));
/**
 * Normalize a quat
 *
 * @param {quat} out the receiving quaternion
 * @param {ReadonlyQuat} a quaternion to normalize
 * @returns {quat} out
 * @function
 */
var quat_normalize = vec4_normalize;
/**
 * Returns whether or not the quaternions have exactly the same elements in the same position (when compared with ===)
 *
 * @param {ReadonlyQuat} a The first quaternion.
 * @param {ReadonlyQuat} b The second quaternion.
 * @returns {Boolean} True if the vectors are equal, false otherwise.
 */
var quat_exactEquals = vec4_exactEquals;
/**
 * Returns whether or not the quaternions have approximately the same elements in the same position.
 *
 * @param {ReadonlyQuat} a The first vector.
 * @param {ReadonlyQuat} b The second vector.
 * @returns {Boolean} True if the vectors are equal, false otherwise.
 */
var quat_equals = vec4_equals;
/**
 * Sets a quaternion to represent the shortest rotation from one
 * vector to another.
 *
 * Both vectors are assumed to be unit length.
 *
 * @param {quat} out the receiving quaternion.
 * @param {ReadonlyVec3} a the initial vector
 * @param {ReadonlyVec3} b the destination vector
 * @returns {quat} out
 */
var rotationTo = function () {
    var tmpvec3 = vec3_create();
    var xUnitVec3 = vec3_fromValues(1, 0, 0);
    var yUnitVec3 = vec3_fromValues(0, 1, 0);
    return function (out, a, b) {
        var dot = vec3_dot(a, b);
        if (dot < -0.999999) {
            vec3_cross(tmpvec3, xUnitVec3, a);
            if (vec3_len(tmpvec3) < 0.000001)
                vec3_cross(tmpvec3, yUnitVec3, a);
            vec3_normalize(tmpvec3, tmpvec3);
            setAxisAngle(out, tmpvec3, Math.PI);
            return out;
        }
        else if (dot > 0.999999) {
            out[0] = 0;
            out[1] = 0;
            out[2] = 0;
            out[3] = 1;
            return out;
        }
        else {
            vec3_cross(tmpvec3, a, b);
            out[0] = tmpvec3[0];
            out[1] = tmpvec3[1];
            out[2] = tmpvec3[2];
            out[3] = 1 + dot;
            return quat_normalize(out, out);
        }
    };
}();
/**
 * Performs a spherical linear interpolation with two control points
 *
 * @param {quat} out the receiving quaternion
 * @param {ReadonlyQuat} a the first operand
 * @param {ReadonlyQuat} b the second operand
 * @param {ReadonlyQuat} c the third operand
 * @param {ReadonlyQuat} d the fourth operand
 * @param {Number} t interpolation amount, in the range [0-1], between the two inputs
 * @returns {quat} out
 */
var sqlerp = function () {
    var temp1 = quat_create();
    var temp2 = quat_create();
    return function (out, a, b, c, d, t) {
        slerp(temp1, a, d, t);
        slerp(temp2, b, c, t);
        slerp(out, temp1, temp2, 2 * t * (1 - t));
        return out;
    };
}();
/**
 * Sets the specified quaternion with values corresponding to the given
 * axes. Each axis is a vec3 and is expected to be unit length and
 * perpendicular to all other specified axes.
 *
 * @param {ReadonlyVec3} view  the vector representing the viewing direction
 * @param {ReadonlyVec3} right the vector representing the local "right" direction
 * @param {ReadonlyVec3} up    the vector representing the local "up" direction
 * @returns {quat} out
 */
var setAxes = function () {
    var matr = mat3_create();
    return function (out, view, right, up) {
        matr[0] = right[0];
        matr[3] = right[1];
        matr[6] = right[2];
        matr[1] = up[0];
        matr[4] = up[1];
        matr[7] = up[2];
        matr[2] = -view[0];
        matr[5] = -view[1];
        matr[8] = -view[2];
        return quat_normalize(out, fromMat3(out, matr));
    };
}();
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/classes/quaternion.js
const IDENTITY_QUATERNION = [0, 0, 0, 1];
class Quaternion extends MathArray {
    constructor(x = 0, y = 0, z = 0, w = 1) {
        super(-0, -0, -0, -0);
        if (Array.isArray(x) && arguments.length === 1) {
            this.copy(x);
        }
        else {
            this.set(x, y, z, w);
        }
    }
    copy(array) {
        this[0] = array[0];
        this[1] = array[1];
        this[2] = array[2];
        this[3] = array[3];
        return this.check();
    }
    set(x, y, z, w) {
        this[0] = x;
        this[1] = y;
        this[2] = z;
        this[3] = w;
        return this.check();
    }
    fromObject(object) {
        this[0] = object.x;
        this[1] = object.y;
        this[2] = object.z;
        this[3] = object.w;
        return this.check();
    }
    fromMatrix3(m) {
        fromMat3(this, m);
        return this.check();
    }
    fromAxisRotation(axis, rad) {
        setAxisAngle(this, axis, rad);
        return this.check();
    }
    identity() {
        quat_identity(this);
        return this.check();
    }
    setAxisAngle(axis, rad) {
        return this.fromAxisRotation(axis, rad);
    }
    get ELEMENTS() {
        return 4;
    }
    get x() {
        return this[0];
    }
    set x(value) {
        this[0] = checkNumber(value);
    }
    get y() {
        return this[1];
    }
    set y(value) {
        this[1] = checkNumber(value);
    }
    get z() {
        return this[2];
    }
    set z(value) {
        this[2] = checkNumber(value);
    }
    get w() {
        return this[3];
    }
    set w(value) {
        this[3] = checkNumber(value);
    }
    len() {
        return quat_length(this);
    }
    lengthSquared() {
        return quat_squaredLength(this);
    }
    dot(a) {
        return quat_dot(this, a);
    }
    rotationTo(vectorA, vectorB) {
        rotationTo(this, vectorA, vectorB);
        return this.check();
    }
    add(a) {
        quat_add(this, this, a);
        return this.check();
    }
    calculateW() {
        calculateW(this, this);
        return this.check();
    }
    conjugate() {
        conjugate(this, this);
        return this.check();
    }
    invert() {
        quat_invert(this, this);
        return this.check();
    }
    lerp(a, b, t) {
        if (t === undefined) {
            return this.lerp(this, a, b);
        }
        quat_lerp(this, a, b, t);
        return this.check();
    }
    multiplyRight(a) {
        quat_multiply(this, this, a);
        return this.check();
    }
    multiplyLeft(a) {
        quat_multiply(this, a, this);
        return this.check();
    }
    normalize() {
        const length = this.len();
        const l = length > 0 ? 1 / length : 0;
        this[0] = this[0] * l;
        this[1] = this[1] * l;
        this[2] = this[2] * l;
        this[3] = this[3] * l;
        if (length === 0) {
            this[3] = 1;
        }
        return this.check();
    }
    rotateX(rad) {
        quat_rotateX(this, this, rad);
        return this.check();
    }
    rotateY(rad) {
        quat_rotateY(this, this, rad);
        return this.check();
    }
    rotateZ(rad) {
        quat_rotateZ(this, this, rad);
        return this.check();
    }
    scale(b) {
        quat_scale(this, this, b);
        return this.check();
    }
    slerp(arg0, arg1, arg2) {
        let start;
        let target;
        let ratio;
        switch (arguments.length) {
            case 1:
                ({
                    start = IDENTITY_QUATERNION,
                    target,
                    ratio
                } = arg0);
                break;
            case 2:
                start = this;
                target = arg0;
                ratio = arg1;
                break;
            default:
                start = arg0;
                target = arg1;
                ratio = arg2;
        }
        slerp(this, start, target, ratio);
        return this.check();
    }
    transformVector4(vector, result = new Vector4()) {
        vec4_transformQuat(result, vector, this);
        return checkVector(result, 4);
    }
    lengthSq() {
        return this.lengthSquared();
    }
    setFromAxisAngle(axis, rad) {
        return this.setAxisAngle(axis, rad);
    }
    premultiply(a) {
        return this.multiplyLeft(a);
    }
    multiply(a) {
        return this.multiplyRight(a);
    }
}
//# sourceMappingURL=quaternion.js.map
; // CONCATENATED MODULE: ./node_modules/@babel/runtime/helpers/esm/typeof.js
function _typeof(obj) {
    "@babel/helpers - typeof";
    return _typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (obj) {
        return typeof obj;
    } : function (obj) {
        return obj && "function" == typeof Symbol && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj;
    }, _typeof(obj);
}
; // CONCATENATED MODULE: ./node_modules/@babel/runtime/helpers/esm/toPrimitive.js
function _toPrimitive(input, hint) {
    if (_typeof(input) !== "object" || input === null)
        return input;
    var prim = input[Symbol.toPrimitive];
    if (prim !== undefined) {
        var res = prim.call(input, hint || "default");
        if (_typeof(res) !== "object")
            return res;
        throw new TypeError("@@toPrimitive must return a primitive value.");
    }
    return (hint === "string" ? String : Number)(input);
}
; // CONCATENATED MODULE: ./node_modules/@babel/runtime/helpers/esm/toPropertyKey.js
function _toPropertyKey(arg) {
    var key = _toPrimitive(arg, "string");
    return _typeof(key) === "symbol" ? key : String(key);
}
; // CONCATENATED MODULE: ./node_modules/@babel/runtime/helpers/esm/defineProperty.js
function _defineProperty(obj, key, value) {
    key = _toPropertyKey(key);
    if (key in obj) {
        Object.defineProperty(obj, key, {
            value: value,
            enumerable: true,
            configurable: true,
            writable: true
        });
    }
    else {
        obj[key] = value;
    }
    return obj;
}
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/classes/spherical-coordinates.js
const spherical_coordinates_EPSILON = 0.000001;
const EARTH_RADIUS_METERS = 6371000;
class SphericalCoordinates {
    constructor({ phi = 0, theta = 0, radius = 1, bearing, pitch, altitude, radiusScale = EARTH_RADIUS_METERS } = {}) {
        _defineProperty(this, "phi", void 0);
        _defineProperty(this, "theta", void 0);
        _defineProperty(this, "radius", void 0);
        _defineProperty(this, "radiusScale", void 0);
        this.phi = phi;
        this.theta = theta;
        this.radius = radius || altitude || 1;
        this.radiusScale = radiusScale || 1;
        if (bearing !== undefined) {
            this.bearing = bearing;
        }
        if (pitch !== undefined) {
            this.pitch = pitch;
        }
        this.check();
    }
    toString() {
        return this.formatString(config);
    }
    formatString({ printTypes = false }) {
        const f = formatValue;
        return "".concat(printTypes ? 'Spherical' : '', "[rho:").concat(f(this.radius), ",theta:").concat(f(this.theta), ",phi:").concat(f(this.phi), "]");
    }
    equals(other) {
        return equals(this.radius, other.radius) && equals(this.theta, other.theta) && equals(this.phi, other.phi);
    }
    exactEquals(other) {
        return this.radius === other.radius && this.theta === other.theta && this.phi === other.phi;
    }
    get bearing() {
        return 180 - degrees(this.phi);
    }
    set bearing(v) {
        this.phi = Math.PI - radians(v);
    }
    get pitch() {
        return degrees(this.theta);
    }
    set pitch(v) {
        this.theta = radians(v);
    }
    get longitude() {
        return degrees(this.phi);
    }
    get latitude() {
        return degrees(this.theta);
    }
    get lng() {
        return degrees(this.phi);
    }
    get lat() {
        return degrees(this.theta);
    }
    get z() {
        return (this.radius - 1) * this.radiusScale;
    }
    set(radius, phi, theta) {
        this.radius = radius;
        this.phi = phi;
        this.theta = theta;
        return this.check();
    }
    clone() {
        return new SphericalCoordinates().copy(this);
    }
    copy(other) {
        this.radius = other.radius;
        this.phi = other.phi;
        this.theta = other.theta;
        return this.check();
    }
    fromLngLatZ([lng, lat, z]) {
        this.radius = 1 + z / this.radiusScale;
        this.phi = radians(lat);
        this.theta = radians(lng);
        return this.check();
    }
    fromVector3(v) {
        this.radius = vec3_length(v);
        if (this.radius > 0) {
            this.theta = Math.atan2(v[0], v[1]);
            this.phi = Math.acos(clamp(v[2] / this.radius, -1, 1));
        }
        return this.check();
    }
    toVector3() {
        return new Vector3(0, 0, this.radius).rotateX({
            radians: this.theta
        }).rotateZ({
            radians: this.phi
        });
    }
    makeSafe() {
        this.phi = Math.max(spherical_coordinates_EPSILON, Math.min(Math.PI - spherical_coordinates_EPSILON, this.phi));
        return this;
    }
    check() {
        if (!Number.isFinite(this.phi) || !Number.isFinite(this.theta) || !(this.radius > 0)) {
            throw new Error('SphericalCoordinates: some fields set to invalid numbers');
        }
        return this;
    }
}
//# sourceMappingURL=spherical-coordinates.js.map
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/classes/euler.js
const ERR_UNKNOWN_ORDER = 'Unknown Euler angle order';
const ALMOST_ONE = 0.99999;
var RotationOrder;
(function (RotationOrder) {
    RotationOrder[RotationOrder["ZYX"] = 0] = "ZYX";
    RotationOrder[RotationOrder["YXZ"] = 1] = "YXZ";
    RotationOrder[RotationOrder["XZY"] = 2] = "XZY";
    RotationOrder[RotationOrder["ZXY"] = 3] = "ZXY";
    RotationOrder[RotationOrder["YZX"] = 4] = "YZX";
    RotationOrder[RotationOrder["XYZ"] = 5] = "XYZ";
})(RotationOrder || (RotationOrder = {}));
class Euler extends MathArray {
    static get ZYX() {
        return RotationOrder.ZYX;
    }
    static get YXZ() {
        return RotationOrder.YXZ;
    }
    static get XZY() {
        return RotationOrder.XZY;
    }
    static get ZXY() {
        return RotationOrder.ZXY;
    }
    static get YZX() {
        return RotationOrder.YZX;
    }
    static get XYZ() {
        return RotationOrder.XYZ;
    }
    static get RollPitchYaw() {
        return RotationOrder.ZYX;
    }
    static get DefaultOrder() {
        return RotationOrder.ZYX;
    }
    static get RotationOrders() {
        return RotationOrder;
    }
    static rotationOrder(order) {
        return RotationOrder[order];
    }
    get ELEMENTS() {
        return 4;
    }
    constructor(x = 0, y = 0, z = 0, order = Euler.DefaultOrder) {
        super(-0, -0, -0, -0);
        if (arguments.length > 0 && Array.isArray(arguments[0])) {
            this.fromVector3(...arguments);
        }
        else {
            this.set(x, y, z, order);
        }
    }
    fromQuaternion(quaternion) {
        const [x, y, z, w] = quaternion;
        const ysqr = y * y;
        const t0 = -2 * (ysqr + z * z) + 1;
        const t1 = +2 * (x * y + w * z);
        let t2 = -2 * (x * z - w * y);
        const t3 = +2 * (y * z + w * x);
        const t4 = -2 * (x * x + ysqr) + 1;
        t2 = t2 > 1 ? 1 : t2;
        t2 = t2 < -1 ? -1 : t2;
        const roll = Math.atan2(t3, t4);
        const pitch = Math.asin(t2);
        const yaw = Math.atan2(t1, t0);
        return this.set(roll, pitch, yaw, Euler.RollPitchYaw);
    }
    fromObject(object) {
        throw new Error('not implemented');
    }
    copy(array) {
        this[0] = array[0];
        this[1] = array[1];
        this[2] = array[2];
        this[3] = Number.isFinite(array[3]) || this.order;
        return this.check();
    }
    set(x = 0, y = 0, z = 0, order) {
        this[0] = x;
        this[1] = y;
        this[2] = z;
        this[3] = Number.isFinite(order) ? order : this[3];
        return this.check();
    }
    validate() {
        return validateOrder(this[3]) && Number.isFinite(this[0]) && Number.isFinite(this[1]) && Number.isFinite(this[2]);
    }
    toArray(array = [], offset = 0) {
        array[offset] = this[0];
        array[offset + 1] = this[1];
        array[offset + 2] = this[2];
        return array;
    }
    toArray4(array = [], offset = 0) {
        array[offset] = this[0];
        array[offset + 1] = this[1];
        array[offset + 2] = this[2];
        array[offset + 3] = this[3];
        return array;
    }
    toVector3(result = [-0, -0, -0]) {
        result[0] = this[0];
        result[1] = this[1];
        result[2] = this[2];
        return result;
    }
    get x() {
        return this[0];
    }
    set x(value) {
        this[0] = checkNumber(value);
    }
    get y() {
        return this[1];
    }
    set y(value) {
        this[1] = checkNumber(value);
    }
    get z() {
        return this[2];
    }
    set z(value) {
        this[2] = checkNumber(value);
    }
    get alpha() {
        return this[0];
    }
    set alpha(value) {
        this[0] = checkNumber(value);
    }
    get beta() {
        return this[1];
    }
    set beta(value) {
        this[1] = checkNumber(value);
    }
    get gamma() {
        return this[2];
    }
    set gamma(value) {
        this[2] = checkNumber(value);
    }
    get phi() {
        return this[0];
    }
    set phi(value) {
        this[0] = checkNumber(value);
    }
    get theta() {
        return this[1];
    }
    set theta(value) {
        this[1] = checkNumber(value);
    }
    get psi() {
        return this[2];
    }
    set psi(value) {
        this[2] = checkNumber(value);
    }
    get roll() {
        return this[0];
    }
    set roll(value) {
        this[0] = checkNumber(value);
    }
    get pitch() {
        return this[1];
    }
    set pitch(value) {
        this[1] = checkNumber(value);
    }
    get yaw() {
        return this[2];
    }
    set yaw(value) {
        this[2] = checkNumber(value);
    }
    get order() {
        return this[3];
    }
    set order(value) {
        this[3] = checkOrder(value);
    }
    fromVector3(v, order) {
        return this.set(v[0], v[1], v[2], Number.isFinite(order) ? order : this[3]);
    }
    fromArray(array, offset = 0) {
        this[0] = array[0 + offset];
        this[1] = array[1 + offset];
        this[2] = array[2 + offset];
        if (array[3] !== undefined) {
            this[3] = array[3];
        }
        return this.check();
    }
    fromRollPitchYaw(roll, pitch, yaw) {
        return this.set(roll, pitch, yaw, RotationOrder.ZYX);
    }
    fromRotationMatrix(m, order = Euler.DefaultOrder) {
        this._fromRotationMatrix(m, order);
        return this.check();
    }
    getRotationMatrix(m) {
        return this._getRotationMatrix(m);
    }
    getQuaternion() {
        const q = new Quaternion();
        switch (this[4]) {
            case RotationOrder.XYZ:
                return q.rotateX(this[0]).rotateY(this[1]).rotateZ(this[2]);
            case RotationOrder.YXZ:
                return q.rotateY(this[0]).rotateX(this[1]).rotateZ(this[2]);
            case RotationOrder.ZXY:
                return q.rotateZ(this[0]).rotateX(this[1]).rotateY(this[2]);
            case RotationOrder.ZYX:
                return q.rotateZ(this[0]).rotateY(this[1]).rotateX(this[2]);
            case RotationOrder.YZX:
                return q.rotateY(this[0]).rotateZ(this[1]).rotateX(this[2]);
            case RotationOrder.XZY:
                return q.rotateX(this[0]).rotateZ(this[1]).rotateY(this[2]);
            default:
                throw new Error(ERR_UNKNOWN_ORDER);
        }
    }
    _fromRotationMatrix(m, order = Euler.DefaultOrder) {
        const m11 = m[0], m12 = m[4], m13 = m[8];
        const m21 = m[1], m22 = m[5], m23 = m[9];
        const m31 = m[2], m32 = m[6], m33 = m[10];
        order = order || this[3];
        switch (order) {
            case Euler.XYZ:
                this[1] = Math.asin(clamp(m13, -1, 1));
                if (Math.abs(m13) < ALMOST_ONE) {
                    this[0] = Math.atan2(-m23, m33);
                    this[2] = Math.atan2(-m12, m11);
                }
                else {
                    this[0] = Math.atan2(m32, m22);
                    this[2] = 0;
                }
                break;
            case Euler.YXZ:
                this[0] = Math.asin(-clamp(m23, -1, 1));
                if (Math.abs(m23) < ALMOST_ONE) {
                    this[1] = Math.atan2(m13, m33);
                    this[2] = Math.atan2(m21, m22);
                }
                else {
                    this[1] = Math.atan2(-m31, m11);
                    this[2] = 0;
                }
                break;
            case Euler.ZXY:
                this[0] = Math.asin(clamp(m32, -1, 1));
                if (Math.abs(m32) < ALMOST_ONE) {
                    this[1] = Math.atan2(-m31, m33);
                    this[2] = Math.atan2(-m12, m22);
                }
                else {
                    this[1] = 0;
                    this[2] = Math.atan2(m21, m11);
                }
                break;
            case Euler.ZYX:
                this[1] = Math.asin(-clamp(m31, -1, 1));
                if (Math.abs(m31) < ALMOST_ONE) {
                    this[0] = Math.atan2(m32, m33);
                    this[2] = Math.atan2(m21, m11);
                }
                else {
                    this[0] = 0;
                    this[2] = Math.atan2(-m12, m22);
                }
                break;
            case Euler.YZX:
                this[2] = Math.asin(clamp(m21, -1, 1));
                if (Math.abs(m21) < ALMOST_ONE) {
                    this[0] = Math.atan2(-m23, m22);
                    this[1] = Math.atan2(-m31, m11);
                }
                else {
                    this[0] = 0;
                    this[1] = Math.atan2(m13, m33);
                }
                break;
            case Euler.XZY:
                this[2] = Math.asin(-clamp(m12, -1, 1));
                if (Math.abs(m12) < ALMOST_ONE) {
                    this[0] = Math.atan2(m32, m22);
                    this[1] = Math.atan2(m13, m11);
                }
                else {
                    this[0] = Math.atan2(-m23, m33);
                    this[1] = 0;
                }
                break;
            default:
                throw new Error(ERR_UNKNOWN_ORDER);
        }
        this[3] = order;
        return this;
    }
    _getRotationMatrix(result) {
        const te = result || [-0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0, -0];
        const x = this.x, y = this.y, z = this.z;
        const a = Math.cos(x);
        const c = Math.cos(y);
        const e = Math.cos(z);
        const b = Math.sin(x);
        const d = Math.sin(y);
        const f = Math.sin(z);
        switch (this[3]) {
            case Euler.XYZ:
                {
                    const ae = a * e, af = a * f, be = b * e, bf = b * f;
                    te[0] = c * e;
                    te[4] = -c * f;
                    te[8] = d;
                    te[1] = af + be * d;
                    te[5] = ae - bf * d;
                    te[9] = -b * c;
                    te[2] = bf - ae * d;
                    te[6] = be + af * d;
                    te[10] = a * c;
                    break;
                }
            case Euler.YXZ:
                {
                    const ce = c * e, cf = c * f, de = d * e, df = d * f;
                    te[0] = ce + df * b;
                    te[4] = de * b - cf;
                    te[8] = a * d;
                    te[1] = a * f;
                    te[5] = a * e;
                    te[9] = -b;
                    te[2] = cf * b - de;
                    te[6] = df + ce * b;
                    te[10] = a * c;
                    break;
                }
            case Euler.ZXY:
                {
                    const ce = c * e, cf = c * f, de = d * e, df = d * f;
                    te[0] = ce - df * b;
                    te[4] = -a * f;
                    te[8] = de + cf * b;
                    te[1] = cf + de * b;
                    te[5] = a * e;
                    te[9] = df - ce * b;
                    te[2] = -a * d;
                    te[6] = b;
                    te[10] = a * c;
                    break;
                }
            case Euler.ZYX:
                {
                    const ae = a * e, af = a * f, be = b * e, bf = b * f;
                    te[0] = c * e;
                    te[4] = be * d - af;
                    te[8] = ae * d + bf;
                    te[1] = c * f;
                    te[5] = bf * d + ae;
                    te[9] = af * d - be;
                    te[2] = -d;
                    te[6] = b * c;
                    te[10] = a * c;
                    break;
                }
            case Euler.YZX:
                {
                    const ac = a * c, ad = a * d, bc = b * c, bd = b * d;
                    te[0] = c * e;
                    te[4] = bd - ac * f;
                    te[8] = bc * f + ad;
                    te[1] = f;
                    te[5] = a * e;
                    te[9] = -b * e;
                    te[2] = -d * e;
                    te[6] = ad * f + bc;
                    te[10] = ac - bd * f;
                    break;
                }
            case Euler.XZY:
                {
                    const ac = a * c, ad = a * d, bc = b * c, bd = b * d;
                    te[0] = c * e;
                    te[4] = -f;
                    te[8] = d * e;
                    te[1] = ac * f + bd;
                    te[5] = a * e;
                    te[9] = ad * f - bc;
                    te[2] = bc * f - ad;
                    te[6] = b * e;
                    te[10] = bd * f + ac;
                    break;
                }
            default:
                throw new Error(ERR_UNKNOWN_ORDER);
        }
        te[3] = 0;
        te[7] = 0;
        te[11] = 0;
        te[12] = 0;
        te[13] = 0;
        te[14] = 0;
        te[15] = 1;
        return te;
    }
    toQuaternion() {
        const cy = Math.cos(this.yaw * 0.5);
        const sy = Math.sin(this.yaw * 0.5);
        const cr = Math.cos(this.roll * 0.5);
        const sr = Math.sin(this.roll * 0.5);
        const cp = Math.cos(this.pitch * 0.5);
        const sp = Math.sin(this.pitch * 0.5);
        const w = cy * cr * cp + sy * sr * sp;
        const x = cy * sr * cp - sy * cr * sp;
        const y = cy * cr * sp + sy * sr * cp;
        const z = sy * cr * cp - cy * sr * sp;
        return new Quaternion(x, y, z, w);
    }
}
function validateOrder(value) {
    return value >= 0 && value < 6;
}
function checkOrder(value) {
    if (value < 0 && value >= 6) {
        throw new Error(ERR_UNKNOWN_ORDER);
    }
    return value;
}
//# sourceMappingURL=euler.js.map
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/classes/pose.js
class Pose {
    constructor({ x = 0, y = 0, z = 0, roll = 0, pitch = 0, yaw = 0, position, orientation } = {}) {
        _defineProperty(this, "position", void 0);
        _defineProperty(this, "orientation", void 0);
        if (Array.isArray(position) && position.length === 3) {
            this.position = new Vector3(position);
        }
        else {
            this.position = new Vector3(x, y, z);
        }
        if (Array.isArray(orientation) && orientation.length === 4) {
            this.orientation = new Euler(orientation, orientation[3]);
        }
        else {
            this.orientation = new Euler(roll, pitch, yaw, Euler.RollPitchYaw);
        }
    }
    get x() {
        return this.position.x;
    }
    set x(value) {
        this.position.x = value;
    }
    get y() {
        return this.position.y;
    }
    set y(value) {
        this.position.y = value;
    }
    get z() {
        return this.position.z;
    }
    set z(value) {
        this.position.z = value;
    }
    get roll() {
        return this.orientation.roll;
    }
    set roll(value) {
        this.orientation.roll = value;
    }
    get pitch() {
        return this.orientation.pitch;
    }
    set pitch(value) {
        this.orientation.pitch = value;
    }
    get yaw() {
        return this.orientation.yaw;
    }
    set yaw(value) {
        this.orientation.yaw = value;
    }
    getPosition() {
        return this.position;
    }
    getOrientation() {
        return this.orientation;
    }
    equals(pose) {
        if (!pose) {
            return false;
        }
        return this.position.equals(pose.position) && this.orientation.equals(pose.orientation);
    }
    exactEquals(pose) {
        if (!pose) {
            return false;
        }
        return this.position.exactEquals(pose.position) && this.orientation.exactEquals(pose.orientation);
    }
    getTransformationMatrix() {
        const sr = Math.sin(this.roll);
        const sp = Math.sin(this.pitch);
        const sw = Math.sin(this.yaw);
        const cr = Math.cos(this.roll);
        const cp = Math.cos(this.pitch);
        const cw = Math.cos(this.yaw);
        return new Matrix4().setRowMajor(cw * cp, -sw * cr + cw * sp * sr, sw * sr + cw * sp * cr, this.x, sw * cp, cw * cr + sw * sp * sr, -cw * sr + sw * sp * cr, this.y, -sp, cp * sr, cp * cr, this.z, 0, 0, 0, 1);
    }
    getTransformationMatrixFromPose(pose) {
        return new Matrix4().multiplyRight(this.getTransformationMatrix()).multiplyRight(pose.getTransformationMatrix().invert());
    }
    getTransformationMatrixToPose(pose) {
        return new Matrix4().multiplyRight(pose.getTransformationMatrix()).multiplyRight(this.getTransformationMatrix().invert());
    }
}
//# sourceMappingURL=pose.js.map
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/lib/math-utils.js
/* harmony default export */ const math_utils = ({
    EPSILON1: 1e-1,
    EPSILON2: 1e-2,
    EPSILON3: 1e-3,
    EPSILON4: 1e-4,
    EPSILON5: 1e-5,
    EPSILON6: 1e-6,
    EPSILON7: 1e-7,
    EPSILON8: 1e-8,
    EPSILON9: 1e-9,
    EPSILON10: 1e-10,
    EPSILON11: 1e-11,
    EPSILON12: 1e-12,
    EPSILON13: 1e-13,
    EPSILON14: 1e-14,
    EPSILON15: 1e-15,
    EPSILON16: 1e-16,
    EPSILON17: 1e-17,
    EPSILON18: 1e-18,
    EPSILON19: 1e-19,
    EPSILON20: 1e-20,
    PI_OVER_TWO: Math.PI / 2,
    PI_OVER_FOUR: Math.PI / 4,
    PI_OVER_SIX: Math.PI / 6,
    TWO_PI: Math.PI * 2
});
//# sourceMappingURL=math-utils.js.map
; // CONCATENATED MODULE: ./node_modules/@math.gl/core/dist/esm/index.js
//# sourceMappingURL=index.js.map
var __webpack_exports__Euler = __webpack_exports__.US;
var __webpack_exports__Matrix3 = __webpack_exports__.Vk;
var __webpack_exports__Matrix4 = __webpack_exports__.yG;
var __webpack_exports__Pose = __webpack_exports__.DJ;
var __webpack_exports__Quaternion = __webpack_exports__._f;
var __webpack_exports__SphericalCoordinates = __webpack_exports__.i1;
var __webpack_exports__Vector2 = __webpack_exports__.FM;
var __webpack_exports__Vector3 = __webpack_exports__.P;
var __webpack_exports__Vector4 = __webpack_exports__.Lt;
var __webpack_exports___Euler = __webpack_exports__.RK;
var __webpack_exports___MathUtils = __webpack_exports__.H7;
var __webpack_exports___Pose = __webpack_exports__.r9;
var __webpack_exports___SphericalCoordinates = __webpack_exports__.F;
var __webpack_exports__acos = __webpack_exports__.Kh;
var __webpack_exports__asin = __webpack_exports__.ZR;
var __webpack_exports__assert = __webpack_exports__.hu;
var __webpack_exports__atan = __webpack_exports__.z4;
var __webpack_exports__clamp = __webpack_exports__.uZ;
var __webpack_exports__clone = __webpack_exports__.d9;
var __webpack_exports__config = __webpack_exports__.vc;
var __webpack_exports__configure = __webpack_exports__.jQ;
var __webpack_exports__cos = __webpack_exports__.mC;
var __webpack_exports__degrees = __webpack_exports__.RW;
var __webpack_exports__equals = __webpack_exports__.fS;
var __webpack_exports__exactEquals = __webpack_exports__.I6;
var __webpack_exports__formatValue = __webpack_exports__.Bw;
var __webpack_exports__isArray = __webpack_exports__.kJ;
var __webpack_exports__lerp = __webpack_exports__.t7;
var __webpack_exports__radians = __webpack_exports__.uR;
var __webpack_exports__sin = __webpack_exports__.O$;
var __webpack_exports__tan = __webpack_exports__.OR;
var __webpack_exports__toDegrees = __webpack_exports__.Ux;
var __webpack_exports__toRadians = __webpack_exports__.Yr;
var __webpack_exports__withEpsilon = __webpack_exports__.BJ;
export { __webpack_exports__Euler as Euler, __webpack_exports__Matrix3 as Matrix3, __webpack_exports__Matrix4 as Matrix4, __webpack_exports__Pose as Pose, __webpack_exports__Quaternion as Quaternion, __webpack_exports__SphericalCoordinates as SphericalCoordinates, __webpack_exports__Vector2 as Vector2, __webpack_exports__Vector3 as Vector3, __webpack_exports__Vector4 as Vector4, __webpack_exports___Euler as _Euler, __webpack_exports___MathUtils as _MathUtils, __webpack_exports___Pose as _Pose, __webpack_exports___SphericalCoordinates as _SphericalCoordinates, __webpack_exports__acos as acos, __webpack_exports__asin as asin, __webpack_exports__assert as assert, __webpack_exports__atan as atan, __webpack_exports__clamp as clamp, __webpack_exports__clone as clone, __webpack_exports__config as config, __webpack_exports__configure as configure, __webpack_exports__cos as cos, __webpack_exports__degrees as degrees, __webpack_exports__equals as equals, __webpack_exports__exactEquals as exactEquals, __webpack_exports__formatValue as formatValue, __webpack_exports__isArray as isArray, __webpack_exports__lerp as lerp, __webpack_exports__radians as radians, __webpack_exports__sin as sin, __webpack_exports__tan as tan, __webpack_exports__toDegrees as toDegrees, __webpack_exports__toRadians as toRadians, __webpack_exports__withEpsilon as withEpsilon };
