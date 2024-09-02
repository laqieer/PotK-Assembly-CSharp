// Decompiled with JetBrains decompiler
// Type: BattleUI04SetHP
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
