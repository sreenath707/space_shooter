using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_scp : MonoBehaviour
{
    private float X_speed = 0f;
    private float Y_speed = 0f;
    private float Player_speed=5.0f;
    [SerializeField]
    private GameObject laser =null;
    [SerializeField]
    private GameObject Triple_shot = null;
    private bool is_tripleshot = false;
    private float time_delay=  0.10f;
    private float next_time =  0.0f;
    [SerializeField]
    private int lives = 3;
    private spawn_scp spawn_script;
    float triple_time=0;
    private bool is_shieldActive=false;
    [SerializeField]
    private GameObject shield_visual;
    [SerializeField]
    private GameObject left_Damage;
    [SerializeField]
    private GameObject Right_Damage;
    [SerializeField]
    private int score;
    UI_Manager_scp manager;
    GameManager_scp Game_manager;
    private AudioSource laser_audio;
    

    void Start()
    {
        score = 0;
        shield_visual.gameObject.SetActive(false);
       transform.position = new Vector3(0, 0, 0);
        spawn_script=GameObject.Find("spawn manager").transform.GetComponent<spawn_scp>();
        manager = GameObject.Find("Canvas").GetComponent<UI_Manager_scp>();
        if(manager==null)
        {
            Debug.Log("manager not found");
        }
        Game_manager= GameObject.Find("GameManager").GetComponent<GameManager_scp>();
        laser_audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        playermovement();
        shooting();

    }

    void playermovement()
    {
        //X
        X_speed = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * X_speed * Player_speed);
        //boundary
        if (transform.position.x < -12.35)
        {
            transform.position = new Vector3(10.29f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 10.29f)
        {
            transform.position = new Vector3(-12.35f, transform.position.y, transform.position.z);
        }

        //y
        Y_speed = Input.GetAxis("Vertical");
        transform.Translate( Vector3.up * Time.deltaTime * Y_speed * Player_speed);
        //Boundary
        if (transform.position.y >= 3.8f)
        {
            transform.position = new Vector3(transform.position.x, 3.8f, transform.position.z);
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, transform.position.z);
        }
    }

    void shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time >next_time)
        {
            if (is_tripleshot == true)
            {
                if(Time.time <= triple_time)
                {
                    Instantiate(Triple_shot, transform.position, Quaternion.identity);
                }
                else
                {
                    is_tripleshot = false;
                }
                
            }
            else
            {
                next_time = Time.time + time_delay;
                Instantiate(laser, transform.position + new Vector3(0, 1.0f, 0), Quaternion.identity);
            }
            laser_audio.Play(0); 
        }
    }

    public void f_Speedboost()
    {
        Player_speed = 8.5f;
        StartCoroutine(reset_speed());
        
    }
    public void f_tripleshot()
    {
        is_tripleshot = true;
        triple_time = Time.time + 5.0f;
    }
    public void Damage()
    {
        if(is_shieldActive == true)
        {
            is_shieldActive = false;
            shield_visual.gameObject.SetActive(false);
            return;
        }
        lives--;
        manager.Update_lives(lives);
        if(lives<1)
        {
            player_death();
        }
        if (lives == 2)
        {
            left_Damage.SetActive(true);
        }
        if (lives == 1)
        {
            Right_Damage.SetActive(true);
        }
    }
     IEnumerator reset_speed()
    {
        yield return new WaitForSeconds(10.0f);
        Player_speed = 5.0f;
    }

    public void Active_shield()
    {
        is_shieldActive = true;
        shield_visual.gameObject.SetActive(true);
    }
   public void score_increment(int add_score)
    {
        score += add_score;
        manager.score_text_update(score);
    }    
    
    void player_death()
    {
        Destroy(this.gameObject);
        Game_manager.playerdies();
        manager.Display_gameover();
        if (spawn_script != null)
        {
            spawn_script.stop_spawn();
        }
        else
        {
            Debug.LogError("NULL CHECK ERROR");
        }
    }
}
