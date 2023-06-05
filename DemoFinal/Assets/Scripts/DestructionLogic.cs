
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionLogic : MonoBehaviour
{
    [SerializeField] private float destructionTime = 1.5f;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "mainCharacter" || collision.gameObject.tag == "enemyHard" || collision.gameObject.tag == "enemyEasy")
        {
            Destroy(gameObject, 0f);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destructionTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
