using Core;
using Models;
using UnityEngine;

namespace Services
{
    public class MatrixProcessor : IMatrixProcessor
    {
        private const float HALF_PI = Mathf.PI / 2;

        public MatrixData Rotate(MatrixData matrix, int times)
        {
            for (var i = 0; i < times; i++)
            {
                var cosTheta = Mathf.Cos(HALF_PI);
                var sinTheta = Mathf.Sin(HALF_PI);

                var rotatedMatrix = new MatrixData();

                rotatedMatrix.m00 = cosTheta * matrix.m00 - sinTheta * matrix.m10;
                rotatedMatrix.m01 = cosTheta * matrix.m01 - sinTheta * matrix.m11;
                rotatedMatrix.m02 = cosTheta * matrix.m02 - sinTheta * matrix.m12;
                rotatedMatrix.m10 = sinTheta * matrix.m00 + cosTheta * matrix.m10;
                rotatedMatrix.m11 = sinTheta * matrix.m01 + cosTheta * matrix.m11;
                rotatedMatrix.m12 = sinTheta * matrix.m02 + cosTheta * matrix.m12;

                rotatedMatrix.m03 = matrix.m03;
                rotatedMatrix.m13 = matrix.m13;
                rotatedMatrix.m23 = matrix.m23;
                rotatedMatrix.m33 = matrix.m33;

                matrix = rotatedMatrix;
            }
            return matrix;
        }

        public MatrixData Reflect(MatrixData matrix, bool horizontal)
        {
            if (horizontal)
            {
                matrix.m00 = -matrix.m00;
                matrix.m10 = -matrix.m10;
                matrix.m20 = -matrix.m20;
                matrix.m30 = -matrix.m30;
            }
            else
            {
                matrix.m01 = -matrix.m01;
                matrix.m11 = -matrix.m11;
                matrix.m21 = -matrix.m21;
                matrix.m31 = -matrix.m31;
            }
            return matrix;
        }
    }
}