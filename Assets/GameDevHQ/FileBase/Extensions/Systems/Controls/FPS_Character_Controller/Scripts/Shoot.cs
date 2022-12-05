using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletHolePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //cast raycast through the center of the crosshair.
        //instantiate a bullet hole prefab.
        //figure out the rotation of the bullet hole.
        //figure out how to get the
        //if left click
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Instantiate(_bulletHolePrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
        }
    }
}
