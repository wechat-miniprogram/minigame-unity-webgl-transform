CS.PerformanceHelper.ReturnNumber(3);
const start = Date.now();
for (let i = 0; i < 1000000; i++) 
{
    CS.PerformanceHelper.ReturnNumber(3);
}
// CS.UnityEngine.Debug.Log('Puerts Number:');
CS.PerformanceHelper.JSNumber.text = 'Puerts Number:' + (Date.now() - start) + 'ms'

CS.PerformanceHelper.ReturnVector(1, 2, 3)
const start2 = Date.now();
for (let i = 0; i < 1000000; i++) 
{
    CS.PerformanceHelper.ReturnVector(1, 2, 3);
}
// CS.UnityEngine.Debug.Log('Puerts Vector:');
// CS.UnityEngine.Debug.Log((Date.now() - start2));
CS.PerformanceHelper.JSVector.text = 'Puerts Vector:' + (Date.now() - start2) + 'ms'

// const fibcache = [0, 1]
function fibonacci(level) {
    if (level == 0) return 0;
    if (level == 1) return 1;
    return fibonacci(level - 1) + fibonacci(level - 2);
}

const start3 = Date.now();
for (let i = 0; i < 100000; i++) {
    fibonacci(12)
}
// CS.UnityEngine.Debug.Log('Puerts fibonacci:');
// CS.UnityEngine.Debug.Log((Date.now() - start3));
CS.PerformanceHelper.JSFibonacci.text = 'Puerts fibonacci:' + (Date.now() - start3) + 'ms'
