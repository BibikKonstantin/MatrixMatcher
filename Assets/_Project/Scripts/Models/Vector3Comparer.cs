using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public class Vector3Comparer : IEqualityComparer<Vector3>
    {
        private const int HASH_MULTIPLIER = 397;
        private readonly float _tolerance;

        public Vector3Comparer(float tolerance)
        {
            _tolerance = tolerance;
        }

        public bool Equals(Vector3 a, Vector3 b)
        {
            return Vector3.Distance(a, b) < _tolerance;
        }

        public int GetHashCode(Vector3 obj)
        {
            return ((int)(obj.x / _tolerance) * HASH_MULTIPLIER) ^
                   ((int)(obj.y / _tolerance) * HASH_MULTIPLIER) ^
                   (int)(obj.z / _tolerance);
        }
    }
}