using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    HeroKnight player;
    public bool death;
    public int life;
    public int maxLife;

    public Image[] heart;
    public Sprite full;
    public Sprite empty;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<HeroKnight>(); 
    }

    // Update is called once per frame
    void Update()
    {
        HealthLogic();
        DeadState();
    }

    void HealthLogic()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            if(life > maxLife)
            {
                life = maxLife;
            }

            if (i < life)
            {
                heart[i].sprite = full;
            }
            else
            {
                heart[i].sprite = empty;
            }

            if (i < maxLife) 
            {
                heart[i].enabled = true;
            }
            else
            {
                heart[i].enabled = false;
            }
        }
    }

    void DeadState()
    {
        if (life <= 0)
        {
            death = true;
            player.m_animator.SetBool("Death", death);
            GetComponent<HeroKnight>().enabled = false;
            Destroy(gameObject, 1.0f);
        }
    }
}
