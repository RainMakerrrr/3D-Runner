using Obstacles;
using PlayerController;
using PlayerController.Animations;
using PlayerController.Input;
using PlayerController.Movement;
using PlayerController.Weight;
using UnityEngine;
using Zenject;

namespace SceneInstallers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private PlayerState _playerState;
        [SerializeField] private PlayerMovement _player;
        [SerializeField] private InputHandler _inputHandler;
        public override void InstallBindings()
        {
            BindInputHandler();
            BindPlayer();
            BindBaseComponents();
            BindWall();
        }

        private void BindWall()
        {
            Container.Bind<Wall>().FromComponentInParents();
        }

        private void BindInputHandler()
        {
            Container.Bind<InputHandler>().FromInstance(_inputHandler).AsSingle();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerMovement>().FromInstance(_player).AsSingle();
            Container.Bind<PlayerCollision>().FromComponentOn(_player.gameObject).AsSingle();
            Container.Bind<PlayerAnimation>().FromComponentOn(_player.gameObject).AsSingle();
            Container.Bind<PlayerWeight>().FromComponentOn(_player.gameObject).AsSingle();
            Container.Bind<PlayerState>().FromInstance(_playerState).AsSingle();
        }

        private void BindBaseComponents()
        {
            Container.Bind<Rigidbody>().FromComponentSibling().AsTransient();
            Container.Bind<Animator>().FromComponentSibling().AsTransient();
            Container.Bind<MeshRenderer>().FromComponentSibling().AsTransient();
        }
    }
}