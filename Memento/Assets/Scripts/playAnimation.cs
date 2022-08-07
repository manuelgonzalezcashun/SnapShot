using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimation : MonoBehaviour
{
    private DialogueManager dm;
    [Header("Phone")]
    [SerializeField] private GameObject Phone;
    private Animation PhoneAnim;
    [Header("Background Switcher")]
    [SerializeField] private GameObject Background;
    private Animation bgChange;

    void Start()
    {
        PhoneAnim = Phone.GetComponent<Animation>();
        bgChange = Background.GetComponent<Animation>();
    }

    public void PlayPhoneAnimation(string animName)
    {
        PhoneAnim.Play(animName);
    }
    public void PlayBackgroundAnimation(string animName)
    {
        bgChange.Play();
        bgChange.Stop();
    }
}
