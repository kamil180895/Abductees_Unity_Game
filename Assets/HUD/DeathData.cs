using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DeathData : ScriptableObject
{
    public float deaths;

    public void ResetDeaths()
    {
        deaths = 0;
    }

    public void AddDeath()
    {
        deaths++;
    }
}
