/// <reference types="csharp" />
import { JsBehaviour } from './Base/base.mjs';
declare class JSBallBehaviour extends JsBehaviour<CS.JsMonoBehaviour> {
    protected prescore: boolean;
    OnTriggerEnter(trigger: CS.UnityEngine.Collider): void;
}
export { JSBallBehaviour };
