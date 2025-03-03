using System.Collections.Generic;
using Models;

namespace Core
{
    public interface IMatrixVisualizer
    {
        public void VisualizeMatrices(
            MatrixContainer modelData,
            MatrixContainer spaceData,
            Dictionary<int, ModelMatchResult> modelIntersectionResults
        );
    }
}