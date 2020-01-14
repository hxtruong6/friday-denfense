using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private List<string> selectableTags = new List<string>() {"Tower"};

    // Start is called before the first frame update
    public Sprite selectionCursor;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (isPointerCursor(hit.transform.gameObject))
            {
                Cursor.SetCursor(selectionCursor.texture, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }
    }

    private bool isPointerCursor(GameObject selection)
    {

        if (selectableTags.Contains(selection.tag))
        {
            return true;
        }
        return false;
    }
}