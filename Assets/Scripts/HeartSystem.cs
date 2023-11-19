using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public int life;
    public int maxLife;

    public Image[] heart;
    public Sprite full;
    public Sprite empty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthLogic();
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
}
