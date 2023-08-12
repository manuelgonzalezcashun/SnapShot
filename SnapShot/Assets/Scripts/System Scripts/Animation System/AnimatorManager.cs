using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] private List<Animations> animations;
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
            PlayAnimation("Heart Filling");
        }
    }
    private void PlayScoreUPAnimation()
    {
        PlayAnimation("Score UP");
    }
    private void PlayScoreDOWNAnimation() 
    {
        PlayAnimation("Score DOWN");
    }
}
