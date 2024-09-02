// Decompiled with JetBrains decompiler
// Type: Quest0021QuantityParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Quest0021QuantityParts : MonoBehaviour
{
  public GameObject[] lefrParent;
  public GameObject[] rightParent;
  public GameObject equals;

  public void Init(int count)
  {
    if (count > 99)
    {
      Debug.LogWarning((object) ("set quantity over 99, count=" + (object) count));
      count = 99;
    }
    int index1 = count % 10;
    int index2 = Mathf.FloorToInt((float) (count / 10));
    for (int index3 = 0; index3 <= 9; ++index3)
    {
      this.rightParent[index3].SetActive(false);
      this.lefrParent[index3].SetActive(false);
    }
    this.rightParent[index1].SetActive(true);
    this.lefrParent[index2].SetActive(true);
    this.equals.SetActive(true);
  }
}
