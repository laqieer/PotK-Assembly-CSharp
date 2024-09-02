// Decompiled with JetBrains decompiler
// Type: Gacha0063SheetModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;

#nullable disable
public class Gacha0063SheetModel
{
  private GachaModule module;

  public Gacha0063SheetModel(GachaModule module) => this.module = module;

  public bool IsSheetGachaOpen => this.module.type == 6;
}
