using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Image oldImage;
    public Sprite RedHeart;
    public Sprite EmptyHeart;

    public void HeartUp()
    {
        oldImage.sprite = RedHeart;
    }    
    public void HeartDown()
    {
        oldImage.sprite = EmptyHeart;
    }
}
