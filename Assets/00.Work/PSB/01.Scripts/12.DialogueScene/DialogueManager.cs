using KoreanTyper;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("SerializeField")]
    [SerializeField] private TextMeshProUGUI textLocated;
    [SerializeField] private List<string> dialogues;
    [Header("Private Value")]
    private int currentDialogueIndex = 0;
    private bool isTyping;
    private bool isAutoDialogue = false;
    private bool isFinished = false;
    private bool isTalking = true;
    [Header("Manager and Coroutine")]
    private Coroutine typingCoroutine;
    private Coroutine autoDialogueCoroutine;

    private void Start()
    {
        isAutoDialogue = false;
        isFinished = false;
        isTalking = true;
        textLocated.text = "";
    }

    private void Update()
    {
        if (isTalking == false) return;
        if (isAutoDialogue == true) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                DisplayCurrentDialogue();
            }
            else
            {
                ShowNextDialogue();
            }
        }

    }

    /// <summary>
    /// 지금 대화 보여주는 메서드
    /// </summary>
    private void DisplayCurrentDialogue()
    {
        if (isTalking == false) return;
        if (currentDialogueIndex < dialogues.Count)
        {
            textLocated.text = $"{dialogues[currentDialogueIndex - 1]}";
            isTyping = false;
        }
        if (currentDialogueIndex == dialogues.Count)
        {
            textLocated.text = $"{dialogues[currentDialogueIndex - 1]}";
            isTyping = false;
        }
    }

    /// <summary>
    /// 다음 대화 내용 보여주는 메서드
    /// </summary>
    private void ShowNextDialogue()
    {
        if (isTalking == false) return;
        if (currentDialogueIndex < dialogues.Count)
        {
            typingCoroutine = StartCoroutine(Typing(dialogues[currentDialogueIndex]));
            currentDialogueIndex++;
        }
        else
        {
            FinishedTalking();
        }
    }

    /// <summary>
    /// 대화 타이핑하는 메서드
    /// </summary>
    /// <param name="characterName"></param>
    /// <param name="dialogue"></param>
    /// <returns></returns>
    private IEnumerator Typing(string dialogue)
    {
        string fullText = $"{dialogue}";
        textLocated.text = "";
        isTyping = true;

        int typingLength = fullText.GetTypingLength(); 

        for (int i = 0; i <= typingLength; i++)
        {
            textLocated.text = fullText.Typing(i);
            yield return new WaitForSeconds(0.05f);
        }

        isTyping = false;
    }

    /// <summary>
    /// 대화 스킵 메서드
    /// </summary>
    public void SkipDialogue()
    {
        if (currentDialogueIndex < dialogues.Count)
        {
            FinishedTalking();
        }
    }

    /// <summary>
    /// 대화가 끝났는지 확인하는 메서드
    /// </summary>
    /// <param name="finished"></param>
    /// <returns></returns>
    public bool CheckFinishDialogue(bool finished)
    {
        return isFinished;
    }

    public bool CheckStartStory(bool started)
    {
        return started; 
    }


    /// <summary>
    /// 이야기 중인지 체크하는 메서드
    /// </summary>
    /// <param name="talking"></param>
    /// <returns></returns>
    public bool CheckTalking(bool talking)
    {
        return isTalking;
    }

    /// <summary>
    /// 자동모드로 변경하는 메서드
    /// </summary>
    public void ToggleAutoDialogue()
    {
        Color origin = Color.white;
        Color changed = Color.yellow;
        isAutoDialogue = !isAutoDialogue;

        if (isAutoDialogue)
        {
            if (autoDialogueCoroutine == null)
            {
                autoDialogueCoroutine = StartCoroutine(AutoDialogueCoroutine());
            }
        }
        else
        {
            isAutoDialogue = false;
            if (autoDialogueCoroutine != null)
            {
                StopCoroutine(autoDialogueCoroutine);
                autoDialogueCoroutine = null;
            }
        }

    }

    /// <summary>
    /// 자동 대화 코루틴
    /// </summary>
    /// <returns></returns>
    private IEnumerator AutoDialogueCoroutine()
    {
        for (int i = currentDialogueIndex; i < dialogues.Count; i++)
        {
            while (isTyping)
            {
                yield return null; 
            }
            yield return new WaitForSeconds(1f);
            ShowNextDialogue();
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(3f);
        FinishedTalking();

    }

    /// <summary>
    /// 이야기 끝나면 할 것들
    /// </summary>
    private void FinishedTalking()
    {
        isFinished = true;
        isTalking = false;
        textLocated.text = "";
    }

}
