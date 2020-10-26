using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class scr_botoes : MonoBehaviour, ISelectHandler
{

    public AudioSource som;

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was selected");
        som.Play();
    }

}
