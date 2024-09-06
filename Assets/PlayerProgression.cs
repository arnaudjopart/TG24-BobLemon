using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerProgression : MonoBehaviour
{
    public int _coins;
    public int _xp;
    public Vector3 _position;
    public HighScore[] _highScores;
    // Start is called before the first frame update
    void Start()
    {
        var persistentDataPath = Application.persistentDataPath;
        Debug.Log(persistentDataPath);
       _highScores = _highScores.OrderBy(highScore => highScore.score).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) SavePlayerDataInPersistentDataPath();
        if (Input.GetKeyDown(KeyCode.Space)) LoadPlayerDataFromPersistentDataPath();
    }

    private void LoadPlayerDataFromPersistentDataPath()
    {
        var path = Application.persistentDataPath + "/save.json";
        if (File.Exists(path))
        {
            var jsondata = File.ReadAllText(path);
            var playerProgressionFromSave = JsonUtility.FromJson<PlayerProgressionData>(jsondata);
            _coins = playerProgressionFromSave.Coins;
            _xp = playerProgressionFromSave.XP;
            _position = playerProgressionFromSave.LastPosition;
            _highScores = playerProgressionFromSave.HighScores;

            _highScores.OrderBy(highScore => highScore.score).ToArray();
        }
        else
        {
            Debug.LogError("No file found at " + path);
        }
    }

    private void SavePlayerDataInPersistentDataPath()
    {
        var path = Application.persistentDataPath+"/save.json";
        var data = new PlayerProgressionData()
        {
            Coins = _coins,
            XP = _xp,
            LastPosition = _position,
            HighScores = _highScores
        };
        var jsonData = JsonUtility.ToJson(data, true);
        Debug.Log(jsonData);

        File.WriteAllText(path, jsonData); 


    }
}

[Serializable]
public class PlayerProgressionData
{
    public int XP;
    public int Coins;
    public Vector3 LastPosition;

    public HighScore[] HighScores;
}
