using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float timescale;
    public float distance;
    private float initialY;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        initialY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.position = new Vector2(transform.position.x, initialY + Mathf.Sin(time * timescale) * distance);
    }
}
