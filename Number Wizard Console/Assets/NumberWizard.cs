using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int max = 1000;
    int min = 1;
    int guess = 500;


    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Welcome to number wizard");
        Debug.Log("Pick a number between "+min+ " and "+max+" .");
        Debug.Log("Push up arrow = Higher, Push down arrow = Lower, Push Enter = Correct");
        max++;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            guess = (max + min) / 2;
            Debug.Log("It's higher or lower then "+guess);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            guess = (max + min) / 2;
            Debug.Log("It's higher or lower then " + guess);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("It's correct.");
        }
        
    }
}
