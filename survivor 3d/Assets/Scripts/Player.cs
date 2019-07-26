using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI textoHP;

    private int life = 10;
    public int Life
    {
        get
        {
            return life;
        }
        set
        {
            if(value <= 0)
            {
                life = 0;
                //mensagem de mrote OOF
            }
            else
            life = value;
        }
    }

    private float timerStart;
    [SerializeField]
    private float timerMax;
    [SerializeField]
    private float lifeMax;

    // Start is called before the first frame update
    void Start()
    {
        timerStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        textoHP.text = "Health: " + Life;

        if(Time.time >= timerStart + timerMax)
        {
            timerStart = Time.time;

            if(Life < lifeMax)
                Life ++;
        }
    }
}
