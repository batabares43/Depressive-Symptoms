using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameButton : MonoBehaviour
{
    [SerializeField] private GameObject CharacterCreationMenu;

    public void createGame()
    {
        CharacterCreationMenu.SetActive(true);
    }
}
