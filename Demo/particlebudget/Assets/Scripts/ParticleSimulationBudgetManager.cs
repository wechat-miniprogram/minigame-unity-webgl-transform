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

            // ����ǿ�Ƹ���ϵͳ����ͨϵͳ
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

            // ʹ��һ��Stopwatch����ʼ��ʱ
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            UnityEngine.Profiling.Profiler.BeginSample("Forced System"); 

            // ǿ�и��µ����ӣ�������ô���ø��£�Ү��Ҳ����ס����˵��
            foreach (var controller in forcedSystems)
            {
                float delta = Time.unscaledDeltaTime;
                controller.Simulate(delta);
            }
            UnityEngine.Profiling.Profiler.EndSample();
            // ��ʱͨ��stopwach�鿴�Ѿ����ĵ�ʱ�䣬������ĵ�ʱ�����ʣ���Ԥ�㣬��ô�Ͳ��ٸ�����
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
