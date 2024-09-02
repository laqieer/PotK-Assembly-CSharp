// Decompiled with JetBrains decompiler
// Type: BattleUI04SetHP
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class BattleUI04SetHP : MonoBehaviour
{
  [SerializeField]
  public GameObject[] hpNumbers;

  public void setValue(int v)
  {
    this.notDisplay();
    this.hpNumbers[v].SetActive(true);
  }

  public void notDisplay()
  {
    foreach (GameObject hpNumber in this.hpNumbers)
      hpNumber.SetActive(false);
  }
}
