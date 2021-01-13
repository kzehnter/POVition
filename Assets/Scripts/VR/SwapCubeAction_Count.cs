using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** Destroy after swap count, Show count in text on cube.
 *
 *  @author Konstantin
 */
public class SwapCubeAction_Count : SwapCubeAction
{
    [SerializeField]
    /** Amount of times a swap will be possible.*/
    private int countNr;
    
    /** All texts on cube. */
    public Text[] textList;
    
    /** Iterates through textList and sets countNr as text. */
    private void showText(){
        foreach (Text textField in textList) {
            textField.text = countNr.ToString();
        }
    }

    /** Show right count at start.
     */
    void Start() {
        showText();
    }

    /** Swap and check if cube should be destroyed.
     */
    public override void performAction(Transform target) {
        performSwap(target);
        countNr--;
        if (countNr <= 0) { 
            this.tag = "Untagged";
            this.GetComponent<Renderer>().material.color = Color.black;
            showText(); 
        } else { 
            showText(); 
        }
    }
}
