using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
  public int scoreValue = 0;
  public TMP_Text scoreText;

  void Start()
  {
    UpdateScoreUI();
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Trash"))
    {
      Destroy(other.gameObject);
      scoreValue += 10;
      UpdateScoreUI();
    }
  }

  void UpdateScoreUI()
  {
    scoreText.text = "Score: " + scoreValue;
  }
}
