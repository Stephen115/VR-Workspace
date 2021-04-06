using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public int characterID;

    public void SelectCharacter1() 
    {
        characterID = 1;
        DataStore.DS.characterID = 1;
    }
    public void SelectCharacter2()
    {
        characterID = 2;
        DataStore.DS.characterID = 2;
    }
    public void SelectCharacter3()
    {
        characterID = 3;
        DataStore.DS.characterID = 3;
    }
    public void SelectCharacter4()
    {
        characterID = 4;
        DataStore.DS.characterID = 4;
    }
    public void SelectCharacter5()
    {
        characterID = 5;
        DataStore.DS.characterID = 5;
    }
    public void SelectCharacter6()
    {
        characterID = 6;
        DataStore.DS.characterID = 6;
    }
}
