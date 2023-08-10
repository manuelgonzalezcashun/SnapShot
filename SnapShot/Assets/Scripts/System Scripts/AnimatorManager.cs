using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip clip;

    private void OnEnable()
    {
        InkDialogueObserver.onReachedMaxScore += PlayHeartAnimation;
    }
    private void OnDisable()
    {
        InkDialogueObserver.onReachedMaxScore -= PlayHeartAnimation;
    }

    private void PlayHeartAnimation(int currentScore)
    {
        if (currentScore == 5)
        {
            animator.Play(clip.name);
        }
    }
}
