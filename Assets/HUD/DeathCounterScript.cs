using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCounterScript : MonoBehaviour
{
    public GameObject textDeaths;
    private TMPro.TextMeshProUGUI text;
    public DeathData deathData;
    public int displayedDeaths;
    // Start is called before the first frame update
    void Start()
    {
        text = textDeaths.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (displayedDeaths != (int)deathData.deaths)
        {
            displayedDeaths = (int)deathData.deaths;
            text.text = displayedDeaths.ToString();
        }
    }
}
