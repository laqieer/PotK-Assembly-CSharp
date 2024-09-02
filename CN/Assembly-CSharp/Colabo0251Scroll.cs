﻿// Decompiled with JetBrains decompiler
// Type: Colabo0251Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colabo0251Scroll : MonoBehaviour
{
  private CrossFestaCampaign campaignData;
  [SerializeField]
  private UI2DSprite spriteIdle;
  [SerializeField]
  private UI2DSprite spritePress;
  [SerializeField]
  public FloatButton BtnFormation;

  [DebuggerHidden]
  public IEnumerator Init(CrossFestaCampaign campaignData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colabo0251Scroll.\u003CInit\u003Ec__Iterator5F9()
    {
      campaignData = campaignData,
      \u003C\u0024\u003EcampaignData = campaignData,
      \u003C\u003Ef__this = this
    };
  }

  public void onOver()
  {
    ((Component) this.spriteIdle).gameObject.SetActive(false);
    ((Component) this.spritePress).gameObject.SetActive(true);
  }

  public void onOut()
  {
    ((Component) this.spriteIdle).gameObject.SetActive(true);
    ((Component) this.spritePress).gameObject.SetActive(false);
  }

  public void IbtnSerial() => this.StartCoroutine(this.AcessAPI());

  [DebuggerHidden]
  private IEnumerator AcessAPI()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colabo0251Scroll.\u003CAcessAPI\u003Ec__Iterator5FA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator CreateSprite(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colabo0251Scroll.\u003CCreateSprite\u003Ec__Iterator5FB()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator LoadSprite(string path, UI2DSprite spriteObj)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colabo0251Scroll.\u003CLoadSprite\u003Ec__Iterator5FC()
    {
      path = path,
      spriteObj = spriteObj,
      \u003C\u0024\u003Epath = path,
      \u003C\u0024\u003EspriteObj = spriteObj
    };
  }
}
