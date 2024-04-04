using UnityEngine;
using uLipSync;

public class BakedDataTest : MonoBehaviour
{
    public GameObject lipSyncComp;
    public BakedData data2;
    private uLipSyncBakedDataPlayer bakedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        bakedPlayer = lipSyncComp.GetComponent<uLipSyncBakedDataPlayer>();
        bakedPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bakedPlayer.isPlaying)
        {
            bakedPlayer.bakedData = data2;
            bakedPlayer.Play();
        }
    }
}
