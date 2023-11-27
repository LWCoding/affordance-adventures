using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class LevelHandler : MonoBehaviour
{

    /// <summary>
    /// This function triggers the WinLevel() function in the
    /// GameManager singleton.
    /// 
    /// Raises an assertion if GameManager is not findable.
    /// </summary>
    public void WinLevel()
    {
        Debug.Assert(GameManager.Instance != null, "Can't find GameManager singleton!", this);
        GameManager.Instance.WinLevel();
    }

}
