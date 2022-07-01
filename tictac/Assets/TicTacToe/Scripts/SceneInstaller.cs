using TicTacToe.Scripts.Views;
using Zenject;

namespace TicTacToe.Scripts
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<FieldModel>().AsSingle();
            Container.Bind<GameStateModel>().AsSingle();
            Container.BindInstance(FindObjectOfType<GameplayView>()).AsSingle();
            Container.BindInstance(FindObjectOfType<UIView>()).AsSingle();
            Container.Bind<GameplayController>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
            Container.Bind<PlayerController>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
            Container.Bind<AIController>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}