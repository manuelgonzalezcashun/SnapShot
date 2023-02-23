using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterData character;
    private Animator animator;

    public static Character instance;

    void Awake()
    {
        gameObject.name = character.name;
        gameObject.SetActive(false);
        instance = this;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
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
