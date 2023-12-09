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
        InkDialogueObserver.UpdateShowCharacters += ShowCharacters;
        InkDialogueObserver.CharacterLeaveScene += DestroyCharacter;
    }
    private void OnDestroy()
    {
        InkTagHandler.onCharExpressionChangeEvent -= CharacterExpressions;
        InkTagHandler.onCharNameChangeEvent -= MinimizeCharacter;
        InkDialogueObserver.UpdateShowCharacters -= ShowCharacters;
        InkDialogueObserver.CharacterLeaveScene -= DestroyCharacter;
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
        gameObject.SetActive(show);
    }

    private void DestroyCharacter(string character)
    {
        if (gameObject.name == character)
        {
            Destroy(gameObject);
        }
    }
}
