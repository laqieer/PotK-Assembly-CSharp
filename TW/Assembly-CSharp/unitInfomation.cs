// Decompiled with JetBrains decompiler
// Type: unitInfomation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
