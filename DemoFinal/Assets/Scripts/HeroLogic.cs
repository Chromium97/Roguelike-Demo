using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroLogic : MonoBehaviour
{

    public Animator anim;
    private Vector2 axis;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float rotSpeed = 8f;
    [SerializeField] public static int health = 3;

    [SerializeField] private int spreadNumber = 2;
    [SerializeField] private float spreadDist = 1.5f;
    [SerializeField] public GameObject orb;
    [SerializeField] public GameObject hero;
    [SerializeField] public bool hasSpread = false;

    public GameObject mainCam;
    public GameObject povCam;

    public GameOverScript gameOver;

    ScoreManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");
        this.transform.Translate(moveSpeed * axis.y * Time.deltaTime * this.transform.forward, Space.World);
        this.transform.RotateAround(Vector3.up, rotSpeed * axis.x * Time.deltaTime);

        if (Input.GetKey(KeyCode.W)) {
            anim.SetTrigger("Run");
            anim.speed = 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetTrigger("Run");
            anim.speed = 1.0f;
        }
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            this.transform.Translate(2.0f * this.transform.up, Space.World);
            anim.speed = 1.0f;

            if (hasSpread) 
            {
                for (int i = 0; i <= spreadNumber; i++)
                {
                    float spawnAngle = 360 / spreadNumber;
                    float rotation = spawnAngle * i;

                    var spawnedObj = Instantiate(orb, transform.position, transform.rotation);

                    spawnedObj.transform.Rotate(new Vector3(0, rotation, 0));
                    spawnedObj.transform.Translate(new Vector3(spreadDist, 0, 0));
                }
            }

           
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("Punch");
            anim.speed = 2.0f;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            mainCam.SetActive(false);
            povCam.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            mainCam.SetActive(true);
            povCam.SetActive(false);
        }

        if (health <= 0)
        {
            gameOver.setGameOver(ScoreManager.totalScore);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "speedBoost")
        {
            moveSpeed = moveSpeed * 1.2f;
        }
        if (collision.gameObject.tag == "life")
        {
            health = 3;
        }
        if (collision.gameObject.tag == "Exploder")
        {
            if (!hasSpread)
            {
                hasSpread = true;
            }
            if (hasSpread)
            {
                spreadNumber += 2;
            }
        }

        if (collision.gameObject.tag == "bossShot")
        {
            health -= 1;
        }
        if (collision.gameObject.tag == "enemShot")
        {
            health -= 1;
        }
        if (collision.gameObject.tag == "largeShot")
        {
            health -= 1;
        }
    }
}
