﻿// Decompiled with JetBrains decompiler
// Type: Colabo0252Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colabo0252Scroll : MonoBehaviour
{
  private CrossFestaAchieve campaignData;
  [SerializeField]
  private UILabel discription;
  [SerializeField]
  private GameObject slc_achieve;
  [SerializeField]
  private GameObject slc_unachieve;
  [SerializeField]
  private UIButton ibtn_SerialGet;
  private int colaboID;

  [DebuggerHidden]
  public IEnumerator Init(CrossFestaAchieve campaignData, int colaboID, bool unlock)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colabo0252Scroll.\u003CInit\u003Ec__Iterator558()
    {
      colaboID = colaboID,
      campaignData = campaignData,
      unlock = unlock,
      \u003C\u0024\u003EcolaboID = colaboID,
      \u003C\u0024\u003EcampaignData = campaignData,
      \u003C\u0024\u003Eunlock = unlock,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnSerial() => this.StartCoroutine(this.IbtnGetSerial());

  [DebuggerHidden]
  public IEnumerator IbtnGetSerial()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colabo0252Scroll.\u003CIbtnGetSerial\u003Ec__Iterator559()
    {
      \u003C\u003Ef__this = this
    };
  }
}
