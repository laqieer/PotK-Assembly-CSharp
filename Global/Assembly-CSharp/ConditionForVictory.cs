// Decompiled with JetBrains decompiler
// Type: ConditionForVictory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System;
using UniLinq;
using UnityEngine;

#nullable disable
public class ConditionForVictory : MonoBehaviour
{
  [SerializeField]
  private UILabel text;
  [SerializeField]
  private UILabel textTwoLine;
  [SerializeField]
  private UILabel textEff;
  [SerializeField]
  private UILabel textEffTwoLine;
  [SerializeField]
  private GameObject defeatCondition;
  [SerializeField]
  private UILabel textDefeatCondition;
  [SerializeField]
  private UILabel textDefeatConditionTwoLine;
  [SerializeField]
  private GameObject waveNumObject;
  [SerializeField]
  private UILabel textWaveNum;

  public void Initialize(BattleVictoryCondition condition, int wave, int maxWave)
  {
    ((Component) this.text).gameObject.SetActive(false);
    ((Component) this.textEff).gameObject.SetActive(false);
    ((Component) this.textTwoLine).gameObject.SetActive(false);
    ((Component) this.textEffTwoLine).gameObject.SetActive(false);
    if (condition.victory_text.Count<char>((Func<char, bool>) (x => x.Equals('\n'))) == 0)
    {
      ((Component) this.text).gameObject.SetActive(true);
      ((Component) this.textEff).gameObject.SetActive(true);
      this.text.text = condition.victory_text;
      this.textEff.text = condition.victory_text;
    }
    else
    {
      ((Component) this.textTwoLine).gameObject.SetActive(true);
      ((Component) this.textEffTwoLine).gameObject.SetActive(true);
      this.textTwoLine.text = condition.victory_text;
      this.textEffTwoLine.text = condition.victory_text;
    }
    this.defeatCondition.SetActive(false);
    if (!string.IsNullOrEmpty(condition.lose_text))
    {
      this.defeatCondition.SetActive(true);
      ((Component) this.textDefeatCondition).gameObject.SetActive(false);
      ((Component) this.textDefeatConditionTwoLine).gameObject.SetActive(false);
      if (condition.lose_text.Count<char>((Func<char, bool>) (x => x.Equals('\n'))) == 0)
      {
        ((Component) this.textDefeatCondition).gameObject.SetActive(true);
        this.textDefeatCondition.text = condition.lose_text;
      }
      else
      {
        ((Component) this.textDefeatConditionTwoLine).gameObject.SetActive(true);
        this.textDefeatConditionTwoLine.text = condition.lose_text;
      }
    }
    this.waveNumObject.SetActive(false);
  }
}
