// Decompiled with JetBrains decompiler
// Type: CriWareDecrypterConfig
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;

#nullable disable
[Serializable]
public class CriWareDecrypterConfig
{
  public string key = string.Empty;
  public string authenticationFile = string.Empty;
  public bool enableAtomDecryption = true;
  public bool enableManaDecryption = true;
}
