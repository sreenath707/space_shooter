using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager_scp : MonoBehaviour
{
    [SerializeField]
    private Text Score_text;
    [SerializeField]
    private Image live_img;
    [SerializeField]
    private Sprite[] live_sprites;
    [SerializeField]
    private Text Gameover_txt;
    [SerializeField]
    private Text Restart_txt;
    [SerializeField]
    private Text Exit_menu_txt;
    void Start()
    {
        Score_text.text = "Score : " + 0;
        Update_lives(3);
        Gameover_txt.gameObject.SetActive(false);
        Restart_txt.gameObject.SetActive(false);
        Exit_menu_txt.gameObject.SetActive(false);
    }


     public void score_text_update(int points)
    {
       Score_text.text = "Score : " + points;
    }
    public void Update_lives(int lives)
    {
        live_img.sprite = live_sprites[lives];
    }
    public void  Display_gameover()
    {
        StartCoroutine(Gameover_routine());
        Restart_txt.gameObject.SetActive(true);
        Exit_menu_txt.gameObject.SetActive(true);
    }
    IEnumerator Gameover_routine()
    {
        while(true)
        {
            while (true)
            {
                Gameover_txt.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                Gameover_txt.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.5f);

            }
        }
       

    }

}
