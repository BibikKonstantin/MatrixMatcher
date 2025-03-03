using Models;

namespace Core
{
    public interface IMatchFinder
    {
        public ModelMatchResult FindAllMatches(MatrixData modelMatrix, MatrixContainer spaceData);
    }
}