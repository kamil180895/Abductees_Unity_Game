using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{

    public bool leverState { get; private set; }
    public float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        leverState = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchLever()
    {
        leverState = !leverState;
    }
}
