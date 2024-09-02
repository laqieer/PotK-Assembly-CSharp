// Decompiled with JetBrains decompiler
// Type: Startup000121NewsScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class Startup000121NewsScrollParts : Startup000121ScrollParts
{
  [SerializeField]
  protected GameObject newsSprite;
  [SerializeField]
  protected GameObject bugSprite;

  public override void SetData(OfficialInformationArticle info, NGMenuBase menu)
  {
    if (info.sub_category_id == 1)
    {
      this.bugSprite.SetActive(true);
      this.newsSprite.SetActive(false);
    }
    else
    {
      this.newsSprite.SetActive(true);
      this.bugSprite.SetActive(false);
    }
  }
}
