using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameDataManager : MonoBehaviour {

    private static String PLAYER_DATA_FILE = "playerData.dat";

    public static GameDataManager instance;

    public int highScore{
        get { return playerData.highScore; }
        set { playerData.highScore = value; }
    }
    public string playerName{
        get { return playerData.PlayerName; }
        set { playerData.PlayerName = value; }
    }

    private PlayerData playerData;

	void Awake () {
        if ( instance == null )
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            init();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
	}

    public void savePlayerData()
    {
        saveDataToStorage();    
    }

    private void init()
    {
        loadDataFromStorage();
    }


    private void loadDataFromStorage()
    {
        if ( File.Exists( Application.persistentDataPath + "/" + PLAYER_DATA_FILE ) )
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(Application.persistentDataPath + "/" + PLAYER_DATA_FILE, FileMode.Open);
            playerData = (PlayerData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
        }
        else
        {
            playerData = new PlayerData();
        }
    }

    private void saveDataToStorage()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Open(
            Application.persistentDataPath + "/" + PLAYER_DATA_FILE, 
            FileMode.OpenOrCreate);
        binaryFormatter.Serialize(fileStream, playerData);
        fileStream.Close();
    }

}

[Serializable]
class PlayerData
{
    public int highScore;
    public string PlayerName;
}
