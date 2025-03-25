using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400;

    UnityEngine.UI.Image noteImage;

    void Start()
    {
        noteImage = GetComponent<UnityEngine.UI.Image>();
    }

    
    void Update()
    {
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;
    }

    public void HideNote()
    {
        noteImage.enabled = false;
    }
}
