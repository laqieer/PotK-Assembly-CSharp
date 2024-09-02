// Decompiled with JetBrains decompiler
// Type: MypageInformationSheet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MypageInformationSheet : MonoBehaviour
{
  public GameObject node_;
  public UILabel txtTitle_;
  public UILabel txtMessage_;
  public int outCount_;

  public void onOutFinished()
  {
    if (!((Component) this).gameObject.activeSelf || --this.outCount_ > 0)
      return;
    ((Component) this).gameObject.SetActive(false);
  }
}
