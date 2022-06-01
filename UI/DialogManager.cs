using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Animator anim;

    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            DisplayNextSentence();
    }

    public void startDialog (Dialog dialog)
    {
        anim.SetBool("isOpen", true);
        sentences = new Queue<string>();
        nameText.text = dialog.name;

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }


        DisplayNextSentence();
    }

    private void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(typeSentence(sentence));
    }

    IEnumerator typeSentence(string sentence)
    {
        dialogText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void EndDialog()
    {
        anim.SetBool("isOpen", false);
    }
        

}
