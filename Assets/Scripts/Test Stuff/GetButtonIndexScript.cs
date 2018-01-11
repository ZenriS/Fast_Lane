using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetButtonIndexScript : MonoBehaviour
{
    //Used to get button child index. But find that I could use Eventsystem to do the same in the main script.
    private JobInfoScript _jobInfoScript;

    void Start()
    {
        _jobInfoScript = transform.parent.GetComponent<JobInfoScript>();
    }

    public void SetIndex()
    {
        _jobInfoScript.RefIndex = transform.GetSiblingIndex();
    }
}
