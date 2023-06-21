using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{

    public bool leverState { get; private set; }
    public float maxDistance;
    public Sprite leverOn;
    public Sprite leverOff;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        leverState = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchLever()
    {
        leverState = !leverState;
        if (leverState)
        {
            spriteRenderer.sprite = leverOn;
        }
        else
        {
            spriteRenderer.sprite = leverOff;
        }
    }
}
