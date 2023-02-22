using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public Sprite[] allSkins;
    public GameObject SkinRender;
    private int currentSkin = 0;
    public PlayerInformation SkinScriptable;

    // Depending on the arrow the user clicks, change the Sprite shown and
    // set that Sprite to the current skin on the ScriptableObject which controls the player skin
    public void changeSkin(string direction)
    {
        if (direction == "Left")
        {
            if (currentSkin == 0)
            {
                currentSkin = 4;
            }
            SkinRender.GetComponent<Image>().sprite = allSkins[currentSkin - 1];
            currentSkin--;
        } else if (direction == "Right")
        {
            if (currentSkin == 3)
            {
                currentSkin = -1;
            }
            SkinRender.GetComponent<Image>().sprite = allSkins[currentSkin + 1];
            currentSkin++;
        }
        SkinScriptable.setCurrentSkin(this.SkinRender.GetComponent<Image>().sprite);
    }
    private void Start()
    {
        currentSkin = 0;
        print(allSkins.Length);
    }

    public Sprite GetCurrentSkin()
    {
        return this.allSkins[currentSkin];
    }

}
