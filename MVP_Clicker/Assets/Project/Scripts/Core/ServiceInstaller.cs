using Project.Scripts.Core.LoadResourcesService;
using Project.Scripts.Game.Areas.SaveSystem;
using Zenject;

namespace Project.Scripts.Core
{
    public class ServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILoadResourcesService>().To<AddressableLoadResourceService>().AsSingle();
            Container.Bind<ISaveSystemService>().To<SaveSystemService>().AsSingle();
        }
    }
}