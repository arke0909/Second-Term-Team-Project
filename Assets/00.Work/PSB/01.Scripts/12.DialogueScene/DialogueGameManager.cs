using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueGameManager : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private GameObject panel;

    [SerializeField] private string startStoryScene;
    [SerializeField] private string endStoryScene;
    [SerializeField] private bool isStartStory;

    private void Start()
    {
        if (dialogueManager.CheckTalking(true))
        {
            dialogueManager.ToggleAutoDialogue();
        }
    }

    private void Update()
    {
        if (dialogueManager.CheckFinishDialogue(true))
        {
            if (dialogueManager.CheckStartStory(isStartStory) == true)
            {
                SceneManager.LoadScene(startStoryScene);
            }
            else
            {
                SceneManager.LoadScene(endStoryScene);
            }
        }

    }

    public void SkipBtn()
    {
        if (dialogueManager.CheckTalking(true))
        {
            if (dialogueManager.CheckStartStory(isStartStory) == false)
            {
                SceneManager.LoadScene(endStoryScene);
            }
            else
            {
                SceneManager.LoadScene(startStoryScene);
            }
        }
    }

    private IEnumerator TypingDelay()
    {
        yield return new WaitForSeconds(0.5f);
    }

    public void AutoBtn()
    {
        if (dialogueManager.CheckTalking(true))
        {
            dialogueManager.ToggleAutoDialogue();
        }
    }


}
