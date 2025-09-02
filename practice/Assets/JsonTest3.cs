using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class RecordingData
{
    public List<FrameData> frames = new List<FrameData>();
}

[Serializable]
public class FrameData
{
    public float timeStamp;
    public Vector3 position;
    public Quaternion rotation;
}

public class JsonTest3 : MonoBehaviour
{
    public static readonly string fileName = "recording.json";
    public static string FileFullPath => Path.Combine(Application.persistentDataPath, fileName);

    public GameObject playerObject;
    public float recordingInterval = 0.1f;

    private RecordingData currentRecording = new RecordingData();

    void Update()
    {

    }

    public void Rec()
    {
        var json = JsonConvert.SerializeObject(currentRecording, new Vector3Converter());
        File.WriteAllText(FileFullPath, json);
    }

    public void Play()
    {
            var json = File.ReadAllText(FileFullPath);
            currentRecording = JsonConvert.DeserializeObject<RecordingData>(json, new Vector3Converter());
        
    }
}
