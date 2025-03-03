using System.Collections.Generic;
using System.IO;
using Core;
using Models;
using UnityEngine;

namespace Services
{
    public class MatchMatchExporter : IMatchExporter
    {
        private const string EXPORT_JSON_NAME = "matches.json";

        public void ExportResults(List<Vector3> matches)
        {
            var exportData = new ExportData
            {
                Offsets = new List<Vector3>(matches)
            };

            var jsonString = JsonUtility.ToJson(exportData, true); 

            var path = Path.Combine(Application.streamingAssetsPath, EXPORT_JSON_NAME);

            File.WriteAllText(path, jsonString);
        }
    }
}