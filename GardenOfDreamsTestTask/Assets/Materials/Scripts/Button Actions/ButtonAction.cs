using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    public ActionButton button;
    public GameObject prefab;

    public void UseAction()
	{
        PlayerActions playerAction = new PlayerActions();
        playerAction.UseAction(button);
	}
}
