﻿// Decompiled with JetBrains decompiler
// Type: Raid032MyRankingStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class Raid032MyRankingStatus : MonoBehaviour
{
  [SerializeField]
  protected Raid032MyRankingStatus.InsStatus[] status = new Raid032MyRankingStatus.InsStatus[2];

  protected void setStatusValues(int?[] values)
  {
    if (this.status == null || values == null || this.status.Length != values.Length)
      return;
    for (int index = 0; index < this.status.Length; ++index)
    {
      if (values[index].HasValue && this.status[index] != null && !((UnityEngine.Object) this.status[index].txtValue == (UnityEngine.Object) null))
        this.status[index].txtValue.SetTextLocalize(values[index].Value);
    }
  }

  protected void changeDrawStatus(Raid032MyRankingStatus.StatusEnum estatus = Raid032MyRankingStatus.StatusEnum.Num, int? intValue = null)
  {
    if (this.status == null)
      return;
    foreach (Raid032MyRankingStatus.InsStatus statu in this.status)
    {
      if (statu != null && !((UnityEngine.Object) statu.top == (UnityEngine.Object) null))
      {
        statu.top.SetActive(statu.status == estatus);
        if (statu.top.activeSelf && intValue.HasValue && (UnityEngine.Object) statu.txtValue != (UnityEngine.Object) null)
          statu.txtValue.SetTextLocalize(intValue.Value);
      }
    }
  }

  public enum StatusEnum
  {
    Guild,
    Overall,
    Num,
  }

  [Serializable]
  public class InsStatus
  {
    public Raid032MyRankingStatus.StatusEnum status = Raid032MyRankingStatus.StatusEnum.Num;
    public GameObject top;
    public UILabel txtValue;
  }
}
