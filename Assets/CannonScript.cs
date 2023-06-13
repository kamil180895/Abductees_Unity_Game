using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public GameObject rocketPrefab;
    private float time = 0.0f;
    public float interpolationPeriod = 1f;
    public float aggroDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject nearestPlayer = players[0];
        float minDist = (nearestPlayer.transform.position - transform.position).magnitude;
        foreach (GameObject p in players)
        {
            float dist = (p.GetComponent<Transform>().position - transform.position).magnitude;
            if (dist < minDist)
            {
                minDist = dist;
                nearestPlayer = p;
            }
        }

        time += Time.deltaTime;

        if (time >= interpolationPeriod && minDist < aggroDistance)
        {
            time = 0;

            GameObject rocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
            Physics2D.IgnoreCollision(rocket.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
