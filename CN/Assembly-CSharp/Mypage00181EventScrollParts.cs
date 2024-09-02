// Decompiled with JetBrains decompiler
// Type: Mypage00181EventScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using UnityEngine;

#nullable disable
public class Mypage00181EventScrollParts : MonoBehaviour
{
  [SerializeField]
  private UI2DSprite sprite;
  [SerializeField]
  private GameObject newSprite;
  [SerializeField]
  private UILabel date;
  [SerializeField]
  private UILabel time;
  private InformationInformation master;
  private DateTime endDate;

  public void IbtnNewslist()
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage001_8_2", false, (object) this.master);
  }
}
