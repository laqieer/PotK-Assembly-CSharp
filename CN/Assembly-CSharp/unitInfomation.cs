﻿// Decompiled with JetBrains decompiler
// Type: unitInfomation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using UnityEngine;

#nullable disable
public class unitInfomation
{
  public BL.Unit bu;
  public Battle0181CharacterStatus p;
  public NGDuelUnit enemy;
  public bool isplayer = true;
  public bool iscriticalcamera;
  public BL.MagicBullet mb;
  public Transform trs;
  public int range;
  public IntimateDuelSupport support;
  public int supportHitIncr;
  public int supportEvasionIncr;
  public int supportCriticalIncr;
  public int supportCriticalEvasionIncr;
  public GameObject root3d;
  public NGDuelManager mng;
  public int[] beforeAilmentEffectIDs;
}
