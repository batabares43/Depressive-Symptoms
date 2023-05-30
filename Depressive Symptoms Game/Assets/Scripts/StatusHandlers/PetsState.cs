using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetsState : MonoBehaviour
{
    [SerializeField] private GameObject dog;
    [SerializeField] private GameObject cat;
    void Start()
    {
        dog.SetActive(GameStateManager.Instance.Dog);
        cat.SetActive(GameStateManager.Instance.Cat);
    }

   
}
