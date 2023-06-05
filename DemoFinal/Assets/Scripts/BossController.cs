using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public Animator anim;
    [SerializeField] private Transform heroLocation;
    [SerializeField] private Transform shotLocation1;
    [SerializeField] private Transform shotLocation2;
    private NavMeshAgent navMesh;
    [SerializeField] private GameObject obj;
    [SerializeField] private int health = 10;
    [SerializeField] private float desestructionDelay = 0f;

    [SerializeField] private GameObject powerUp;
    [SerializeField] private GameObject healthBoost;
    [SerializeField] private GameObject exploder;


    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "heroShot")
        {
            health = health - 1;
            if (health <= 0)
            {
                var choosePowerUp = Random.Range(1, 6);
                if (choosePowerUp == 1)
                {
                    Instantiate(powerUp, shotLocation1.position, shotLocation1.rotation);
                }
                if (choosePowerUp == 2)
                {
                    Instantiate(exploder, shotLocation1.position, shotLocation1.rotation);
                }
                if (choosePowerUp >= 3)
                {
                    Instantiate(healthBoost, shotLocation1.position, shotLocation1.rotation);
                }

                Invoke("DestroyCollisionObj", desestructionDelay);
                ScoreManager.totalScore += 2;
            }

        }
    }

    private void DestroyCollisionObj()
    {
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyFire());
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.destination = heroLocation.position;
    }

    IEnumerator enemyFire()
    {
        var randomShotTime = Random.Range(1.0f, 8.0f);
        yield return new WaitForSeconds(randomShotTime);
        Instantiate(obj, shotLocation1.position, shotLocation1.rotation);
        Instantiate(obj, shotLocation2.position, shotLocation2.rotation);
        anim.SetTrigger("Attack");
        anim.SetTrigger("Walk");
        StartCoroutine(enemyFire());
    }
}
