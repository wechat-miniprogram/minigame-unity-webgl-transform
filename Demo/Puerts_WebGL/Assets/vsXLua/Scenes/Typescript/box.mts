import { Quaternion, Vector3 } from 'external/math.gl.gen.mjs'
import CSVector3 = CS.UnityEngine.Vector3;
import CSQuaternion = CS.UnityEngine.Quaternion;
declare const PuertsWebGL: any;
let useMemorySetter = typeof PuertsWebGL != 'undefined'

const boxConfig = { "range": 24, "destroyRange": 0.5 };
const speedConfig = { "speed": 0.2 }

const boxUpdates: any[] = []
const freeIndex: number[] = []
function addUpdate(fn: any) {
    if (freeIndex.length) {
        const index = freeIndex.pop()
        boxUpdates[index] = fn;
        return index;
    } else {
        const index = boxUpdates.length;
        boxUpdates.push(fn);
        return index;
    }
}
function freeUpdate(index: number) {
    boxUpdates[index] = null;
    freeIndex.push(index);
}

let CSTimeDeltaTime = 0;
CS.ScriptBehaviourManager.AddUpdate(puer.$typeof(CS.BoxWithJS), function () {
    CSTimeDeltaTime = CS.UnityEngine.Time.deltaTime;
    currentTargetPositionAtThisFrame = null;
    boxUpdates.forEach(updater => {
        if (!updater) return;
        try {
            updater()
        } catch (e) { }
    });
})

const defaultFront = new Vector3(1, 0, 0);
let currentTargetPositionAtThisFrame: Vector3 | null = null
export default function Box(mb: CS.BoxWithJS) {
    CS.BoxWithJS.TotalBoxCount++;
    
    let myPosition: any;
    let myRotation: any;
    if (useMemorySetter) {
        const positionPtrIn32 = mb.GetPositionSetterPointer() >> 2;
        const rotationPtrIn32 = mb.GetRotationSetterPointer() >> 2;
        myPosition = Object.create({}, {
            x: {
                get: () => PuertsWebGL.unityInstance.HEAPF32[positionPtrIn32],
                set: value => PuertsWebGL.unityInstance.HEAPF32[positionPtrIn32] = value
            },
            y: {
                get: () => PuertsWebGL.unityInstance.HEAPF32[positionPtrIn32 + 1],
                set: value => PuertsWebGL.unityInstance.HEAPF32[positionPtrIn32 + 1] = value
            },
            z: {
                get: () => PuertsWebGL.unityInstance.HEAPF32[positionPtrIn32 + 2],
                set: value => PuertsWebGL.unityInstance.HEAPF32[positionPtrIn32 + 2] = value
            }
        })
        myRotation = Object.create({}, {
            x: {
                get: () => PuertsWebGL.unityInstance.HEAPF32[rotationPtrIn32],
                set: value => PuertsWebGL.unityInstance.HEAPF32[rotationPtrIn32] = value
            },
            y: {
                get: () => PuertsWebGL.unityInstance.HEAPF32[rotationPtrIn32 + 1],
                set: value => PuertsWebGL.unityInstance.HEAPF32[rotationPtrIn32 + 1] = value
            },
            z: {
                get: () => PuertsWebGL.unityInstance.HEAPF32[rotationPtrIn32 + 2],
                set: value => PuertsWebGL.unityInstance.HEAPF32[rotationPtrIn32 + 2] = value
            },
            w: {
                get: () => PuertsWebGL.unityInstance.HEAPF32[rotationPtrIn32 + 3],
                set: value => PuertsWebGL.unityInstance.HEAPF32[rotationPtrIn32 + 3] = value
            }
        })
    }

    const index = addUpdate(function () {
        if (!currentTargetPositionAtThisFrame) {
            const CSTargetPosition = mb.target.position;
            currentTargetPositionAtThisFrame = new Vector3(
                CSTargetPosition.x,
                CSTargetPosition.y,
                CSTargetPosition.z,
            );
        }
        const jsPosition = useMemorySetter ? new Vector3(myPosition.x, myPosition.y, myPosition.z) :
            new Vector3(mb.transform.position.x, mb.transform.position.y, mb.transform.position.z)
        const deltaVec = new Vector3(currentTargetPositionAtThisFrame).subtract(jsPosition);

        if (deltaVec.magnitude() < boxConfig.destroyRange) {
            return CS.UnityEngine.Object.Destroy(mb.gameObject);
        }
        const deltaVecNormalized = deltaVec.normalize();

        const quaternion = new Quaternion()
        quaternion.rotationTo(defaultFront, deltaVecNormalized);
        if (useMemorySetter) {
            myRotation.x = quaternion.x
            myRotation.y = quaternion.y
            myRotation.z = quaternion.z
            myRotation.w = quaternion.w

        } else {
            mb.transform.rotation = new CSQuaternion(
                quaternion.x, quaternion.y, quaternion.z, quaternion.w
            );
        }

        const finalPosition = jsPosition.add(deltaVec.normalize().multiplyByScalar(CSTimeDeltaTime * speedConfig.speed));
        if (useMemorySetter) {
            myPosition.x = finalPosition.x;
            myPosition.y = finalPosition.y;
            myPosition.z = finalPosition.z;
            
        } else {
            mb.transform.position = new CSVector3(
                finalPosition.x, finalPosition.y, finalPosition.z
            );

        }
    });
    mb.ScriptOnDestroy = function () {
        CS.BoxWithJS.TotalBoxCount--;
        freeUpdate(index);
    }


    const randomPositionX = Math.random() * boxConfig.range - (boxConfig.range / 2) + mb.target.position.x;
    const randomPositionZ = Math.random() * boxConfig.range - (boxConfig.range / 2) + mb.target.position.z;
    if (useMemorySetter) {
        myPosition.x = randomPositionX
        myPosition.z = randomPositionZ

    } else {
        mb.transform.position = new CS.UnityEngine.Vector3(
            randomPositionX, mb.transform.position.y, randomPositionZ
        )
    }
     
}