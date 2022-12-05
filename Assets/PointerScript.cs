using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PointerScript : MonoBehaviour
{
    [SerializeField]
    private PlayerChallenge6 _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerChallenge6>();
        if (_player == null)
        {
            Debug.LogError("Failed to find Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if left click
        //cast out ray
        //if hit floor
        //set target destination (tell player to move here)
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Left Clicked");
            Vector2 mousePos = Mouse.current.position.ReadValue();

            Ray rayOrigin = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                if (hitInfo.collider.name == "Floor")
                {
                    //update opsition to move to
                    _player.UpdateDestination(hitInfo.point);
                }
            }
        }
    }
}
