using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterData character;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        gameObject.name = character.name;
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void CharacterExpressions(string charExpression)
    {
        foreach (AnimationClip expresion in character.expressions)
        {
            if (expresion.name == charExpression)
            {
                animator.Play(expresion.name);
            }
        }
    }


}
