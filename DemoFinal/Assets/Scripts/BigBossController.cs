using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigBossController : MonoBehaviour
{
    public Animator anim;
    [SerializeField] private Transform heroLocation;
    [SerializeField] private Transform shotLocation1;
    [SerializeField] private Transform shotLocation2;
    [SerializeField] private int spreadNumber = 6;
    [SerializeField] private float spreadDist = 1f;
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
               
                Instantiate(powerUp, shotLocation1.position, shotLocation1.rotation);
                Instantiate(healthBoost, shotLocation2.position, shotLocation2.rotation);
                Instantiate(exploder, shotLocation2.position, shotLocation2.rotation);


                Invoke("DestroyCollisionObj", desestructionDelay);
                ScoreManager.totalScore += 10;
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
        for (int i = 0; i <= spreadNumber; i++)
        {
            float spawnAngle = 360 / spreadNumber;
            float rotation = spawnAngle * i;

            var spawnedObj = Instantiate(obj, shotLocation1.position, shotLocation1.rotation);

            spawnedObj.transform.Rotate(new Vector3(0, rotation, 0));
            spawnedObj.transform.Translate(new Vector3(spreadDist, 0, 0));
        }
        anim.SetTrigger("Attack");
        anim.SetTrigger("Walk");
        StartCoroutine(enemyFire());
    }
}
