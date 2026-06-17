using UnityEngine;
using Newtonsoft.Json;

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
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
