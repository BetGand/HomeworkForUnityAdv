using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Game : MonoBehaviour {
    static PlayerData player;
    public GameObject cube;
	// Use this for initialization
	void Start () {
        player = new PlayerData();
        LoadPicture();

    }
	
	// Update is called once per frame
	void Update () {
        player.experiance++;
        StartCoroutine("Saves");

    }

    void LoadPicture()
    {
        string path = Application.streamingAssetsPath + "/Images";
        if (Directory.Exists(path))
        {
            using (WWW picture = new WWW(path + "/house.jpg"))
            {
                Renderer renderer = cube.GetComponent<Renderer>();
                renderer.material.mainTexture = picture.texture;
            }
        }
    }
    IEnumerator Saves()
    {
            string json = JsonUtility.ToJson(player);
            string path = Application.streamingAssetsPath + "/saves";
            //search for the folder
            if (!Directory.Exists(path))
                //create the folder - if not exist
                Directory.CreateDirectory(path);
            File.WriteAllText(path + "/save.json", json);
            yield return new WaitForSeconds(1f);
    }
}
