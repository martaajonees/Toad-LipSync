using UnityEngine;
using uLipSync;

public class BakedDataTest : MonoBehaviour
{
    public GameObject lipSyncComp;
    public BakedData dataRight, dataLeft, dataFordward, dataBackward;
    private uLipSyncBakedDataPlayer bakedPlayer;


    // Start is called before the first frame update
    void Start()
    {
        bakedPlayer = lipSyncComp.GetComponent<uLipSyncBakedDataPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bakedPlayer.isPlaying)
        {
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                bakedPlayer.bakedData = dataRight;
                bakedPlayer.Play();
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                bakedPlayer.bakedData = dataLeft;
                bakedPlayer.Play();
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                bakedPlayer.bakedData = dataFordward;
                bakedPlayer.Play();
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                bakedPlayer.bakedData = dataBackward;
                bakedPlayer.Play();
            }
        }
    }
}
