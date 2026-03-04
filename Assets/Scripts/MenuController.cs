using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Clear any previous scores
        PlayerPrefs.SetInt("Score", 0);

        SceneManager.LoadScene("GameScene");
    }
}