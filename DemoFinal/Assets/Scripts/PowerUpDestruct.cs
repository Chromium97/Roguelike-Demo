using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDestruct : MonoBehaviour
{
    [SerializeField] private float destructionTime = 0f;
    public AudioClip pickUp;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "mainCharacter")
        {
            AudioSource.PlayClipAtPoint(pickUp, transform.position);
            Destroy(gameObject, 0f);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
