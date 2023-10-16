using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuState : MonoBehaviour
{
    public int stateValue = 0; // 0-3 for each possible state during the menu. The "press now" screen and the three hovering states in the main menu for "New", "Load" and "Option"
    public Button[] buttonlist; // The index is in the same order as the state value int. (the 4 buttons: press now, new, load and option)
    public float timer = 0;
    public bool timerStart = false;
    public int upDown = 1;
    public Material newGame;
    public Material newGamePlus;
    public GameObject newGameSign;
    public Image logo;

    void Update()
    {
        if (stateValue == 2)
        {
            FindObjectOfType<trainaman>().balls = true;
        }
        else
        {
            FindObjectOfType<trainaman>().balls = false;
        }
        if (timerStart)
        {
            timer += Time.deltaTime;
            if (timer > 0.34)
            {
                logo.enabled = false;
                buttonlist[0].GetComponentInChildren<Animator>().SetBool("activated", false);
                buttonlist[0].GetComponent<Image>().enabled = false;
                timer = 0;
                buttonlist[1].GetComponent<Image>().enabled = true;
                buttonlist[2].GetComponent<Image>().enabled = true;
                buttonlist[3].GetComponent<Image>().enabled = true;
                newGameSign.GetComponent<MeshRenderer>().material= newGamePlus ;
                timerStart = false;
                


            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (stateValue == 0)
            {
                buttonlist[stateValue].GetComponentInChildren<Animator>().SetBool("activated", true);
                stateValue +=1;
                timerStart = true;
                

            }
        }

        if (stateValue != 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (stateValue != 1)
                {
                    upDown -= 1;
                }
                else
                {
                    upDown = 3;
                }
                
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (stateValue != 3)
                {
                    upDown += 1;
                }
                else
                {
                    upDown = 1;
                }
            }

            stateValue = upDown;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            logo.enabled = true;
            buttonlist[stateValue].GetComponentInChildren<Animator>().GetComponent<Image>().enabled=true;
            buttonlist[0].GetComponent<Image>().enabled = true;
            buttonlist[1].GetComponent<Image>().enabled = false;
            buttonlist[2].GetComponent<Image>().enabled = false;
            buttonlist[3].GetComponent<Image>().enabled = false;
            newGameSign.GetComponent<MeshRenderer>().material = newGame;
            stateValue = 0;
            upDown = 1;
        }
        if (!timerStart)
        {
            for (int i = 0; i < buttonlist.Length; i++)
            {
                if (i != stateValue)
                {
                    buttonlist[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                }
                else
                {
                    buttonlist[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                }

            }
        }
       


    }
}
