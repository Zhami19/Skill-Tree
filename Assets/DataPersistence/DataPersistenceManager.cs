using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;
    public static DataPersistenceManager instance {  get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene.");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //load saved data

        if (this.gameData == null)
        {
            Debug.Log("No data was found.  Initializing data to defaults.");
            NewGame();
        }

        //push loaded data to scripts that need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("Loaded money count = " + gameData.moneyCount);
    }

    public void SaveGame()
    {
        //pass data to scripts to update it
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        //save data with data handler

        Debug.Log("Saved money count = " + gameData.moneyCount);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IDataPersistence>();  //review 

        return new List<IDataPersistence>(dataPersistenceObjects);

        
    }
}
