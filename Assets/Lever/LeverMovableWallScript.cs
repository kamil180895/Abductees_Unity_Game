using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LeverMovableWallScript : MonoBehaviour
{
    public GameObject connectedLever;
    public Transform positionLeverOff;
    public Transform positionLeverOn;
    public float moveSpeed;

    private Transform moveTarget;

    // Start is called before the first frame update
    void Start()
    {
        moveTarget = positionLeverOff;
    }

    // Update is called once per frame
    void Update()
    {
        if(connectedLever.GetComponent<LeverScript>().leverState)
        {
            moveTarget = positionLeverOn;
        }
        else
        {
            moveTarget = positionLeverOff;
        }

        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, moveTarget.position, step);
    }
}
