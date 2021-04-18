using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] Image image;
    public int Health;
    public int Starthealth;
  
    void Start()
    {
        image.fillAmount = (float)Health / Starthealth;
    }
    public void decreaseHealth(int diff)
    {
        Health -= diff;
        
        image.fillAmount =(float)Health / Starthealth;
        if(Health <= 30)
        {
            VRlookWalk.player.PlayerDie();
    
        }
    }
}
