using UnityEngine;
using Newtonsoft.Json;
// using System.Text.Json.Serialization;
using System.Diagnostics.Contracts;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

public class SSeasonJSONData
{
    public bool AppHasStarted { get; set; } //if the towerworld scene has been started from the application or returned from another scene
    public int CurrentLevelIndex { get; set; }
    public List<int> LevelIndexes { get; set; } //the LvIndex ID is the list nr. The value is the level index itself
}

public class JSONHandler : MonoBehaviour
{
    public static JSONHandler Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            return;
        }

        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public SSeasonJSONData GetJSONData()
    {
        string path = Application.persistentDataPath + "/sseason.json";
        SSeasonJSONData retData = new SSeasonJSONData();

        if (File.Exists(path))
        {
            string output;
            using (StreamReader sr = new StreamReader(path))
            {
                output = sr.ReadToEnd();
            }

            retData = JsonConvert.DeserializeObject<SSeasonJSONData>(output);
        }

        return retData;
    }

    public void WriteJSON(SSeasonJSONData data)
    {
        string path = Application.persistentDataPath + "/sseason.json";
        string output = JsonConvert.SerializeObject(data);
        File.WriteAllText(path, output);
    }
}
