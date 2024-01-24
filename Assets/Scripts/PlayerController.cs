using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5f;

    private CharacterController characterController;
    private SaveManager checkSave;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        checkSave = GameObject.Find("SaveManagerObject").GetComponent<SaveManager>();
        PlayerPosition();
    }

    // Update is called once per frame
    void Update()
    {
        CharacMove();
    }

    void PlayerPosition()
    {
        transform.position = new Vector3(checkSave.playerPosition.x, checkSave.playerPosition.y, checkSave.playerPosition.z);
    }

    void CharacMove()
    {
        float inputH = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(inputH, 0f, 0f);
        Vector3 moveVector = moveDirection * playerSpeed * Time.deltaTime;
        characterController.Move(moveVector);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Check_One")
        {
            Debug.Log("Save");
            checkSave.checkPoint = "1";
            checkSave.SavedData();
        }

        if(other.gameObject.tag == "Check_Two")
        {
            Debug.Log("Save 2");
            checkSave.checkPoint = "2";
            checkSave.SavedData();
        }

        if(other.gameObject.tag == "Check_Three")
        {
            Debug.Log("Save 3");
            checkSave.checkPoint = "3";
            checkSave.SavedData();
        }
    }
}
