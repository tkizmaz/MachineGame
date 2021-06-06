using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isTarget;
    
    public void setIsTarget()
    {
        this.isTarget = true;
    }

    public bool getIsTarget()
    {
        return this.isTarget;
    }

}
