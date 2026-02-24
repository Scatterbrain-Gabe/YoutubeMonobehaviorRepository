using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class ByteSizeMeasurementTool : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    string key = "de0bad2ad049f47336d2dca5f5ab8f6c";
    string iv = "ef53809bee5af068";
    private void Awake()
    {
         if(inputField == null) inputField = GetComponent<TMP_InputField>();
    }
    public void MeasureBytes()
    {
        if (inputField == null) { return; }
        string key = inputField.text;
        Debug.LogAssertion("Byte Array Length: " + Encoding.UTF8.GetBytes(key).Length);

    }
   
}
