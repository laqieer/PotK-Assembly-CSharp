// Decompiled with JetBrains decompiler
// Type: Mypage00181NewsScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
