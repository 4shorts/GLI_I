using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChallange2 : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("left clicked");

            Vector2 mousePos = Mouse.current.position.ReadValue();
            //define the starting point of the ray

            Ray rayOrigin = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                //who did I hit?
                var hitRenderer = hitInfo.collider.GetComponent<MeshRenderer>();

                if (hitRenderer == null)
                    return;

                switch (hitInfo.collider.tag)
                {

                    case "Cube":
                        hitRenderer.material.color = Random.ColorHSV();
                        break;
                    case "Sphere":
                        //do nothing
                        break;
                    case "Capsule":
                        hitRenderer.material.color = Color.black;
                        break;
                }
            }
        }
    }
}
