using UnityEngine;
using Views;
using Zenject;

namespace Services
{
    public class PrefabsHandler : IInitializable
    {
        private MatrixView _matrixViewPrefab;
        
        private const string MATRIX_VIEW_PREFAB = "MatrixViewPrefab";

        public MatrixView MatrixViewPrefab => _matrixViewPrefab; 

        public void Initialize()
        {
            _matrixViewPrefab = Resources.Load<MatrixView>(MATRIX_VIEW_PREFAB);
            
            if (_matrixViewPrefab == null)
            {
                throw new System.Exception("MatrixViewPrefab not found in Resources");
            }
        }
    }
}