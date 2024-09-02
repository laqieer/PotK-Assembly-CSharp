// Decompiled with JetBrains decompiler
// Type: Bugu00539ChangeSceneParam
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class Bugu00539ChangeSceneParam
{
  public List<GameCore.ItemInfo> num_list;
  public bool is_new;
  public string[] anim_pattern;
  public GameCore.ItemInfo baseItem;
  public System.Action backSceneCallback;

  public Bugu00539ChangeSceneParam(
    List<GameCore.ItemInfo> numList,
    bool isNew,
    string[] animPattern,
    GameCore.ItemInfo baseItem,
    System.Action backScene)
  {
    this.num_list = numList;
    this.is_new = isNew;
    this.anim_pattern = animPattern;
    this.baseItem = baseItem;
    this.backSceneCallback = backScene;
  }
}
