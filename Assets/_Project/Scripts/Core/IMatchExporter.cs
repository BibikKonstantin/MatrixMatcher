using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public interface IMatchExporter
    {
        void ExportResults(List<Vector3> matches);
    }
}