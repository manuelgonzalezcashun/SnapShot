using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterData character;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        gameObject.name = character.name;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        InkTagHandler.onCharExpressionChangeEvent += CharacterExpressions;
        InkTagHandler.onCharNameChangeEvent += MinimizeCharacter;
        InkDialogueObserver.UpdateShowCharacters += ShowCharacters;
    }
    private void OnDestroy()
    {
        InkTagHandler.onCharExpressionChangeEvent -= CharacterExpressions;
        InkTagHandler.onCharNameChangeEvent -= MinimizeCharacter;
        InkDialogueObserver.UpdateShowCharacters -= ShowCharacters;
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
    private void MinimizeCharacter(string name)
    {
        if (name != character.name)
        {
            spriteRenderer.color = Color.gray;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }

    }
    private void ShowCharacters(bool show)
    {
        bool showCharacters = show;
        gameObject.SetActive(showCharacters);
    }
}
