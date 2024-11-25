using System.Collections;
using UnityEngine;

public class DialogueGameManager : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private GameObject panel;

    [SerializeField] private string startStoryScene;
    [SerializeField] private string endStoryScene;
    [SerializeField] private bool isStartStory;

    [SerializeField] private SceneManageSO sceneManage;

    private BGMScript BGMScript;

    private void Start()
    {
        BGMScript = FindAnyObjectByType<BGMScript>();
        if (dialogueManager.CheckTalking(true))
        {
            dialogueManager.ToggleAutoDialogue();
        }
        if (BGMScript != null)
        {
            BGMScript.StopBGM();
        }
    }

    private void Update()
    {
        if (dialogueManager.CheckFinishDialogue(true))
        {
            if (dialogueManager.CheckStartStory(isStartStory) == true)
            {
                sceneManage.SceneLoad(startStoryScene);
            }
            else
            {
                sceneManage.SceneLoad(endStoryScene);
            }
        }

    }

    public void SkipBtn()
    {
        if (dialogueManager.CheckTalking(true))
        {
            if (dialogueManager.CheckStartStory(isStartStory) == false)
            {
                sceneManage.SceneLoad(endStoryScene);
            }
            else
            {
                sceneManage.SceneLoad(startStoryScene);
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
