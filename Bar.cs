using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float value;
    public GameObject nextUp;
    public GameObject nextDown;
    public GameObject[] balls;

    private Stack<GameObject> ballsLeft;
    private Stack<GameObject> ballsRight;

    //Initialize attributes
    // Args: None
    // Returns: None
    private void Start()
    {
        ballsLeft = new Stack<GameObject>();
        ballsRight = new Stack<GameObject>();
        foreach (GameObject ball in balls)
        {
            ballsLeft.Push(ball);
        }
    }

    //Add a amount of balls to the right side of the bar
    // Args: amounts of Balls
    // Returns: None
    public void add()
    {
        if (value < 9)
        {
            moveBallRight();
        }
        else if (value == 9 && nextUp != null)
        {
            float temp = value;
            for (int i = 0; i < temp; i++)
                moveBallLeft();
            nextUp.GetComponent<Bar>().add();
        }
        else if(value == 9 && nextUp == null)
        {
            moveBallRight();
        }


    }

    //put a amount of balls back to the Left side of the bar
    // Args: amounts of Balls
    // Returns: None
    public void remove()
    {
        if (value > 1)
            moveBallLeft();
        else if (value == 1 && nextDown != null && nextDown.GetComponent<Bar>().getValue() == 0)
        {
            moveBallLeft();
            for (int i = 0; i < 9; i++)
                nextDown.GetComponent<Bar>().add();
        }
        else if (value == 1 && nextDown == null)
            moveBallLeft();
    }

    private void moveBallRight()
    {
        GameObject temp = ballsLeft.Pop();
        temp.transform.position = new Vector3(temp.transform.position.x + 4.6f, temp.transform.position.y, temp.transform.position.z);
        ballsRight.Push(temp);
        value = ballsRight.Count;
    }

    private void moveBallLeft()
    {
        GameObject temp = ballsRight.Pop();
        temp.transform.position = new Vector3(temp.transform.position.x - 4.6f, temp.transform.position.y, temp.transform.position.z);
        ballsLeft.Push(temp);
        value = ballsRight.Count;
    }

    public void reset()
    {
        float temp = value;
        for (int i = 0; i < temp; i++)
            moveBallLeft();
    }

    //Return currents amount of balls on the Right side
    // Args: None
    // Returns: Amount of balls
    public float getValue()
    {
        return value;
    }

}
