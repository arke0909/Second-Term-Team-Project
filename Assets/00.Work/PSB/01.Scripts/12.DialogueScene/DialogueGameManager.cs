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
                sceneManage.SceneLoad(startStoryScene.GetHashCode());
            }
            else
            {
                sceneManage.SceneLoad(endStoryScene.GetHashCode());
            }
        }

    }

    public void SkipBtn()
    {
        if (dialogueManager.CheckTalking(true))
        {
            if (dialogueManager.CheckStartStory(isStartStory) == false)
            {
                sceneManage.SceneLoad(endStoryScene.GetHashCode());
            }
            else
            {
                sceneManage.SceneLoad(startStoryScene.GetHashCode());
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
