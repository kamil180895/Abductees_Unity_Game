using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoorScript : MonoBehaviour
{
    public float endingTriggerDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject farthestPlayer = players[0];
        float maxDist = (farthestPlayer.transform.position - transform.position).magnitude;
        foreach (GameObject p in players)
        {
            float dist = (p.GetComponent<Transform>().position - transform.position).magnitude;
            if (dist > maxDist)
            {
                maxDist = dist;
                farthestPlayer = p;
            }
        }

        if(maxDist < endingTriggerDistance)
        {
            //zakończ poziom
            Debug.Log("Wygrałeś");
        }
    }
}
