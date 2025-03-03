using System.IO;
using Core;
using Models;
using UnityEngine;
using Zenject;

namespace Services
{
    public class DataLoader :
        IDataLoader,
        IInitializable
    {
        private string _modelPath;  
        private string _spacePath;
        
        private const string MODEL_JSON_NAME = "model.json";
        private const string SPACE_JSON_NAME = "space.json";

        public void Initialize()
        {
            _modelPath = Path.Combine(Application.streamingAssetsPath, MODEL_JSON_NAME);  
            _spacePath = Path.Combine(Application.streamingAssetsPath, SPACE_JSON_NAME);  
        }

        public MatrixContainer LoadModelData() => LoadJson(_modelPath);

        public MatrixContainer LoadSpaceData() => LoadJson(_spacePath);

        private MatrixContainer LoadJson(string path)
        {
            if (!File.Exists(path))
            {
                Debug.LogError($"File not found: {path}");
                return null;
            }

            var matricesJson = File.ReadAllText(path);
            var wrappedJson = "{\"Matrices\":" + matricesJson + "}";
            
            var container = JsonUtility.FromJson<MatrixContainer>(wrappedJson);
            
            return container;
        }
    }
}