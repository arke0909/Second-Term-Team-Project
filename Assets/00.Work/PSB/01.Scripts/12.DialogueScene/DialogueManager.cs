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
    /// ���� ��ȭ �����ִ� �޼���
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
    /// ���� ��ȭ ���� �����ִ� �޼���
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
    /// ��ȭ Ÿ�����ϴ� �޼���
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
    /// ��ȭ ��ŵ �޼���
    /// </summary>
    public void SkipDialogue()
    {
        if (currentDialogueIndex < dialogues.Count)
        {
            FinishedTalking();
        }
    }

    /// <summary>
    /// ��ȭ�� �������� Ȯ���ϴ� �޼���
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
    /// �̾߱� ������ üũ�ϴ� �޼���
    /// </summary>
    /// <param name="talking"></param>
    /// <returns></returns>
    public bool CheckTalking(bool talking)
    {
        return isTalking;
    }

    /// <summary>
    /// �ڵ����� �����ϴ� �޼���
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
    /// �ڵ� ��ȭ �ڷ�ƾ
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
    /// �̾߱� ������ �� �͵�
    /// </summary>
    private void FinishedTalking()
    {
        isFinished = true;
        isTalking = false;
        textLocated.text = "";
    }

}
