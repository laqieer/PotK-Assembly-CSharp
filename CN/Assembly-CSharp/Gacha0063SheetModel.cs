// Decompiled with JetBrains decompiler
// Type: Gacha0063SheetModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;

#nullable disable
public class Gacha0063SheetModel
{
  private GachaModule module;

  public Gacha0063SheetModel(GachaModule module) => this.module = module;

  public bool IsSheetGachaOpen => this.module.type == 6;
}
