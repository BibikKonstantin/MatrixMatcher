using UnityEngine;

namespace _Project.Scripts.DB
{
    [CreateAssetMenu(fileName = "MatchConfig", menuName = "Settings/MatchConfig", order = 1)]
    public class MatchConfig : ScriptableObject
    {
        [SerializeField] private float _tolerance = 0.05f;
        [SerializeField] private float _maxOffset = 10f;

        public float Tolerance => _tolerance;
        public float MaxOffset => _maxOffset;
    }
}