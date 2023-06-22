using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDoorScript : MonoBehaviour
{
    public float endingTriggerDistance;
    public string sceneName;

    void Start()
    {
        
    }

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
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            Debug.Log("Wygrałeś");
        }
    }
}
