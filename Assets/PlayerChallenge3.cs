using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChallenge3 : MonoBehaviour
{
    [SerializeField]
    private GameObject _spherePrefab;


    // Update is called once per frame
    void Update()
    {
        
        //if left click
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Left Clicked");

            Vector2 mousePos = Mouse.current.position.ReadValue();

            Ray rayOrigin = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("Hit: " + hitInfo.collider.name);
                Instantiate(_spherePrefab, hitInfo.point, Quaternion.identity);
            }

        }

        //raycast (origin = mouse pos)
        //hitInfo (to detect the floor)
        //instantiate sphere at hit point
    }
}
