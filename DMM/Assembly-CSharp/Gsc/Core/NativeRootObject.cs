// Decompiled with JetBrains decompiler
// Type: Gsc.Core.NativeRootObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace Gsc.Core
{
  public class NativeRootObject : MonoBehaviour
  {
    public static GameObject Instance { get; private set; }

    public static void CreateInstance()
    {
      if (!((Object) NativeRootObject.Instance == (Object) null))
        return;
      GameObject gameObject = new GameObject("GSCC.NativeRootObject");
      gameObject.hideFlags = HideFlags.HideAndDontSave;
      Object.DontDestroyOnLoad((Object) gameObject);
      gameObject.AddComponent<NativeRootObject>();
    }

    private void Awake() => NativeRootObject.Instance = this.gameObject;
  }
}
