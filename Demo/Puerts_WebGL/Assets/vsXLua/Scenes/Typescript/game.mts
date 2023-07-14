import { Quaternion, Vector3 } from 'external/math.gl.gen.mjs'
import CSVector3 = CS.UnityEngine.Vector3;
import CSQuaternion = CS.UnityEngine.Quaternion;

export default function Game(mb: CS.GameWithJS) {

    let gap = 0.01;

    CS.UnityEngine.Application.targetFrameRate = 60;

    let timeCount = 0;

    let tenFrameDeltaTime = 0

    CS.ScriptBehaviourManager.AddUpdate(puer.$typeof(CS.GameWithJS), function () {
        if (CS.UnityEngine.Time.frameCount % 10 == 0) {
            mb.FpsText.text = "FPS: " + (10 / tenFrameDeltaTime).toFixed(2);
            tenFrameDeltaTime = 0;
        } else {
            tenFrameDeltaTime += CS.UnityEngine.Time.deltaTime
        }
        mb.BoxText.text = "Box: " + CS.BoxWithJS.TotalBoxCount;

        const vec2 = mb.Joystick.Direction;

        const direction3D = new Vector3(vec2.x, 0, vec2.y)
        if (direction3D.magnitude() > 0) {
            const originPosition = new Vector3(
                mb.Main.transform.position.x,
                mb.Main.transform.position.y,
                mb.Main.transform.position.z,
            );
            const finalPosition = originPosition.add(direction3D.multiplyByScalar(4 * CS.UnityEngine.Time.deltaTime))
            mb.Main.transform.position = new CSVector3(
                finalPosition.x, finalPosition.y, finalPosition.z
            );
            const quaternion = new Quaternion()
            quaternion.rotationTo(new Vector3(1, 0, 0), direction3D.normalize());
            mb.Main.transform.rotation = new CSQuaternion(
                quaternion.x, quaternion.y, quaternion.z, quaternion.w
            )
        }

        timeCount += CS.UnityEngine.Time.deltaTime;
        while (timeCount > gap) {
            timeCount -= gap;
            generateSubbox()
        }
    });

    function generateSubbox() {
        if (CS.BoxWithJS.TotalBoxCount < 3000) {
            const box = CS.UnityEngine.Object.Instantiate(mb.SubPrefab, mb.transform) as CS.UnityEngine.GameObject;
            const mbbox = box.GetComponent(puer.$typeof(CS.BoxWithJS)) as CS.BoxWithJS;
            mbbox.target = mb.Main.transform;
        }
    }
}