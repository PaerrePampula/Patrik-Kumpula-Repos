using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public List<Transform> cardUI;

    static private CanvasController _currentMainCanvas; //Tämänhetkinen pääcanvas.
    static public CanvasController mainCanvas //getataan maincanvas ja setataan se jos se on null
    {
        get
        {
            if (_currentMainCanvas == null)
            {
                _currentMainCanvas = FindObjectOfType<CanvasController>();
            }
            return _currentMainCanvas;
        }
    }
}
