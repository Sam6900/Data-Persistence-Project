using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string PlayerName;
    public string BestPlayerName;
    public int PlayerScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return; 
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerData();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int playerScore;
        public string bestPlayerName;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.playerName = PlayerName;
        data.playerScore = PlayerScore;
        data.bestPlayerName = BestPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.playerName;
            PlayerScore = data.playerScore;
            BestPlayerName = data.bestPlayerName;
        }
    }
}


