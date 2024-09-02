// Decompiled with JetBrains decompiler
// Type: Unit0046Character
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Unit0046Character : MonoBehaviour
{
  public GameObject select;
  public GameObject Notselect;
  public int mynumber;

  public void CharaSetActive(bool selectCondition) => this.Notselect.SetActive(!selectCondition);
}
