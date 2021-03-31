using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GazeInteraction : MonoBehaviour
{
    public float gazeTime = 2f;
    public UnityEvent GVRClick;
    private bool gazedAt;
    public float gvrTimer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gazedAt)
        {
            gvrTimer += Time.deltaTime;

        }
        if (gvrTimer >  gazeTime )
        {
            GVRClick.Invoke();
           // SceneManager.LoadScene("SchoolScene");
            gvrTimer =0;
        }
    }

    public void Enter()
    {
        gazedAt = true;
    //    Debug.Log("PointerEnter");
    }

    public void Exit()
    {
        gazedAt = false;
        gvrTimer = 0;
  //      Debug.Log("PointerExit");
    }
   

}
