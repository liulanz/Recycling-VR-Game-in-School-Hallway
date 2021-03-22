using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRlookWalk : MonoBehaviour
{
    public static VRlookWalk player;
    bool alive = true;
    public Transform vrCamera;
    public float toggleAngle = 20.0f;
    public float speed = 5.0f;
    public bool moveForward;
    public AudioClip gameoverSound;
    private CharacterController cc;

    // Use this for initialization
    void Start()
    {
        alive = true;
        cc = GetComponent<CharacterController>();
    }
    private void Awake()
    {
        player = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (!alive)
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
        AudioSource.PlayClipAtPoint(gameoverSound, transform.position, 0.5f);
        //call restart after 1.5 sec
        Invoke("Restart", 1.5f);


    }
    void Restart()
    {
        // restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
    }
}
