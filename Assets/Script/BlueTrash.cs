using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTrash : MonoBehaviour
{
    
    [SerializeField] float turnSpeed = 90f;
    public AudioClip collectSound;
    [SerializeField] ParticleSystem disappearEffect = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        //check that the object we collided with is the player
        if (other.gameObject.tag != "TrashbinBlue")
        {
            //  Debug.Log(other.gameObject.name);
            Destroy(gameObject);
            VRlookWalk.player.lossLife();
            //   Debug.Log(other.gameObject.name);
            

            return;
        }
        else 
        { 
            // add to the player's score
            GameManager.inst.IncrementScore();
            Instantiate(disappearEffect, transform.position, Quaternion.identity);
            // play audio
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            //destroy this coin object
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime,0);
    }
}
