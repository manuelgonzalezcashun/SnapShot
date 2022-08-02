using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhoneScript : MonoBehaviour
{
    public GameObject Phone;
    private Animation PhoneAnim;
    // Start is called before the first frame update
    void Start()
    {
        PhoneAnim = Phone.GetComponent<Animation>();
    }

    // Update is called once per frame
    public void PlayPhoneAnimation(string animName)
    {
            PhoneAnim.Play(animName);
    }
}
