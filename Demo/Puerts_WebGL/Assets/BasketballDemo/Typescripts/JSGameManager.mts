import { JsBehaviour } from './Base/base.mjs'

class JSGameManager extends JsBehaviour<CS.GameManager>{
    public static instance: JSGameManager;

    Start() {
        this.spawnBall();
        JSGameManager.instance = this;
    }

    protected pressed: number;
    protected useTouch: boolean;
    Update() {
        const expectPressTimeMax = 1000;
        if (!this.pressed && (CS.UnityEngine.Input.GetMouseButtonDown(0) || CS.UnityEngine.Input.touchCount != 0)) {
            this.pressed = Date.now();
            if (CS.UnityEngine.Input.touchCount) {
                this.useTouch = true;
            }
        }
        if (
            this.pressed && (
                this.useTouch ? CS.UnityEngine.Input.touchCount == 0 : CS.UnityEngine.Input.GetMouseButtonUp(0)
            )
        ) {
            this.shootBall(Math.min(expectPressTimeMax, Date.now() - this.pressed) / expectPressTimeMax);
            this.pressed = 0;
        }
        //@ts-ignore
        globalThis._puerts_registry && globalThis._puerts_registry.cleanup();
    }

    shootBall(power: number) {
        const rigidbody = this.currentBall.GetComponent(puer.$typeof(CS.UnityEngine.Rigidbody)) as CS.UnityEngine.Rigidbody;
        rigidbody.isKinematic = false;
        rigidbody.velocity = new CS.UnityEngine.Vector3(1 + 2 * power, 3 + 6 * power, 0);
        setTimeout(()=> {
            this.spawnBall();
        }, 500);
    }

    protected currentBall: CS.UnityEngine.GameObject;
    spawnBall() {
        const ball = this.currentBall = CS.UnityEngine.Object.Instantiate(this._mb.BallPrefab) as CS.UnityEngine.GameObject;
        ball.transform.position = this._mb.BallSpawnPoint.transform.position;

        const rigidbody = ball.GetComponent(puer.$typeof(CS.UnityEngine.Rigidbody)) as CS.UnityEngine.Rigidbody;
        rigidbody.isKinematic = true;
    }


}

export { JSGameManager }