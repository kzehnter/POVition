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
    [SerializeField]
    /** Time in seconds between swaps.
     */
    private int delayTime;

    public Text[] textList;
    private bool running = false;
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

    private void showText() {
        foreach (Text textField in textList) {
            textField.text = timeForText.ToString();
        }
    }

    void Start() {
        timeForText = (float)delayTime;
        showText();
    }

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
        performSwap(target);
        StartCoroutine(waiter(target));
    }
}
