// Decompiled with JetBrains decompiler
// Type: MetaOp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
public enum MetaOp
{
  None = 0,
  Add = 1,
  Sub = 2,
  Mul = 4,
  Div = 8,
  Eq = 16, // 0x00000010
  Neg = 32, // 0x00000020
  ALL = 63, // 0x0000003F
}
