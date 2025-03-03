using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Core
{
    public interface IMatrixProcessor
    {
        MatrixData Rotate(MatrixData matrix, int times);
        MatrixData Reflect(MatrixData matrix, bool horizontal);
    }
}