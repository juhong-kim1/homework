using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    public Quaternion rotation;
    public Color color;
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
            Renderer renderer = objects.GetComponent<Renderer>();
            Color objectColor = renderer.material.color;

            SaveObjData objData = new SaveObjData()
            {
                position = objects.transform.position,
                rotation = objects.transform.rotation,
                color = objectColor
            };
 
            saveData.cubes.Add(objData);
        }
            var json = JsonConvert.SerializeObject(saveData ,new Vector3Converter(), new QuaternionConverter(), new ColorConverter());
            File.WriteAllText(FileFullPath, json);
    }

    public void Load()
    {
        gameObjects.Clear();

        var json = File.ReadAllText(FileFullPath);
        var saveData = JsonConvert.DeserializeObject<SaveData>(json, new Vector3Converter(), new QuaternionConverter(), new ColorConverter());

        foreach (var cubeData in saveData.cubes)
        {
            GameObject newObj = Instantiate(target, cubeData.position, Quaternion.identity);

            Renderer renderer = newObj.GetComponent<Renderer>();
            renderer.material.color = cubeData.color;
            gameObjects.Add(newObj);
        }

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

            Color randomColor = new Color(
               UnityEngine.Random.Range(0f, 1f),
               UnityEngine.Random.Range(0f, 1f),
               UnityEngine.Random.Range(0f, 1f),
               1f);


           Vector3 position = new Vector3(randomX, randomY, 0f);
            Vector3 Rotation = new Vector3(rotationX, rotationY, 0f);

            GameObject newObj = Instantiate(target, position, Quaternion.Euler(Rotation));

            Renderer renderer = newObj.GetComponent<Renderer>();
            renderer.material.color = randomColor;

            gameObjects.Add(newObj);
        }
    }
}
