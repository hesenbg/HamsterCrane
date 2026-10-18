using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] int firstSceneIndex;

    [SerializeField] Canvas main;

    [SerializeField] Canvas controls;

    public void SwitcControls()
    {
        controls.gameObject.SetActive(true);
        main.gameObject.SetActive(false);
    }

    public void SwitchMain()
    {
        controls.gameObject.SetActive(false);
        main.gameObject.SetActive(true);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadSceneAsync(firstSceneIndex);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
