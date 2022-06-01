using UnityEngine;
using TMPro;

public class Abakus : MonoBehaviour
{
    public float thousands;
    public float hundreds;
    public float tens;
    public float one;

    public GameObject GO_one;
    public GameObject GO_tens;
    public GameObject GO_hundreds;
    public GameObject GO_thousands;

    public GameObject questText;
    public GameObject answerText;

    private float result;
    private string guess;

    private void Start()
    {
        newQuest();
    }
    private void Update()
    {
        guess = "" + GO_thousands.GetComponent<Bar>().getValue() + GO_hundreds.GetComponent<Bar>().getValue() + GO_tens.GetComponent<Bar>().getValue() + GO_one.GetComponent<Bar>().getValue();
        answerText.GetComponent<TextMeshProUGUI>().text = guess;
        if (System.Int16.Parse(guess) == result)
            newQuest();
    }

    private void newQuest()
    {
        int firstNumber = Random.Range(0, 100);
        int secondNumber = Random.Range(0, 100);
        result = firstNumber + secondNumber;
        questText.GetComponent<TextMeshProUGUI>().text = "" + firstNumber + " + " + secondNumber + " = ";
        GO_one.GetComponent<Bar>().reset();
        GO_tens.GetComponent<Bar>().reset();
        GO_hundreds.GetComponent<Bar>().reset();
        GO_thousands.GetComponent<Bar>().reset();
    }

}
