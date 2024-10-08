﻿// Decompiled with JetBrains decompiler
// Type: CoinExchangeIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class CoinExchangeIcon : BackButtonMenuBase
{
  [SerializeField]
  private GameObject slcCoinBaseOn;
  [SerializeField]
  private GameObject slcCoinBaseOff;
  [SerializeField]
  private UI2DSprite dynIcon;
  private int index;
  private System.Action<int> callbackPush;

  public int id { get; private set; }

  public IEnumerator Init(int id, int index, System.Action<int> callbackPush)
  {
    this.id = id;
    this.index = index;
    this.callbackPush = callbackPush;
    Future<UnityEngine.Sprite> future = MasterData.CommonTicket[id].LoadIconMSpriteF();
    IEnumerator e = future.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.dynIcon.sprite2D = future.Result;
    this.setBaseOnOff(false);
  }

  public void setBaseOnOff(bool enable)
  {
    this.slcCoinBaseOn?.SetActive(enable);
    this.slcCoinBaseOff?.SetActive(!enable);
  }

  public override void onBackButton()
  {
  }

  public void IbtnPush()
  {
    if (this.callbackPush == null)
      return;
    this.callbackPush(this.index);
  }
}
