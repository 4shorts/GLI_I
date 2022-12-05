using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChallange4 : MonoBehaviour
{
    private Rigidbody _rigid;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector3.down * 3f, Color.blue);
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, 3f))
        {
            if (hitInfo.collider.name == "Floor")
            {
                _rigid.isKinematic = true;
                _rigid.useGravity = false;
            }
        }
    }

    
}
