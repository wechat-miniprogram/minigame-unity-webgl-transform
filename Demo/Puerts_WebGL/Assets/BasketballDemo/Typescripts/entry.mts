import { JSGameManager } from "./JSGameManager.mjs";
import { JSBallBehaviour } from "./JSBallBehaviour.mjs";

function makeFactory(cls: any) {
    return function(...args: any[]) {
        return new cls(...args);
    }
}

const JSBallBehaviourFactory = makeFactory(JSBallBehaviour)
const JSGameManagerFactory = makeFactory(JSGameManager)
export { 
    JSBallBehaviourFactory as JSBallBehaviour, 
    JSGameManagerFactory as JSGameManager 
}