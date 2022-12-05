using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        //requires user input
        //left mouse click

        //fire raycast from the main camera or mouse position
        //access the object that we hit

        //change color

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("left clicked");

            Vector2 mousePos = Mouse.current.position.ReadValue();
            //define the starting point of the ray

            Ray rayOrigin = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("Hit: " + hitInfo.collider.name);

                var hitObject = hitInfo.collider.GetComponent<MeshRenderer>();

                if (hitObject != null)
                {
                    hitObject.material.color = UnityEngine.Random.ColorHSV();
                }
            }
        }
    }
}
