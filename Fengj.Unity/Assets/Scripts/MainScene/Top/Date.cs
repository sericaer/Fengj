using Fengj.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Date : MonoBehaviour
{
    public Text year;
    public Text month;
    public Text day;

    public IDate dateObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        year.text = dateObj.year.ToString();
        month.text = dateObj.month.ToString();
        day.text = dateObj.day.ToString();
    }
}
