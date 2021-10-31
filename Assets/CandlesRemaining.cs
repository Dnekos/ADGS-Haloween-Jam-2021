using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CandlesRemaining : MonoBehaviour
{
   private int totalCandles;
   private TMP_Text tmp;
   private int candlesRemaining;

   private void Start()
   {
      // get candles in scene
      GameObject[] candles = GameObject.FindGameObjectsWithTag("Candle");
      totalCandles = candles.Length;
      tmp = GetComponent<TMP_Text>();
      tmp.SetText(totalCandles + "/" + totalCandles);
      candlesRemaining = totalCandles;
   }

   public void DecrementRemainingCandles()
   {
      candlesRemaining--;
      tmp.SetText(candlesRemaining + "/" + totalCandles);
   }
}
