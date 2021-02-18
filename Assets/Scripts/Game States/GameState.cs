using System;
using PlayerController;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;


public class GameState : MonoBehaviour
{
    [SerializeField] private Image _loseGameImage;
    [SerializeField] private Image _winGameImage;
    private PlayerState _playerState;

    [Inject]
    private void Construct(PlayerState playerState)
    {
        _playerState = playerState;
    }

    private void OnEnable()
    {
        _playerState.OnStateChanged += StateChangeHandler;
    }

    private void StateChangeHandler(State state)
    {
        switch (state)
        {
            case State.WIN:
                _winGameImage.gameObject.SetActive(true);
                break;
            case State.LOSE:
                _loseGameImage.gameObject.SetActive(true);
                break;
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else Debug.Log("No more scenes yet");
    }

    public void CloseGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
    }
    
    private void OnDisable()
    {
        _playerState.OnStateChanged -= StateChangeHandler;
    }
}
