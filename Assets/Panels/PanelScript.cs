using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelScript : MonoBehaviour
{
    public GameObject panel;
    private SpriteRenderer spriteRenderer;
    public GameObject text;
    private TMPro.TextMeshProUGUI textMesh;
    public Sprite[] sprites;
    public string[] texts;
    public int currentSprite;
    void Start()
    {
        spriteRenderer = panel.GetComponent<SpriteRenderer>();
        textMesh = text.GetComponent<TMPro.TextMeshProUGUI>();
        currentSprite = -1;
        ChangeSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite()
    {
        currentSprite++;
        if (currentSprite >= sprites.Length)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        spriteRenderer.sprite = sprites[currentSprite];
        textMesh.text = texts[currentSprite];
    }
}
