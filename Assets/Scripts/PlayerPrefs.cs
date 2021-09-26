using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PlayerPrefs : MonoBehaviour
{
    public static PlayerPrefs instance;

    public int bestScore;
    public string playerName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SavePlayerData
    {
        public int bestScore;
    }

    public void SaveBestScore()
    {
        SavePlayerData data = new SavePlayerData();
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavePlayerData data = JsonUtility.FromJson<SavePlayerData>(json);

            bestScore = data.bestScore;
        }
    }
}
