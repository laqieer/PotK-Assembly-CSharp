﻿// Decompiled with JetBrains decompiler
// Type: Mypage00181FunctionScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

public class Mypage00181FunctionScrollParts : MonoBehaviour
{
  [SerializeField]
  private UILabel title;
  [SerializeField]
  private UILabel date;
  [SerializeField]
  private UILabel time;
  [SerializeField]
  private GameObject newSprite;
  private InformationInformation master;

  public void IbtnNewslist() => Singleton<NGSceneManager>.GetInstance().changeScene("mypage001_8_2", false, (object) this.master);
}
