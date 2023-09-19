using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISavable
{
    // Start is called before the first frame update

    object SaveState();


    void LoadState(object state);


}
