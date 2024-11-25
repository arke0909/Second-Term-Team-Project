using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FeedbacksPlayer : MonoBehaviour
{
    private List<Feedback> _feedbacks;

    private void Awake()
    {
        _feedbacks = GetComponentsInChildren<Feedback>().ToList();
    }

    public void PlayFeedbacks()
    {
        StopFeedbacks();
        _feedbacks.ForEach(feedback => feedback.PlayFeedback());
    }

    private void StopFeedbacks()
    {
        _feedbacks.ForEach(feedback => feedback.StopFeedback());
    }
}
