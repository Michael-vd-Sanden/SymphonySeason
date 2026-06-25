using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;
using System.Threading.Tasks;

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

        Debug.Log(Application.persistentDataPath);
    }

    public async Task CreateFirsttimeData()
    {
        SSeasonJSONData retData = new SSeasonJSONData();

        string output = @"{
                'AppHasStarted': true,
                'CurrentLevelIndex': 0,
                'LevelIndexes': [0,0]
            }";
        retData = JsonConvert.DeserializeObject<SSeasonJSONData>(output);

        JSONHandler.Instance.WriteJSON(retData);
        Debug.Log("Created data");

        await Task.Yield();
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
