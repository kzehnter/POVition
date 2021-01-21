using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** Timercube actions.
 *
 *  @author Konstantin
 */
public class SwapCubeAction_Timer : SwapCubeAction
{
    /** Time in seconds between swaps.*/
    public int delayTime;
    /** All text objects on sides of the cube.*/
    public Text[] textList;
    /** for counting and restricting swaps during run.*/
    private bool running = false;
    /** Goes down every frame if running. */
    private float timeForText;

    /** Waits delayTime and swaps.
     */
    IEnumerator waiter(Transform target) {
        running = true;
        yield return new WaitForSeconds(delayTime);
        performSwap(target);
        running = false;
        timeForText = (float)delayTime;
    }

    /** Updates text on all textfields.
     */
    private void showText() {
        foreach (Text textField in textList) {
            textField.text = timeForText.ToString();
        }
    }

    /** Initialization and text showing.
     */
    void Start() {
        timeForText = (float)delayTime;
        showText();
    }

    /** Count down time and show text.
     */
    void FixedUpdate() {
        if (running) { 
            timeForText -= Time.deltaTime; 
        }
        showText();
    }
    
    /** Swap, start waiter().
     *  Startet by OnPointerClick in PlayerAction
     */
    public override void performAction(Transform target) {
        if (!running) {
            performSwap(target);
            StartCoroutine(waiter(target));
        }
    }
}
