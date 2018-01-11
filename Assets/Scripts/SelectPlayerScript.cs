using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectPlayerScript : MonoBehaviour
{
    public SpriteRenderer PlayerSprite;
    public List<Sprite> Sprites;
    public EventSystem EventSys;
    public PlayerInfoManagerScript PlayerInfoManager;
    private int _buttonIndex;
    public Animator InputAnimator;
    

    void Start()
    {
        for (int i = 0; i < Sprites.Count; i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = Sprites[i]; //Sets buttons sprite from the sprite list. Just test for fun. But also insure the right image gets put.
        }
    }

    public void SetPlayer()
    {
        if (PlayerInfoManager.PlayerName !="")
        {
            _buttonIndex = EventSys.currentSelectedGameObject.transform.GetSiblingIndex(); //Gets the buttons child nr and uses to choose sprite.
            PlayerSprite.sprite = Sprites[_buttonIndex];
            PlayerInfoManager.PlayerImage = Sprites[_buttonIndex];
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            InputAnimator.SetTrigger("doTrigger");
        }
        

    }
}
