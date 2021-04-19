using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRlookWalk : MonoBehaviour
{
    public HealthBarController healthbar;
    public static VRlookWalk player;
    bool alive = true;
    bool played = false;
    public Transform vrCamera;
    public float toggleAngle = 20.0f;
    public float speed = 5.0f;
    public bool moveForward;
    public AudioClip gameoverSound;
    public AudioClip wrongbinSound;
    private CharacterController cc;
    [SerializeField] GameObject hands;
    public GameOver gameover;
    [SerializeField] Canvas score;
    public void GameOverPage()
    {
        score.enabled = false;
        hands.SetActive(false);
        gameover.Setup(GameManager.inst.score);
        Invoke("MainMenu", 4.0f);

    }


    // Use this for initialization
    void Start()
    {
        score.enabled = true;
        hands.SetActive(true);
        gameover.hide();
        alive = true;
        cc = GetComponent<CharacterController>();
    }
    private void Awake()
    {
        player = this;
    }
    public void lossLife()
    {
        healthbar.decreaseHealth(24);
        AudioSource.PlayClipAtPoint(wrongbinSound, transform.position);

    }
    // Update is called once per frame
    void Update()
    {
        if (!alive )
        {
            return;
        }
        
        // player falls off the ground
        if (transform.position.y < -5)
        {
            PlayerDie();
            return;
        }
        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            moveForward = true;
        }
        else
        {
            moveForward = false;
        }

        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }
       
        
    }
    public void PlayerDie()
    {
        alive = false;
         Die();
    }
    void Die()
    {
        if (!played)
        {
            AudioSource.PlayClipAtPoint(gameoverSound, transform.position, 0.2f);
            Invoke("GameOverPage", 1.0f);
            played = true;
        }
        //  GameOver();
        //call restart after 1.5 sec

       


    }
    void MainMenu()
    {
       
       SceneManager.LoadScene("MenuScene");
    
   }
}
