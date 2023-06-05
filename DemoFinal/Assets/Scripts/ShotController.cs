using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void ShootProjectile() 
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(obj, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShootProjectile();   
    }
}
