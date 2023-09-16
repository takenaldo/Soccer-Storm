using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalLineController : MonoBehaviour
{
    public TextMeshProUGUI txtScore;

    public GameObject basketBack;
    public GameObject basketFront;
    public GameObject goalLine2;
    public GameObject goalLine3;
    public GameObject wallBottom;
    public GameObject wallTop;
    public GameObject cup;

    private Vector2 def_basketBack;
    private Vector2 def_basketFront;
    private Vector2 def_goalLine2;
    private Vector2 def_goalLine3;

    private Vector2 def_wall_top;
    private Vector2 def_wall_bottom;
    private Transform def_cup;


    public GameObject preWallTop;
    public GameObject preWallBottom;

    public GameObject prefabCup;
    public GameObject prefabCupParent;



    public Transform prefabWallParent;

    bool moveBasketStarted = false; // for movement of basket after goal scored , also can prevent double goal
    float moveStart = 0f; // timestamp for when goal is scored 

    private void Start()
    {
        def_basketBack = basketBack.transform.position;
        def_basketFront = basketFront.transform.position;
        def_goalLine2 = goalLine2.transform.position;
        def_goalLine3 = goalLine3.transform.position;
        def_wall_top = wallTop.transform.position;
        def_wall_bottom = wallBottom.transform.position;
        def_cup = cup.transform;

    }

    float waitingTime = 1f;
    private void FixedUpdate()
    {
        if (moveBasketStarted)
        {
            float diff = Time.time - moveStart;
            if (GameManager.instance.score > 50)
                waitingTime = 0f;
            if (diff >= waitingTime)
            {
                MoveBasket();
                moveBasketStarted = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!moveBasketStarted)
        {
            float y_direction = collision.gameObject.GetComponent<Rigidbody2D>().velocity.y;


            if (y_direction < 0 && gameObject.CompareTag("goal_2"))
            {
                GameManager.instance.score += GameManager.DOWN_WARD;
                txtScore.text = GameManager.instance.score + "";

                moveBasketStarted = true;
                moveStart = Time.time;
            }
            else if (y_direction > 0 && gameObject.CompareTag("goal_3"))
            {
                GameManager.instance.score += GameManager.UP_WARD;
                txtScore.text = GameManager.instance.score + "";

                moveBasketStarted = true;
                moveStart = Time.time;
        }
    }



    }

    public void timer(float waitingTime)
    {
        StartCoroutine(waiter(waitingTime));
    }

    private IEnumerator waiter(float waitingTimeInsec)
    {
        yield return new WaitForSeconds(waitingTimeInsec);
        MoveBasket();
    }


    public void MoveBasket()
    {
        float spaceToAdd = 3f;

        float randX = new System.Random().Next(-2, 2);
        float randY = new System.Random().Next(-2 , 2);

        basketBack.transform.position = def_basketBack;
        basketBack.transform.Translate(randX, randY, 0);

        basketFront.transform.position = def_basketFront;
        basketFront.transform.Translate(randX, randY, 0);

        wallTop.SetActive(true);
        wallTop.transform.position = def_wall_top;
        wallTop.transform.Translate(0, 0, 0);

        wallBottom.SetActive(true);
        wallBottom.transform.position = def_wall_bottom;
        wallBottom.transform.Translate(0, 0, 0);

//        cup.transform.position = wallBottom.transform.position;
        float RandX = new System.Random().Next(-3, -2);
        float RandY = new System.Random().Next(0, 5);

        // randomly generate Cups
        if(Helper.getRandom(3) == 0)
        {
            GameObject new_cup = GameObject.Instantiate(prefabCup, prefabCupParent.transform);
            new_cup.transform.Translate(RandX, RandY, 0);
        }
    }

}
