using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isTarget;
    
    public void setIsTarget(bool isSelected)
    {
        this.isTarget = isSelected;
    }

    public bool getIsTarget()
    {
        return this.isTarget;
    }

}
