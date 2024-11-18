using UnityEngine;

public abstract class Feedback : MonoBehaviour
{
    public abstract void PlayFeedbak();
    public abstract void StopFeedback();
    private void OnDisable()
    {
        StopFeedback();
    }
}
