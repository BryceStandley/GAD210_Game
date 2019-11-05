using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairMovement : MonoBehaviour
{

    public float testDistance = 0.2f;
    public float startWaitTime = 5f;
    public float moveDistanceDelta = 0.1f;

    private float _waitTime;
    private int _currentMovePoint;

    public float smoothTime = 0.5f;
    Vector3 smoothVelocity;

    public Transform[] movePoints;
    

    void Start()
    {
        _waitTime = startWaitTime; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, movePoints[_currentMovePoint].position, ref smoothVelocity, smoothTime);
        //transform.position = Vector3.MoveTowards(transform.position, movePoints[_currentMovePoint].position, moveDistanceDelta);
        if(Vector3.Distance(transform.position, movePoints[_currentMovePoint].position) < testDistance)
        {
            if (_waitTime <= 0)
            {
                _currentMovePoint++;
                if (_currentMovePoint > movePoints.Length - 1)
                {
                    _currentMovePoint = 0;
                }
                _waitTime = startWaitTime;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
    }
}
