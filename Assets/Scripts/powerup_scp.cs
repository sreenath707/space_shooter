using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup_scp : MonoBehaviour
{
    [SerializeField]
    private int ID;//triple-0 speed-1 sheild-2
    [SerializeField]
    private GameObject Sheild;
    [SerializeField]
    private AudioClip Powerup_clip;
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 3.0f);
        if(transform.position.y < -8.0f)
        {
            Destroy(this.gameObject);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            AudioSource.PlayClipAtPoint(Powerup_clip, transform.position);
            player_scp player_script = collision.transform.GetComponent<player_scp>();
            if(player_script != null)
            {
                switch(ID)
                {
                    case 0: 
                        player_script.f_tripleshot();
                        break;
                    case 1: 
                        player_script.f_Speedboost();
                        break;
                    case 2:
                        player_script.Active_shield();
                        break;
                }
            
            }
            
            Destroy(this.gameObject);
        }
    }
}
