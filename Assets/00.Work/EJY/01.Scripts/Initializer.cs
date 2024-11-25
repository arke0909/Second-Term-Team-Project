using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    private List<IInitializable> _intializable = new List<IInitializable>();

    private void Awake()
    {
        GetComponentsInChildren<IInitializable>().ToList().ForEach
            (compo => compo.Initialze());
    }
}
