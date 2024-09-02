// Decompiled with JetBrains decompiler
// Type: NGUIDebug
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Internal/Debug")]
public class NGUIDebug : MonoBehaviour
{
  private static bool mRayDebug = false;
  private static List<string> mLines = new List<string>();
  private static NGUIDebug mInstance = (NGUIDebug) null;

  public static bool debugRaycast
  {
    get => NGUIDebug.mRayDebug;
    set
    {
      if (!Application.isPlaying)
        return;
      NGUIDebug.mRayDebug = value;
      if (!value)
        return;
      NGUIDebug.CreateInstance();
    }
  }

  public static void CreateInstance()
  {
    if (!Object.op_Equality((Object) NGUIDebug.mInstance, (Object) null))
      return;
    GameObject gameObject = new GameObject("_NGUI Debug");
    NGUIDebug.mInstance = gameObject.AddComponent<NGUIDebug>();
    Object.DontDestroyOnLoad((Object) gameObject);
  }

  private static void LogString(string text)
  {
    if (Application.isPlaying)
    {
      if (NGUIDebug.mLines.Count > 20)
        NGUIDebug.mLines.RemoveAt(0);
      NGUIDebug.mLines.Add(text);
      NGUIDebug.CreateInstance();
    }
    else
      Debug.Log((object) text);
  }

  public static void Log(params object[] objs)
  {
    string text = string.Empty;
    for (int index = 0; index < objs.Length; ++index)
      text = index != 0 ? text + ", " + objs[index].ToString() : text + objs[index].ToString();
    NGUIDebug.LogString(text);
  }

  public static void DrawBounds(Bounds b)
  {
    Vector3 center = ((Bounds) ref b).center;
    Vector3 vector3_1 = Vector3.op_Subtraction(((Bounds) ref b).center, ((Bounds) ref b).extents);
    Vector3 vector3_2 = Vector3.op_Addition(((Bounds) ref b).center, ((Bounds) ref b).extents);
    Debug.DrawLine(new Vector3(vector3_1.x, vector3_1.y, center.z), new Vector3(vector3_2.x, vector3_1.y, center.z), Color.red);
    Debug.DrawLine(new Vector3(vector3_1.x, vector3_1.y, center.z), new Vector3(vector3_1.x, vector3_2.y, center.z), Color.red);
    Debug.DrawLine(new Vector3(vector3_2.x, vector3_1.y, center.z), new Vector3(vector3_2.x, vector3_2.y, center.z), Color.red);
    Debug.DrawLine(new Vector3(vector3_1.x, vector3_2.y, center.z), new Vector3(vector3_2.x, vector3_2.y, center.z), Color.red);
  }

  private void OnGUI()
  {
    if (NGUIDebug.mLines.Count == 0)
    {
      if (!NGUIDebug.mRayDebug || !Object.op_Inequality((Object) UICamera.hoveredObject, (Object) null) || !Application.isPlaying)
        return;
      GUILayout.Label("Last Hit: " + NGUITools.GetHierarchy(UICamera.hoveredObject).Replace("\"", string.Empty), new GUILayoutOption[0]);
    }
    else
    {
      int index = 0;
      for (int count = NGUIDebug.mLines.Count; index < count; ++index)
        GUILayout.Label(NGUIDebug.mLines[index], new GUILayoutOption[0]);
    }
  }
}
