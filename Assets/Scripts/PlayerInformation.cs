using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Information", menuName = "ScriptableObjects/PlayerInformation", order = 1)]

public class PlayerInformation : ScriptableObject
{
    public Sprite currentSkin; // Manages the skin selected by the user
    public int coinsToBuyNewStuff; // Manages the coins the user has


    // Getters & Setters
    public Sprite getCurrentSkin()
    {
        return this.currentSkin;
    }

    public int getCoinsToBuyNewStuff()
    {
        return this.coinsToBuyNewStuff;
    }

    public void setCurrentSkin(Sprite newSkin)
    {
        this.currentSkin = newSkin;
    }

    public void setCoinsToBuyNewStuff(int coins)
    {
        this.coinsToBuyNewStuff = coins;
    }
}
