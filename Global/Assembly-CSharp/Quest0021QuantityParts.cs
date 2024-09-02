// Decompiled with JetBrains decompiler
// Type: Quest0021QuantityParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
      Debug.LogWarning((object) ("Quest quantity count exceeds 99, reducing. Original: " + (object) count));
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
