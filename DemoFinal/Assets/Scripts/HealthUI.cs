using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] public Image lifeHeart1;
    [SerializeField] public Image lifeHeart2;
    [SerializeField] public Image lifeHeart3;
    
    // Start is called before the first frame update
    void Start()
    {
        lifeHeart1.enabled = true;
        lifeHeart2.enabled = true;
        lifeHeart3.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (HeroLogic.health == 2)
        {
            lifeHeart1.enabled = false;
        }
        if (HeroLogic.health == 1)
        {
            lifeHeart2.enabled = false;
        }
        if (HeroLogic.health == 0)
        {
            lifeHeart3.enabled = false;
        }
        if (HeroLogic.health == 3)
        {
            lifeHeart1.enabled = true;
            lifeHeart2.enabled = true;
            lifeHeart3.enabled = true;
        }
    }
}
