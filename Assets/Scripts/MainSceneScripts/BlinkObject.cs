using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkObject : MonoBehaviour
{
    private Image _Image;

    void Start()
    {
        _Image = GetComponent<Image>();

        StartCoroutine("blink");
    }

    IEnumerator blink()
    {
        yield return new WaitForSeconds(0.4f);
        _Image.enabled = false;
        yield return new WaitForSeconds(0.4f);
        _Image.enabled = true;

        StartCoroutine("blink");
    }
}
