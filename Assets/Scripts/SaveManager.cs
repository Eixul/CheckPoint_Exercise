using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Text checkText;
    [SerializeField] public string checkPoint;
    [SerializeField] public Vector3 playerPosition;

    PlayerController playerCont;
    
    // Start is called before the first frame update
    void Start()
    {
        playerCont = GameObject.Find("Player").GetComponent<PlayerController>();
        LoadedData();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = playerCont.transform.position;
    }

    public void SavedData()
    {
        PlayerPrefs.SetString("checkpoint", checkPoint);
        PlayerPrefs.SetFloat("position x", playerCont.transform.position.x);
        PlayerPrefs.SetFloat("position y", playerCont.transform.position.y);
        PlayerPrefs.SetFloat("position z", playerCont.transform.position.z);
        LoadedData();
    }

    void LoadedData()
    {
        checkText.text = "Checkpoint: " + PlayerPrefs.GetString("Checkpoint: ", checkPoint);
        playerPosition = new Vector3(PlayerPrefs.GetFloat("position x", 7.73f), PlayerPrefs.GetFloat("position y", 1.2f), PlayerPrefs.GetFloat("position z", 0f));
    }

    void DataDeleted()
    {
        PlayerPrefs.DeleteKey("checkpoint");
        PlayerPrefs.DeleteKey("position x");
        PlayerPrefs.DeleteKey("position y");
        PlayerPrefs.DeleteKey("position z");

        LoadedData();
    }
}
