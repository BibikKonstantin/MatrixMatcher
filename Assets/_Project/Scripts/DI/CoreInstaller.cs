using Initializers;
using Core;
using Services;
using Zenject;

namespace DI
{
    public class CoreInstaller : MonoInstaller 
    {
        public override void InstallBindings()
        {
            BindServices();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<PrefabsHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DataLoader>().AsSingle();
            
            Container.Bind<IMatrixProcessor>().To<MatrixProcessor>().AsSingle();  
            Container.BindInterfacesAndSelfTo<MatchFinder>().AsSingle(); 
            
            Container.BindInterfacesAndSelfTo<MatrixVisualizer>().AsSingle();
            Container.Bind<IMatchExporter>().To<MatchMatchExporter>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<MatricesInitializer>().AsSingle();
        }
    }
}