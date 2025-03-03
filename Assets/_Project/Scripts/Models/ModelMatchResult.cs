using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public class ModelMatchResult
    {
        private readonly List<Vector3> _matchingSpacePositions;
        
        public bool HasMatch => _matchingSpacePositions.Count > 0;
        public IReadOnlyList<Vector3> MatchingSpacePositions => _matchingSpacePositions;
        
        public ModelMatchResult(List<Vector3> matchingSpacePositions)
        {
            _matchingSpacePositions = matchingSpacePositions ?? new List<Vector3>();
        }
    }
}