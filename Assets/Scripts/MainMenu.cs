using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] int firstSceneIndex;




    public void LoadFirstLevel()
    {
        SceneManager.LoadSceneAsync(firstSceneIndex);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
