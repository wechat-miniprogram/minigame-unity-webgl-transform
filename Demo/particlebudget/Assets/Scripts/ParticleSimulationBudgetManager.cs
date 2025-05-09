using UnityEngine;
using System.Collections.Generic;

namespace ParticleSimulationBudget
{
    public class ParticleSimulationBudgetManager : MonoBehaviour
    {
        public static ParticleSimulationBudgetManager Instance { get; private set; }

        [Header("Global Settings")]
        [Tooltip("Maximum simulation time per frame (milliseconds)")]
        [SerializeField] private float _maxFrameBudgetMS = 2.5f;

        private List<ParticleSystemController> _managedSystems = new List<ParticleSystemController>();
        private Camera _mainCamera;

        public Camera MainCamera => _mainCamera;

        public int UpdatedNormalParticles => _updatedNormalParticles;

        private int _updatedNormalParticles = 0; 


        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            _mainCamera = Camera.main;
        }

        public void RegisterSystem(ParticleSystemController controller)
        {
            if (!_managedSystems.Contains(controller))
            {
                _managedSystems.Add(controller);
            }
        }

        public void UnregisterSystem(ParticleSystemController controller)
        {
            _managedSystems.Remove(controller);
        }

        void LateUpdate()
        {
            if (_mainCamera == null) return;

            float remainingBudget = _maxFrameBudgetMS; // Convert to seconds

            // 分离强制更新系统和普通系统
            var forcedSystems = new List<ParticleSystemController>();
            var normalSystems = new List<ParticleSystemController>();

            foreach (var controller in _managedSystems)
            {
                if (controller.PriorityPreset == ParticlePriorityPreset.ForceUpdate)
                {
                    forcedSystems.Add(controller);
                }
                else
                {
                    normalSystems.Add(controller);
                }
            }

            // Sort other systems by priority
            normalSystems.Sort((a, b) => b.CalculatedPriority.CompareTo(a.CalculatedPriority));

            // 使用一个Stopwatch，开始计时
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            UnityEngine.Profiling.Profiler.BeginSample("Forced System"); 

            // 强行更新的粒子，无论怎么都得更新，耶稣也留不住，我说的
            foreach (var controller in forcedSystems)
            {
                float delta = Time.unscaledDeltaTime;
                controller.Simulate(delta);
            }
            UnityEngine.Profiling.Profiler.EndSample();
            // 此时通过stopwach查看已经消耗的时间，如果消耗的时间大于剩余的预算，那么就不再更新了
            if (stopwatch.Elapsed.TotalMilliseconds >= remainingBudget)
            {
                return;
            }


            // Process remaining systems
            _updatedNormalParticles = 0;
            foreach (var controller in normalSystems)
            {
                UnityEngine.Profiling.Profiler.BeginSample("Normal System");
                float requiredTime = controller.RequiredSimulationTime;

                controller.Simulate(requiredTime);
                _updatedNormalParticles++;


                UnityEngine.Profiling.Profiler.EndSample();
                if (stopwatch.Elapsed.TotalMilliseconds >= remainingBudget)
                {
                    break; 
                }
                
            }




        }

        public static void CreateInstanceIfNeeded()
        {
            if (Instance == null)
            {
                new GameObject("ParticleSimulationBudgetManager", typeof(ParticleSimulationBudgetManager));
            }
        }
    }
}
