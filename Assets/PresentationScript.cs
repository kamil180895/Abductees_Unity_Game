using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
