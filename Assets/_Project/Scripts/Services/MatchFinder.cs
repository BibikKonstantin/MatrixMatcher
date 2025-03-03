using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.DB;
using Core;
using Models;
using UnityEngine;
using Zenject;

namespace Services
{
    public class MatchFinder : IMatchFinder, IInitializable
    {
        [Inject] private readonly MatchConfig _matchConfig;
        
        private float _tolerance;
        private float _maxOffset;

        public void Initialize()
        {
            _tolerance = _matchConfig.Tolerance;
            _maxOffset = _matchConfig.MaxOffset;
        }

        public ModelMatchResult FindAllMatches(
            MatrixData modelMatrix,
            MatrixContainer spaceData
        )
        {
            var matchingSpacePositions = new List<Vector3>();
            var modelPosition = new Vector3(modelMatrix.m03, modelMatrix.m13, modelMatrix.m23);

            var spacePositions = new HashSet<Vector3>(
                spaceData
                    .Matrices
                    .Select(matrixData => new Vector3(matrixData.m03, matrixData.m13, matrixData.m23)),
                new Vector3Comparer(_tolerance)
            );

            foreach (var spacePosition in spacePositions)
            {
                var offset = spacePosition - modelPosition;
                var shiftedPosition = modelPosition + offset;

                if (!(offset.magnitude <= _maxOffset) || !spacePositions.Contains(shiftedPosition))
                    continue;
                
                if (!matchingSpacePositions.Contains(spacePosition))
                {
                    matchingSpacePositions.Add(spacePosition);
                }
            }

            return new ModelMatchResult(matchingSpacePositions);
        }
    }
}