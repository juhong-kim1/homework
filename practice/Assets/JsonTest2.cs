using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Overlays;
using UnityEngine;


[Serializable]
public class SaveData
{
    public List<SaveObjData> cubes = new List<SaveObjData>();
}

[Serializable]
public class SaveObjData
{
    public Vector3 position;
}

public class JsonTest2 : MonoBehaviour
{
    public static readonly string fileName = "cube.json";

    public static string FileFullPath => Path.Combine(Application.persistentDataPath, fileName);

    public List<GameObject> gameObjects = new List<GameObject>();
    public GameObject target;

    public void Save()
    {
        SaveData saveData = new SaveData();

        foreach (var objects in gameObjects)
        {
            SaveObjData objData = new SaveObjData()
            {
                position = objects.transform.position,
            };
 
            saveData.cubes.Add(objData);
        }
            var json = JsonConvert.SerializeObject(saveData ,new Vector3Converter());
            File.WriteAllText(FileFullPath, json);
    }

    public void Load()
    {
            var json = File.ReadAllText(FileFullPath);
            var position = JsonConvert.DeserializeObject<Vector3>(json, new Vector3Converter());
            target.transform.position = position;

    }

    public void Random()
    {
        int randomNumber = UnityEngine.Random.Range(0, 4);

        for (int i = 0; i < randomNumber; i++)
        {
            float randomX = UnityEngine.Random.Range(-10.0f, 10.0f);
            float randomY = UnityEngine.Random.Range(-5.0f, 5.0f);

            float rotationX = UnityEngine.Random.Range(0f, 90f);
            float rotationY = UnityEngine.Random.Range(0f, 90f);

            Vector3 position = new Vector3(randomX, randomY, 0f);
            Vector3 Rotation = new Vector3(rotationX, rotationY, 0f);

            Instantiate(target, position, Quaternion.Euler(Rotation));
            gameObjects.Add(target);
        }
    }
}
