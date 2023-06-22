using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHudScript : MonoBehaviour
{
    public Sprite headRed;
    public Sprite headBlue;
    public Sprite slotFull;
    public Sprite slotEmpty;
    public SpriteRenderer head;
    public SpriteRenderer slot1;
    public SpriteRenderer slot2;
    public SpriteRenderer slot3;
    public int bulletCount;
    private int bulletsLeft;
    public GameObject player;
    private PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
        if (gameObject.tag == "Player1")
        {
            head.sprite = headRed;
        }
        else if (gameObject.tag == "Player2")
        {
            head.sprite = headBlue;
        }
        bulletCount = 0;
        bulletsLeft = bulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        bulletCount = playerScript.currentProjetiles;
        if (bulletCount != bulletsLeft)
        {
            if (bulletCount == 3)
            {
                slot1.sprite = slotFull;
                slot2.sprite = slotFull;
                slot3.sprite = slotFull;
            }
            else if (bulletCount == 2)
            {
                slot1.sprite = slotFull;
                slot2.sprite = slotFull;
                slot3.sprite = slotEmpty;
            }
            else if (bulletCount == 1)
            {
                slot1.sprite = slotFull;
                slot2.sprite = slotEmpty;
                slot3.sprite = slotEmpty;
            }
            else if (bulletCount == 0)
            {
                slot1.sprite = slotEmpty;
                slot2.sprite = slotEmpty;
                slot3.sprite = slotEmpty;
            }
            bulletsLeft = bulletCount;
        }
    }
}
