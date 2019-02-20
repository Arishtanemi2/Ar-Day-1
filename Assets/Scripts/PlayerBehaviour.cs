using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public float health;
    public Text healthText;
    public Image damageImage;
    public float flashSpeed=5f;
    public Color flashColor=new Color(1f,0f,0f,0.2f);
    bool damaged;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text=health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0)
            gameOverPanel.SetActive(true);
        //flash red when damaged
        if(damaged)
            damageImage.color=flashColor;
        else
            damageImage.color=Color.Lerp(damageImage.color,Color.clear,flashSpeed*Time.deltaTime);
        damaged=false;
        
    }
    public void Damage(float damage)
    {
        health-=damage;
        damaged=true;
        healthText.text=health.ToString();
    }
}
