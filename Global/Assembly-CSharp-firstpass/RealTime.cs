// Decompiled with JetBrains decompiler
// Type: RealTime
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
public class RealTime : MonoBehaviour
{
  private static RealTime mInst;
  private float mRealTime;
  private float mRealDelta;

  public static float time
  {
    get
    {
      if (Object.op_Equality((Object) RealTime.mInst, (Object) null))
        RealTime.Spawn();
      return RealTime.mInst.mRealTime;
    }
  }

  public static float deltaTime
  {
    get
    {
      if (Object.op_Equality((Object) RealTime.mInst, (Object) null))
        RealTime.Spawn();
      return RealTime.mInst.mRealDelta;
    }
  }

  private static void Spawn()
  {
    GameObject gameObject = new GameObject("_RealTime");
    Object.DontDestroyOnLoad((Object) gameObject);
    RealTime.mInst = gameObject.AddComponent<RealTime>();
    RealTime.mInst.mRealTime = Time.realtimeSinceStartup;
  }

  private void Update()
  {
    float realtimeSinceStartup = Time.realtimeSinceStartup;
    this.mRealDelta = Mathf.Clamp01(realtimeSinceStartup - this.mRealTime);
    this.mRealTime = realtimeSinceStartup;
  }
}
