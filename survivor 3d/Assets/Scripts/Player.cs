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
    private int score;

    private float horizontal;
    private float vertical;
    private Rigidbody body;

    [SerializeField]
    private float speed = 2f;

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
        }
    }

    private float timerStart;

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
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isAlive())
        {
            if (Time.time >= timerStart + timerMax)
            {
                timerStart = Time.time;

                if (Life < lifeMax)
                {
                    Life++;
                    print("print printo");
                    textoHP.text = "Health: " + Life;
                }
            }

            if (Time.time >= timerStart + timerMaxScore && Life > 0)
            {
                timerStart = Time.time;
                score += 5;

                scoreText.text = "Score: " + score;
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