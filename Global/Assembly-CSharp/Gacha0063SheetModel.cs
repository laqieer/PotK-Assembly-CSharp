// Decompiled with JetBrains decompiler
// Type: Gacha0063SheetModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;

#nullable disable
public class Gacha0063SheetModel
{
  private GachaModule module;

  public Gacha0063SheetModel(GachaModule module) => this.module = module;

  public bool IsSheetGachaOpen => this.module.type == 6;
}
