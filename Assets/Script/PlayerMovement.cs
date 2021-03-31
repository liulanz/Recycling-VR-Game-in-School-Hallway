
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool alive = true;

    public Transform vrCamera;
    public float toggleAngle = 30.0f;
    public float speed = 5.0f;
    public bool moveForward;
   


    //private CharacterController cc;
    [SerializeField] Rigidbody rb;
    // Use this for initialization
    void Start()
    {
       // cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       
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

            //cc.SimpleMove(forward * speed);
           
           rb.MovePosition(rb.position + forward);
        }
        
    }
    public void Die()
    {
        alive = false;

        //call restart after 2 sec
        Invoke("Restart", 2);


    }
    void Restart()
    {
        // restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
