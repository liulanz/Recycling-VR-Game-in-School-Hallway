using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencils : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        //check that the object we collided with is the player
        if (other.gameObject.name != "Player")
        {
            return;
        }
        GameManager.inst.IncrementScore();

        // add to the player's score
        //destroy this coin object
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);

    }
}
