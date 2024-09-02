// Decompiled with JetBrains decompiler
// Type: AddStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
      this.TxtOperator.SetText(Consts.GetInstance().PLUS);
      this.TxtStatus[(int) index].SetTextLocalize(Math.Abs(value));
      ((Component) this.TxtStatus[(int) index]).gameObject.SetActive(true);
    }
    else
    {
      this.TxtOperator.SetText(Consts.GetInstance().MINUS);
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
