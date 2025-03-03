using System.Collections.Generic;
using Core;
using Models;
using UnityEngine;
using Views;
using Zenject;

namespace Services
{
    public class MatrixVisualizer : 
        IMatrixVisualizer,
        IInitializable
    {
        [Inject] private PrefabsHandler _prefabsHandler;
    
        private MatrixView _matrixViewPrefab;
        private Transform _parentTransform;
        
        private const string VISUALIZATION_PARENT_NAME = "VisualizationData";

        public void Initialize()
        {
            _matrixViewPrefab = _prefabsHandler.MatrixViewPrefab;
            _parentTransform = new GameObject(VISUALIZATION_PARENT_NAME).transform;
        }

        public void VisualizeMatrices(
            MatrixContainer modelData,
            MatrixContainer spaceData,
            Dictionary<int, ModelMatchResult> modelIntersectionResults
        )
        {
            foreach (Transform child in _parentTransform)
            {
                Object.Destroy(child.gameObject);
            }

            for (var i = 0; i < spaceData.Matrices.Length; i++)
            {
                var spaceMatrix = spaceData.Matrices[i];
                var position = new Vector3(spaceMatrix.m03, spaceMatrix.m13, spaceMatrix.m23);
                var rotation = MatrixToQuaternion(spaceMatrix);
            
                CreateView(position, rotation, Color.white);
            }

            for (var i = 0; i < modelData.Matrices.Length; i++)
            {
                if (!modelIntersectionResults[i].HasMatch)
                    continue;
            
                var modelMatrix = modelData.Matrices[i];
                var position = new Vector3(modelMatrix.m03, modelMatrix.m13, modelMatrix.m23);
                var rotation = MatrixToQuaternion(modelMatrix);

                CreateView(position, rotation, Color.blue);
            }
        }

        private void CreateView(
            Vector3 position, 
            Quaternion rotation,
            Color color
        )
        {
            var view = Object.Instantiate(_matrixViewPrefab, position, rotation, _parentTransform);
            var renderer = view.Renderer;
           
            renderer.material.color = color;
        }

        private Quaternion MatrixToQuaternion(MatrixData matrix)
        {
            var targetMatrix = new Matrix4x4
            {
                m00 = matrix.m00, m01 = matrix.m01, m02 = matrix.m02, m03 = 0,
                m10 = matrix.m10, m11 = matrix.m11, m12 = matrix.m12, m13 = 0,
                m20 = matrix.m20, m21 = matrix.m21, m22 = matrix.m22, m23 = 0,
                m30 = 0, m31 = 0, m32 = 0, m33 = 1
            };

            return Quaternion.LookRotation(
                targetMatrix.GetColumn(2), 
                targetMatrix.GetColumn(1)  
            );
        }
    }
}