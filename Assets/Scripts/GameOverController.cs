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
        SceneManager.LoadScene(0);
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);         
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
