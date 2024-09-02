// Decompiled with JetBrains decompiler
// Type: SDKMgr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class SDKMgr : Singleton<SDKMgr>
{
  private bool bIsWechatShareSucceed;
  private bool bIsWechatCircleShareSucceed;
  private bool bIsWechatFavirateShareSucceed;
  private string strCBResult = string.Empty;

  protected override void Initialize()
  {
  }

  public void ShareToWechatCircle() => this.StartCoroutine(this.TakeScreenshot());

  [DebuggerHidden]
  private IEnumerator TakeScreenshot()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    SDKMgr.\u003CTakeScreenshot\u003Ec__IteratorB07 screenshot = new SDKMgr.\u003CTakeScreenshot\u003Ec__IteratorB07();
    return (IEnumerator) screenshot;
  }
}
