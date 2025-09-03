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
}

public class JsonTest3 : MonoBehaviour
{
    public static readonly string fileName = "recording.json";
    public static string FileFullPath => Path.Combine(Application.persistentDataPath, fileName);

    public GameObject playerObject;
    private float recordingInterval = 0.1f;
    private float recordingTime = 0f;
    private float lastRecordTime = 0f;

    bool isRecording = false;
    bool isPlaying = false;

    private RecordingData currentRecording = new RecordingData();

    void Update()
    {
        if(isRecording)
        {
            recordingTime += Time.deltaTime;
            if (recordingTime - lastRecordTime >= recordingInterval)
            {
                FrameData frame = new FrameData()
                {
                    timeStamp = recordingTime,
                    position = playerObject.transform.position
                };
                currentRecording.frames.Add(frame);
                lastRecordTime = recordingTime;
            }
        }

        if (isPlaying)
        {
            



        }

    }

    public void Rec()
    {
        if (isRecording)
        {
            var json = JsonConvert.SerializeObject(currentRecording, new Vector3Converter());
            File.WriteAllText(FileFullPath, json);
            isRecording = false;
        }
        else
        {
            isRecording = true;
            recordingTime = 0f;
        }
    }

    public void Play()
    {
            var json = File.ReadAllText(FileFullPath);
            currentRecording = JsonConvert.DeserializeObject<RecordingData>(json, new Vector3Converter());
            isPlaying = true;
    }
}
