// Decompiled with JetBrains decompiler
// Type: HeadlineLabel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Custum/UI/HeadlineLabel")]
public class HeadlineLabel : UILabel
{
  public int headlinePerLine = 20;
  public int headlineMaxLine = 3;

  public bool SetHeadline(string message) => this.SetTextHeadline(message, this.headlinePerLine, this.headlineMaxLine);
}
