using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject First_Person;
    public GameObject Third_Person;
 
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            First_Person.SetActive(true);
            Third_Person.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            First_Person.SetActive(false);
            Third_Person.SetActive(true);
        }
    }



}
