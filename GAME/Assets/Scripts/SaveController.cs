using UnityEngine;
using System.IO;
using Unity.Cinemachine;

public class SaveController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string saveLocation;
    void Start()
    {
        //define lacation
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");

        LoadGame();
    }

   public void SaveGame()
    {
        SaveData saveData = new SaveData
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
            //mapBoundary = FindObjectOfType<CinemachineConfiner>().m_BoundingShape2D.gameObject.name

        };
        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));
            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;

            //FindObjectOfType<CinemachineConfiner>().m_BoundingShape2D = GameObject.Find(saveData.mapBoundary).GetComponent<CapsuleCollider2D>();
        }
        else
        {
            SaveGame();
        }
    }
    
    

}
