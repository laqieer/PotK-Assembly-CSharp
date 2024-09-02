// Decompiled with JetBrains decompiler
// Type: DownloadLanguage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DownloadLanguage : MonoBehaviour
{
  private static DownloadLanguage instance;

  public static DownloadLanguage Instance => DownloadLanguage.instance;

  private void Awake()
  {
    if (Object.op_Implicit((Object) DownloadLanguage.instance))
      Object.Destroy((Object) DownloadLanguage.instance);
    else
      DownloadLanguage.instance = this;
    ((Component) this).transform.parent = ((Component) LocalizationPreset.Instance).transform;
  }

  private void Start()
  {
    if (!LocalizationPreset.Instance.EnableLocalization)
      return;
    this.StartCoroutine(this.AssetBundleDownload());
  }

  [DebuggerHidden]
  private IEnumerator AssetBundleDownload()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DownloadLanguage.\u003CAssetBundleDownload\u003Ec__Iterator110()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void StartAssetBundleDownload() => this.StartCoroutine(this.AssetBundleDownload());
}
