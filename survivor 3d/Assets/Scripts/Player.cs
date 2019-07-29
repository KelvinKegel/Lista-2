using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI textoHP;

    public TextMeshProUGUI textoMorte;

    public TextMeshProUGUI scoreText;

    private bool alive = true;

    [SerializeField]
    private bool isPlayerOne = true;

     [SerializeField]
    private int score = 0;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            if (value <= 0)
            {
               score = 0;
               
            }
            else
            {
                score = value;
            }

           scoreText.text = "Score: " + score;
        }
    }

    private float horizontal;
    private float vertical;
    private Rigidbody body;

    [SerializeField]
    private float speed = 2f;
 [SerializeField]
    private int life = 10;

    public int Life
    {
        get
        {
            return life;
        }
        set
        {
            if (value <= 0)
            {
                alive = false;
                life = 0;
                textoMorte.text = "OOF" + System.Environment.NewLine + "(Aperte qualquer tecla para reiniciar)";
            }
            else if(value >= lifeMax)
            {
                life = (int)lifeMax;
            }
            else
            {
                life = value;
            }

            textoHP.text = "Health" + life;
        }
    }

    private float timerStart;
    private float timerStartScore;

    [SerializeField]
    private float timerMax;

    [SerializeField]
    private float timerMaxScore;

    [SerializeField]
    private float lifeMax;

    // Start is called before the first frame update
    private void Start()
    {
        timerStart = Time.time;
        timerStartScore = Time.time;
        body = GetComponent<Rigidbody>();
        textoHP.text = "Health" + Life;
        scoreText.text = "Score: " + Score;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isAlive())
        {
            if (Time.time >= timerStart + timerMax)
            {
                timerStart = Time.time;

              
                    Life++;
                    
                
            }

            if (Time.time >= timerStartScore + timerMaxScore && Life > 0)
            {
                timerStartScore = Time.time;
                Score += 5;
              
            }

            if (isPlayerOne == true)
            {
                vertical = Input.GetAxisRaw("Vertical");
                horizontal = Input.GetAxisRaw("Horizontal");
            }
            else
            {
                vertical = Input.GetAxisRaw("Vertical2");
                horizontal = Input.GetAxisRaw("Horizontal2");
            }

            body.velocity = new Vector3(horizontal * speed, 0, vertical * speed);
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