using _Project.Scripts.DB;
using UnityEngine;
using Zenject;

namespace DI
{
    [CreateAssetMenu(fileName = "ConfigsInstaller", menuName = "Installers/ConfigsInstaller", order = 2)]
    public class ConfigsInstaller : ScriptableObjectInstaller<ConfigsInstaller>
    {
        [SerializeField] private MatchConfig _matchConfig;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MatchConfig>().FromInstance(_matchConfig).AsSingle();
        }
    }
}