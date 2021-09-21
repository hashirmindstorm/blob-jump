using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void OnRestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ActivateUI()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}
