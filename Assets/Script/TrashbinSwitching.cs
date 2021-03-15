using UnityEngine;

public class TrashbinSwitching : MonoBehaviour
{
    public int selectedBin = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectBin();
        
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedBin = selectedBin;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (selectedBin >= transform.childCount - 1)
                selectedBin = 0;
            else
                selectedBin++;
        }
        if(previousSelectedBin != selectedBin)
        {
            SelectBin();
        }
    }
    void SelectBin()
    {
        int i = 0;
        foreach(Transform bin in transform)
        {
            if (i == selectedBin)
                bin.gameObject.SetActive(true);
            else
                bin.gameObject.SetActive(false);
            i++;
        }
    }
}
