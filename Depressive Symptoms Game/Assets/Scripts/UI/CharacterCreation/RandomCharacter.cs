using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class RandomCharacter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;

    private void OnEnable()
    {
        nameText.text = "";
        GetComponent<SkinButton>().changeSex(Random.Range(0,2));
        GetComponent<SkinButton>().changeSkin(Random.Range(0, 4));
        GetComponent<HairButton>().changeHair(Random.Range(0, 8));
        GetComponent<HairButton>().changeHairColor(Random.Range(0, 6));
        GetComponent<EyeButton>().changeEye(Random.Range(0, 3));
        GetComponent<EyeButton>().changeEyeColor(Random.Range(0, 6));
        GetComponent<NoseButton>().changeNose(Random.Range(0, 5));
        GetComponent<MouthButton>().changeMouth(Random.Range(0, 5));
        GetComponent<OutfitButton>().changeOutfit(Random.Range(0, 10));
        GetComponent<AccesoryButton>().changeAccesory(Random.Range(0, 3));

    }
}
