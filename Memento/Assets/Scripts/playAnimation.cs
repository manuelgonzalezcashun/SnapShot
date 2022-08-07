using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimation : MonoBehaviour
{
    private DialogueManager dm;
    [Header("Phone")]
    [SerializeField] private GameObject Phone;
    private Animation PhoneAnim;

    void Start()
    {
        PhoneAnim = Phone.GetComponent<Animation>();
    }

    public void PlayPhoneAnimation(string animName)
    {
        PhoneAnim.Play(animName);
    }
}
