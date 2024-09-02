// Decompiled with JetBrains decompiler
// Type: UISpriteExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public static class UISpriteExtension
{
  public static void ChangeSprite(this UISprite target, string newName)
  {
    if (Object.op_Equality((Object) target, (Object) null))
    {
      Debug.LogWarning((object) "UISprite is Null");
    }
    else
    {
      if (target.atlas.spriteList.Find((Predicate<UISpriteData>) (x => x.name == newName)) == null)
        return;
      target.spriteName = newName;
      UISpriteData atlasSprite = target.GetAtlasSprite();
      if (atlasSprite == null)
      {
        Debug.LogWarning((object) "Atlas内のSprite取得失敗");
      }
      else
      {
        target.width = atlasSprite.width;
        target.height = atlasSprite.height;
      }
    }
  }
}
