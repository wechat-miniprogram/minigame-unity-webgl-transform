/// <reference types="csharp" />
import { JsBehaviour } from './Base/base.mjs';
declare class JSGameManager extends JsBehaviour<CS.GameManager> {
    static instance: JSGameManager;
    Start(): void;
    protected pressed: number;
    protected useTouch: boolean;
    Update(): void;
    shootBall(power: number): void;
    protected currentBall: CS.UnityEngine.GameObject;
    spawnBall(): void;
}
export { JSGameManager };
