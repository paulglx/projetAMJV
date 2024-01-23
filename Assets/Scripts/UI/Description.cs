using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    public string displayName;

    [TextArea(3, 10)]
    public string description;

    [TextArea(3, 10)]
    public string capacityDescription;
}
