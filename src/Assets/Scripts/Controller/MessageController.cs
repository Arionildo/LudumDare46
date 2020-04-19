using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageController : MonoBehaviour
{

    public TextMeshProUGUI m_Message;

    public void ShowMessage(string message)
    {
        StartCoroutine(ShowMessageCoroutine(message, 3.0f));
    }

    public void ShowMessage(string message, float delay)
    {
        StartCoroutine(ShowMessageCoroutine(message, delay));
    }

    IEnumerator ShowMessageCoroutine(string message, float delay)
    {
        m_Message.text = message;
        m_Message.enabled = true;
        yield return new WaitForSeconds(delay);
        m_Message.enabled = false;
    }
}
