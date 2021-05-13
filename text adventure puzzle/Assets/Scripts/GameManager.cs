using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    int sceneIndex = 1;
    string tmpSceneName = "";

    RoomController roomWord;
    GameObject correctWord;

    string[] lookObjects;

    bool initialBaseScene = false;
    bool canMoveNextScene = true;

    public Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

    }

  
    public void LoadNextScene()
    {
        if (tmpSceneName != "")
        {
            SceneManager.UnloadSceneAsync(sceneIndex-1);
        }

        if (SceneManager.GetActiveScene().buildIndex + sceneIndex < SceneManager.sceneCountInBuildSettings)
        {

            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + sceneIndex, LoadSceneMode.Additive);
            sceneIndex += 1;
            tmpSceneName = $"{sceneIndex}";
        }
        else
        {
            Infotext.Instance.UpdateInfo("This was last scene");
        }
    }

    public void UpdateCorrectWord(GameObject w)
    {
        correctWord = w;
    }

    public GameObject ReturnCorrectWord()
    {
        return correctWord;  
    }

    public void QuitGame()
    {
        //Application.Quit();
        Debug.Log("Quit game.");
    }

    public bool CanMoveNextScene()
    {
        return canMoveNextScene;
    }

    public void ChangeCanMoveNextScene(bool b)
    {
        canMoveNextScene = b;
    }

    public void FadeToLevel()
    {
        anime.SetTrigger("FadeOut");
    }

    
}
