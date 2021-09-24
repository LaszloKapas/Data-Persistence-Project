using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenu : MonoBehaviour
{
    public Text playerNameInput;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainScene()
    {
        if(PlayerPrefs.instance != null)
        {
            PlayerPrefs.instance.playerName = playerNameInput.text.ToString();

            print(playerNameInput.text);
        }

        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        // save playerdata
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
