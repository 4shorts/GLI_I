using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AI : MonoBehaviour
{

    private enum AIState
    {
        Walking,
        Jumping,
        Attack,
        Death
    }
    //store all way points
    //select a random way point
    //travel to that way point
    [SerializeField]
    private List<Transform> _wayPoints;
    private NavMeshAgent _agent;
    private int _currentPoint = 0;
    private bool _inReverse = false;
    [SerializeField]
    private AIState _currentState;
    private bool _attacking = false;
    // Start is called before the first frame update
    void Start()
    {
       _agent = GetComponent<NavMeshAgent>();

        var randomTarget = Random.Range(0, _wayPoints.Count);

        if (_agent != null)
        {

            _agent.destination = _wayPoints[_currentPoint].position;

            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            _currentState = AIState.Jumping;
            _agent.isStopped = true;
        }

        //determain current AI behavior
        switch(_currentState)
        {
            case AIState.Walking:
                Debug.Log("Walking...");
                CalculateAIMovement();
                break;
            case AIState.Jumping:
                Debug.Log("Jumping...");
                break;
            case AIState.Attack:
                Debug.Log("Attack...");
                if (_attacking == false)
                {
                    StartCoroutine(AttackRoutine());
                    _attacking = true;
                }
                break;
            case AIState.Death:
                Debug.Log("Death...");
                break;
        }
    }

    void CalculateAIMovement()
    {
        if (_agent.remainingDistance < 0.5f)
        {
            if (_inReverse == true)
            {
                Reverse();
            }
            else
            {
                Forward();
            }
            _agent.SetDestination(_wayPoints[_currentPoint].position);

            _currentState = AIState.Attack;
        }
    }

    void Forward()
    {
        if (_currentPoint == _wayPoints.Count - 1)
        {
            _inReverse = true;
            _currentPoint--;
        }

        else
        {
            _currentPoint++;
        }
    }

    void Reverse()
    {
        if (_currentPoint == 0)
        {
            _inReverse = false;
            _currentPoint++;
        }
        else
        {
            _currentPoint--;
        }
    }

    IEnumerator AttackRoutine()
    {
        _agent.isStopped = true;
        yield return new WaitForSeconds(3.0f);
        _agent.isStopped = false;
        _currentState = AIState.Walking;
        _attacking = false;
    }
}
