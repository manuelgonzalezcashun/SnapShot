using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterData character;
    SpriteRenderer spriteRenderer;

    void Awake()
    { 
        gameObject.name = character.name;
        spriteRenderer = GetComponent<SpriteRenderer>();
        InkTagHandler.onCharExpressionChangeEvent += CharacterExpressions;
        InkTagHandler.onCharNameChangeEvent += MinimizeCharacter;
    }
    private void OnDestroy()
    {
        InkTagHandler.onCharExpressionChangeEvent -= CharacterExpressions;
        InkTagHandler.onCharNameChangeEvent -= MinimizeCharacter;
    }
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void CharacterExpressions(string charExpression)
    {
        foreach (Sprite expresion in character.expressions)
        {
            if (expresion.name == charExpression)
            {
                spriteRenderer.sprite = expresion;
            }
        }
    }
    private void MinimizeCharacter()
    {
        spriteRenderer.color = Color.gray;
    }
}
