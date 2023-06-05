using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LargeEnemyController : MonoBehaviour
{
    public Animator anim;
    [SerializeField] private Transform heroLocation;
    [SerializeField] private Transform shotLocation1;
    private NavMeshAgent navMesh;
    [SerializeField] private GameObject obj;
    [SerializeField] private int health = 4;
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
                var randomPowerUpRange = Random.Range(0, 20);

                if (randomPowerUpRange == 1)
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
                }

                Invoke("DestroyCollisionObj", desestructionDelay);
                ScoreManager.totalScore += 1;
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
        anim.SetTrigger("Attack");
        Instantiate(obj, shotLocation1.position, shotLocation1.rotation);
        anim.speed = 1;
        anim.SetTrigger("Walk");
        StartCoroutine(enemyFire());
    }

}
