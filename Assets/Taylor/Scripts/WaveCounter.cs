using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    public static int waveNumber = 0;
    private int addCabbage = 0;
    Text score;

    // Use this for initialization
    void Start()
    {
        score = GetComponent<Text>();

    }
    // Update is called once per frame
    void Update()
    {
        score.text = "Wave: " + waveNumber;

        if (WaveCounter.waveNumber == 0 && addCabbage == 0)
        {
            CabbageCounter.cabbageAmount += 100;
            addCabbage += 2;
        }
        else
        {
            if (WaveCounter.waveNumber == 2 && addCabbage == 2)
            {
                CabbageCounter.cabbageAmount += 100;
                addCabbage += 1;
            }
            else
            {
                if (WaveCounter.waveNumber == 3 && addCabbage == 3)
                {
                    CabbageCounter.cabbageAmount += 100;
                    addCabbage += 1;
                }
                else
                {
                    if (WaveCounter.waveNumber == 4 && addCabbage == 4)
                    {
                        CabbageCounter.cabbageAmount += 100;
                        addCabbage += 1;
                    }
                    else
                    {
                        if (WaveCounter.waveNumber == 5 && addCabbage == 5)
                        {
                            CabbageCounter.cabbageAmount += 100;
                            addCabbage += 1;
                        }
                        else
                        {
                            if (WaveCounter.waveNumber == 6 && addCabbage == 6)
                            {
                                CabbageCounter.cabbageAmount += 100;
                                addCabbage += 1;
                            }
                            else
                            {
                                if (WaveCounter.waveNumber == 7 && addCabbage == 7)
                                {
                                    CabbageCounter.cabbageAmount += 100;
                                    addCabbage += 1;
                                }
                                else
                                {
                                    if (WaveCounter.waveNumber == 8 && addCabbage == 8)
                                    {
                                        CabbageCounter.cabbageAmount += 100;
                                        addCabbage += 1;
                                    }
                                    else
                                    {
                                        if (WaveCounter.waveNumber == 9 && addCabbage == 9)
                                        {
                                            CabbageCounter.cabbageAmount += 100;
                                            addCabbage += 1;
                                        }
                                        else
                                        {
                                            if (WaveCounter.waveNumber == 10 && addCabbage == 10)
                                            {
                                                CabbageCounter.cabbageAmount += 100;
                                                addCabbage += 1;
                                            }
                                            else
                                            {
                                                if (WaveCounter.waveNumber == 11 && addCabbage == 11)
                                                {
                                                    CabbageCounter.cabbageAmount += 0;
                                                    addCabbage += 1;
                                                }
                                                else
                                                {
                                                    if (WaveCounter.waveNumber == 12 && addCabbage == 12)
                                                    {
                                                        CabbageCounter.cabbageAmount += 0;
                                                        addCabbage += 1;
                                                    }
                                                    else
                                                    {
                                                        if (WaveCounter.waveNumber == 13 && addCabbage == 13)
                                                        {
                                                            CabbageCounter.cabbageAmount += 0;
                                                            addCabbage += 1;
                                                        }
                                                        else
                                                        {
                                                            if (WaveCounter.waveNumber == 14 && addCabbage == 14)
                                                            {
                                                                CabbageCounter.cabbageAmount += 0;
                                                                addCabbage += 1;
                                                            }
                                                            else
                                                            {
                                                                if (WaveCounter.waveNumber == 15 && addCabbage == 15)
                                                                {
                                                                    CabbageCounter.cabbageAmount += 0;
                                                                    addCabbage += 1;
                                                                }
                                                                else
                                                                {
                                                                    if (WaveCounter.waveNumber == 16 && addCabbage == 16)
                                                                    {
                                                                        CabbageCounter.cabbageAmount += 0;
                                                                        addCabbage += 1;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (WaveCounter.waveNumber == 17 && addCabbage == 17)
                                                                        {
                                                                            CabbageCounter.cabbageAmount += 0;
                                                                            addCabbage += 1;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (WaveCounter.waveNumber == 18 && addCabbage == 18)
                                                                            {
                                                                                CabbageCounter.cabbageAmount += 0;
                                                                                addCabbage += 1;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (WaveCounter.waveNumber == 19 && addCabbage == 19)
                                                                                {
                                                                                    CabbageCounter.cabbageAmount += 0;
                                                                                    addCabbage += 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (WaveCounter.waveNumber == 20 && addCabbage == 20)
                                                                                    {
                                                                                        CabbageCounter.cabbageAmount += 0;
                                                                                        addCabbage += 1;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}