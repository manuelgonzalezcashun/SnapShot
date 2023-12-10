using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] private List<Animations> animations;
    private string currentState;

    const string HEART_FILLING = "Heart Filling";
    const string SCORE_UP = "Score UP";
    const string SCORE_DOWN = "Score DOWN";
    const string RESET_STATE = "Reset State";
    private void OnEnable()
    {
        InkDialogueObserver.onReachedMaxScore += PlayHeartAnimation;
        RelationshipMeter.scoreUp += PlayScoreUPAnimation;
        RelationshipMeter.scoreDown += PlayScoreDOWNAnimation;

    }
    private void OnDisable()
    {
        InkDialogueObserver.onReachedMaxScore -= PlayHeartAnimation;
        RelationshipMeter.scoreUp -= PlayScoreUPAnimation;
        RelationshipMeter.scoreDown -= PlayScoreDOWNAnimation;
    }
    private void PlayAnimation(string name)
    {
        foreach (Animations anims in animations)
        {
            if (name == anims.animName)
            {
                anims.animAnimator.Play(anims.animClip.name);
            }
        }
    }

    private void PlayHeartAnimation(int currentScore)
    {
        if (currentScore == 5)
        {
            ChangeAnimationState(HEART_FILLING);
        }
    }
    private void PlayScoreUPAnimation()
    {
        ChangeAnimationState(SCORE_UP);
        Invoke("ResetState", 0.5f);
    }
    private void PlayScoreDOWNAnimation()
    {
        ChangeAnimationState(SCORE_DOWN);
        Invoke("ResetState", 0.5f);

    }

    private void ResetState()
    {
        ChangeAnimationState(RESET_STATE);
    }

    private void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        PlayAnimation(newState);

        currentState = newState;
    }
}
