// Decompiled with JetBrains decompiler
// Type: Unit0046Character
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Unit0046Character : MonoBehaviour
{
  public GameObject select;
  public GameObject Notselect;
  public int mynumber;
  [SerializeField]
  private GameObject special;

  public void CharaSetActive(bool selectCondition, bool isSpecial)
  {
    this.Notselect.SetActive(!selectCondition);
    this.special.SetActive(isSpecial);
  }
}
