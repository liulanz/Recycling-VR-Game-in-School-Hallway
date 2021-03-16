﻿
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Camera _mainCamera;
    bool alive = true;
    public float speed = 5f;
    [SerializeField] Rigidbody rb;
    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 1.5f;
    public float speedIncreasePerPoint = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }
    private void FixedUpdate()
    {
        if (!alive)
        {
            return;
        }
        Vector3 movement = GetMoveSpeed(_mainCamera.transform.rotation.x, _mainCamera.transform.rotation.y);
       
        transform.position += (transform.forward + movement) / 15;
        // Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        // Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        // rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.y < -5) // going off the edge
        {
            Die();
        }
    }
    private Vector3 GetMoveSpeed(float x, float y)

    {

        // create our movement vector value based off of where we're looking at with a cap
        float xMove = Mathf.Min(Mathf.Abs(y*8), 3);
     
        float yMove = Mathf.Min(Mathf.Abs(x*8), 3);
        // Figure out which direction our plane should be turning to
        if (x >= 0)
            yMove *= -1;
        if (y < 0)
            xMove *= -1;

        return new Vector3(xMove, yMove, 0f);

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