using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleHolder : MonoBehaviour
{
    public static HoleHolder instance;
    [SerializeField] private List<Hole> easyHoles;
    [SerializeField] private List<Hole> mediumHoles;
    [SerializeField] private List<Hole> hardHoles;

    private void Awake()
    {
        instance = this;
    }

    public GameObject FindEasyHole()
    {
        int sizeOfList = easyHoles.Count;
        Hole selectedHole = easyHoles[Random.Range(0, sizeOfList)];
        easyHoles.Remove(selectedHole);
        return selectedHole.gameObject;
    }

    public GameObject FindMediumHole()
    {
        int sizeOfList = mediumHoles.Count;
        Hole selectedHole = mediumHoles[Random.Range(0, sizeOfList)];
        mediumHoles.Remove(selectedHole);
        return selectedHole.gameObject;
    }

    public GameObject FindHardHole()
    {
        int sizeOfList = hardHoles.Count;
        Hole selectedHole = hardHoles[Random.Range(0, sizeOfList)];
        hardHoles.Remove(selectedHole);
        return selectedHole.gameObject;
    }

}
