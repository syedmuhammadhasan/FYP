using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChangeCount : MonoBehaviour
{
    int count = 0;
    [SerializeField] TextMeshProUGUI countTextBox;
   public void IncreaseCount()
    {
        
        count += 1;
        countTextBox.text = count.ToString();
        
    }
    public void DecreaseCount()
    {
        if (count == 0)
        {
            count = 0;
            countTextBox.text = count.ToString();
        }
        else
        {
            count -= 1;
            countTextBox.text = count.ToString();
        }
        
        
    }
   
}
