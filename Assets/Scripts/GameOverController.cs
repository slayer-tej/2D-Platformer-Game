using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonHome;
    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        buttonHome.onClick.AddListener(LobbyScreen);
    }

    private void LobbyScreen()
    {
        SoundManager.Instance.Play(Sounds.RestartButtonclick);
        SceneManager.LoadScene(0);
        SoundManager.Instance.PlayMusic(Sounds.Music);

    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);         
    }

    private void ReloadLevel()
    {
        SoundManager.Instance.Play(Sounds.RestartButtonclick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManager.Instance.PlayMusic(Sounds.Music);

    }
}
