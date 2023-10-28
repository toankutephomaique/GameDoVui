using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Ins;

    public Text timeText;

    public Text questionText;

    public Dialog dialog;

    public AnswerButton[] answerButtons;

    private void Awake()
    {
        MakeSingleleton();
    }

    public void SetTimeText(string content)
    {
        if (timeText)
            timeText.text = content;
    }

    public void SetQuestionText(string content)
    {
        if (questionText)
            questionText.text = content;
    }
    public void ShuffleAnswers()
    {
        if (answerButtons != null && answerButtons.Length > 0)
        {
            int n = answerButtons.Length;
            for (int i = n - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                // Swap answerButtons[i] and answerButtons[j]
                AnswerButton temp = answerButtons[i];
                answerButtons[i] = answerButtons[j];
                answerButtons[j] = temp;
            }

            // Gán thẻ "RightAnswer" cho nút đầu tiên trong mảng (sau khi đã xáo trộn)
            answerButtons[0].tag = "RightAnswer";

            // Gán các nút còn lại là "Untagged"
            for (int i = 1; i < n; i++)
            {
                answerButtons[i].tag = "Untagged";
            }
        }
    }

    public void MakeSingleleton()
    {
        if (Ins == null)
        {
            Ins = this;
        }else
        {
            Destroy(gameObject);
        }
    }

}
