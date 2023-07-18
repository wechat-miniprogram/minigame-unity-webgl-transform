class JsBehaviour<T extends CS.JsMonoBehaviour> {

    Start(): void { }
    Update(): void { }
    OnTriggerEnter(other: CS.UnityEngine.Collider): void { }

    public _mb: T

    constructor(mb: T) {
        // mono.Js
        this._mb = mb;
        if (this.Start != JsBehaviour.prototype.Start) {
            mb.JsStart = this.Start.bind(this);
        }
        if (this.Update != JsBehaviour.prototype.Update) {
            mb.JsUpdate = this.Update.bind(this);
        }
        if (this.OnTriggerEnter != JsBehaviour.prototype.OnTriggerEnter) {
            mb.JsOnTriggerEnter = this.OnTriggerEnter.bind(this);
        }
    }
}

export { JsBehaviour }