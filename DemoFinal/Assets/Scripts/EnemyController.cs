using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Animator anim;
    [SerializeField] private Transform heroLocation;
    [SerializeField] private Transform shotLocation;
    private NavMeshAgent navMesh;
    [SerializeField]  private GameObject obj;
    [SerializeField] private GameObject powerUp;
    [SerializeField] private GameObject healthBoost;
    [SerializeField] private GameObject exploder;
    [SerializeField] private int health = 2;
    [SerializeField] private float desestructionDelay = 0f;


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
                            if (choosePowerUp == 1) {
                                 Instantiate(powerUp, shotLocation.position, shotLocation.rotation);
                            }
                            if (choosePowerUp == 2)
                            {
                                Instantiate(exploder, shotLocation.position, shotLocation.rotation);
                            }
                            if (choosePowerUp >= 3)
                            { 
                                Instantiate(healthBoost, shotLocation.position, shotLocation.rotation);
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
        Instantiate(obj, shotLocation.position, shotLocation.rotation);
        anim.SetTrigger("Attack");
        anim.SetTrigger("Walk");
        StartCoroutine(enemyFire());
    }
}
