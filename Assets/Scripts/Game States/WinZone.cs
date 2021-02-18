using PlayerController;
using UnityEngine;
using Zenject;

public class WinZone : MonoBehaviour
{
   private PlayerState _playerState;

   [Inject]
   private void Construct(PlayerState playerState)
   {
      _playerState = playerState;
   }
   
   private void OnTriggerEnter(Collider other)
   {
      _playerState.State = State.WIN;
   }
}
