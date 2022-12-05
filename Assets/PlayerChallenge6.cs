using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChallenge6 : MonoBehaviour
{
    //variable to store target destination
    [SerializeField]
    private Vector3 _targetDestination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move towards target
        //code logic for movement
        //calculate distance
        var distance = Vector3.Distance(_targetDestination, transform.position);

        if (distance > 1.0f)
        {
            //direction = destination - source
            var direction = _targetDestination - transform.position;
            direction.Normalize();
            //move towards destination
            transform.Translate(direction * 2.0f * Time.deltaTime);
        }
    }

    public void UpdateDestination(Vector3 pos)
    {
        //lock the y to -0.68
        pos.y = -0.71f;
        _targetDestination = pos;
    }
}
