using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI textoHP;

    public TextMeshProUGUI textoMorte;

    bool alive = true;

    float horizontal;
    Rigidbody body;

    [SerializeField]
    float speed = 2f;

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
                alive = false;
                life = 0;
                textoMorte.text = "OOF" + System.Environment.NewLine + "(Aperte qualquer tecla para reiniciar)";
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
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        textoHP.text = "Health: " + Life;

        if(alive)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            body.velocity = new Vector3(horizontal * speed, 0, 0);

            if(Time.time >= timerStart + timerMax)
            {
               timerStart = Time.time;
    
                if(Life < lifeMax)
                Life ++;
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                reloadScene();
            }
        }

    }

    //Para chamar

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool isAlive()
    {
        return alive;
    }

    public void setAlive(bool a)
    {
        alive = a;
    }
}
