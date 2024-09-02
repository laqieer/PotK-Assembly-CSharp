// Decompiled with JetBrains decompiler
// Type: Mypage00181NewsScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class Mypage00181NewsScrollParts : MonoBehaviour
{
  [SerializeField]
  private UILabel title;
  [SerializeField]
  private UILabel date;
  [SerializeField]
  private UILabel time;
  [SerializeField]
  private GameObject newsSprite;
  [SerializeField]
  private GameObject bugSprite;
  [SerializeField]
  private GameObject newSprite;
  private InformationInformation master;

  public void IbtnNewslist()
  {
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage001_8_2", false, (object) this.master);
  }
}
