// Decompiled with JetBrains decompiler
// Type: AddStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UnityEngine;

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
    AddStatus.Type type = value > 0 ? AddStatus.Type.ADD : AddStatus.Type.SUB;
    ((IEnumerable<GameObject>) this.BG).ToggleOnce((int) type);
    this.TxtCategory.SetText(category);
    foreach (Component txtStatu in this.TxtStatus)
      txtStatu.gameObject.SetActive(false);
    if (type == AddStatus.Type.ADD)
    {
      this.TxtOperator.SetText(Consts.GetInstance().PLUS);
      this.TxtStatus[(int) type].SetTextLocalize(Math.Abs(value));
      this.TxtStatus[(int) type].gameObject.SetActive(true);
    }
    else
    {
      this.TxtOperator.SetText(Consts.GetInstance().MINUS);
      this.TxtStatus[(int) type].SetTextLocalize(Math.Abs(value));
      this.TxtStatus[(int) type].gameObject.SetActive(true);
    }
  }

  private enum Type
  {
    SUB,
    ADD,
  }
}
