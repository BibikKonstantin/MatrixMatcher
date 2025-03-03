using Models;

namespace Core
{
    public interface IDataLoader
    {
        MatrixContainer LoadModelData();  
        MatrixContainer LoadSpaceData(); 
    }
}