using System.Collections.Generic;
using Core;
using Models;
using UnityEngine;
using Zenject;

namespace Initializers
{
    public class MatricesInitializer : IInitializable
    {
        [Inject] private IDataLoader _dataLoader;
        [Inject] private IMatrixProcessor _matrixProcessor;
        [Inject] private IMatchFinder _matchFinder;
        [Inject] private IMatrixVisualizer _matrixVisualizer;
        [Inject] private IMatchExporter _matchExporter;
    
        private MatrixContainer _modelData;
        private MatrixContainer _spaceData;
    
        private readonly Dictionary<int, ModelMatchResult> _modelMatchResults = new();
        private readonly List<Vector3> _matches = new();
    
        public void Initialize()
        {
            if(!TryLoadData())
                return;

            FindMatches();
        
            Visualize();
        
            ExportMatches();
        }

        private bool TryLoadData()
        {
            _modelData = _dataLoader.LoadModelData();
            _spaceData = _dataLoader.LoadSpaceData();

            if (_modelData == null || _modelData.Matrices == null)
                return false;

            if (_spaceData == null || _spaceData.Matrices == null)
                return false;
        
            return true;
        }

        private void FindMatches() 
        {
            for (var i = 0; i < _modelData.Matrices.Length; i++)
            {
                var matchResult = _matchFinder.FindAllMatches(_modelData.Matrices[i], _spaceData);
                _modelMatchResults[i] = matchResult;
            
                var modelMatrix = _modelData.Matrices[i];
                var modelPosition = new Vector3(modelMatrix.m03, modelMatrix.m13, modelMatrix.m23);

                foreach (var spacePosition in matchResult.MatchingSpacePositions)
                {
                    var offset = spacePosition - modelPosition;
                    _matches.Add(offset);
                }
            }
        }

        private void Visualize()
        {
            _matrixVisualizer.VisualizeMatrices(_modelData, _spaceData, _modelMatchResults);
        }
    
        private void ExportMatches()
        {
            if (_matches.Count > 0) 
            {
                _matchExporter.ExportResults(_matches);
            }
        }
    }
}