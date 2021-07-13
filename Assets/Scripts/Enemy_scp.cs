using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_scp : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.0f;
    private player_scp player_s;
    private Animator Enemy_explode_anim;
    private bool Isenemyalive = true;
    private AudioSource Explosion_audio;
   
    void Start()
    {
        player_s = GameObject.Find("Player").GetComponent<player_scp>();
        if(player_s==null)
        {
            Debug.Log("WWWWRRRROOOOOONNNGGGGGG");
        }
       Enemy_explode_anim = GetComponent<Animator>();
        if(Enemy_explode_anim==null)
        {
            Debug.Log("WWWWRRRROOOOOONNNGGGGGG");
        }

        Explosion_audio= GetComponent<AudioSource>();
    }

 
    void Update()
    {
        if(transform.position.y < -7)
        {
            transform.position = new Vector3(Random.Range(-8.0f,8.0f), 7.5f, transform.position.z);
        }
        transform.Translate(Vector3.down * speed * Time.deltaTime );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag== "laser")
        {
            Destroy(other.gameObject);
            Enemy_explosion();
            Destroy(this.gameObject,2.5f);
            player_s.score_increment(10);
            Isenemyalive = false;

        }
        else if(other.tag == "Player" && Isenemyalive==true)
        {
            player_scp  player_script;
            player_script = other.transform.GetComponent<player_scp>();
            
            if (player_script != null)
            {
                player_script.Damage();
            }
            else
            {
                Debug.LogError("NULL CHECK ERROR");
            }
            Enemy_explosion();
            Destroy(this.gameObject,2.5f);
        }
    }
    void Enemy_explosion()
    {
        Enemy_explode_anim.SetTrigger("Enemy_dies");
        Explosion_audio.Play(0);
    }

}
