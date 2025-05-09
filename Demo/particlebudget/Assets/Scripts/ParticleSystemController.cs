using UnityEngine;
using System.Collections;

namespace ParticleSimulationBudget
{
    public enum ParticlePriorityPreset { ForceUpdate, High, Normal }

    [RequireComponent(typeof(ParticleSystem))]
    public class ParticleSystemController : MonoBehaviour
    {

        [Header("Priority Settings")]
        [SerializeField] private ParticlePriorityPreset _priorityPreset = ParticlePriorityPreset.Normal;
        [SerializeField][Range(0, 5)] private float _basePriority = 1f;
        [SerializeField][Range(0, 5)] private float _distanceFactor = 1f;

        public ParticlePriorityPreset PriorityPreset => _priorityPreset;

        private ParticleSystem _ps;
        private Renderer _renderer;
        private float _lastSimulatedTime;
        private bool _isVisible;

        public float CalculatedPriority { get; private set; }
        public ParticlePriorityPreset CurrentPreset => _priorityPreset;
        public float RequiredSimulationTime => (Time.time - _lastSimulatedTime);

        void Awake()
        {
            _ps = GetComponent<ParticleSystem>();
            _renderer = GetComponent<Renderer>();
        }

        private void Start()
        {
            ParticleSimulationBudgetManager.CreateInstanceIfNeeded();
            ParticleSimulationBudgetManager.Instance.RegisterSystem(this);
            _ps.Pause(true);
        }


        void Update()
        {
            UpdateVisibility();
            /* 屏占比计算对于性能影响较大
            if (Time.frameCount % 3 == 0) // Update every 3 frames
            {
                UpdateScreenArea();
            }*/
            CalculatePriority();
        }

        private void UpdateVisibility()
        {
            if (_renderer == null) return;
            _isVisible = _renderer.isVisible;
        }

        private void CalculatePriority()
        {
            if (_priorityPreset == ParticlePriorityPreset.ForceUpdate)
            {
                CalculatedPriority = float.MaxValue;
                return;
            }

            float unsimulatedTime = Time.time - _lastSimulatedTime;
            float compensation = Mathf.Log(1 + unsimulatedTime) * (_priorityPreset == ParticlePriorityPreset.High? 2f: 1f);

            float distanceFactor = 1f;
            if (Camera.main != null)
            {
                // 使用平方距离避免开方运算
                Vector3 offset = transform.position - Camera.main.transform.position;
                float sqrDistance = offset.sqrMagnitude;
                // 调整公式保持距离衰减特性，+0.1防止除零
                distanceFactor = 1.0f / (sqrDistance * 0.1f + 1);
            }

            distanceFactor *= _distanceFactor;

            CalculatedPriority = _basePriority + compensation * distanceFactor;

            // Visibility penalty
            if (!_isVisible) CalculatedPriority *= 0.3f;
        }

        public void Simulate(float deltaTime)
        {
            if (deltaTime <= 0) return;

            _ps.Simulate(deltaTime, true, false, false);
            _lastSimulatedTime = Time.time;
        }

#if UNITY_EDITOR
        void OnDrawGizmosSelected()
        {
            if (!Application.isPlaying) return;
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(_renderer.bounds.center, _renderer.bounds.size);
            UnityEditor.Handles.Label(transform.position,
                $"Prio: {CalculatedPriority:F1}\nPreset: {_priorityPreset}");
        }
#endif
    }
}
