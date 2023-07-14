/// <reference types="csharp" />
declare class JsBehaviour<T extends CS.JsMonoBehaviour> {
    Start(): void;
    Update(): void;
    OnTriggerEnter(other: CS.UnityEngine.Collider): void;
    _mb: T;
    constructor(mb: T);
}
export { JsBehaviour };
