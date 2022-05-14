using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorLight : MonoBehaviour
{
    [SerializeField] private SpriteRenderer target;
    [SerializeField]private Color[] colors;
    [SerializeField] private float timeBetween;
    [SerializeField] private float currentTime=0;

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeBetween)
        {
            target.color = colors[Random.Range(0, colors.Length)];
            currentTime = 0;
        }
    }
}
