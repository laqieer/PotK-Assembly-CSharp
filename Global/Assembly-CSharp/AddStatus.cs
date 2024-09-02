// Decompiled with JetBrains decompiler
// Type: AddStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class AddStatus : MonoBehaviour
{
  [SerializeField]
  private GameObject[] BG;
  [SerializeField]
  private UILabel TxtCategory;
  [SerializeField]
  private UILabel TxtOperator;
  [SerializeField]
  private UILabel[] TxtStatus;

  public void Init(string category, int value)
  {
    AddStatus.Type index = value <= 0 ? AddStatus.Type.SUB : AddStatus.Type.ADD;
    ((IEnumerable<GameObject>) this.BG).ToggleOnce((int) index);
    this.TxtCategory.SetText(category);
    foreach (Component txtStatu in this.TxtStatus)
      txtStatu.gameObject.SetActive(false);
    if (index == AddStatus.Type.ADD)
    {
      this.TxtOperator.SetText(Consts.Lookup("PLUS"));
      this.TxtStatus[(int) index].SetTextLocalize(Math.Abs(value));
      ((Component) this.TxtStatus[(int) index]).gameObject.SetActive(true);
    }
    else
    {
      this.TxtOperator.SetText(Consts.Lookup("MINUS"));
      this.TxtStatus[(int) index].SetTextLocalize(Math.Abs(value));
      ((Component) this.TxtStatus[(int) index]).gameObject.SetActive(true);
    }
  }

  private enum Type
  {
    SUB,
    ADD,
  }
}
