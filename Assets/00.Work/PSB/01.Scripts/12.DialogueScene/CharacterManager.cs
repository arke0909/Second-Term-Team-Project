using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private List<CharacterImage> characterImages;

    private void Start()
    {
        foreach (CharacterImage characterImage in characterImages)
        {
            characterImage.image.color = new Color(characterImage.image.color.r,
                characterImage.image.color.g, characterImage.image.color.b, 0.25f);  //시작하면 어둡게 만들기
        }
    }
    public void UpdateCharacterImages(string speakingCharacterName)
    {
        foreach (CharacterImage characterImage in characterImages)
        {
            if (characterImage.characterName == speakingCharacterName)
            {
                characterImage.image.color = new Color(characterImage.image.color.r, 
                    characterImage.image.color.g, characterImage.image.color.b, 1f); // 밝게 설정
            }
            else
            {
                characterImage.image.color = new Color(characterImage.image.color.r,
                    characterImage.image.color.g, characterImage.image.color.b, 0.25f); // 어둡게 설정
            }
        }
    }


}
