// Decompiled with JetBrains decompiler
// Type: Startup0008Data
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Startup0008Data
{
  public string titleAgreement;
  public string agreementHedder;
  public string agreement;
  public string titleDissent;
  public string dissent;

  [DebuggerHidden]
  public IEnumerator Initialize()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup0008Data.\u003CInitialize\u003Ec__Iterator1B4()
    {
      \u003C\u003Ef__this = this
    };
  }

  public string I2Converter(string key, string defaultValue) => defaultValue;
}
