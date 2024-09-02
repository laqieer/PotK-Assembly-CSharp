// Decompiled with JetBrains decompiler
// Type: Client
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Client : MonoBehaviour
{
  private LuaScriptMgr luaMgr;

  private void Start()
  {
    this.luaMgr = new LuaScriptMgr();
    this.luaMgr.Start();
    this.luaMgr.DoFile("System.Test");
  }

  private void Update()
  {
    if (this.luaMgr == null)
      return;
    this.luaMgr.Update();
  }

  private void LateUpdate()
  {
    if (this.luaMgr == null)
      return;
    this.luaMgr.LateUpate();
  }

  private void FixedUpdate()
  {
    if (this.luaMgr == null)
      return;
    this.luaMgr.FixedUpdate();
  }

  private void OnGUI()
  {
    if (GUI.Button(new Rect(10f, 10f, 120f, 50f), "Test"))
    {
      float realtimeSinceStartup = Time.realtimeSinceStartup;
      Vector3 vector3 = Vector3.one;
      for (int index = 0; index < 200000; ++index)
      {
        vector3 = ((Component) this).transform.position;
        ((Component) this).transform.position = Vector3.one;
      }
      Debug.Log((object) ("c# cost time: " + (object) (float) ((double) Time.realtimeSinceStartup - (double) realtimeSinceStartup)));
      ((Component) this).transform.position = Vector3.zero;
      this.luaMgr.CallLuaFunction("Test");
    }
    if (GUI.Button(new Rect(10f, 70f, 120f, 50f), "Test2"))
    {
      float realtimeSinceStartup = Time.realtimeSinceStartup;
      for (int index = 0; index < 200000; ++index)
        ((Component) this).transform.Rotate(Vector3.up, 1f);
      Debug.Log((object) ("c# cost time: " + (object) (float) ((double) Time.realtimeSinceStartup - (double) realtimeSinceStartup)));
      this.luaMgr.CallLuaFunction("Test2", (object) ((Component) this).transform);
    }
    if (GUI.Button(new Rect(10f, 130f, 120f, 50f), "Test3"))
    {
      float realtimeSinceStartup = Time.realtimeSinceStartup;
      Vector3 one = Vector3.one;
      for (int index = 0; index < 200000; ++index)
      {
        // ISSUE: explicit constructor call
        ((Vector3) ref one).\u002Ector((float) index, (float) index, (float) index);
      }
      Debug.Log((object) ("c# cost time: " + (object) (float) ((double) Time.realtimeSinceStartup - (double) realtimeSinceStartup)));
      this.luaMgr.CallLuaFunction("Test3", (object) ((Component) this).transform);
    }
    if (GUI.Button(new Rect(10f, 190f, 120f, 50f), "Test4"))
    {
      float realtimeSinceStartup = Time.realtimeSinceStartup;
      for (int index = 0; index < 200000; ++index)
      {
        GameObject gameObject = new GameObject();
      }
      Debug.Log((object) ("c# cost time: " + (object) (float) ((double) Time.realtimeSinceStartup - (double) realtimeSinceStartup)));
      this.luaMgr.CallLuaFunction("Test4", (object) ((Component) this).transform);
    }
    if (!GUI.Button(new Rect(10f, 250f, 120f, 50f), "Test5"))
      return;
    float realtimeSinceStartup1 = Time.realtimeSinceStartup;
    for (int index = 0; index < 20000; ++index)
    {
      GameObject gameObject = new GameObject();
      gameObject.AddComponent<SkinnedMeshRenderer>();
      SkinnedMeshRenderer component = gameObject.GetComponent<SkinnedMeshRenderer>();
      ((Renderer) component).castShadows = false;
      ((Renderer) component).receiveShadows = false;
    }
    Debug.Log((object) ("c# cost time: " + (object) (float) ((double) Time.realtimeSinceStartup - (double) realtimeSinceStartup1)));
    this.luaMgr.CallLuaFunction("Test5", (object) ((Component) this).transform);
  }
}
