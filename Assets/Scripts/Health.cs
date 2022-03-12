using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    // Con  este script controlamos la UI de la vida del jugador

    private newThirdPersonController playerControllerScript;
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<newThirdPersonController>();
    }

    void Update()
    {

        health = playerControllerScript.objectLife;

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
                {
                    hearts[i].enabled = true;
                }
            else
            {
                hearts[i].enabled = false;
            }
        }
     

    }
}
