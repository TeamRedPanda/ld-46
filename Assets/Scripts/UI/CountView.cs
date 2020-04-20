using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountView : MonoBehaviour
{
    [SerializeField] string m_TextToShow;
    [SerializeField] TMPro.TextMeshProUGUI m_Text;

    void Start()
    {
        UpdateCount(0);
    }

    public void UpdateCount(int count)
    {
        m_Text.SetText(string.Format(m_TextToShow, count));
    }
}
