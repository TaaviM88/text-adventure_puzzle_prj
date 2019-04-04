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
    string correctWord;

    string[] lookObjects;

    bool initialBaseScene = false;
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

    public void UpdateCorrectWord(string w)
    {
        correctWord = w;
    }

    public string ReturnCorrectWord()
    {
        return correctWord;  
    }

    public string LookObject(string obj)
    {
        string tmp = "";


        return tmp;
    }

    public void QuitGame()
    {
        //Application.Quit();
        Debug.Log("Quit game.");
    }
}
