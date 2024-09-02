// Decompiled with JetBrains decompiler
// Type: iTween
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class iTween : MonoBehaviour
{
  public static List<Hashtable> tweens = new List<Hashtable>();
  private static GameObject cameraFade;
  public string id;
  public string type;
  public string method;
  public iTween.EaseType easeType;
  public float time;
  public float delay;
  public iTween.LoopType loopType;
  public bool isRunning;
  public bool isPaused;
  public string _name;
  private float runningTime;
  private float percentage;
  private float delayStarted;
  private bool kinematic;
  private bool isLocal;
  private bool loop;
  private bool reverse;
  private bool wasPaused;
  private bool physics;
  private Hashtable tweenArguments;
  private Space space;
  private iTween.EasingFunction ease;
  private iTween.ApplyTween apply;
  private AudioSource audioSource;
  private Vector3[] vector3s;
  private Vector2[] vector2s;
  private Color[,] colors;
  private float[] floats;
  private Rect[] rects;
  private iTween.CRSpline path;
  private Vector3 preUpdate;
  private Vector3 postUpdate;
  private iTween.NamedValueColor namedcolorvalue;
  private float lastRealTime;
  private bool useRealTime;
  private Transform thisTransform;

  private iTween(Hashtable h) => this.tweenArguments = h;

  public void SetPhysics(bool flag) => this.physics = flag;

  public static void Init(GameObject target) => iTween.MoveBy(target, Vector3.zero, 0.0f);

  public static void CameraFadeFrom(float amount, float time)
  {
    if (Object.op_Implicit((Object) iTween.cameraFade))
      iTween.CameraFadeFrom(iTween.Hash((object) nameof (amount), (object) amount, (object) nameof (time), (object) time));
    else
      Debug.LogError((object) "iTween Error: You must first add a camera fade object with CameraFadeAdd() before atttempting to use camera fading.");
  }

  public static void CameraFadeFrom(Hashtable args)
  {
    if (Object.op_Implicit((Object) iTween.cameraFade))
      iTween.ColorFrom(iTween.cameraFade, args);
    else
      Debug.LogError((object) "iTween Error: You must first add a camera fade object with CameraFadeAdd() before atttempting to use camera fading.");
  }

  public static void CameraFadeTo(float amount, float time)
  {
    if (Object.op_Implicit((Object) iTween.cameraFade))
      iTween.CameraFadeTo(iTween.Hash((object) nameof (amount), (object) amount, (object) nameof (time), (object) time));
    else
      Debug.LogError((object) "iTween Error: You must first add a camera fade object with CameraFadeAdd() before atttempting to use camera fading.");
  }

  public static void CameraFadeTo(Hashtable args)
  {
    if (Object.op_Implicit((Object) iTween.cameraFade))
      iTween.ColorTo(iTween.cameraFade, args);
    else
      Debug.LogError((object) "iTween Error: You must first add a camera fade object with CameraFadeAdd() before atttempting to use camera fading.");
  }

  public static void ValueTo(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    if (!args.Contains((object) "onupdate") || !args.Contains((object) "from") || !args.Contains((object) "to"))
    {
      Debug.LogError((object) "iTween Error: ValueTo() requires an 'onupdate' callback function and a 'from' and 'to' property.  The supplied 'onupdate' callback must accept a single argument that is the same type as the supplied 'from' and 'to' properties!");
    }
    else
    {
      args[(object) "type"] = (object) "value";
      if ((object) args[(object) "from"].GetType() == (object) typeof (Vector2))
        args[(object) "method"] = (object) "vector2";
      else if ((object) args[(object) "from"].GetType() == (object) typeof (Vector3))
        args[(object) "method"] = (object) "vector3";
      else if ((object) args[(object) "from"].GetType() == (object) typeof (Rect))
        args[(object) "method"] = (object) "rect";
      else if ((object) args[(object) "from"].GetType() == (object) typeof (float))
        args[(object) "method"] = (object) "float";
      else if ((object) args[(object) "from"].GetType() == (object) typeof (Color))
      {
        args[(object) "method"] = (object) "color";
      }
      else
      {
        Debug.LogError((object) "iTween Error: ValueTo() only works with interpolating Vector3s, Vector2s, floats, ints, Rects and Colors!");
        return;
      }
      if (!args.Contains((object) "easetype"))
        args.Add((object) "easetype", (object) iTween.EaseType.linear);
      iTween.Launch(target, args);
    }
  }

  public static void FadeFrom(GameObject target, float alpha, float time)
  {
    iTween.FadeFrom(target, iTween.Hash((object) nameof (alpha), (object) alpha, (object) nameof (time), (object) time));
  }

  public static void FadeFrom(GameObject target, Hashtable args) => iTween.ColorFrom(target, args);

  public static void FadeTo(GameObject target, float alpha, float time)
  {
    iTween.FadeTo(target, iTween.Hash((object) nameof (alpha), (object) alpha, (object) nameof (time), (object) time));
  }

  public static void FadeTo(GameObject target, Hashtable args) => iTween.ColorTo(target, args);

  public static void ColorFrom(GameObject target, Color color, float time)
  {
    iTween.ColorFrom(target, iTween.Hash((object) nameof (color), (object) color, (object) nameof (time), (object) time));
  }

  public static void ColorFrom(GameObject target, Hashtable args)
  {
    Color color1 = new Color();
    Color color2 = new Color();
    args = iTween.CleanArgs(args);
    if (!args.Contains((object) "includechildren") || (bool) args[(object) "includechildren"])
    {
      foreach (Transform transform in target.transform)
      {
        Hashtable args1 = (Hashtable) args.Clone();
        args1[(object) "ischild"] = (object) true;
        iTween.ColorFrom(((Component) transform).gameObject, args1);
      }
    }
    if (!args.Contains((object) "easetype"))
      args.Add((object) "easetype", (object) iTween.EaseType.linear);
    if (Object.op_Implicit((Object) target.GetComponent<GUITexture>()))
      color2 = color1 = target.GetComponent<GUITexture>().color;
    else if (Object.op_Implicit((Object) target.GetComponent<GUIText>()))
      color2 = color1 = target.GetComponent<GUIText>().material.color;
    else if (Object.op_Implicit((Object) target.GetComponent<Renderer>()))
      color2 = color1 = target.GetComponent<Renderer>().material.color;
    else if (Object.op_Implicit((Object) target.GetComponent<Light>()))
      color2 = color1 = target.GetComponent<Light>().color;
    if (args.Contains((object) "color"))
    {
      color1 = (Color) args[(object) "color"];
    }
    else
    {
      if (args.Contains((object) "r"))
        color1.r = (float) args[(object) "r"];
      if (args.Contains((object) "g"))
        color1.g = (float) args[(object) "g"];
      if (args.Contains((object) "b"))
        color1.b = (float) args[(object) "b"];
      if (args.Contains((object) "a"))
        color1.a = (float) args[(object) "a"];
    }
    if (args.Contains((object) "amount"))
    {
      color1.a = (float) args[(object) "amount"];
      args.Remove((object) "amount");
    }
    else if (args.Contains((object) "alpha"))
    {
      color1.a = (float) args[(object) "alpha"];
      args.Remove((object) "alpha");
    }
    if (Object.op_Implicit((Object) target.GetComponent<GUITexture>()))
      target.GetComponent<GUITexture>().color = color1;
    else if (Object.op_Implicit((Object) target.GetComponent<GUIText>()))
      target.GetComponent<GUIText>().material.color = color1;
    else if (Object.op_Implicit((Object) target.GetComponent<Renderer>()))
      target.GetComponent<Renderer>().material.color = color1;
    else if (Object.op_Implicit((Object) target.GetComponent<Light>()))
      target.GetComponent<Light>().color = color1;
    args[(object) "color"] = (object) color2;
    args[(object) "type"] = (object) "color";
    args[(object) "method"] = (object) "to";
    iTween.Launch(target, args);
  }

  public static void ColorTo(GameObject target, Color color, float time)
  {
    iTween.ColorTo(target, iTween.Hash((object) nameof (color), (object) color, (object) nameof (time), (object) time));
  }

  public static void ColorTo(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    if (!args.Contains((object) "includechildren") || (bool) args[(object) "includechildren"])
    {
      foreach (Transform transform in target.transform)
      {
        Hashtable args1 = (Hashtable) args.Clone();
        args1[(object) "ischild"] = (object) true;
        iTween.ColorTo(((Component) transform).gameObject, args1);
      }
    }
    if (!args.Contains((object) "easetype"))
      args.Add((object) "easetype", (object) iTween.EaseType.linear);
    args[(object) "type"] = (object) "color";
    args[(object) "method"] = (object) "to";
    iTween.Launch(target, args);
  }

  public static void AudioFrom(GameObject target, float volume, float pitch, float time)
  {
    iTween.AudioFrom(target, iTween.Hash((object) nameof (volume), (object) volume, (object) nameof (pitch), (object) pitch, (object) nameof (time), (object) time));
  }

  public static void AudioFrom(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    AudioSource component;
    if (args.Contains((object) "audiosource"))
      component = (AudioSource) args[(object) "audiosource"];
    else if (Object.op_Implicit((Object) target.GetComponent<AudioSource>()))
    {
      component = target.GetComponent<AudioSource>();
    }
    else
    {
      Debug.LogError((object) "iTween Error: AudioFrom requires an AudioSource.");
      return;
    }
    Vector2 vector2_1;
    Vector2 vector2_2;
    vector2_1.x = vector2_2.x = component.volume;
    vector2_1.y = vector2_2.y = component.pitch;
    if (args.Contains((object) "volume"))
      vector2_2.x = (float) args[(object) "volume"];
    if (args.Contains((object) "pitch"))
      vector2_2.y = (float) args[(object) "pitch"];
    component.volume = vector2_2.x;
    component.pitch = vector2_2.y;
    args[(object) "volume"] = (object) vector2_1.x;
    args[(object) "pitch"] = (object) vector2_1.y;
    if (!args.Contains((object) "easetype"))
      args.Add((object) "easetype", (object) iTween.EaseType.linear);
    args[(object) "type"] = (object) "audio";
    args[(object) "method"] = (object) "to";
    iTween.Launch(target, args);
  }

  public static void AudioTo(GameObject target, float volume, float pitch, float time)
  {
    iTween.AudioTo(target, iTween.Hash((object) nameof (volume), (object) volume, (object) nameof (pitch), (object) pitch, (object) nameof (time), (object) time));
  }

  public static void AudioTo(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    if (!args.Contains((object) "easetype"))
      args.Add((object) "easetype", (object) iTween.EaseType.linear);
    args[(object) "type"] = (object) "audio";
    args[(object) "method"] = (object) "to";
    iTween.Launch(target, args);
  }

  public static void Stab(GameObject target, AudioClip audioclip, float delay)
  {
    iTween.Stab(target, iTween.Hash((object) nameof (audioclip), (object) audioclip, (object) nameof (delay), (object) delay));
  }

  public static void Stab(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    args[(object) "type"] = (object) "stab";
    iTween.Launch(target, args);
  }

  public static void LookFrom(GameObject target, Vector3 looktarget, float time)
  {
    iTween.LookFrom(target, iTween.Hash((object) nameof (looktarget), (object) looktarget, (object) nameof (time), (object) time));
  }

  public static void LookFrom(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    Vector3 eulerAngles1 = target.transform.eulerAngles;
    if ((object) args[(object) "looktarget"].GetType() == (object) typeof (Transform))
    {
      Transform transform1 = target.transform;
      Transform transform2 = (Transform) args[(object) "looktarget"];
      Vector3? nullable = (Vector3?) args[(object) "up"];
      Vector3 vector3 = !nullable.HasValue ? iTween.Defaults.up : nullable.Value;
      transform1.LookAt(transform2, vector3);
    }
    else if ((object) args[(object) "looktarget"].GetType() == (object) typeof (Vector3))
    {
      Transform transform = target.transform;
      Vector3 vector3_1 = (Vector3) args[(object) "looktarget"];
      Vector3? nullable = (Vector3?) args[(object) "up"];
      Vector3 vector3_2 = !nullable.HasValue ? iTween.Defaults.up : nullable.Value;
      transform.LookAt(vector3_1, vector3_2);
    }
    if (args.Contains((object) "axis"))
    {
      Vector3 eulerAngles2 = target.transform.eulerAngles;
      string key = (string) args[(object) "axis"];
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (iTween.\u003C\u003Ef__switch\u0024map0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          iTween.\u003C\u003Ef__switch\u0024map0 = new Dictionary<string, int>(3)
          {
            {
              "x",
              0
            },
            {
              "y",
              1
            },
            {
              "z",
              2
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (iTween.\u003C\u003Ef__switch\u0024map0.TryGetValue(key, out num))
        {
          switch (num)
          {
            case 0:
              eulerAngles2.y = eulerAngles1.y;
              eulerAngles2.z = eulerAngles1.z;
              break;
            case 1:
              eulerAngles2.x = eulerAngles1.x;
              eulerAngles2.z = eulerAngles1.z;
              break;
            case 2:
              eulerAngles2.x = eulerAngles1.x;
              eulerAngles2.y = eulerAngles1.y;
              break;
          }
        }
      }
      target.transform.eulerAngles = eulerAngles2;
    }
    args[(object) "rotation"] = (object) eulerAngles1;
    args[(object) "type"] = (object) "rotate";
    args[(object) "method"] = (object) "to";
    iTween.Launch(target, args);
  }

  public static void LookTo(GameObject target, Vector3 looktarget, float time)
  {
    iTween.LookTo(target, iTween.Hash((object) nameof (looktarget), (object) looktarget, (object) nameof (time), (object) time));
  }

  public static void LookTo(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    if (args.Contains((object) "looktarget") && (object) args[(object) "looktarget"].GetType() == (object) typeof (Transform))
    {
      Transform transform = (Transform) args[(object) "looktarget"];
      args[(object) "position"] = (object) new Vector3(transform.position.x, transform.position.y, transform.position.z);
      args[(object) "rotation"] = (object) new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
    }
    args[(object) "type"] = (object) "look";
    args[(object) "method"] = (object) "to";
    iTween.Launch(target, args);
  }

  public static void MoveTo(GameObject target, Vector3 position, float time)
  {
    iTween.MoveTo(target, iTween.Hash((object) nameof (position), (object) position, (object) nameof (time), (object) time));
  }

  public static void MoveTo(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    if (args.Contains((object) "position") && (object) args[(object) "position"].GetType() == (object) typeof (Transform))
    {
      Transform transform = (Transform) args[(object) "position"];
      args[(object) "position"] = (object) new Vector3(transform.position.x, transform.position.y, transform.position.z);
      args[(object) "rotation"] = (object) new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
      args[(object) "scale"] = (object) new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    args[(object) "type"] = (object) "move";
    args[(object) "method"] = (object) "to";
    iTween.Launch(target, args);
  }

  public static void MoveFrom(GameObject target, Vector3 position, float time)
  {
    iTween.MoveFrom(target, iTween.Hash((object) nameof (position), (object) position, (object) nameof (time), (object) time));
  }

  public static void MoveFrom(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    bool flag = !args.Contains((object) "islocal") ? iTween.Defaults.isLocal : (bool) args[(object) "islocal"];
    if (args.Contains((object) "path"))
    {
      Vector3[] vector3Array;
      if ((object) args[(object) "path"].GetType() == (object) typeof (Vector3[]))
      {
        Vector3[] sourceArray = (Vector3[]) args[(object) "path"];
        vector3Array = new Vector3[sourceArray.Length];
        Array.Copy((Array) sourceArray, (Array) vector3Array, sourceArray.Length);
      }
      else
      {
        Transform[] transformArray = (Transform[]) args[(object) "path"];
        vector3Array = new Vector3[transformArray.Length];
        for (int index = 0; index < transformArray.Length; ++index)
          vector3Array[index] = transformArray[index].position;
      }
      if (Vector3.op_Inequality(vector3Array[vector3Array.Length - 1], target.transform.position))
      {
        Vector3[] destinationArray = new Vector3[vector3Array.Length + 1];
        Array.Copy((Array) vector3Array, (Array) destinationArray, vector3Array.Length);
        if (flag)
        {
          destinationArray[destinationArray.Length - 1] = target.transform.localPosition;
          target.transform.localPosition = destinationArray[0];
        }
        else
        {
          destinationArray[destinationArray.Length - 1] = target.transform.position;
          target.transform.position = destinationArray[0];
        }
        args[(object) "path"] = (object) destinationArray;
      }
      else
      {
        if (flag)
          target.transform.localPosition = vector3Array[0];
        else
          target.transform.position = vector3Array[0];
        args[(object) "path"] = (object) vector3Array;
      }
    }
    else
    {
      Vector3 vector3_1;
      Vector3 vector3_2 = !flag ? (vector3_1 = target.transform.position) : (vector3_1 = target.transform.localPosition);
      if (args.Contains((object) "position"))
      {
        if ((object) args[(object) "position"].GetType() == (object) typeof (Transform))
          vector3_1 = ((Transform) args[(object) "position"]).position;
        else if ((object) args[(object) "position"].GetType() == (object) typeof (Vector3))
          vector3_1 = (Vector3) args[(object) "position"];
      }
      else
      {
        if (args.Contains((object) "x"))
          vector3_1.x = (float) args[(object) "x"];
        if (args.Contains((object) "y"))
          vector3_1.y = (float) args[(object) "y"];
        if (args.Contains((object) "z"))
          vector3_1.z = (float) args[(object) "z"];
      }
      if (flag)
        target.transform.localPosition = vector3_1;
      else
        target.transform.position = vector3_1;
      args[(object) "position"] = (object) vector3_2;
    }
    args[(object) "type"] = (object) "move";
    args[(object) "method"] = (object) "to";
    iTween.Launch(target, args);
  }

  public static void MoveAdd(GameObject target, Vector3 amount, float time)
  {
    iTween.MoveAdd(target, iTween.Hash((object) nameof (amount), (object) amount, (object) nameof (time), (object) time));
  }

  public static void MoveAdd(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    args[(object) "type"] = (object) "move";
    args[(object) "method"] = (object) "add";
    iTween.Launch(target, args);
  }

  public static void MoveBy(GameObject target, Vector3 amount, float time)
  {
    iTween.MoveBy(target, iTween.Hash((object) nameof (amount), (object) amount, (object) nameof (time), (object) time));
  }

  public static void MoveBy(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    args[(object) "type"] = (object) "move";
    args[(object) "method"] = (object) "by";
    iTween.Launch(target, args);
  }

  public static void ScaleTo(GameObject target, Vector3 scale, float time)
  {
    iTween.ScaleTo(target, iTween.Hash((object) nameof (scale), (object) scale, (object) nameof (time), (object) time));
  }

  public static void ScaleTo(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    if (args.Contains((object) "scale") && (object) args[(object) "scale"].GetType() == (object) typeof (Transform))
    {
      Transform transform = (Transform) args[(object) "scale"];
      args[(object) "position"] = (object) new Vector3(transform.position.x, transform.position.y, transform.position.z);
      args[(object) "rotation"] = (object) new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
      args[(object) "scale"] = (object) new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    args[(object) "type"] = (object) "scale";
    args[(object) "method"] = (object) "to";
    iTween.Launch(target, args);
  }

  public static void ScaleFrom(GameObject target, Vector3 scale, float time)
  {
    iTween.ScaleFrom(target, iTween.Hash((object) nameof (scale), (object) scale, (object) nameof (time), (object) time));
  }

  public static void ScaleFrom(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    Vector3 localScale;
    Vector3 vector3 = localScale = target.transform.localScale;
    if (args.Contains((object) "scale"))
    {
      if ((object) args[(object) "scale"].GetType() == (object) typeof (Transform))
        localScale = ((Transform) args[(object) "scale"]).localScale;
      else if ((object) args[(object) "scale"].GetType() == (object) typeof (Vector3))
        localScale = (Vector3) args[(object) "scale"];
    }
    else
    {
      if (args.Contains((object) "x"))
        localScale.x = (float) args[(object) "x"];
      if (args.Contains((object) "y"))
        localScale.y = (float) args[(object) "y"];
      if (args.Contains((object) "z"))
        localScale.z = (float) args[(object) "z"];
    }
    target.transform.localScale = localScale;
    args[(object) "scale"] = (object) vector3;
    args[(object) "type"] = (object) "scale";
    args[(object) "method"] = (object) "to";
    iTween.Launch(target, args);
  }

  public static void ScaleAdd(GameObject target, Vector3 amount, float time)
  {
    iTween.ScaleAdd(target, iTween.Hash((object) nameof (amount), (object) amount, (object) nameof (time), (object) time));
  }

  public static void ScaleAdd(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    args[(object) "type"] = (object) "scale";
    args[(object) "method"] = (object) "add";
    iTween.Launch(target, args);
  }

  public static void ScaleBy(GameObject target, Vector3 amount, float time)
  {
    iTween.ScaleBy(target, iTween.Hash((object) nameof (amount), (object) amount, (object) nameof (time), (object) time));
  }

  public static void ScaleBy(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    args[(object) "type"] = (object) "scale";
    args[(object) "method"] = (object) "by";
    iTween.Launch(target, args);
  }

  public static void RotateTo(GameObject target, Vector3 rotation, float time)
  {
    iTween.RotateTo(target, iTween.Hash((object) nameof (rotation), (object) rotation, (object) nameof (time), (object) time));
  }

  public static void RotateTo(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    if (args.Contains((object) "rotation") && (object) args[(object) "rotation"].GetType() == (object) typeof (Transform))
    {
      Transform transform = (Transform) args[(object) "rotation"];
      args[(object) "position"] = (object) new Vector3(transform.position.x, transform.position.y, transform.position.z);
      args[(object) "rotation"] = (object) new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
      args[(object) "scale"] = (object) new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    args[(object) "type"] = (object) "rotate";
    args[(object) "method"] = (object) "to";
    iTween.Launch(target, args);
  }

  public static void RotateFrom(GameObject target, Vector3 rotation, float time)
  {
    iTween.RotateFrom(target, iTween.Hash((object) nameof (rotation), (object) rotation, (object) nameof (time), (object) time));
  }

  public static void RotateFrom(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    bool flag = !args.Contains((object) "islocal") ? iTween.Defaults.isLocal : (bool) args[(object) "islocal"];
    Vector3 vector3_1;
    Vector3 vector3_2 = !flag ? (vector3_1 = target.transform.eulerAngles) : (vector3_1 = target.transform.localEulerAngles);
    if (args.Contains((object) "rotation"))
    {
      if ((object) args[(object) "rotation"].GetType() == (object) typeof (Transform))
        vector3_1 = ((Transform) args[(object) "rotation"]).eulerAngles;
      else if ((object) args[(object) "rotation"].GetType() == (object) typeof (Vector3))
        vector3_1 = (Vector3) args[(object) "rotation"];
    }
    else
    {
      if (args.Contains((object) "x"))
        vector3_1.x = (float) args[(object) "x"];
      if (args.Contains((object) "y"))
        vector3_1.y = (float) args[(object) "y"];
      if (args.Contains((object) "z"))
        vector3_1.z = (float) args[(object) "z"];
    }
    if (flag)
      target.transform.localEulerAngles = vector3_1;
    else
      target.transform.eulerAngles = vector3_1;
    args[(object) "rotation"] = (object) vector3_2;
    args[(object) "type"] = (object) "rotate";
    args[(object) "method"] = (object) "to";
    iTween.Launch(target, args);
  }

  public static void RotateAdd(GameObject target, Vector3 amount, float time)
  {
    iTween.RotateAdd(target, iTween.Hash((object) nameof (amount), (object) amount, (object) nameof (time), (object) time));
  }

  public static void RotateAdd(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    args[(object) "type"] = (object) "rotate";
    args[(object) "method"] = (object) "add";
    iTween.Launch(target, args);
  }

  public static void RotateBy(GameObject target, Vector3 amount, float time)
  {
    iTween.RotateBy(target, iTween.Hash((object) nameof (amount), (object) amount, (object) nameof (time), (object) time));
  }

  public static void RotateBy(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    args[(object) "type"] = (object) "rotate";
    args[(object) "method"] = (object) "by";
    iTween.Launch(target, args);
  }

  public static void ShakePosition(GameObject target, Vector3 amount, float time)
  {
    iTween.ShakePosition(target, iTween.Hash((object) nameof (amount), (object) amount, (object) nameof (time), (object) time));
  }

  public static void ShakePosition(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    args[(object) "type"] = (object) "shake";
    args[(object) "method"] = (object) "position";
    iTween.Launch(target, args);
  }

  public static void ShakeScale(GameObject target, Vector3 amount, float time)
  {
    iTween.ShakeScale(target, iTween.Hash((object) nameof (amount), (object) amount, (object) nameof (time), (object) time));
  }

  public static void ShakeScale(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    args[(object) "type"] = (object) "shake";
    args[(object) "method"] = (object) "scale";
    iTween.Launch(target, args);
  }

  public static void ShakeRotation(GameObject target, Vector3 amount, float time)
  {
    iTween.ShakeRotation(target, iTween.Hash((object) nameof (amount), (object) amount, (object) nameof (time), (object) time));
  }

  public static void ShakeRotation(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    args[(object) "type"] = (object) "shake";
    args[(object) "method"] = (object) "rotation";
    iTween.Launch(target, args);
  }

  public static void PunchPosition(GameObject target, Vector3 amount, float time)
  {
    iTween.PunchPosition(target, iTween.Hash((object) nameof (amount), (object) amount, (object) nameof (time), (object) time));
  }

  public static void PunchPosition(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    args[(object) "type"] = (object) "punch";
    args[(object) "method"] = (object) "position";
    args[(object) "easetype"] = (object) iTween.EaseType.punch;
    iTween.Launch(target, args);
  }

  public static void PunchRotation(GameObject target, Vector3 amount, float time)
  {
    iTween.PunchRotation(target, iTween.Hash((object) nameof (amount), (object) amount, (object) nameof (time), (object) time));
  }

  public static void PunchRotation(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    args[(object) "type"] = (object) "punch";
    args[(object) "method"] = (object) "rotation";
    args[(object) "easetype"] = (object) iTween.EaseType.punch;
    iTween.Launch(target, args);
  }

  public static void PunchScale(GameObject target, Vector3 amount, float time)
  {
    iTween.PunchScale(target, iTween.Hash((object) nameof (amount), (object) amount, (object) nameof (time), (object) time));
  }

  public static void PunchScale(GameObject target, Hashtable args)
  {
    args = iTween.CleanArgs(args);
    args[(object) "type"] = (object) "punch";
    args[(object) "method"] = (object) "scale";
    args[(object) "easetype"] = (object) iTween.EaseType.punch;
    iTween.Launch(target, args);
  }

  private void GenerateTargets()
  {
    string type = this.type;
    if (type == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (iTween.\u003C\u003Ef__switch\u0024mapA == null)
    {
      // ISSUE: reference to a compiler-generated field
      iTween.\u003C\u003Ef__switch\u0024mapA = new Dictionary<string, int>(10)
      {
        {
          "value",
          0
        },
        {
          "color",
          1
        },
        {
          "audio",
          2
        },
        {
          "move",
          3
        },
        {
          "scale",
          4
        },
        {
          "rotate",
          5
        },
        {
          "shake",
          6
        },
        {
          "punch",
          7
        },
        {
          "look",
          8
        },
        {
          "stab",
          9
        }
      };
    }
    int num1;
    // ISSUE: reference to a compiler-generated field
    if (!iTween.\u003C\u003Ef__switch\u0024mapA.TryGetValue(type, out num1))
      return;
    switch (num1)
    {
      case 0:
        string method1 = this.method;
        if (method1 == null)
          break;
        // ISSUE: reference to a compiler-generated field
        if (iTween.\u003C\u003Ef__switch\u0024map1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          iTween.\u003C\u003Ef__switch\u0024map1 = new Dictionary<string, int>(5)
          {
            {
              "float",
              0
            },
            {
              "vector2",
              1
            },
            {
              "vector3",
              2
            },
            {
              "color",
              3
            },
            {
              "rect",
              4
            }
          };
        }
        int num2;
        // ISSUE: reference to a compiler-generated field
        if (!iTween.\u003C\u003Ef__switch\u0024map1.TryGetValue(method1, out num2))
          break;
        switch (num2)
        {
          case 0:
            this.GenerateFloatTargets();
            this.apply = new iTween.ApplyTween(this.ApplyFloatTargets);
            return;
          case 1:
            this.GenerateVector2Targets();
            this.apply = new iTween.ApplyTween(this.ApplyVector2Targets);
            return;
          case 2:
            this.GenerateVector3Targets();
            this.apply = new iTween.ApplyTween(this.ApplyVector3Targets);
            return;
          case 3:
            this.GenerateColorTargets();
            this.apply = new iTween.ApplyTween(this.ApplyColorTargets);
            return;
          case 4:
            this.GenerateRectTargets();
            this.apply = new iTween.ApplyTween(this.ApplyRectTargets);
            return;
          default:
            return;
        }
      case 1:
        string method2 = this.method;
        if (method2 == null)
          break;
        // ISSUE: reference to a compiler-generated field
        if (iTween.\u003C\u003Ef__switch\u0024map2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          iTween.\u003C\u003Ef__switch\u0024map2 = new Dictionary<string, int>(1)
          {
            {
              "to",
              0
            }
          };
        }
        int num3;
        // ISSUE: reference to a compiler-generated field
        if (!iTween.\u003C\u003Ef__switch\u0024map2.TryGetValue(method2, out num3) || num3 != 0)
          break;
        this.GenerateColorToTargets();
        this.apply = new iTween.ApplyTween(this.ApplyColorToTargets);
        break;
      case 2:
        string method3 = this.method;
        if (method3 == null)
          break;
        // ISSUE: reference to a compiler-generated field
        if (iTween.\u003C\u003Ef__switch\u0024map3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          iTween.\u003C\u003Ef__switch\u0024map3 = new Dictionary<string, int>(1)
          {
            {
              "to",
              0
            }
          };
        }
        int num4;
        // ISSUE: reference to a compiler-generated field
        if (!iTween.\u003C\u003Ef__switch\u0024map3.TryGetValue(method3, out num4) || num4 != 0)
          break;
        this.GenerateAudioToTargets();
        this.apply = new iTween.ApplyTween(this.ApplyAudioToTargets);
        break;
      case 3:
        string method4 = this.method;
        if (method4 == null)
          break;
        // ISSUE: reference to a compiler-generated field
        if (iTween.\u003C\u003Ef__switch\u0024map4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          iTween.\u003C\u003Ef__switch\u0024map4 = new Dictionary<string, int>(3)
          {
            {
              "to",
              0
            },
            {
              "by",
              1
            },
            {
              "add",
              1
            }
          };
        }
        int num5;
        // ISSUE: reference to a compiler-generated field
        if (!iTween.\u003C\u003Ef__switch\u0024map4.TryGetValue(method4, out num5))
          break;
        switch (num5)
        {
          case 0:
            if (this.tweenArguments.Contains((object) "path"))
            {
              this.GenerateMoveToPathTargets();
              this.apply = new iTween.ApplyTween(this.ApplyMoveToPathTargets);
              return;
            }
            this.GenerateMoveToTargets();
            this.apply = new iTween.ApplyTween(this.ApplyMoveToTargets);
            return;
          case 1:
            this.GenerateMoveByTargets();
            this.apply = new iTween.ApplyTween(this.ApplyMoveByTargets);
            return;
          default:
            return;
        }
      case 4:
        string method5 = this.method;
        if (method5 == null)
          break;
        // ISSUE: reference to a compiler-generated field
        if (iTween.\u003C\u003Ef__switch\u0024map5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          iTween.\u003C\u003Ef__switch\u0024map5 = new Dictionary<string, int>(3)
          {
            {
              "to",
              0
            },
            {
              "by",
              1
            },
            {
              "add",
              2
            }
          };
        }
        int num6;
        // ISSUE: reference to a compiler-generated field
        if (!iTween.\u003C\u003Ef__switch\u0024map5.TryGetValue(method5, out num6))
          break;
        switch (num6)
        {
          case 0:
            this.GenerateScaleToTargets();
            this.apply = new iTween.ApplyTween(this.ApplyScaleToTargets);
            return;
          case 1:
            this.GenerateScaleByTargets();
            this.apply = new iTween.ApplyTween(this.ApplyScaleToTargets);
            return;
          case 2:
            this.GenerateScaleAddTargets();
            this.apply = new iTween.ApplyTween(this.ApplyScaleToTargets);
            return;
          default:
            return;
        }
      case 5:
        string method6 = this.method;
        if (method6 == null)
          break;
        // ISSUE: reference to a compiler-generated field
        if (iTween.\u003C\u003Ef__switch\u0024map6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          iTween.\u003C\u003Ef__switch\u0024map6 = new Dictionary<string, int>(3)
          {
            {
              "to",
              0
            },
            {
              "add",
              1
            },
            {
              "by",
              2
            }
          };
        }
        int num7;
        // ISSUE: reference to a compiler-generated field
        if (!iTween.\u003C\u003Ef__switch\u0024map6.TryGetValue(method6, out num7))
          break;
        switch (num7)
        {
          case 0:
            this.GenerateRotateToTargets();
            this.apply = new iTween.ApplyTween(this.ApplyRotateToTargets);
            return;
          case 1:
            this.GenerateRotateAddTargets();
            this.apply = new iTween.ApplyTween(this.ApplyRotateAddTargets);
            return;
          case 2:
            this.GenerateRotateByTargets();
            this.apply = new iTween.ApplyTween(this.ApplyRotateAddTargets);
            return;
          default:
            return;
        }
      case 6:
        string method7 = this.method;
        if (method7 == null)
          break;
        // ISSUE: reference to a compiler-generated field
        if (iTween.\u003C\u003Ef__switch\u0024map7 == null)
        {
          // ISSUE: reference to a compiler-generated field
          iTween.\u003C\u003Ef__switch\u0024map7 = new Dictionary<string, int>(3)
          {
            {
              "position",
              0
            },
            {
              "scale",
              1
            },
            {
              "rotation",
              2
            }
          };
        }
        int num8;
        // ISSUE: reference to a compiler-generated field
        if (!iTween.\u003C\u003Ef__switch\u0024map7.TryGetValue(method7, out num8))
          break;
        switch (num8)
        {
          case 0:
            this.GenerateShakePositionTargets();
            this.apply = new iTween.ApplyTween(this.ApplyShakePositionTargets);
            return;
          case 1:
            this.GenerateShakeScaleTargets();
            this.apply = new iTween.ApplyTween(this.ApplyShakeScaleTargets);
            return;
          case 2:
            this.GenerateShakeRotationTargets();
            this.apply = new iTween.ApplyTween(this.ApplyShakeRotationTargets);
            return;
          default:
            return;
        }
      case 7:
        string method8 = this.method;
        if (method8 == null)
          break;
        // ISSUE: reference to a compiler-generated field
        if (iTween.\u003C\u003Ef__switch\u0024map8 == null)
        {
          // ISSUE: reference to a compiler-generated field
          iTween.\u003C\u003Ef__switch\u0024map8 = new Dictionary<string, int>(3)
          {
            {
              "position",
              0
            },
            {
              "rotation",
              1
            },
            {
              "scale",
              2
            }
          };
        }
        int num9;
        // ISSUE: reference to a compiler-generated field
        if (!iTween.\u003C\u003Ef__switch\u0024map8.TryGetValue(method8, out num9))
          break;
        switch (num9)
        {
          case 0:
            this.GeneratePunchPositionTargets();
            this.apply = new iTween.ApplyTween(this.ApplyPunchPositionTargets);
            return;
          case 1:
            this.GeneratePunchRotationTargets();
            this.apply = new iTween.ApplyTween(this.ApplyPunchRotationTargets);
            return;
          case 2:
            this.GeneratePunchScaleTargets();
            this.apply = new iTween.ApplyTween(this.ApplyPunchScaleTargets);
            return;
          default:
            return;
        }
      case 8:
        string method9 = this.method;
        if (method9 == null)
          break;
        // ISSUE: reference to a compiler-generated field
        if (iTween.\u003C\u003Ef__switch\u0024map9 == null)
        {
          // ISSUE: reference to a compiler-generated field
          iTween.\u003C\u003Ef__switch\u0024map9 = new Dictionary<string, int>(1)
          {
            {
              "to",
              0
            }
          };
        }
        int num10;
        // ISSUE: reference to a compiler-generated field
        if (!iTween.\u003C\u003Ef__switch\u0024map9.TryGetValue(method9, out num10) || num10 != 0)
          break;
        this.GenerateLookToTargets();
        this.apply = new iTween.ApplyTween(this.ApplyLookToTargets);
        break;
      case 9:
        this.GenerateStabTargets();
        this.apply = new iTween.ApplyTween(this.ApplyStabTargets);
        break;
    }
  }

  private void GenerateRectTargets()
  {
    this.rects = new Rect[3];
    this.rects[0] = (Rect) this.tweenArguments[(object) "from"];
    this.rects[1] = (Rect) this.tweenArguments[(object) "to"];
  }

  private void GenerateColorTargets()
  {
    this.colors = new Color[1, 3];
    this.colors[0, 0] = (Color) this.tweenArguments[(object) "from"];
    this.colors[0, 1] = (Color) this.tweenArguments[(object) "to"];
  }

  private void GenerateVector3Targets()
  {
    this.vector3s = new Vector3[3];
    this.vector3s[0] = (Vector3) this.tweenArguments[(object) "from"];
    this.vector3s[1] = (Vector3) this.tweenArguments[(object) "to"];
    if (!this.tweenArguments.Contains((object) "speed"))
      return;
    this.time = Math.Abs(Vector3.Distance(this.vector3s[0], this.vector3s[1])) / (float) this.tweenArguments[(object) "speed"];
  }

  private void GenerateVector2Targets()
  {
    this.vector2s = new Vector2[3];
    this.vector2s[0] = (Vector2) this.tweenArguments[(object) "from"];
    this.vector2s[1] = (Vector2) this.tweenArguments[(object) "to"];
    if (!this.tweenArguments.Contains((object) "speed"))
      return;
    Vector3 vector3_1;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_1).\u002Ector(this.vector2s[0].x, this.vector2s[0].y, 0.0f);
    Vector3 vector3_2;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_2).\u002Ector(this.vector2s[1].x, this.vector2s[1].y, 0.0f);
    this.time = Math.Abs(Vector3.Distance(vector3_1, vector3_2)) / (float) this.tweenArguments[(object) "speed"];
  }

  private void GenerateFloatTargets()
  {
    this.floats = new float[3];
    this.floats[0] = (float) this.tweenArguments[(object) "from"];
    this.floats[1] = (float) this.tweenArguments[(object) "to"];
    if (!this.tweenArguments.Contains((object) "speed"))
      return;
    this.time = Math.Abs(this.floats[0] - this.floats[1]) / (float) this.tweenArguments[(object) "speed"];
  }

  private void GenerateColorToTargets()
  {
    if (Object.op_Implicit((Object) ((Component) this).GetComponent<GUITexture>()))
    {
      this.colors = new Color[1, 3];
      this.colors[0, 0] = this.colors[0, 1] = ((Component) this).GetComponent<GUITexture>().color;
    }
    else if (Object.op_Implicit((Object) ((Component) this).GetComponent<GUIText>()))
    {
      this.colors = new Color[1, 3];
      this.colors[0, 0] = this.colors[0, 1] = ((Component) this).GetComponent<GUIText>().material.color;
    }
    else if (Object.op_Implicit((Object) ((Component) this).GetComponent<Renderer>()))
    {
      this.colors = new Color[((Component) this).GetComponent<Renderer>().materials.Length, 3];
      for (int index = 0; index < ((Component) this).GetComponent<Renderer>().materials.Length; ++index)
      {
        this.colors[index, 0] = ((Component) this).GetComponent<Renderer>().materials[index].GetColor(this.namedcolorvalue.ToString());
        this.colors[index, 1] = ((Component) this).GetComponent<Renderer>().materials[index].GetColor(this.namedcolorvalue.ToString());
      }
    }
    else if (Object.op_Implicit((Object) ((Component) this).GetComponent<Light>()))
    {
      this.colors = new Color[1, 3];
      this.colors[0, 0] = this.colors[0, 1] = ((Component) this).GetComponent<Light>().color;
    }
    else
      this.colors = new Color[1, 3];
    if (this.tweenArguments.Contains((object) "color"))
    {
      for (int index = 0; index < this.colors.GetLength(0); ++index)
        this.colors[index, 1] = (Color) this.tweenArguments[(object) "color"];
    }
    else
    {
      if (this.tweenArguments.Contains((object) "r"))
      {
        for (int index = 0; index < this.colors.GetLength(0); ++index)
          this.colors[index, 1].r = (float) this.tweenArguments[(object) "r"];
      }
      if (this.tweenArguments.Contains((object) "g"))
      {
        for (int index = 0; index < this.colors.GetLength(0); ++index)
          this.colors[index, 1].g = (float) this.tweenArguments[(object) "g"];
      }
      if (this.tweenArguments.Contains((object) "b"))
      {
        for (int index = 0; index < this.colors.GetLength(0); ++index)
          this.colors[index, 1].b = (float) this.tweenArguments[(object) "b"];
      }
      if (this.tweenArguments.Contains((object) "a"))
      {
        for (int index = 0; index < this.colors.GetLength(0); ++index)
          this.colors[index, 1].a = (float) this.tweenArguments[(object) "a"];
      }
    }
    if (this.tweenArguments.Contains((object) "amount"))
    {
      for (int index = 0; index < this.colors.GetLength(0); ++index)
        this.colors[index, 1].a = (float) this.tweenArguments[(object) "amount"];
    }
    else
    {
      if (!this.tweenArguments.Contains((object) "alpha"))
        return;
      for (int index = 0; index < this.colors.GetLength(0); ++index)
        this.colors[index, 1].a = (float) this.tweenArguments[(object) "alpha"];
    }
  }

  private void GenerateAudioToTargets()
  {
    this.vector2s = new Vector2[3];
    if (this.tweenArguments.Contains((object) "audiosource"))
      this.audioSource = (AudioSource) this.tweenArguments[(object) "audiosource"];
    else if (Object.op_Implicit((Object) ((Component) this).GetComponent<AudioSource>()))
    {
      this.audioSource = ((Component) this).GetComponent<AudioSource>();
    }
    else
    {
      Debug.LogError((object) "iTween Error: AudioTo requires an AudioSource.");
      this.Dispose();
    }
    this.vector2s[0] = this.vector2s[1] = new Vector2(this.audioSource.volume, this.audioSource.pitch);
    if (this.tweenArguments.Contains((object) "volume"))
      this.vector2s[1].x = (float) this.tweenArguments[(object) "volume"];
    if (!this.tweenArguments.Contains((object) "pitch"))
      return;
    this.vector2s[1].y = (float) this.tweenArguments[(object) "pitch"];
  }

  private void GenerateStabTargets()
  {
    if (this.tweenArguments.Contains((object) "audiosource"))
      this.audioSource = (AudioSource) this.tweenArguments[(object) "audiosource"];
    else if (Object.op_Implicit((Object) ((Component) this).GetComponent<AudioSource>()))
    {
      this.audioSource = ((Component) this).GetComponent<AudioSource>();
    }
    else
    {
      ((Component) this).gameObject.AddComponent<AudioSource>();
      this.audioSource = ((Component) this).GetComponent<AudioSource>();
      this.audioSource.playOnAwake = false;
    }
    this.audioSource.clip = (AudioClip) this.tweenArguments[(object) "audioclip"];
    if (this.tweenArguments.Contains((object) "pitch"))
      this.audioSource.pitch = (float) this.tweenArguments[(object) "pitch"];
    if (this.tweenArguments.Contains((object) "volume"))
      this.audioSource.volume = (float) this.tweenArguments[(object) "volume"];
    this.time = this.audioSource.clip.length / this.audioSource.pitch;
  }

  private void GenerateLookToTargets()
  {
    this.vector3s = new Vector3[3];
    this.vector3s[0] = this.thisTransform.eulerAngles;
    if (this.tweenArguments.Contains((object) "looktarget"))
    {
      if ((object) this.tweenArguments[(object) "looktarget"].GetType() == (object) typeof (Transform))
      {
        Transform thisTransform = this.thisTransform;
        Transform tweenArgument1 = (Transform) this.tweenArguments[(object) "looktarget"];
        Vector3? tweenArgument2 = (Vector3?) this.tweenArguments[(object) "up"];
        Vector3 vector3 = !tweenArgument2.HasValue ? iTween.Defaults.up : tweenArgument2.Value;
        thisTransform.LookAt(tweenArgument1, vector3);
      }
      else if ((object) this.tweenArguments[(object) "looktarget"].GetType() == (object) typeof (Vector3))
      {
        Transform thisTransform = this.thisTransform;
        Vector3 tweenArgument3 = (Vector3) this.tweenArguments[(object) "looktarget"];
        Vector3? tweenArgument4 = (Vector3?) this.tweenArguments[(object) "up"];
        Vector3 vector3 = !tweenArgument4.HasValue ? iTween.Defaults.up : tweenArgument4.Value;
        thisTransform.LookAt(tweenArgument3, vector3);
      }
    }
    else
    {
      Debug.LogError((object) "iTween Error: LookTo needs a 'looktarget' property!");
      this.Dispose();
    }
    this.vector3s[1] = this.thisTransform.eulerAngles;
    this.thisTransform.eulerAngles = this.vector3s[0];
    if (this.tweenArguments.Contains((object) "axis"))
    {
      string tweenArgument = (string) this.tweenArguments[(object) "axis"];
      if (tweenArgument != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (iTween.\u003C\u003Ef__switch\u0024mapB == null)
        {
          // ISSUE: reference to a compiler-generated field
          iTween.\u003C\u003Ef__switch\u0024mapB = new Dictionary<string, int>(3)
          {
            {
              "x",
              0
            },
            {
              "y",
              1
            },
            {
              "z",
              2
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (iTween.\u003C\u003Ef__switch\u0024mapB.TryGetValue(tweenArgument, out num))
        {
          switch (num)
          {
            case 0:
              this.vector3s[1].y = this.vector3s[0].y;
              this.vector3s[1].z = this.vector3s[0].z;
              break;
            case 1:
              this.vector3s[1].x = this.vector3s[0].x;
              this.vector3s[1].z = this.vector3s[0].z;
              break;
            case 2:
              this.vector3s[1].x = this.vector3s[0].x;
              this.vector3s[1].y = this.vector3s[0].y;
              break;
          }
        }
      }
    }
    this.vector3s[1] = new Vector3(this.clerp(this.vector3s[0].x, this.vector3s[1].x, 1f), this.clerp(this.vector3s[0].y, this.vector3s[1].y, 1f), this.clerp(this.vector3s[0].z, this.vector3s[1].z, 1f));
    if (!this.tweenArguments.Contains((object) "speed"))
      return;
    this.time = Math.Abs(Vector3.Distance(this.vector3s[0], this.vector3s[1])) / (float) this.tweenArguments[(object) "speed"];
  }

  private void GenerateMoveToPathTargets()
  {
    Vector3[] vector3Array1;
    if ((object) this.tweenArguments[(object) "path"].GetType() == (object) typeof (Vector3[]))
    {
      Vector3[] tweenArgument = (Vector3[]) this.tweenArguments[(object) "path"];
      if (tweenArgument.Length == 1)
      {
        Debug.LogError((object) "iTween Error: Attempting a path movement with MoveTo requires an array of more than 1 entry!");
        this.Dispose();
      }
      vector3Array1 = new Vector3[tweenArgument.Length];
      Array.Copy((Array) tweenArgument, (Array) vector3Array1, tweenArgument.Length);
    }
    else
    {
      Transform[] tweenArgument = (Transform[]) this.tweenArguments[(object) "path"];
      if (tweenArgument.Length == 1)
      {
        Debug.LogError((object) "iTween Error: Attempting a path movement with MoveTo requires an array of more than 1 entry!");
        this.Dispose();
      }
      vector3Array1 = new Vector3[tweenArgument.Length];
      for (int index = 0; index < tweenArgument.Length; ++index)
        vector3Array1[index] = tweenArgument[index].position;
    }
    bool flag;
    int num;
    if (Vector3.op_Inequality(this.thisTransform.position, vector3Array1[0]))
    {
      if (!this.tweenArguments.Contains((object) "movetopath") || (bool) this.tweenArguments[(object) "movetopath"])
      {
        flag = true;
        num = 3;
      }
      else
      {
        flag = false;
        num = 2;
      }
    }
    else
    {
      flag = false;
      num = 2;
    }
    this.vector3s = new Vector3[vector3Array1.Length + num];
    int destinationIndex;
    if (flag)
    {
      this.vector3s[1] = this.thisTransform.position;
      destinationIndex = 2;
    }
    else
      destinationIndex = 1;
    Array.Copy((Array) vector3Array1, 0, (Array) this.vector3s, destinationIndex, vector3Array1.Length);
    this.vector3s[0] = Vector3.op_Addition(this.vector3s[1], Vector3.op_Subtraction(this.vector3s[1], this.vector3s[2]));
    this.vector3s[this.vector3s.Length - 1] = Vector3.op_Addition(this.vector3s[this.vector3s.Length - 2], Vector3.op_Subtraction(this.vector3s[this.vector3s.Length - 2], this.vector3s[this.vector3s.Length - 3]));
    if (Vector3.op_Equality(this.vector3s[1], this.vector3s[this.vector3s.Length - 2]))
    {
      Vector3[] vector3Array2 = new Vector3[this.vector3s.Length];
      Array.Copy((Array) this.vector3s, (Array) vector3Array2, this.vector3s.Length);
      vector3Array2[0] = vector3Array2[vector3Array2.Length - 3];
      vector3Array2[vector3Array2.Length - 1] = vector3Array2[2];
      this.vector3s = new Vector3[vector3Array2.Length];
      Array.Copy((Array) vector3Array2, (Array) this.vector3s, vector3Array2.Length);
    }
    this.path = new iTween.CRSpline(this.vector3s);
    if (!this.tweenArguments.Contains((object) "speed"))
      return;
    this.time = iTween.PathLength(this.vector3s) / (float) this.tweenArguments[(object) "speed"];
  }

  private void GenerateMoveToTargets()
  {
    this.vector3s = new Vector3[3];
    this.vector3s[0] = !this.isLocal ? (this.vector3s[1] = this.thisTransform.position) : (this.vector3s[1] = this.thisTransform.localPosition);
    if (this.tweenArguments.Contains((object) "position"))
    {
      if ((object) this.tweenArguments[(object) "position"].GetType() == (object) typeof (Transform))
        this.vector3s[1] = ((Transform) this.tweenArguments[(object) "position"]).position;
      else if ((object) this.tweenArguments[(object) "position"].GetType() == (object) typeof (Vector3))
        this.vector3s[1] = (Vector3) this.tweenArguments[(object) "position"];
    }
    else
    {
      if (this.tweenArguments.Contains((object) "x"))
        this.vector3s[1].x = (float) this.tweenArguments[(object) "x"];
      if (this.tweenArguments.Contains((object) "y"))
        this.vector3s[1].y = (float) this.tweenArguments[(object) "y"];
      if (this.tweenArguments.Contains((object) "z"))
        this.vector3s[1].z = (float) this.tweenArguments[(object) "z"];
    }
    if (this.tweenArguments.Contains((object) "orienttopath") && (bool) this.tweenArguments[(object) "orienttopath"])
      this.tweenArguments[(object) "looktarget"] = (object) this.vector3s[1];
    if (!this.tweenArguments.Contains((object) "speed"))
      return;
    this.time = Math.Abs(Vector3.Distance(this.vector3s[0], this.vector3s[1])) / (float) this.tweenArguments[(object) "speed"];
  }

  private void GenerateMoveByTargets()
  {
    this.vector3s = new Vector3[6];
    this.vector3s[4] = this.thisTransform.eulerAngles;
    this.vector3s[0] = this.vector3s[1] = this.vector3s[3] = this.thisTransform.position;
    if (this.tweenArguments.Contains((object) "amount"))
    {
      this.vector3s[1] = Vector3.op_Addition(this.vector3s[0], (Vector3) this.tweenArguments[(object) "amount"]);
    }
    else
    {
      if (this.tweenArguments.Contains((object) "x"))
        this.vector3s[1].x = this.vector3s[0].x + (float) this.tweenArguments[(object) "x"];
      if (this.tweenArguments.Contains((object) "y"))
        this.vector3s[1].y = this.vector3s[0].y + (float) this.tweenArguments[(object) "y"];
      if (this.tweenArguments.Contains((object) "z"))
        this.vector3s[1].z = this.vector3s[0].z + (float) this.tweenArguments[(object) "z"];
    }
    this.thisTransform.Translate(this.vector3s[1], this.space);
    this.vector3s[5] = this.thisTransform.position;
    this.thisTransform.position = this.vector3s[0];
    if (this.tweenArguments.Contains((object) "orienttopath") && (bool) this.tweenArguments[(object) "orienttopath"])
      this.tweenArguments[(object) "looktarget"] = (object) this.vector3s[1];
    if (!this.tweenArguments.Contains((object) "speed"))
      return;
    this.time = Math.Abs(Vector3.Distance(this.vector3s[0], this.vector3s[1])) / (float) this.tweenArguments[(object) "speed"];
  }

  private void GenerateScaleToTargets()
  {
    this.vector3s = new Vector3[3];
    this.vector3s[0] = this.vector3s[1] = this.thisTransform.localScale;
    if (this.tweenArguments.Contains((object) "scale"))
    {
      if ((object) this.tweenArguments[(object) "scale"].GetType() == (object) typeof (Transform))
        this.vector3s[1] = ((Transform) this.tweenArguments[(object) "scale"]).localScale;
      else if ((object) this.tweenArguments[(object) "scale"].GetType() == (object) typeof (Vector3))
        this.vector3s[1] = (Vector3) this.tweenArguments[(object) "scale"];
    }
    else
    {
      if (this.tweenArguments.Contains((object) "x"))
        this.vector3s[1].x = (float) this.tweenArguments[(object) "x"];
      if (this.tweenArguments.Contains((object) "y"))
        this.vector3s[1].y = (float) this.tweenArguments[(object) "y"];
      if (this.tweenArguments.Contains((object) "z"))
        this.vector3s[1].z = (float) this.tweenArguments[(object) "z"];
    }
    if (!this.tweenArguments.Contains((object) "speed"))
      return;
    this.time = Math.Abs(Vector3.Distance(this.vector3s[0], this.vector3s[1])) / (float) this.tweenArguments[(object) "speed"];
  }

  private void GenerateScaleByTargets()
  {
    this.vector3s = new Vector3[3];
    this.vector3s[0] = this.vector3s[1] = this.thisTransform.localScale;
    if (this.tweenArguments.Contains((object) "amount"))
    {
      this.vector3s[1] = Vector3.Scale(this.vector3s[1], (Vector3) this.tweenArguments[(object) "amount"]);
    }
    else
    {
      if (this.tweenArguments.Contains((object) "x"))
        this.vector3s[1].x *= (float) this.tweenArguments[(object) "x"];
      if (this.tweenArguments.Contains((object) "y"))
        this.vector3s[1].y *= (float) this.tweenArguments[(object) "y"];
      if (this.tweenArguments.Contains((object) "z"))
        this.vector3s[1].z *= (float) this.tweenArguments[(object) "z"];
    }
    if (!this.tweenArguments.Contains((object) "speed"))
      return;
    this.time = Math.Abs(Vector3.Distance(this.vector3s[0], this.vector3s[1])) / (float) this.tweenArguments[(object) "speed"];
  }

  private void GenerateScaleAddTargets()
  {
    this.vector3s = new Vector3[3];
    this.vector3s[0] = this.vector3s[1] = this.thisTransform.localScale;
    if (this.tweenArguments.Contains((object) "amount"))
    {
      ref Vector3 local = ref this.vector3s[1];
      local = Vector3.op_Addition(local, (Vector3) this.tweenArguments[(object) "amount"]);
    }
    else
    {
      if (this.tweenArguments.Contains((object) "x"))
        this.vector3s[1].x += (float) this.tweenArguments[(object) "x"];
      if (this.tweenArguments.Contains((object) "y"))
        this.vector3s[1].y += (float) this.tweenArguments[(object) "y"];
      if (this.tweenArguments.Contains((object) "z"))
        this.vector3s[1].z += (float) this.tweenArguments[(object) "z"];
    }
    if (!this.tweenArguments.Contains((object) "speed"))
      return;
    this.time = Math.Abs(Vector3.Distance(this.vector3s[0], this.vector3s[1])) / (float) this.tweenArguments[(object) "speed"];
  }

  private void GenerateRotateToTargets()
  {
    this.vector3s = new Vector3[3];
    this.vector3s[0] = !this.isLocal ? (this.vector3s[1] = this.thisTransform.eulerAngles) : (this.vector3s[1] = this.thisTransform.localEulerAngles);
    if (this.tweenArguments.Contains((object) "rotation"))
    {
      if ((object) this.tweenArguments[(object) "rotation"].GetType() == (object) typeof (Transform))
        this.vector3s[1] = ((Transform) this.tweenArguments[(object) "rotation"]).eulerAngles;
      else if ((object) this.tweenArguments[(object) "rotation"].GetType() == (object) typeof (Vector3))
        this.vector3s[1] = (Vector3) this.tweenArguments[(object) "rotation"];
    }
    else
    {
      if (this.tweenArguments.Contains((object) "x"))
        this.vector3s[1].x = (float) this.tweenArguments[(object) "x"];
      if (this.tweenArguments.Contains((object) "y"))
        this.vector3s[1].y = (float) this.tweenArguments[(object) "y"];
      if (this.tweenArguments.Contains((object) "z"))
        this.vector3s[1].z = (float) this.tweenArguments[(object) "z"];
    }
    this.vector3s[1] = new Vector3(this.clerp(this.vector3s[0].x, this.vector3s[1].x, 1f), this.clerp(this.vector3s[0].y, this.vector3s[1].y, 1f), this.clerp(this.vector3s[0].z, this.vector3s[1].z, 1f));
    if (!this.tweenArguments.Contains((object) "speed"))
      return;
    this.time = Math.Abs(Vector3.Distance(this.vector3s[0], this.vector3s[1])) / (float) this.tweenArguments[(object) "speed"];
  }

  private void GenerateRotateAddTargets()
  {
    this.vector3s = new Vector3[5];
    this.vector3s[0] = this.vector3s[1] = this.vector3s[3] = this.thisTransform.eulerAngles;
    if (this.tweenArguments.Contains((object) "amount"))
    {
      ref Vector3 local = ref this.vector3s[1];
      local = Vector3.op_Addition(local, (Vector3) this.tweenArguments[(object) "amount"]);
    }
    else
    {
      if (this.tweenArguments.Contains((object) "x"))
        this.vector3s[1].x += (float) this.tweenArguments[(object) "x"];
      if (this.tweenArguments.Contains((object) "y"))
        this.vector3s[1].y += (float) this.tweenArguments[(object) "y"];
      if (this.tweenArguments.Contains((object) "z"))
        this.vector3s[1].z += (float) this.tweenArguments[(object) "z"];
    }
    if (!this.tweenArguments.Contains((object) "speed"))
      return;
    this.time = Math.Abs(Vector3.Distance(this.vector3s[0], this.vector3s[1])) / (float) this.tweenArguments[(object) "speed"];
  }

  private void GenerateRotateByTargets()
  {
    this.vector3s = new Vector3[4];
    this.vector3s[0] = this.vector3s[1] = this.vector3s[3] = this.thisTransform.eulerAngles;
    if (this.tweenArguments.Contains((object) "amount"))
    {
      ref Vector3 local = ref this.vector3s[1];
      local = Vector3.op_Addition(local, Vector3.Scale((Vector3) this.tweenArguments[(object) "amount"], new Vector3(360f, 360f, 360f)));
    }
    else
    {
      if (this.tweenArguments.Contains((object) "x"))
        this.vector3s[1].x += 360f * (float) this.tweenArguments[(object) "x"];
      if (this.tweenArguments.Contains((object) "y"))
        this.vector3s[1].y += 360f * (float) this.tweenArguments[(object) "y"];
      if (this.tweenArguments.Contains((object) "z"))
        this.vector3s[1].z += 360f * (float) this.tweenArguments[(object) "z"];
    }
    if (!this.tweenArguments.Contains((object) "speed"))
      return;
    this.time = Math.Abs(Vector3.Distance(this.vector3s[0], this.vector3s[1])) / (float) this.tweenArguments[(object) "speed"];
  }

  private void GenerateShakePositionTargets()
  {
    this.vector3s = new Vector3[4];
    this.vector3s[3] = this.thisTransform.eulerAngles;
    this.vector3s[0] = this.thisTransform.position;
    if (this.tweenArguments.Contains((object) "amount"))
    {
      this.vector3s[1] = (Vector3) this.tweenArguments[(object) "amount"];
    }
    else
    {
      if (this.tweenArguments.Contains((object) "x"))
        this.vector3s[1].x = (float) this.tweenArguments[(object) "x"];
      if (this.tweenArguments.Contains((object) "y"))
        this.vector3s[1].y = (float) this.tweenArguments[(object) "y"];
      if (!this.tweenArguments.Contains((object) "z"))
        return;
      this.vector3s[1].z = (float) this.tweenArguments[(object) "z"];
    }
  }

  private void GenerateShakeScaleTargets()
  {
    this.vector3s = new Vector3[3];
    this.vector3s[0] = this.thisTransform.localScale;
    if (this.tweenArguments.Contains((object) "amount"))
    {
      this.vector3s[1] = (Vector3) this.tweenArguments[(object) "amount"];
    }
    else
    {
      if (this.tweenArguments.Contains((object) "x"))
        this.vector3s[1].x = (float) this.tweenArguments[(object) "x"];
      if (this.tweenArguments.Contains((object) "y"))
        this.vector3s[1].y = (float) this.tweenArguments[(object) "y"];
      if (!this.tweenArguments.Contains((object) "z"))
        return;
      this.vector3s[1].z = (float) this.tweenArguments[(object) "z"];
    }
  }

  private void GenerateShakeRotationTargets()
  {
    this.vector3s = new Vector3[3];
    this.vector3s[0] = this.thisTransform.eulerAngles;
    if (this.tweenArguments.Contains((object) "amount"))
    {
      this.vector3s[1] = (Vector3) this.tweenArguments[(object) "amount"];
    }
    else
    {
      if (this.tweenArguments.Contains((object) "x"))
        this.vector3s[1].x = (float) this.tweenArguments[(object) "x"];
      if (this.tweenArguments.Contains((object) "y"))
        this.vector3s[1].y = (float) this.tweenArguments[(object) "y"];
      if (!this.tweenArguments.Contains((object) "z"))
        return;
      this.vector3s[1].z = (float) this.tweenArguments[(object) "z"];
    }
  }

  private void GeneratePunchPositionTargets()
  {
    this.vector3s = new Vector3[5];
    this.vector3s[4] = this.thisTransform.eulerAngles;
    this.vector3s[0] = this.thisTransform.position;
    this.vector3s[1] = this.vector3s[3] = Vector3.zero;
    if (this.tweenArguments.Contains((object) "amount"))
    {
      this.vector3s[1] = (Vector3) this.tweenArguments[(object) "amount"];
    }
    else
    {
      if (this.tweenArguments.Contains((object) "x"))
        this.vector3s[1].x = (float) this.tweenArguments[(object) "x"];
      if (this.tweenArguments.Contains((object) "y"))
        this.vector3s[1].y = (float) this.tweenArguments[(object) "y"];
      if (!this.tweenArguments.Contains((object) "z"))
        return;
      this.vector3s[1].z = (float) this.tweenArguments[(object) "z"];
    }
  }

  private void GeneratePunchRotationTargets()
  {
    this.vector3s = new Vector3[4];
    this.vector3s[0] = this.thisTransform.eulerAngles;
    this.vector3s[1] = this.vector3s[3] = Vector3.zero;
    if (this.tweenArguments.Contains((object) "amount"))
    {
      this.vector3s[1] = (Vector3) this.tweenArguments[(object) "amount"];
    }
    else
    {
      if (this.tweenArguments.Contains((object) "x"))
        this.vector3s[1].x = (float) this.tweenArguments[(object) "x"];
      if (this.tweenArguments.Contains((object) "y"))
        this.vector3s[1].y = (float) this.tweenArguments[(object) "y"];
      if (!this.tweenArguments.Contains((object) "z"))
        return;
      this.vector3s[1].z = (float) this.tweenArguments[(object) "z"];
    }
  }

  private void GeneratePunchScaleTargets()
  {
    this.vector3s = new Vector3[3];
    this.vector3s[0] = this.thisTransform.localScale;
    this.vector3s[1] = Vector3.zero;
    if (this.tweenArguments.Contains((object) "amount"))
    {
      this.vector3s[1] = (Vector3) this.tweenArguments[(object) "amount"];
    }
    else
    {
      if (this.tweenArguments.Contains((object) "x"))
        this.vector3s[1].x = (float) this.tweenArguments[(object) "x"];
      if (this.tweenArguments.Contains((object) "y"))
        this.vector3s[1].y = (float) this.tweenArguments[(object) "y"];
      if (!this.tweenArguments.Contains((object) "z"))
        return;
      this.vector3s[1].z = (float) this.tweenArguments[(object) "z"];
    }
  }

  private void ApplyRectTargets()
  {
    ((Rect) ref this.rects[2]).x = this.ease(((Rect) ref this.rects[0]).x, ((Rect) ref this.rects[1]).x, this.percentage);
    ((Rect) ref this.rects[2]).y = this.ease(((Rect) ref this.rects[0]).y, ((Rect) ref this.rects[1]).y, this.percentage);
    ((Rect) ref this.rects[2]).width = this.ease(((Rect) ref this.rects[0]).width, ((Rect) ref this.rects[1]).width, this.percentage);
    ((Rect) ref this.rects[2]).height = this.ease(((Rect) ref this.rects[0]).height, ((Rect) ref this.rects[1]).height, this.percentage);
    this.tweenArguments[(object) "onupdateparams"] = (object) this.rects[2];
    if ((double) this.percentage != 1.0)
      return;
    this.tweenArguments[(object) "onupdateparams"] = (object) this.rects[1];
  }

  private void ApplyColorTargets()
  {
    this.colors[0, 2].r = this.ease(this.colors[0, 0].r, this.colors[0, 1].r, this.percentage);
    this.colors[0, 2].g = this.ease(this.colors[0, 0].g, this.colors[0, 1].g, this.percentage);
    this.colors[0, 2].b = this.ease(this.colors[0, 0].b, this.colors[0, 1].b, this.percentage);
    this.colors[0, 2].a = this.ease(this.colors[0, 0].a, this.colors[0, 1].a, this.percentage);
    this.tweenArguments[(object) "onupdateparams"] = (object) this.colors[0, 2];
    if ((double) this.percentage != 1.0)
      return;
    this.tweenArguments[(object) "onupdateparams"] = (object) this.colors[0, 1];
  }

  private void ApplyVector3Targets()
  {
    this.vector3s[2].x = this.ease(this.vector3s[0].x, this.vector3s[1].x, this.percentage);
    this.vector3s[2].y = this.ease(this.vector3s[0].y, this.vector3s[1].y, this.percentage);
    this.vector3s[2].z = this.ease(this.vector3s[0].z, this.vector3s[1].z, this.percentage);
    this.tweenArguments[(object) "onupdateparams"] = (object) this.vector3s[2];
    if ((double) this.percentage != 1.0)
      return;
    this.tweenArguments[(object) "onupdateparams"] = (object) this.vector3s[1];
  }

  private void ApplyVector2Targets()
  {
    this.vector2s[2].x = this.ease(this.vector2s[0].x, this.vector2s[1].x, this.percentage);
    this.vector2s[2].y = this.ease(this.vector2s[0].y, this.vector2s[1].y, this.percentage);
    this.tweenArguments[(object) "onupdateparams"] = (object) this.vector2s[2];
    if ((double) this.percentage != 1.0)
      return;
    this.tweenArguments[(object) "onupdateparams"] = (object) this.vector2s[1];
  }

  private void ApplyFloatTargets()
  {
    this.floats[2] = this.ease(this.floats[0], this.floats[1], this.percentage);
    this.tweenArguments[(object) "onupdateparams"] = (object) this.floats[2];
    if ((double) this.percentage != 1.0)
      return;
    this.tweenArguments[(object) "onupdateparams"] = (object) this.floats[1];
  }

  private void ApplyColorToTargets()
  {
    for (int index = 0; index < this.colors.GetLength(0); ++index)
    {
      this.colors[index, 2].r = this.ease(this.colors[index, 0].r, this.colors[index, 1].r, this.percentage);
      this.colors[index, 2].g = this.ease(this.colors[index, 0].g, this.colors[index, 1].g, this.percentage);
      this.colors[index, 2].b = this.ease(this.colors[index, 0].b, this.colors[index, 1].b, this.percentage);
      this.colors[index, 2].a = this.ease(this.colors[index, 0].a, this.colors[index, 1].a, this.percentage);
    }
    if (Object.op_Implicit((Object) ((Component) this).GetComponent<GUITexture>()))
      ((Component) this).GetComponent<GUITexture>().color = this.colors[0, 2];
    else if (Object.op_Implicit((Object) ((Component) this).GetComponent<GUIText>()))
      ((Component) this).GetComponent<GUIText>().material.color = this.colors[0, 2];
    else if (Object.op_Implicit((Object) ((Component) this).GetComponent<Renderer>()))
    {
      for (int index = 0; index < this.colors.GetLength(0); ++index)
        ((Component) this).GetComponent<Renderer>().materials[index].SetColor(this.namedcolorvalue.ToString(), this.colors[index, 2]);
    }
    else if (Object.op_Implicit((Object) ((Component) this).GetComponent<Light>()))
      ((Component) this).GetComponent<Light>().color = this.colors[0, 2];
    if ((double) this.percentage != 1.0)
      return;
    if (Object.op_Implicit((Object) ((Component) this).GetComponent<GUITexture>()))
      ((Component) this).GetComponent<GUITexture>().color = this.colors[0, 1];
    else if (Object.op_Implicit((Object) ((Component) this).GetComponent<GUIText>()))
      ((Component) this).GetComponent<GUIText>().material.color = this.colors[0, 1];
    else if (Object.op_Implicit((Object) ((Component) this).GetComponent<Renderer>()))
    {
      for (int index = 0; index < this.colors.GetLength(0); ++index)
        ((Component) this).GetComponent<Renderer>().materials[index].SetColor(this.namedcolorvalue.ToString(), this.colors[index, 1]);
    }
    else
    {
      if (!Object.op_Implicit((Object) ((Component) this).GetComponent<Light>()))
        return;
      ((Component) this).GetComponent<Light>().color = this.colors[0, 1];
    }
  }

  private void ApplyAudioToTargets()
  {
    this.vector2s[2].x = this.ease(this.vector2s[0].x, this.vector2s[1].x, this.percentage);
    this.vector2s[2].y = this.ease(this.vector2s[0].y, this.vector2s[1].y, this.percentage);
    this.audioSource.volume = this.vector2s[2].x;
    this.audioSource.pitch = this.vector2s[2].y;
    if ((double) this.percentage != 1.0)
      return;
    this.audioSource.volume = this.vector2s[1].x;
    this.audioSource.pitch = this.vector2s[1].y;
  }

  private void ApplyStabTargets()
  {
  }

  private void ApplyMoveToPathTargets()
  {
    this.preUpdate = this.thisTransform.position;
    float num = this.ease(0.0f, 1f, this.percentage);
    if (this.isLocal)
      this.thisTransform.localPosition = this.path.Interp(Mathf.Clamp(num, 0.0f, 1f));
    else
      this.thisTransform.position = this.path.Interp(Mathf.Clamp(num, 0.0f, 1f));
    if (this.tweenArguments.Contains((object) "orienttopath") && (bool) this.tweenArguments[(object) "orienttopath"])
      this.tweenArguments[(object) "looktarget"] = (object) this.path.Interp(Mathf.Clamp(this.ease(0.0f, 1f, Mathf.Min(1f, this.percentage + (!this.tweenArguments.Contains((object) "lookahead") ? iTween.Defaults.lookAhead : (float) this.tweenArguments[(object) "lookahead"]))), 0.0f, 1f));
    this.postUpdate = this.thisTransform.position;
    if (!this.physics)
      return;
    this.thisTransform.position = this.preUpdate;
    ((Component) this).GetComponent<Rigidbody>().MovePosition(this.postUpdate);
  }

  private void ApplyMoveToTargets()
  {
    this.preUpdate = this.thisTransform.position;
    this.vector3s[2].x = this.ease(this.vector3s[0].x, this.vector3s[1].x, this.percentage);
    this.vector3s[2].y = this.ease(this.vector3s[0].y, this.vector3s[1].y, this.percentage);
    this.vector3s[2].z = this.ease(this.vector3s[0].z, this.vector3s[1].z, this.percentage);
    if (this.isLocal)
      this.thisTransform.localPosition = this.vector3s[2];
    else
      this.thisTransform.position = this.vector3s[2];
    if ((double) this.percentage == 1.0)
    {
      if (this.isLocal)
        this.thisTransform.localPosition = this.vector3s[1];
      else
        this.thisTransform.position = this.vector3s[1];
    }
    this.postUpdate = this.thisTransform.position;
    if (!this.physics)
      return;
    this.thisTransform.position = this.preUpdate;
    ((Component) this).GetComponent<Rigidbody>().MovePosition(this.postUpdate);
  }

  private void ApplyMoveByTargets()
  {
    this.preUpdate = this.thisTransform.position;
    Vector3 vector3 = new Vector3();
    if (this.tweenArguments.Contains((object) "looktarget"))
    {
      vector3 = this.thisTransform.eulerAngles;
      this.thisTransform.eulerAngles = this.vector3s[4];
    }
    this.vector3s[2].x = this.ease(this.vector3s[0].x, this.vector3s[1].x, this.percentage);
    this.vector3s[2].y = this.ease(this.vector3s[0].y, this.vector3s[1].y, this.percentage);
    this.vector3s[2].z = this.ease(this.vector3s[0].z, this.vector3s[1].z, this.percentage);
    this.thisTransform.Translate(Vector3.op_Subtraction(this.vector3s[2], this.vector3s[3]), this.space);
    this.vector3s[3] = this.vector3s[2];
    if (this.tweenArguments.Contains((object) "looktarget"))
      this.thisTransform.eulerAngles = vector3;
    this.postUpdate = this.thisTransform.position;
    if (!this.physics)
      return;
    this.thisTransform.position = this.preUpdate;
    ((Component) this).GetComponent<Rigidbody>().MovePosition(this.postUpdate);
  }

  private void ApplyScaleToTargets()
  {
    this.vector3s[2].x = this.ease(this.vector3s[0].x, this.vector3s[1].x, this.percentage);
    this.vector3s[2].y = this.ease(this.vector3s[0].y, this.vector3s[1].y, this.percentage);
    this.vector3s[2].z = this.ease(this.vector3s[0].z, this.vector3s[1].z, this.percentage);
    this.thisTransform.localScale = this.vector3s[2];
    if ((double) this.percentage != 1.0)
      return;
    this.thisTransform.localScale = this.vector3s[1];
  }

  private void ApplyLookToTargets()
  {
    this.vector3s[2].x = this.ease(this.vector3s[0].x, this.vector3s[1].x, this.percentage);
    this.vector3s[2].y = this.ease(this.vector3s[0].y, this.vector3s[1].y, this.percentage);
    this.vector3s[2].z = this.ease(this.vector3s[0].z, this.vector3s[1].z, this.percentage);
    if (this.isLocal)
      this.thisTransform.localRotation = Quaternion.Euler(this.vector3s[2]);
    else
      this.thisTransform.rotation = Quaternion.Euler(this.vector3s[2]);
  }

  private void ApplyRotateToTargets()
  {
    this.preUpdate = this.thisTransform.eulerAngles;
    this.vector3s[2].x = this.ease(this.vector3s[0].x, this.vector3s[1].x, this.percentage);
    this.vector3s[2].y = this.ease(this.vector3s[0].y, this.vector3s[1].y, this.percentage);
    this.vector3s[2].z = this.ease(this.vector3s[0].z, this.vector3s[1].z, this.percentage);
    if (this.isLocal)
      this.thisTransform.localRotation = Quaternion.Euler(this.vector3s[2]);
    else
      this.thisTransform.rotation = Quaternion.Euler(this.vector3s[2]);
    if ((double) this.percentage == 1.0)
    {
      if (this.isLocal)
        this.thisTransform.localRotation = Quaternion.Euler(this.vector3s[1]);
      else
        this.thisTransform.rotation = Quaternion.Euler(this.vector3s[1]);
    }
    this.postUpdate = this.thisTransform.eulerAngles;
    if (!this.physics)
      return;
    this.thisTransform.eulerAngles = this.preUpdate;
    ((Component) this).GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(this.postUpdate));
  }

  private void ApplyRotateAddTargets()
  {
    this.preUpdate = this.thisTransform.eulerAngles;
    this.vector3s[2].x = this.ease(this.vector3s[0].x, this.vector3s[1].x, this.percentage);
    this.vector3s[2].y = this.ease(this.vector3s[0].y, this.vector3s[1].y, this.percentage);
    this.vector3s[2].z = this.ease(this.vector3s[0].z, this.vector3s[1].z, this.percentage);
    this.thisTransform.Rotate(Vector3.op_Subtraction(this.vector3s[2], this.vector3s[3]), this.space);
    this.vector3s[3] = this.vector3s[2];
    this.postUpdate = this.thisTransform.eulerAngles;
    if (!this.physics)
      return;
    this.thisTransform.eulerAngles = this.preUpdate;
    ((Component) this).GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(this.postUpdate));
  }

  private void ApplyShakePositionTargets()
  {
    this.preUpdate = !this.isLocal ? this.thisTransform.position : this.thisTransform.localPosition;
    Vector3 vector3 = new Vector3();
    if (this.tweenArguments.Contains((object) "looktarget"))
    {
      vector3 = this.thisTransform.eulerAngles;
      this.thisTransform.eulerAngles = this.vector3s[3];
    }
    if ((double) this.percentage == 0.0)
      this.thisTransform.Translate(this.vector3s[1], this.space);
    if (this.isLocal)
      this.thisTransform.localPosition = this.vector3s[0];
    else
      this.thisTransform.position = this.vector3s[0];
    float num = 1f - this.percentage;
    this.vector3s[2].x = Random.Range(-this.vector3s[1].x * num, this.vector3s[1].x * num);
    this.vector3s[2].y = Random.Range(-this.vector3s[1].y * num, this.vector3s[1].y * num);
    this.vector3s[2].z = Random.Range(-this.vector3s[1].z * num, this.vector3s[1].z * num);
    if (this.isLocal)
    {
      Transform thisTransform = this.thisTransform;
      thisTransform.localPosition = Vector3.op_Addition(thisTransform.localPosition, this.vector3s[2]);
    }
    else
    {
      Transform thisTransform = this.thisTransform;
      thisTransform.position = Vector3.op_Addition(thisTransform.position, this.vector3s[2]);
    }
    if (this.tweenArguments.Contains((object) "looktarget"))
      this.thisTransform.eulerAngles = vector3;
    this.postUpdate = this.thisTransform.position;
    if (!this.physics)
      return;
    this.thisTransform.position = this.preUpdate;
    ((Component) this).GetComponent<Rigidbody>().MovePosition(this.postUpdate);
  }

  private void ApplyShakeScaleTargets()
  {
    if ((double) this.percentage == 0.0)
      this.thisTransform.localScale = this.vector3s[1];
    this.thisTransform.localScale = this.vector3s[0];
    float num = 1f - this.percentage;
    this.vector3s[2].x = Random.Range(-this.vector3s[1].x * num, this.vector3s[1].x * num);
    this.vector3s[2].y = Random.Range(-this.vector3s[1].y * num, this.vector3s[1].y * num);
    this.vector3s[2].z = Random.Range(-this.vector3s[1].z * num, this.vector3s[1].z * num);
    Transform thisTransform = this.thisTransform;
    thisTransform.localScale = Vector3.op_Addition(thisTransform.localScale, this.vector3s[2]);
  }

  private void ApplyShakeRotationTargets()
  {
    this.preUpdate = this.thisTransform.eulerAngles;
    if ((double) this.percentage == 0.0)
      this.thisTransform.Rotate(this.vector3s[1], this.space);
    this.thisTransform.eulerAngles = this.vector3s[0];
    float num = 1f - this.percentage;
    this.vector3s[2].x = Random.Range(-this.vector3s[1].x * num, this.vector3s[1].x * num);
    this.vector3s[2].y = Random.Range(-this.vector3s[1].y * num, this.vector3s[1].y * num);
    this.vector3s[2].z = Random.Range(-this.vector3s[1].z * num, this.vector3s[1].z * num);
    this.thisTransform.Rotate(this.vector3s[2], this.space);
    this.postUpdate = this.thisTransform.eulerAngles;
    if (!this.physics)
      return;
    this.thisTransform.eulerAngles = this.preUpdate;
    ((Component) this).GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(this.postUpdate));
  }

  private void ApplyPunchPositionTargets()
  {
    this.preUpdate = this.thisTransform.position;
    Vector3 vector3 = new Vector3();
    if (this.tweenArguments.Contains((object) "looktarget"))
    {
      vector3 = this.thisTransform.eulerAngles;
      this.thisTransform.eulerAngles = this.vector3s[4];
    }
    if ((double) this.vector3s[1].x > 0.0)
      this.vector3s[2].x = this.punch(this.vector3s[1].x, this.percentage);
    else if ((double) this.vector3s[1].x < 0.0)
      this.vector3s[2].x = -this.punch(Mathf.Abs(this.vector3s[1].x), this.percentage);
    if ((double) this.vector3s[1].y > 0.0)
      this.vector3s[2].y = this.punch(this.vector3s[1].y, this.percentage);
    else if ((double) this.vector3s[1].y < 0.0)
      this.vector3s[2].y = -this.punch(Mathf.Abs(this.vector3s[1].y), this.percentage);
    if ((double) this.vector3s[1].z > 0.0)
      this.vector3s[2].z = this.punch(this.vector3s[1].z, this.percentage);
    else if ((double) this.vector3s[1].z < 0.0)
      this.vector3s[2].z = -this.punch(Mathf.Abs(this.vector3s[1].z), this.percentage);
    this.thisTransform.Translate(Vector3.op_Subtraction(this.vector3s[2], this.vector3s[3]), this.space);
    this.vector3s[3] = this.vector3s[2];
    if (this.tweenArguments.Contains((object) "looktarget"))
      this.thisTransform.eulerAngles = vector3;
    this.postUpdate = this.thisTransform.position;
    if (!this.physics)
      return;
    this.thisTransform.position = this.preUpdate;
    ((Component) this).GetComponent<Rigidbody>().MovePosition(this.postUpdate);
  }

  private void ApplyPunchRotationTargets()
  {
    this.preUpdate = this.thisTransform.eulerAngles;
    if ((double) this.vector3s[1].x > 0.0)
      this.vector3s[2].x = this.punch(this.vector3s[1].x, this.percentage);
    else if ((double) this.vector3s[1].x < 0.0)
      this.vector3s[2].x = -this.punch(Mathf.Abs(this.vector3s[1].x), this.percentage);
    if ((double) this.vector3s[1].y > 0.0)
      this.vector3s[2].y = this.punch(this.vector3s[1].y, this.percentage);
    else if ((double) this.vector3s[1].y < 0.0)
      this.vector3s[2].y = -this.punch(Mathf.Abs(this.vector3s[1].y), this.percentage);
    if ((double) this.vector3s[1].z > 0.0)
      this.vector3s[2].z = this.punch(this.vector3s[1].z, this.percentage);
    else if ((double) this.vector3s[1].z < 0.0)
      this.vector3s[2].z = -this.punch(Mathf.Abs(this.vector3s[1].z), this.percentage);
    this.thisTransform.Rotate(Vector3.op_Subtraction(this.vector3s[2], this.vector3s[3]), this.space);
    this.vector3s[3] = this.vector3s[2];
    this.postUpdate = this.thisTransform.eulerAngles;
    if (!this.physics)
      return;
    this.thisTransform.eulerAngles = this.preUpdate;
    ((Component) this).GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(this.postUpdate));
  }

  private void ApplyPunchScaleTargets()
  {
    if ((double) this.vector3s[1].x > 0.0)
      this.vector3s[2].x = this.punch(this.vector3s[1].x, this.percentage);
    else if ((double) this.vector3s[1].x < 0.0)
      this.vector3s[2].x = -this.punch(Mathf.Abs(this.vector3s[1].x), this.percentage);
    if ((double) this.vector3s[1].y > 0.0)
      this.vector3s[2].y = this.punch(this.vector3s[1].y, this.percentage);
    else if ((double) this.vector3s[1].y < 0.0)
      this.vector3s[2].y = -this.punch(Mathf.Abs(this.vector3s[1].y), this.percentage);
    if ((double) this.vector3s[1].z > 0.0)
      this.vector3s[2].z = this.punch(this.vector3s[1].z, this.percentage);
    else if ((double) this.vector3s[1].z < 0.0)
      this.vector3s[2].z = -this.punch(Mathf.Abs(this.vector3s[1].z), this.percentage);
    this.thisTransform.localScale = Vector3.op_Addition(this.vector3s[0], this.vector3s[2]);
  }

  [DebuggerHidden]
  private IEnumerator TweenDelay()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new iTween.\u003CTweenDelay\u003Ec__Iterator6()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void TweenStart()
  {
    this.CallBack("onstart");
    if (!this.loop)
    {
      this.ConflictCheck();
      this.GenerateTargets();
    }
    if (this.type == "stab")
      this.audioSource.PlayOneShot(this.audioSource.clip);
    if (this.type == "move" || this.type == "scale" || this.type == "rotate" || this.type == "punch" || this.type == "shake" || this.type == "curve" || this.type == "look")
      this.EnableKinematic();
    this.isRunning = true;
  }

  [DebuggerHidden]
  private IEnumerator TweenRestart()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new iTween.\u003CTweenRestart\u003Ec__Iterator7()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void TweenUpdate()
  {
    this.apply();
    this.CallBack("onupdate");
    this.UpdatePercentage();
  }

  private void TweenComplete()
  {
    this.isRunning = false;
    this.percentage = (double) this.percentage <= 0.5 ? 0.0f : 1f;
    this.apply();
    if (this.type == "value")
      this.CallBack("onupdate");
    if (this.loopType == iTween.LoopType.none)
      this.Dispose();
    else
      this.TweenLoop();
    this.CallBack("oncomplete");
  }

  private void TweenLoop()
  {
    this.DisableKinematic();
    switch (this.loopType)
    {
      case iTween.LoopType.loop:
        this.percentage = 0.0f;
        this.runningTime = 0.0f;
        this.apply();
        this.StartCoroutine("TweenRestart");
        break;
      case iTween.LoopType.pingPong:
        this.reverse = !this.reverse;
        this.runningTime = 0.0f;
        this.StartCoroutine("TweenRestart");
        break;
    }
  }

  public static Rect RectUpdate(Rect currentValue, Rect targetValue, float speed)
  {
    Rect rect;
    // ISSUE: explicit constructor call
    ((Rect) ref rect).\u002Ector(iTween.FloatUpdate(((Rect) ref currentValue).x, ((Rect) ref targetValue).x, speed), iTween.FloatUpdate(((Rect) ref currentValue).y, ((Rect) ref targetValue).y, speed), iTween.FloatUpdate(((Rect) ref currentValue).width, ((Rect) ref targetValue).width, speed), iTween.FloatUpdate(((Rect) ref currentValue).height, ((Rect) ref targetValue).height, speed));
    return rect;
  }

  public static Vector3 Vector3Update(Vector3 currentValue, Vector3 targetValue, float speed)
  {
    Vector3 vector3 = Vector3.op_Subtraction(targetValue, currentValue);
    currentValue = Vector3.op_Addition(currentValue, Vector3.op_Multiply(Vector3.op_Multiply(vector3, speed), Time.deltaTime));
    return currentValue;
  }

  public static Vector2 Vector2Update(Vector2 currentValue, Vector2 targetValue, float speed)
  {
    Vector2 vector2 = Vector2.op_Subtraction(targetValue, currentValue);
    currentValue = Vector2.op_Addition(currentValue, Vector2.op_Multiply(Vector2.op_Multiply(vector2, speed), Time.deltaTime));
    return currentValue;
  }

  public static float FloatUpdate(float currentValue, float targetValue, float speed)
  {
    float num = targetValue - currentValue;
    currentValue += num * speed * Time.deltaTime;
    return currentValue;
  }

  public static void FadeUpdate(GameObject target, Hashtable args)
  {
    args[(object) "a"] = args[(object) "alpha"];
    iTween.ColorUpdate(target, args);
  }

  public static void FadeUpdate(GameObject target, float alpha, float time)
  {
    iTween.FadeUpdate(target, iTween.Hash((object) nameof (alpha), (object) alpha, (object) nameof (time), (object) time));
  }

  public static void ColorUpdate(GameObject target, Hashtable args)
  {
    iTween.CleanArgs(args);
    Color[] colorArray = new Color[4];
    if (!args.Contains((object) "includechildren") || (bool) args[(object) "includechildren"])
    {
      foreach (Component component in target.transform)
        iTween.ColorUpdate(component.gameObject, args);
    }
    float num = !args.Contains((object) "time") ? iTween.Defaults.updateTime : (float) args[(object) "time"] * iTween.Defaults.updateTimePercentage;
    if (Object.op_Implicit((Object) target.GetComponent<GUITexture>()))
      colorArray[0] = colorArray[1] = target.GetComponent<GUITexture>().color;
    else if (Object.op_Implicit((Object) target.GetComponent<GUIText>()))
      colorArray[0] = colorArray[1] = target.GetComponent<GUIText>().material.color;
    else if (Object.op_Implicit((Object) target.GetComponent<Renderer>()))
      colorArray[0] = colorArray[1] = target.GetComponent<Renderer>().material.color;
    else if (Object.op_Implicit((Object) target.GetComponent<Light>()))
      colorArray[0] = colorArray[1] = target.GetComponent<Light>().color;
    if (args.Contains((object) "color"))
    {
      colorArray[1] = (Color) args[(object) "color"];
    }
    else
    {
      if (args.Contains((object) "r"))
        colorArray[1].r = (float) args[(object) "r"];
      if (args.Contains((object) "g"))
        colorArray[1].g = (float) args[(object) "g"];
      if (args.Contains((object) "b"))
        colorArray[1].b = (float) args[(object) "b"];
      if (args.Contains((object) "a"))
        colorArray[1].a = (float) args[(object) "a"];
    }
    colorArray[3].r = Mathf.SmoothDamp(colorArray[0].r, colorArray[1].r, ref colorArray[2].r, num);
    colorArray[3].g = Mathf.SmoothDamp(colorArray[0].g, colorArray[1].g, ref colorArray[2].g, num);
    colorArray[3].b = Mathf.SmoothDamp(colorArray[0].b, colorArray[1].b, ref colorArray[2].b, num);
    colorArray[3].a = Mathf.SmoothDamp(colorArray[0].a, colorArray[1].a, ref colorArray[2].a, num);
    if (Object.op_Implicit((Object) target.GetComponent<GUITexture>()))
      target.GetComponent<GUITexture>().color = colorArray[3];
    else if (Object.op_Implicit((Object) target.GetComponent<GUIText>()))
      target.GetComponent<GUIText>().material.color = colorArray[3];
    else if (Object.op_Implicit((Object) target.GetComponent<Renderer>()))
    {
      target.GetComponent<Renderer>().material.color = colorArray[3];
    }
    else
    {
      if (!Object.op_Implicit((Object) target.GetComponent<Light>()))
        return;
      target.GetComponent<Light>().color = colorArray[3];
    }
  }

  public static void ColorUpdate(GameObject target, Color color, float time)
  {
    iTween.ColorUpdate(target, iTween.Hash((object) nameof (color), (object) color, (object) nameof (time), (object) time));
  }

  public static void AudioUpdate(GameObject target, Hashtable args)
  {
    iTween.CleanArgs(args);
    Vector2[] vector2Array = new Vector2[4];
    float num = !args.Contains((object) "time") ? iTween.Defaults.updateTime : (float) args[(object) "time"] * iTween.Defaults.updateTimePercentage;
    AudioSource component;
    if (args.Contains((object) "audiosource"))
      component = (AudioSource) args[(object) "audiosource"];
    else if (Object.op_Implicit((Object) target.GetComponent<AudioSource>()))
    {
      component = target.GetComponent<AudioSource>();
    }
    else
    {
      Debug.LogError((object) "iTween Error: AudioUpdate requires an AudioSource.");
      return;
    }
    vector2Array[0] = vector2Array[1] = new Vector2(component.volume, component.pitch);
    if (args.Contains((object) "volume"))
      vector2Array[1].x = (float) args[(object) "volume"];
    if (args.Contains((object) "pitch"))
      vector2Array[1].y = (float) args[(object) "pitch"];
    vector2Array[3].x = Mathf.SmoothDampAngle(vector2Array[0].x, vector2Array[1].x, ref vector2Array[2].x, num);
    vector2Array[3].y = Mathf.SmoothDampAngle(vector2Array[0].y, vector2Array[1].y, ref vector2Array[2].y, num);
    component.volume = vector2Array[3].x;
    component.pitch = vector2Array[3].y;
  }

  public static void AudioUpdate(GameObject target, float volume, float pitch, float time)
  {
    iTween.AudioUpdate(target, iTween.Hash((object) nameof (volume), (object) volume, (object) nameof (pitch), (object) pitch, (object) nameof (time), (object) time));
  }

  public static void RotateUpdate(GameObject target, Hashtable args)
  {
    iTween.CleanArgs(args);
    Vector3[] vector3Array = new Vector3[4];
    Vector3 eulerAngles1 = target.transform.eulerAngles;
    float num = !args.Contains((object) "time") ? iTween.Defaults.updateTime : (float) args[(object) "time"] * iTween.Defaults.updateTimePercentage;
    bool flag = !args.Contains((object) "islocal") ? iTween.Defaults.isLocal : (bool) args[(object) "islocal"];
    vector3Array[0] = !flag ? target.transform.eulerAngles : target.transform.localEulerAngles;
    if (args.Contains((object) "rotation"))
    {
      if ((object) args[(object) "rotation"].GetType() == (object) typeof (Transform))
      {
        Transform transform = (Transform) args[(object) "rotation"];
        vector3Array[1] = transform.eulerAngles;
      }
      else if ((object) args[(object) "rotation"].GetType() == (object) typeof (Vector3))
        vector3Array[1] = (Vector3) args[(object) "rotation"];
    }
    vector3Array[3].x = Mathf.SmoothDampAngle(vector3Array[0].x, vector3Array[1].x, ref vector3Array[2].x, num);
    vector3Array[3].y = Mathf.SmoothDampAngle(vector3Array[0].y, vector3Array[1].y, ref vector3Array[2].y, num);
    vector3Array[3].z = Mathf.SmoothDampAngle(vector3Array[0].z, vector3Array[1].z, ref vector3Array[2].z, num);
    if (flag)
      target.transform.localEulerAngles = vector3Array[3];
    else
      target.transform.eulerAngles = vector3Array[3];
    if (!Object.op_Inequality((Object) target.GetComponent<Rigidbody>(), (Object) null))
      return;
    Vector3 eulerAngles2 = target.transform.eulerAngles;
    target.transform.eulerAngles = eulerAngles1;
    target.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(eulerAngles2));
  }

  public static void RotateUpdate(GameObject target, Vector3 rotation, float time)
  {
    iTween.RotateUpdate(target, iTween.Hash((object) nameof (rotation), (object) rotation, (object) nameof (time), (object) time));
  }

  public static void ScaleUpdate(GameObject target, Hashtable args)
  {
    iTween.CleanArgs(args);
    Vector3[] vector3Array = new Vector3[4];
    float num = !args.Contains((object) "time") ? iTween.Defaults.updateTime : (float) args[(object) "time"] * iTween.Defaults.updateTimePercentage;
    vector3Array[0] = vector3Array[1] = target.transform.localScale;
    if (args.Contains((object) "scale"))
    {
      if ((object) args[(object) "scale"].GetType() == (object) typeof (Transform))
      {
        Transform transform = (Transform) args[(object) "scale"];
        vector3Array[1] = transform.localScale;
      }
      else if ((object) args[(object) "scale"].GetType() == (object) typeof (Vector3))
        vector3Array[1] = (Vector3) args[(object) "scale"];
    }
    else
    {
      if (args.Contains((object) "x"))
        vector3Array[1].x = (float) args[(object) "x"];
      if (args.Contains((object) "y"))
        vector3Array[1].y = (float) args[(object) "y"];
      if (args.Contains((object) "z"))
        vector3Array[1].z = (float) args[(object) "z"];
    }
    vector3Array[3].x = Mathf.SmoothDamp(vector3Array[0].x, vector3Array[1].x, ref vector3Array[2].x, num);
    vector3Array[3].y = Mathf.SmoothDamp(vector3Array[0].y, vector3Array[1].y, ref vector3Array[2].y, num);
    vector3Array[3].z = Mathf.SmoothDamp(vector3Array[0].z, vector3Array[1].z, ref vector3Array[2].z, num);
    target.transform.localScale = vector3Array[3];
  }

  public static void ScaleUpdate(GameObject target, Vector3 scale, float time)
  {
    iTween.ScaleUpdate(target, iTween.Hash((object) nameof (scale), (object) scale, (object) nameof (time), (object) time));
  }

  public static void MoveUpdate(GameObject target, Hashtable args)
  {
    iTween.CleanArgs(args);
    Vector3[] vector3Array = new Vector3[4];
    Vector3 position1 = target.transform.position;
    float num = !args.Contains((object) "time") ? iTween.Defaults.updateTime : (float) args[(object) "time"] * iTween.Defaults.updateTimePercentage;
    bool flag = !args.Contains((object) "islocal") ? iTween.Defaults.isLocal : (bool) args[(object) "islocal"];
    vector3Array[0] = !flag ? (vector3Array[1] = target.transform.position) : (vector3Array[1] = target.transform.localPosition);
    if (args.Contains((object) "position"))
    {
      if ((object) args[(object) "position"].GetType() == (object) typeof (Transform))
      {
        Transform transform = (Transform) args[(object) "position"];
        vector3Array[1] = transform.position;
      }
      else if ((object) args[(object) "position"].GetType() == (object) typeof (Vector3))
        vector3Array[1] = (Vector3) args[(object) "position"];
    }
    else
    {
      if (args.Contains((object) "x"))
        vector3Array[1].x = (float) args[(object) "x"];
      if (args.Contains((object) "y"))
        vector3Array[1].y = (float) args[(object) "y"];
      if (args.Contains((object) "z"))
        vector3Array[1].z = (float) args[(object) "z"];
    }
    vector3Array[3].x = Mathf.SmoothDamp(vector3Array[0].x, vector3Array[1].x, ref vector3Array[2].x, num);
    vector3Array[3].y = Mathf.SmoothDamp(vector3Array[0].y, vector3Array[1].y, ref vector3Array[2].y, num);
    vector3Array[3].z = Mathf.SmoothDamp(vector3Array[0].z, vector3Array[1].z, ref vector3Array[2].z, num);
    if (args.Contains((object) "orienttopath") && (bool) args[(object) "orienttopath"])
      args[(object) "looktarget"] = (object) vector3Array[3];
    if (args.Contains((object) "looktarget"))
      iTween.LookUpdate(target, args);
    if (flag)
      target.transform.localPosition = vector3Array[3];
    else
      target.transform.position = vector3Array[3];
    if (!Object.op_Inequality((Object) target.GetComponent<Rigidbody>(), (Object) null))
      return;
    Vector3 position2 = target.transform.position;
    target.transform.position = position1;
    target.GetComponent<Rigidbody>().MovePosition(position2);
  }

  public static void MoveUpdate(GameObject target, Vector3 position, float time)
  {
    iTween.MoveUpdate(target, iTween.Hash((object) nameof (position), (object) position, (object) nameof (time), (object) time));
  }

  public static void LookUpdate(GameObject target, Hashtable args)
  {
    iTween.CleanArgs(args);
    Vector3[] vector3Array = new Vector3[5];
    float num1 = !args.Contains((object) "looktime") ? (!args.Contains((object) "time") ? iTween.Defaults.updateTime : (float) args[(object) "time"] * 0.15f * iTween.Defaults.updateTimePercentage) : (float) args[(object) "looktime"] * iTween.Defaults.updateTimePercentage;
    vector3Array[0] = target.transform.eulerAngles;
    if (args.Contains((object) "looktarget"))
    {
      if ((object) args[(object) "looktarget"].GetType() == (object) typeof (Transform))
      {
        Transform transform1 = target.transform;
        Transform transform2 = (Transform) args[(object) "looktarget"];
        Vector3? nullable = (Vector3?) args[(object) "up"];
        Vector3 vector3 = !nullable.HasValue ? iTween.Defaults.up : nullable.Value;
        transform1.LookAt(transform2, vector3);
      }
      else if ((object) args[(object) "looktarget"].GetType() == (object) typeof (Vector3))
      {
        Transform transform = target.transform;
        Vector3 vector3_1 = (Vector3) args[(object) "looktarget"];
        Vector3? nullable = (Vector3?) args[(object) "up"];
        Vector3 vector3_2 = !nullable.HasValue ? iTween.Defaults.up : nullable.Value;
        transform.LookAt(vector3_1, vector3_2);
      }
      vector3Array[1] = target.transform.eulerAngles;
      target.transform.eulerAngles = vector3Array[0];
      vector3Array[3].x = Mathf.SmoothDampAngle(vector3Array[0].x, vector3Array[1].x, ref vector3Array[2].x, num1);
      vector3Array[3].y = Mathf.SmoothDampAngle(vector3Array[0].y, vector3Array[1].y, ref vector3Array[2].y, num1);
      vector3Array[3].z = Mathf.SmoothDampAngle(vector3Array[0].z, vector3Array[1].z, ref vector3Array[2].z, num1);
      target.transform.eulerAngles = vector3Array[3];
      if (!args.Contains((object) "axis"))
        return;
      vector3Array[4] = target.transform.eulerAngles;
      string key = (string) args[(object) "axis"];
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (iTween.\u003C\u003Ef__switch\u0024mapC == null)
        {
          // ISSUE: reference to a compiler-generated field
          iTween.\u003C\u003Ef__switch\u0024mapC = new Dictionary<string, int>(3)
          {
            {
              "x",
              0
            },
            {
              "y",
              1
            },
            {
              "z",
              2
            }
          };
        }
        int num2;
        // ISSUE: reference to a compiler-generated field
        if (iTween.\u003C\u003Ef__switch\u0024mapC.TryGetValue(key, out num2))
        {
          switch (num2)
          {
            case 0:
              vector3Array[4].y = vector3Array[0].y;
              vector3Array[4].z = vector3Array[0].z;
              break;
            case 1:
              vector3Array[4].x = vector3Array[0].x;
              vector3Array[4].z = vector3Array[0].z;
              break;
            case 2:
              vector3Array[4].x = vector3Array[0].x;
              vector3Array[4].y = vector3Array[0].y;
              break;
          }
        }
      }
      target.transform.eulerAngles = vector3Array[4];
    }
    else
      Debug.LogError((object) "iTween Error: LookUpdate needs a 'looktarget' property!");
  }

  public static void LookUpdate(GameObject target, Vector3 looktarget, float time)
  {
    iTween.LookUpdate(target, iTween.Hash((object) nameof (looktarget), (object) looktarget, (object) nameof (time), (object) time));
  }

  public static float PathLength(Transform[] path)
  {
    Vector3[] path1 = new Vector3[path.Length];
    float num1 = 0.0f;
    for (int index = 0; index < path.Length; ++index)
      path1[index] = path[index].position;
    Vector3[] pts = iTween.PathControlPointGenerator(path1);
    Vector3 vector3_1 = iTween.Interp(pts, 0.0f);
    int num2 = path.Length * 20;
    for (int index = 1; index <= num2; ++index)
    {
      float t = (float) index / (float) num2;
      Vector3 vector3_2 = iTween.Interp(pts, t);
      num1 += Vector3.Distance(vector3_1, vector3_2);
      vector3_1 = vector3_2;
    }
    return num1;
  }

  public static float PathLength(Vector3[] path)
  {
    float num1 = 0.0f;
    Vector3[] pts = iTween.PathControlPointGenerator(path);
    Vector3 vector3_1 = iTween.Interp(pts, 0.0f);
    int num2 = path.Length * 20;
    for (int index = 1; index <= num2; ++index)
    {
      float t = (float) index / (float) num2;
      Vector3 vector3_2 = iTween.Interp(pts, t);
      num1 += Vector3.Distance(vector3_1, vector3_2);
      vector3_1 = vector3_2;
    }
    return num1;
  }

  public static Texture2D CameraTexture(Color color)
  {
    Texture2D texture2D = new Texture2D(Screen.width, Screen.height, (TextureFormat) 5, false);
    Color[] colorArray = new Color[Screen.width * Screen.height];
    for (int index = 0; index < colorArray.Length; ++index)
      colorArray[index] = color;
    texture2D.SetPixels(colorArray);
    texture2D.Apply();
    return texture2D;
  }

  public static void PutOnPath(GameObject target, Vector3[] path, float percent)
  {
    target.transform.position = iTween.Interp(iTween.PathControlPointGenerator(path), percent);
  }

  public static void PutOnPath(Transform target, Vector3[] path, float percent)
  {
    target.position = iTween.Interp(iTween.PathControlPointGenerator(path), percent);
  }

  public static void PutOnPath(GameObject target, Transform[] path, float percent)
  {
    Vector3[] path1 = new Vector3[path.Length];
    for (int index = 0; index < path.Length; ++index)
      path1[index] = path[index].position;
    target.transform.position = iTween.Interp(iTween.PathControlPointGenerator(path1), percent);
  }

  public static void PutOnPath(Transform target, Transform[] path, float percent)
  {
    Vector3[] path1 = new Vector3[path.Length];
    for (int index = 0; index < path.Length; ++index)
      path1[index] = path[index].position;
    target.position = iTween.Interp(iTween.PathControlPointGenerator(path1), percent);
  }

  public static Vector3 PointOnPath(Transform[] path, float percent)
  {
    Vector3[] path1 = new Vector3[path.Length];
    for (int index = 0; index < path.Length; ++index)
      path1[index] = path[index].position;
    return iTween.Interp(iTween.PathControlPointGenerator(path1), percent);
  }

  public static void DrawLine(Vector3[] line)
  {
    if (line.Length <= 0)
      return;
    iTween.DrawLineHelper(line, iTween.Defaults.color, "gizmos");
  }

  public static void DrawLine(Vector3[] line, Color color)
  {
    if (line.Length <= 0)
      return;
    iTween.DrawLineHelper(line, color, "gizmos");
  }

  public static void DrawLine(Transform[] line)
  {
    if (line.Length <= 0)
      return;
    Vector3[] line1 = new Vector3[line.Length];
    for (int index = 0; index < line.Length; ++index)
      line1[index] = line[index].position;
    iTween.DrawLineHelper(line1, iTween.Defaults.color, "gizmos");
  }

  public static void DrawLine(Transform[] line, Color color)
  {
    if (line.Length <= 0)
      return;
    Vector3[] line1 = new Vector3[line.Length];
    for (int index = 0; index < line.Length; ++index)
      line1[index] = line[index].position;
    iTween.DrawLineHelper(line1, color, "gizmos");
  }

  public static void DrawLineGizmos(Vector3[] line)
  {
    if (line.Length <= 0)
      return;
    iTween.DrawLineHelper(line, iTween.Defaults.color, "gizmos");
  }

  public static void DrawLineGizmos(Vector3[] line, Color color)
  {
    if (line.Length <= 0)
      return;
    iTween.DrawLineHelper(line, color, "gizmos");
  }

  public static void DrawLineGizmos(Transform[] line)
  {
    if (line.Length <= 0)
      return;
    Vector3[] line1 = new Vector3[line.Length];
    for (int index = 0; index < line.Length; ++index)
      line1[index] = line[index].position;
    iTween.DrawLineHelper(line1, iTween.Defaults.color, "gizmos");
  }

  public static void DrawLineGizmos(Transform[] line, Color color)
  {
    if (line.Length <= 0)
      return;
    Vector3[] line1 = new Vector3[line.Length];
    for (int index = 0; index < line.Length; ++index)
      line1[index] = line[index].position;
    iTween.DrawLineHelper(line1, color, "gizmos");
  }

  public static void DrawLineHandles(Vector3[] line)
  {
    if (line.Length <= 0)
      return;
    iTween.DrawLineHelper(line, iTween.Defaults.color, "handles");
  }

  public static void DrawLineHandles(Vector3[] line, Color color)
  {
    if (line.Length <= 0)
      return;
    iTween.DrawLineHelper(line, color, "handles");
  }

  public static void DrawLineHandles(Transform[] line)
  {
    if (line.Length <= 0)
      return;
    Vector3[] line1 = new Vector3[line.Length];
    for (int index = 0; index < line.Length; ++index)
      line1[index] = line[index].position;
    iTween.DrawLineHelper(line1, iTween.Defaults.color, "handles");
  }

  public static void DrawLineHandles(Transform[] line, Color color)
  {
    if (line.Length <= 0)
      return;
    Vector3[] line1 = new Vector3[line.Length];
    for (int index = 0; index < line.Length; ++index)
      line1[index] = line[index].position;
    iTween.DrawLineHelper(line1, color, "handles");
  }

  public static Vector3 PointOnPath(Vector3[] path, float percent)
  {
    return iTween.Interp(iTween.PathControlPointGenerator(path), percent);
  }

  public static void DrawPath(Vector3[] path)
  {
    if (path.Length <= 0)
      return;
    iTween.DrawPathHelper(path, iTween.Defaults.color, "gizmos");
  }

  public static void DrawPath(Vector3[] path, Color color)
  {
    if (path.Length <= 0)
      return;
    iTween.DrawPathHelper(path, color, "gizmos");
  }

  public static void DrawPath(Transform[] path)
  {
    if (path.Length <= 0)
      return;
    Vector3[] path1 = new Vector3[path.Length];
    for (int index = 0; index < path.Length; ++index)
      path1[index] = path[index].position;
    iTween.DrawPathHelper(path1, iTween.Defaults.color, "gizmos");
  }

  public static void DrawPath(Transform[] path, Color color)
  {
    if (path.Length <= 0)
      return;
    Vector3[] path1 = new Vector3[path.Length];
    for (int index = 0; index < path.Length; ++index)
      path1[index] = path[index].position;
    iTween.DrawPathHelper(path1, color, "gizmos");
  }

  public static void DrawPathGizmos(Vector3[] path)
  {
    if (path.Length <= 0)
      return;
    iTween.DrawPathHelper(path, iTween.Defaults.color, "gizmos");
  }

  public static void DrawPathGizmos(Vector3[] path, Color color)
  {
    if (path.Length <= 0)
      return;
    iTween.DrawPathHelper(path, color, "gizmos");
  }

  public static void DrawPathGizmos(Transform[] path)
  {
    if (path.Length <= 0)
      return;
    Vector3[] path1 = new Vector3[path.Length];
    for (int index = 0; index < path.Length; ++index)
      path1[index] = path[index].position;
    iTween.DrawPathHelper(path1, iTween.Defaults.color, "gizmos");
  }

  public static void DrawPathGizmos(Transform[] path, Color color)
  {
    if (path.Length <= 0)
      return;
    Vector3[] path1 = new Vector3[path.Length];
    for (int index = 0; index < path.Length; ++index)
      path1[index] = path[index].position;
    iTween.DrawPathHelper(path1, color, "gizmos");
  }

  public static void DrawPathHandles(Vector3[] path)
  {
    if (path.Length <= 0)
      return;
    iTween.DrawPathHelper(path, iTween.Defaults.color, "handles");
  }

  public static void DrawPathHandles(Vector3[] path, Color color)
  {
    if (path.Length <= 0)
      return;
    iTween.DrawPathHelper(path, color, "handles");
  }

  public static void DrawPathHandles(Transform[] path)
  {
    if (path.Length <= 0)
      return;
    Vector3[] path1 = new Vector3[path.Length];
    for (int index = 0; index < path.Length; ++index)
      path1[index] = path[index].position;
    iTween.DrawPathHelper(path1, iTween.Defaults.color, "handles");
  }

  public static void DrawPathHandles(Transform[] path, Color color)
  {
    if (path.Length <= 0)
      return;
    Vector3[] path1 = new Vector3[path.Length];
    for (int index = 0; index < path.Length; ++index)
      path1[index] = path[index].position;
    iTween.DrawPathHelper(path1, color, "handles");
  }

  public static void CameraFadeDepth(int depth)
  {
    if (!Object.op_Implicit((Object) iTween.cameraFade))
      return;
    iTween.cameraFade.transform.position = new Vector3(iTween.cameraFade.transform.position.x, iTween.cameraFade.transform.position.y, (float) depth);
  }

  public static void CameraFadeDestroy()
  {
    if (!Object.op_Implicit((Object) iTween.cameraFade))
      return;
    Object.Destroy((Object) iTween.cameraFade);
  }

  public static void CameraFadeSwap(Texture2D texture)
  {
    if (!Object.op_Implicit((Object) iTween.cameraFade))
      return;
    iTween.cameraFade.GetComponent<GUITexture>().texture = (Texture) texture;
  }

  public static GameObject CameraFadeAdd(Texture2D texture, int depth)
  {
    if (Object.op_Implicit((Object) iTween.cameraFade))
      return (GameObject) null;
    iTween.cameraFade = new GameObject("iTween Camera Fade");
    iTween.cameraFade.transform.position = new Vector3(0.5f, 0.5f, (float) depth);
    iTween.cameraFade.AddComponent<GUITexture>();
    iTween.cameraFade.GetComponent<GUITexture>().texture = (Texture) texture;
    iTween.cameraFade.GetComponent<GUITexture>().color = new Color(0.5f, 0.5f, 0.5f, 0.0f);
    return iTween.cameraFade;
  }

  public static GameObject CameraFadeAdd(Texture2D texture)
  {
    if (Object.op_Implicit((Object) iTween.cameraFade))
      return (GameObject) null;
    iTween.cameraFade = new GameObject("iTween Camera Fade");
    iTween.cameraFade.transform.position = new Vector3(0.5f, 0.5f, (float) iTween.Defaults.cameraFadeDepth);
    iTween.cameraFade.AddComponent<GUITexture>();
    iTween.cameraFade.GetComponent<GUITexture>().texture = (Texture) texture;
    iTween.cameraFade.GetComponent<GUITexture>().color = new Color(0.5f, 0.5f, 0.5f, 0.0f);
    return iTween.cameraFade;
  }

  public static GameObject CameraFadeAdd()
  {
    if (Object.op_Implicit((Object) iTween.cameraFade))
      return (GameObject) null;
    iTween.cameraFade = new GameObject("iTween Camera Fade");
    iTween.cameraFade.transform.position = new Vector3(0.5f, 0.5f, (float) iTween.Defaults.cameraFadeDepth);
    iTween.cameraFade.AddComponent<GUITexture>();
    iTween.cameraFade.GetComponent<GUITexture>().texture = (Texture) iTween.CameraTexture(Color.black);
    iTween.cameraFade.GetComponent<GUITexture>().color = new Color(0.5f, 0.5f, 0.5f, 0.0f);
    return iTween.cameraFade;
  }

  public static void Resume(GameObject target)
  {
    foreach (Behaviour component in (Component[]) target.GetComponents<iTween>())
      component.enabled = true;
  }

  public static void Resume(GameObject target, bool includechildren)
  {
    iTween.Resume(target);
    if (!includechildren)
      return;
    foreach (Component component in target.transform)
      iTween.Resume(component.gameObject, true);
  }

  public static void Resume(GameObject target, string type)
  {
    foreach (iTween component in (Component[]) target.GetComponents<iTween>())
    {
      if ((component.type + component.method).Substring(0, type.Length).ToLower() == type.ToLower())
        ((Behaviour) component).enabled = true;
    }
  }

  public static void Resume(GameObject target, string type, bool includechildren)
  {
    foreach (iTween component in (Component[]) target.GetComponents<iTween>())
    {
      if ((component.type + component.method).Substring(0, type.Length).ToLower() == type.ToLower())
        ((Behaviour) component).enabled = true;
    }
    if (!includechildren)
      return;
    foreach (Component component in target.transform)
      iTween.Resume(component.gameObject, type, true);
  }

  public static void Resume()
  {
    for (int index = 0; index < iTween.tweens.Count; ++index)
      iTween.Resume((GameObject) iTween.tweens[index][(object) "target"]);
  }

  public static void Resume(string type)
  {
    ArrayList arrayList = new ArrayList();
    for (int index = 0; index < iTween.tweens.Count; ++index)
    {
      GameObject gameObject = (GameObject) iTween.tweens[index][(object) "target"];
      arrayList.Insert(arrayList.Count, (object) gameObject);
    }
    for (int index = 0; index < arrayList.Count; ++index)
      iTween.Resume((GameObject) arrayList[index], type);
  }

  public static void Pause(GameObject target)
  {
    foreach (iTween component in (Component[]) target.GetComponents<iTween>())
    {
      if ((double) component.delay > 0.0)
      {
        component.delay -= Time.time - component.delayStarted;
        component.StopCoroutine("TweenDelay");
      }
      component.isPaused = true;
      ((Behaviour) component).enabled = false;
    }
  }

  public static void Pause(GameObject target, bool includechildren)
  {
    iTween.Pause(target);
    if (!includechildren)
      return;
    foreach (Component component in target.transform)
      iTween.Pause(component.gameObject, true);
  }

  public static void Pause(GameObject target, string type)
  {
    foreach (iTween component in (Component[]) target.GetComponents<iTween>())
    {
      if ((component.type + component.method).Substring(0, type.Length).ToLower() == type.ToLower())
      {
        if ((double) component.delay > 0.0)
        {
          component.delay -= Time.time - component.delayStarted;
          component.StopCoroutine("TweenDelay");
        }
        component.isPaused = true;
        ((Behaviour) component).enabled = false;
      }
    }
  }

  public static void Pause(GameObject target, string type, bool includechildren)
  {
    foreach (iTween component in (Component[]) target.GetComponents<iTween>())
    {
      if ((component.type + component.method).Substring(0, type.Length).ToLower() == type.ToLower())
      {
        if ((double) component.delay > 0.0)
        {
          component.delay -= Time.time - component.delayStarted;
          component.StopCoroutine("TweenDelay");
        }
        component.isPaused = true;
        ((Behaviour) component).enabled = false;
      }
    }
    if (!includechildren)
      return;
    foreach (Component component in target.transform)
      iTween.Pause(component.gameObject, type, true);
  }

  public static void Pause()
  {
    for (int index = 0; index < iTween.tweens.Count; ++index)
      iTween.Pause((GameObject) iTween.tweens[index][(object) "target"]);
  }

  public static void Pause(string type)
  {
    ArrayList arrayList = new ArrayList();
    for (int index = 0; index < iTween.tweens.Count; ++index)
    {
      GameObject gameObject = (GameObject) iTween.tweens[index][(object) "target"];
      arrayList.Insert(arrayList.Count, (object) gameObject);
    }
    for (int index = 0; index < arrayList.Count; ++index)
      iTween.Pause((GameObject) arrayList[index], type);
  }

  public static int Count() => iTween.tweens.Count;

  public static int Count(string type)
  {
    int num = 0;
    for (int index = 0; index < iTween.tweens.Count; ++index)
    {
      Hashtable tween = iTween.tweens[index];
      if (((string) tween[(object) nameof (type)] + (string) tween[(object) "method"]).Substring(0, type.Length).ToLower() == type.ToLower())
        ++num;
    }
    return num;
  }

  public static int Count(GameObject target)
  {
    return ((Component[]) target.GetComponents<iTween>()).Length;
  }

  public static int Count(GameObject target, string type)
  {
    int num = 0;
    foreach (iTween component in (Component[]) target.GetComponents<iTween>())
    {
      if ((component.type + component.method).Substring(0, type.Length).ToLower() == type.ToLower())
        ++num;
    }
    return num;
  }

  public static void Stop()
  {
    for (int index = 0; index < iTween.tweens.Count; ++index)
      iTween.Stop((GameObject) iTween.tweens[index][(object) "target"]);
    iTween.tweens.Clear();
  }

  public static void Stop(string type)
  {
    ArrayList arrayList = new ArrayList();
    for (int index = 0; index < iTween.tweens.Count; ++index)
    {
      GameObject gameObject = (GameObject) iTween.tweens[index][(object) "target"];
      arrayList.Insert(arrayList.Count, (object) gameObject);
    }
    for (int index = 0; index < arrayList.Count; ++index)
      iTween.Stop((GameObject) arrayList[index], type);
  }

  public static void StopByName(string name)
  {
    ArrayList arrayList = new ArrayList();
    for (int index = 0; index < iTween.tweens.Count; ++index)
    {
      GameObject gameObject = (GameObject) iTween.tweens[index][(object) "target"];
      arrayList.Insert(arrayList.Count, (object) gameObject);
    }
    for (int index = 0; index < arrayList.Count; ++index)
      iTween.StopByName((GameObject) arrayList[index], name);
  }

  public static void Stop(GameObject target)
  {
    foreach (iTween component in (Component[]) target.GetComponents<iTween>())
      component.Dispose();
  }

  public static void Stop(GameObject target, bool includechildren)
  {
    iTween.Stop(target);
    if (!includechildren)
      return;
    foreach (Component component in target.transform)
      iTween.Stop(component.gameObject, true);
  }

  public static void Stop(GameObject target, string type)
  {
    foreach (iTween component in (Component[]) target.GetComponents<iTween>())
    {
      if ((component.type + component.method).Substring(0, type.Length).ToLower() == type.ToLower())
        component.Dispose();
    }
  }

  public static void StopByName(GameObject target, string name)
  {
    foreach (iTween component in (Component[]) target.GetComponents<iTween>())
    {
      if (component._name == name)
        component.Dispose();
    }
  }

  public static void Stop(GameObject target, string type, bool includechildren)
  {
    foreach (iTween component in (Component[]) target.GetComponents<iTween>())
    {
      if ((component.type + component.method).Substring(0, type.Length).ToLower() == type.ToLower())
        component.Dispose();
    }
    if (!includechildren)
      return;
    foreach (Component component in target.transform)
      iTween.Stop(component.gameObject, type, true);
  }

  public static void StopByName(GameObject target, string name, bool includechildren)
  {
    foreach (iTween component in (Component[]) target.GetComponents<iTween>())
    {
      if (component._name == name)
        component.Dispose();
    }
    if (!includechildren)
      return;
    foreach (Component component in target.transform)
      iTween.StopByName(component.gameObject, name, true);
  }

  public static Hashtable Hash(params object[] args)
  {
    Hashtable hashtable = new Hashtable(args.Length / 2);
    if (args.Length % 2 != 0)
    {
      Debug.LogError((object) "Tween Error: Hash requires an even number of arguments!");
      return (Hashtable) null;
    }
    for (int index = 0; index < args.Length - 1; index += 2)
      hashtable.Add(args[index], args[index + 1]);
    return hashtable;
  }

  private void Awake()
  {
    this.thisTransform = ((Component) this).transform;
    this.RetrieveArgs();
    this.lastRealTime = Time.realtimeSinceStartup;
  }

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new iTween.\u003CStart\u003Ec__Iterator8()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    if (!this.isRunning || this.physics)
      return;
    if (!this.reverse)
    {
      if ((double) this.percentage < 1.0)
        this.TweenUpdate();
      else
        this.TweenComplete();
    }
    else if ((double) this.percentage > 0.0)
      this.TweenUpdate();
    else
      this.TweenComplete();
  }

  private void FixedUpdate()
  {
    if (!this.isRunning || !this.physics)
      return;
    if (!this.reverse)
    {
      if ((double) this.percentage < 1.0)
        this.TweenUpdate();
      else
        this.TweenComplete();
    }
    else if ((double) this.percentage > 0.0)
      this.TweenUpdate();
    else
      this.TweenComplete();
  }

  private void LateUpdate()
  {
    if (!this.tweenArguments.Contains((object) "looktarget") || !this.isRunning || !(this.type == "move") && !(this.type == "shake") && !(this.type == "punch"))
      return;
    iTween.LookUpdate(((Component) this).gameObject, this.tweenArguments);
  }

  private void OnEnable()
  {
    if (this.isRunning)
      this.EnableKinematic();
    if (!this.isPaused)
      return;
    this.isPaused = false;
    if ((double) this.delay <= 0.0)
      return;
    this.wasPaused = true;
    this.ResumeDelay();
  }

  private void OnDisable() => this.DisableKinematic();

  private static void DrawLineHelper(Vector3[] line, Color color, string method)
  {
    Gizmos.color = color;
    for (int index = 0; index < line.Length - 1; ++index)
    {
      switch (method)
      {
        case "gizmos":
          Gizmos.DrawLine(line[index], line[index + 1]);
          break;
        case "handles":
          Debug.LogError((object) "iTween Error: Drawing a line with Handles is temporarily disabled because of compatability issues with Unity 2.6!");
          break;
      }
    }
  }

  private static void DrawPathHelper(Vector3[] path, Color color, string method)
  {
    Vector3[] pts = iTween.PathControlPointGenerator(path);
    Vector3 vector3_1 = iTween.Interp(pts, 0.0f);
    Gizmos.color = color;
    int num = path.Length * 20;
    for (int index = 1; index <= num; ++index)
    {
      float t = (float) index / (float) num;
      Vector3 vector3_2 = iTween.Interp(pts, t);
      switch (method)
      {
        case "gizmos":
          Gizmos.DrawLine(vector3_2, vector3_1);
          break;
        case "handles":
          Debug.LogError((object) "iTween Error: Drawing a path with Handles is temporarily disabled because of compatability issues with Unity 2.6!");
          break;
      }
      vector3_1 = vector3_2;
    }
  }

  private static Vector3[] PathControlPointGenerator(Vector3[] path)
  {
    Vector3[] sourceArray = path;
    int num = 2;
    Vector3[] vector3Array1 = new Vector3[sourceArray.Length + num];
    Array.Copy((Array) sourceArray, 0, (Array) vector3Array1, 1, sourceArray.Length);
    vector3Array1[0] = Vector3.op_Addition(vector3Array1[1], Vector3.op_Subtraction(vector3Array1[1], vector3Array1[2]));
    vector3Array1[vector3Array1.Length - 1] = Vector3.op_Addition(vector3Array1[vector3Array1.Length - 2], Vector3.op_Subtraction(vector3Array1[vector3Array1.Length - 2], vector3Array1[vector3Array1.Length - 3]));
    if (Vector3.op_Equality(vector3Array1[1], vector3Array1[vector3Array1.Length - 2]))
    {
      Vector3[] vector3Array2 = new Vector3[vector3Array1.Length];
      Array.Copy((Array) vector3Array1, (Array) vector3Array2, vector3Array1.Length);
      vector3Array2[0] = vector3Array2[vector3Array2.Length - 3];
      vector3Array2[vector3Array2.Length - 1] = vector3Array2[2];
      vector3Array1 = new Vector3[vector3Array2.Length];
      Array.Copy((Array) vector3Array2, (Array) vector3Array1, vector3Array2.Length);
    }
    return vector3Array1;
  }

  private static Vector3 Interp(Vector3[] pts, float t)
  {
    int num1 = pts.Length - 3;
    int index = Mathf.Min(Mathf.FloorToInt(t * (float) num1), num1 - 1);
    float num2 = t * (float) num1 - (float) index;
    Vector3 pt1 = pts[index];
    Vector3 pt2 = pts[index + 1];
    Vector3 pt3 = pts[index + 2];
    Vector3 pt4 = pts[index + 3];
    return Vector3.op_Multiply(0.5f, Vector3.op_Addition(Vector3.op_Addition(Vector3.op_Addition(Vector3.op_Multiply(Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Addition(Vector3.op_UnaryNegation(pt1), Vector3.op_Multiply(3f, pt2)), Vector3.op_Multiply(3f, pt3)), pt4), num2 * num2 * num2), Vector3.op_Multiply(Vector3.op_Subtraction(Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Multiply(2f, pt1), Vector3.op_Multiply(5f, pt2)), Vector3.op_Multiply(4f, pt3)), pt4), num2 * num2)), Vector3.op_Multiply(Vector3.op_Addition(Vector3.op_UnaryNegation(pt1), pt3), num2)), Vector3.op_Multiply(2f, pt2)));
  }

  private static void Launch(GameObject target, Hashtable args)
  {
    if (!args.Contains((object) "id"))
      args[(object) "id"] = (object) iTween.GenerateID();
    if (!args.Contains((object) nameof (target)))
      args[(object) nameof (target)] = (object) target;
    iTween.tweens.Insert(0, args);
    target.AddComponent<iTween>();
  }

  private static Hashtable CleanArgs(Hashtable args)
  {
    Hashtable hashtable1 = new Hashtable(args.Count);
    Hashtable hashtable2 = new Hashtable(args.Count);
    foreach (DictionaryEntry dictionaryEntry in args)
      hashtable1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
    foreach (DictionaryEntry dictionaryEntry in hashtable1)
    {
      if ((object) dictionaryEntry.Value.GetType() == (object) typeof (int))
      {
        float num = (float) (int) dictionaryEntry.Value;
        args[dictionaryEntry.Key] = (object) num;
      }
      if ((object) dictionaryEntry.Value.GetType() == (object) typeof (double))
      {
        float num = (float) (double) dictionaryEntry.Value;
        args[dictionaryEntry.Key] = (object) num;
      }
    }
    foreach (DictionaryEntry dictionaryEntry in args)
      hashtable2.Add((object) dictionaryEntry.Key.ToString().ToLower(), dictionaryEntry.Value);
    args = hashtable2;
    return args;
  }

  private static string GenerateID() => Guid.NewGuid().ToString();

  private void RetrieveArgs()
  {
    foreach (Hashtable tween in iTween.tweens)
    {
      if (Object.op_Equality((Object) tween[(object) "target"], (Object) ((Component) this).gameObject))
      {
        this.tweenArguments = tween;
        break;
      }
    }
    this.id = (string) this.tweenArguments[(object) "id"];
    this.type = (string) this.tweenArguments[(object) "type"];
    this._name = (string) this.tweenArguments[(object) "name"];
    this.method = (string) this.tweenArguments[(object) "method"];
    this.time = !this.tweenArguments.Contains((object) "time") ? iTween.Defaults.time : (float) this.tweenArguments[(object) "time"];
    if (Object.op_Inequality((Object) ((Component) this).GetComponent<Rigidbody>(), (Object) null))
      this.physics = true;
    this.delay = !this.tweenArguments.Contains((object) "delay") ? iTween.Defaults.delay : (float) this.tweenArguments[(object) "delay"];
    if (this.tweenArguments.Contains((object) "namedcolorvalue"))
    {
      if ((object) this.tweenArguments[(object) "namedcolorvalue"].GetType() == (object) typeof (iTween.NamedValueColor))
      {
        this.namedcolorvalue = (iTween.NamedValueColor) this.tweenArguments[(object) "namedcolorvalue"];
      }
      else
      {
        try
        {
          this.namedcolorvalue = (iTween.NamedValueColor) Enum.Parse(typeof (iTween.NamedValueColor), (string) this.tweenArguments[(object) "namedcolorvalue"], true);
        }
        catch
        {
          Debug.LogWarning((object) "iTween: Unsupported namedcolorvalue supplied! Default will be used.");
          this.namedcolorvalue = iTween.NamedValueColor._Color;
        }
      }
    }
    else
      this.namedcolorvalue = iTween.Defaults.namedColorValue;
    if (this.tweenArguments.Contains((object) "looptype"))
    {
      if ((object) this.tweenArguments[(object) "looptype"].GetType() == (object) typeof (iTween.LoopType))
      {
        this.loopType = (iTween.LoopType) this.tweenArguments[(object) "looptype"];
      }
      else
      {
        try
        {
          this.loopType = (iTween.LoopType) Enum.Parse(typeof (iTween.LoopType), (string) this.tweenArguments[(object) "looptype"], true);
        }
        catch
        {
          Debug.LogWarning((object) "iTween: Unsupported loopType supplied! Default will be used.");
          this.loopType = iTween.LoopType.none;
        }
      }
    }
    else
      this.loopType = iTween.LoopType.none;
    if (this.tweenArguments.Contains((object) "easetype"))
    {
      if ((object) this.tweenArguments[(object) "easetype"].GetType() == (object) typeof (iTween.EaseType))
      {
        this.easeType = (iTween.EaseType) this.tweenArguments[(object) "easetype"];
      }
      else
      {
        try
        {
          this.easeType = (iTween.EaseType) Enum.Parse(typeof (iTween.EaseType), (string) this.tweenArguments[(object) "easetype"], true);
        }
        catch
        {
          Debug.LogWarning((object) "iTween: Unsupported easeType supplied! Default will be used.");
          this.easeType = iTween.Defaults.easeType;
        }
      }
    }
    else
      this.easeType = iTween.Defaults.easeType;
    if (this.tweenArguments.Contains((object) "space"))
    {
      if ((object) this.tweenArguments[(object) "space"].GetType() == (object) typeof (Space))
      {
        this.space = (Space) (int) this.tweenArguments[(object) "space"];
      }
      else
      {
        try
        {
          this.space = (Space) (int) Enum.Parse(typeof (Space), (string) this.tweenArguments[(object) "space"], true);
        }
        catch
        {
          Debug.LogWarning((object) "iTween: Unsupported space supplied! Default will be used.");
          this.space = iTween.Defaults.space;
        }
      }
    }
    else
      this.space = iTween.Defaults.space;
    this.isLocal = !this.tweenArguments.Contains((object) "islocal") ? iTween.Defaults.isLocal : (bool) this.tweenArguments[(object) "islocal"];
    this.useRealTime = !this.tweenArguments.Contains((object) "ignoretimescale") ? iTween.Defaults.useRealTime : (bool) this.tweenArguments[(object) "ignoretimescale"];
    this.GetEasingFunction();
  }

  private void GetEasingFunction()
  {
    switch (this.easeType)
    {
      case iTween.EaseType.easeInQuad:
        this.ease = new iTween.EasingFunction(this.easeInQuad);
        break;
      case iTween.EaseType.easeOutQuad:
        this.ease = new iTween.EasingFunction(this.easeOutQuad);
        break;
      case iTween.EaseType.easeInOutQuad:
        this.ease = new iTween.EasingFunction(this.easeInOutQuad);
        break;
      case iTween.EaseType.easeInCubic:
        this.ease = new iTween.EasingFunction(this.easeInCubic);
        break;
      case iTween.EaseType.easeOutCubic:
        this.ease = new iTween.EasingFunction(this.easeOutCubic);
        break;
      case iTween.EaseType.easeInOutCubic:
        this.ease = new iTween.EasingFunction(this.easeInOutCubic);
        break;
      case iTween.EaseType.easeInQuart:
        this.ease = new iTween.EasingFunction(this.easeInQuart);
        break;
      case iTween.EaseType.easeOutQuart:
        this.ease = new iTween.EasingFunction(this.easeOutQuart);
        break;
      case iTween.EaseType.easeInOutQuart:
        this.ease = new iTween.EasingFunction(this.easeInOutQuart);
        break;
      case iTween.EaseType.easeInQuint:
        this.ease = new iTween.EasingFunction(this.easeInQuint);
        break;
      case iTween.EaseType.easeOutQuint:
        this.ease = new iTween.EasingFunction(this.easeOutQuint);
        break;
      case iTween.EaseType.easeInOutQuint:
        this.ease = new iTween.EasingFunction(this.easeInOutQuint);
        break;
      case iTween.EaseType.easeInSine:
        this.ease = new iTween.EasingFunction(this.easeInSine);
        break;
      case iTween.EaseType.easeOutSine:
        this.ease = new iTween.EasingFunction(this.easeOutSine);
        break;
      case iTween.EaseType.easeInOutSine:
        this.ease = new iTween.EasingFunction(this.easeInOutSine);
        break;
      case iTween.EaseType.easeInExpo:
        this.ease = new iTween.EasingFunction(this.easeInExpo);
        break;
      case iTween.EaseType.easeOutExpo:
        this.ease = new iTween.EasingFunction(this.easeOutExpo);
        break;
      case iTween.EaseType.easeInOutExpo:
        this.ease = new iTween.EasingFunction(this.easeInOutExpo);
        break;
      case iTween.EaseType.easeInCirc:
        this.ease = new iTween.EasingFunction(this.easeInCirc);
        break;
      case iTween.EaseType.easeOutCirc:
        this.ease = new iTween.EasingFunction(this.easeOutCirc);
        break;
      case iTween.EaseType.easeInOutCirc:
        this.ease = new iTween.EasingFunction(this.easeInOutCirc);
        break;
      case iTween.EaseType.linear:
        this.ease = new iTween.EasingFunction(this.linear);
        break;
      case iTween.EaseType.spring:
        this.ease = new iTween.EasingFunction(this.spring);
        break;
      case iTween.EaseType.easeInBounce:
        this.ease = new iTween.EasingFunction(this.easeInBounce);
        break;
      case iTween.EaseType.easeOutBounce:
        this.ease = new iTween.EasingFunction(this.easeOutBounce);
        break;
      case iTween.EaseType.easeInOutBounce:
        this.ease = new iTween.EasingFunction(this.easeInOutBounce);
        break;
      case iTween.EaseType.easeInBack:
        this.ease = new iTween.EasingFunction(this.easeInBack);
        break;
      case iTween.EaseType.easeOutBack:
        this.ease = new iTween.EasingFunction(this.easeOutBack);
        break;
      case iTween.EaseType.easeInOutBack:
        this.ease = new iTween.EasingFunction(this.easeInOutBack);
        break;
      case iTween.EaseType.easeInElastic:
        this.ease = new iTween.EasingFunction(this.easeInElastic);
        break;
      case iTween.EaseType.easeOutElastic:
        this.ease = new iTween.EasingFunction(this.easeOutElastic);
        break;
      case iTween.EaseType.easeInOutElastic:
        this.ease = new iTween.EasingFunction(this.easeInOutElastic);
        break;
    }
  }

  private void UpdatePercentage()
  {
    if (this.useRealTime)
      this.runningTime += Time.realtimeSinceStartup - this.lastRealTime;
    else
      this.runningTime += Time.deltaTime;
    this.percentage = !this.reverse ? this.runningTime / this.time : (float) (1.0 - (double) this.runningTime / (double) this.time);
    this.lastRealTime = Time.realtimeSinceStartup;
  }

  private void CallBack(string callbackType)
  {
    if (!this.tweenArguments.Contains((object) callbackType) || this.tweenArguments.Contains((object) "ischild"))
      return;
    GameObject gameObject = !this.tweenArguments.Contains((object) (callbackType + "target")) ? ((Component) this).gameObject : (GameObject) this.tweenArguments[(object) (callbackType + "target")];
    if ((object) this.tweenArguments[(object) callbackType].GetType() == (object) typeof (string))
    {
      gameObject.SendMessage((string) this.tweenArguments[(object) callbackType], this.tweenArguments[(object) (callbackType + "params")], (SendMessageOptions) 1);
    }
    else
    {
      Debug.LogError((object) "iTween Error: Callback method references must be passed as a String!");
      Object.Destroy((Object) this);
    }
  }

  private void Dispose()
  {
    for (int index = 0; index < iTween.tweens.Count; ++index)
    {
      if ((string) iTween.tweens[index][(object) "id"] == this.id)
      {
        iTween.tweens.RemoveAt(index);
        break;
      }
    }
    Object.Destroy((Object) this);
  }

  private void ConflictCheck()
  {
    foreach (iTween component in (Component[]) ((Component) this).GetComponents<iTween>())
    {
      if (component.type == "value")
        break;
      if (component.isRunning && component.type == this.type)
      {
        if (component.method != this.method)
          break;
        if (component.tweenArguments.Count != this.tweenArguments.Count)
        {
          component.Dispose();
          break;
        }
        foreach (DictionaryEntry tweenArgument in this.tweenArguments)
        {
          if (!component.tweenArguments.Contains(tweenArgument.Key))
          {
            component.Dispose();
            return;
          }
          if (!component.tweenArguments[tweenArgument.Key].Equals(this.tweenArguments[tweenArgument.Key]) && (string) tweenArgument.Key != "id")
          {
            component.Dispose();
            return;
          }
        }
        this.Dispose();
      }
    }
  }

  private void EnableKinematic()
  {
  }

  private void DisableKinematic()
  {
  }

  private void ResumeDelay() => this.StartCoroutine("TweenDelay");

  private float linear(float start, float end, float value) => Mathf.Lerp(start, end, value);

  private float clerp(float start, float end, float value)
  {
    float num1 = 0.0f;
    float num2 = 360f;
    float num3 = Mathf.Abs((float) (((double) num2 - (double) num1) * 0.5));
    float num4;
    if ((double) end - (double) start < -(double) num3)
    {
      float num5 = (num2 - start + end) * value;
      num4 = start + num5;
    }
    else if ((double) end - (double) start > (double) num3)
    {
      float num6 = (float) -((double) num2 - (double) end + (double) start) * value;
      num4 = start + num6;
    }
    else
      num4 = start + (end - start) * value;
    return num4;
  }

  private float spring(float start, float end, float value)
  {
    value = Mathf.Clamp01(value);
    value = (float) (((double) Mathf.Sin((float) ((double) value * 3.1415927410125732 * (0.20000000298023224 + 2.5 * (double) value * (double) value * (double) value))) * (double) Mathf.Pow(1f - value, 2.2f) + (double) value) * (1.0 + 1.2000000476837158 * (1.0 - (double) value)));
    return start + (end - start) * value;
  }

  private float easeInQuad(float start, float end, float value)
  {
    end -= start;
    return end * value * value + start;
  }

  private float easeOutQuad(float start, float end, float value)
  {
    end -= start;
    return (float) (-(double) end * (double) value * ((double) value - 2.0)) + start;
  }

  private float easeInOutQuad(float start, float end, float value)
  {
    value /= 0.5f;
    end -= start;
    if ((double) value < 1.0)
      return end * 0.5f * value * value + start;
    --value;
    return (float) (-(double) end * 0.5 * ((double) value * ((double) value - 2.0) - 1.0)) + start;
  }

  private float easeInCubic(float start, float end, float value)
  {
    end -= start;
    return end * value * value * value + start;
  }

  private float easeOutCubic(float start, float end, float value)
  {
    --value;
    end -= start;
    return end * (float) ((double) value * (double) value * (double) value + 1.0) + start;
  }

  private float easeInOutCubic(float start, float end, float value)
  {
    value /= 0.5f;
    end -= start;
    if ((double) value < 1.0)
      return end * 0.5f * value * value * value + start;
    value -= 2f;
    return (float) ((double) end * 0.5 * ((double) value * (double) value * (double) value + 2.0)) + start;
  }

  private float easeInQuart(float start, float end, float value)
  {
    end -= start;
    return end * value * value * value * value + start;
  }

  private float easeOutQuart(float start, float end, float value)
  {
    --value;
    end -= start;
    return (float) (-(double) end * ((double) value * (double) value * (double) value * (double) value - 1.0)) + start;
  }

  private float easeInOutQuart(float start, float end, float value)
  {
    value /= 0.5f;
    end -= start;
    if ((double) value < 1.0)
      return end * 0.5f * value * value * value * value + start;
    value -= 2f;
    return (float) (-(double) end * 0.5 * ((double) value * (double) value * (double) value * (double) value - 2.0)) + start;
  }

  private float easeInQuint(float start, float end, float value)
  {
    end -= start;
    return end * value * value * value * value * value + start;
  }

  private float easeOutQuint(float start, float end, float value)
  {
    --value;
    end -= start;
    return end * (float) ((double) value * (double) value * (double) value * (double) value * (double) value + 1.0) + start;
  }

  private float easeInOutQuint(float start, float end, float value)
  {
    value /= 0.5f;
    end -= start;
    if ((double) value < 1.0)
      return end * 0.5f * value * value * value * value * value + start;
    value -= 2f;
    return (float) ((double) end * 0.5 * ((double) value * (double) value * (double) value * (double) value * (double) value + 2.0)) + start;
  }

  private float easeInSine(float start, float end, float value)
  {
    end -= start;
    return -end * Mathf.Cos(value * 1.57079637f) + end + start;
  }

  private float easeOutSine(float start, float end, float value)
  {
    end -= start;
    return end * Mathf.Sin(value * 1.57079637f) + start;
  }

  private float easeInOutSine(float start, float end, float value)
  {
    end -= start;
    return (float) (-(double) end * 0.5 * ((double) Mathf.Cos(3.14159274f * value) - 1.0)) + start;
  }

  private float easeInExpo(float start, float end, float value)
  {
    end -= start;
    return end * Mathf.Pow(2f, (float) (10.0 * ((double) value - 1.0))) + start;
  }

  private float easeOutExpo(float start, float end, float value)
  {
    end -= start;
    return end * (float) (-(double) Mathf.Pow(2f, -10f * value) + 1.0) + start;
  }

  private float easeInOutExpo(float start, float end, float value)
  {
    value /= 0.5f;
    end -= start;
    if ((double) value < 1.0)
      return end * 0.5f * Mathf.Pow(2f, (float) (10.0 * ((double) value - 1.0))) + start;
    --value;
    return (float) ((double) end * 0.5 * (-(double) Mathf.Pow(2f, -10f * value) + 2.0)) + start;
  }

  private float easeInCirc(float start, float end, float value)
  {
    end -= start;
    return (float) (-(double) end * ((double) Mathf.Sqrt((float) (1.0 - (double) value * (double) value)) - 1.0)) + start;
  }

  private float easeOutCirc(float start, float end, float value)
  {
    --value;
    end -= start;
    return end * Mathf.Sqrt((float) (1.0 - (double) value * (double) value)) + start;
  }

  private float easeInOutCirc(float start, float end, float value)
  {
    value /= 0.5f;
    end -= start;
    if ((double) value < 1.0)
      return (float) (-(double) end * 0.5 * ((double) Mathf.Sqrt((float) (1.0 - (double) value * (double) value)) - 1.0)) + start;
    value -= 2f;
    return (float) ((double) end * 0.5 * ((double) Mathf.Sqrt((float) (1.0 - (double) value * (double) value)) + 1.0)) + start;
  }

  private float easeInBounce(float start, float end, float value)
  {
    end -= start;
    float num = 1f;
    return end - this.easeOutBounce(0.0f, end, num - value) + start;
  }

  private float easeOutBounce(float start, float end, float value)
  {
    value /= 1f;
    end -= start;
    if ((double) value < 0.36363637447357178)
      return end * (121f / 16f * value * value) + start;
    if ((double) value < 0.72727274894714355)
    {
      value -= 0.545454562f;
      return end * (float) (121.0 / 16.0 * (double) value * (double) value + 0.75) + start;
    }
    if ((double) value < 10.0 / 11.0)
    {
      value -= 0.8181818f;
      return end * (float) (121.0 / 16.0 * (double) value * (double) value + 15.0 / 16.0) + start;
    }
    value -= 0.954545438f;
    return end * (float) (121.0 / 16.0 * (double) value * (double) value + 63.0 / 64.0) + start;
  }

  private float easeInOutBounce(float start, float end, float value)
  {
    end -= start;
    float num = 1f;
    return (double) value < (double) num * 0.5 ? this.easeInBounce(0.0f, end, value * 2f) * 0.5f + start : (float) ((double) this.easeOutBounce(0.0f, end, value * 2f - num) * 0.5 + (double) end * 0.5) + start;
  }

  private float easeInBack(float start, float end, float value)
  {
    end -= start;
    value /= 1f;
    float num = 1.70158f;
    return (float) ((double) end * (double) value * (double) value * (((double) num + 1.0) * (double) value - (double) num)) + start;
  }

  private float easeOutBack(float start, float end, float value)
  {
    float num = 1.70158f;
    end -= start;
    --value;
    return end * (float) ((double) value * (double) value * (((double) num + 1.0) * (double) value + (double) num) + 1.0) + start;
  }

  private float easeInOutBack(float start, float end, float value)
  {
    float num1 = 1.70158f;
    end -= start;
    value /= 0.5f;
    if ((double) value < 1.0)
    {
      float num2 = num1 * 1.525f;
      return (float) ((double) end * 0.5 * ((double) value * (double) value * (((double) num2 + 1.0) * (double) value - (double) num2))) + start;
    }
    value -= 2f;
    float num3 = num1 * 1.525f;
    return (float) ((double) end * 0.5 * ((double) value * (double) value * (((double) num3 + 1.0) * (double) value + (double) num3) + 2.0)) + start;
  }

  private float punch(float amplitude, float value)
  {
    if ((double) value == 0.0 || (double) value == 1.0)
      return 0.0f;
    float num1 = 0.3f;
    float num2 = num1 / 6.28318548f * Mathf.Asin(0.0f);
    return amplitude * Mathf.Pow(2f, -10f * value) * Mathf.Sin((float) (((double) value * 1.0 - (double) num2) * 6.2831854820251465) / num1);
  }

  private float easeInElastic(float start, float end, float value)
  {
    end -= start;
    float num1 = 1f;
    float num2 = num1 * 0.3f;
    float num3 = 0.0f;
    if ((double) value == 0.0)
      return start;
    if ((double) (value /= num1) == 1.0)
      return start + end;
    float num4;
    if ((double) num3 == 0.0 || (double) num3 < (double) Mathf.Abs(end))
    {
      num3 = end;
      num4 = num2 / 4f;
    }
    else
      num4 = num2 / 6.28318548f * Mathf.Asin(end / num3);
    return (float) -((double) num3 * (double) Mathf.Pow(2f, 10f * --value) * (double) Mathf.Sin((float) (((double) value * (double) num1 - (double) num4) * 6.2831854820251465) / num2)) + start;
  }

  private float easeOutElastic(float start, float end, float value)
  {
    end -= start;
    float num1 = 1f;
    float num2 = num1 * 0.3f;
    float num3 = 0.0f;
    if ((double) value == 0.0)
      return start;
    if ((double) (value /= num1) == 1.0)
      return start + end;
    float num4;
    if ((double) num3 == 0.0 || (double) num3 < (double) Mathf.Abs(end))
    {
      num3 = end;
      num4 = num2 * 0.25f;
    }
    else
      num4 = num2 / 6.28318548f * Mathf.Asin(end / num3);
    return num3 * Mathf.Pow(2f, -10f * value) * Mathf.Sin((float) (((double) value * (double) num1 - (double) num4) * 6.2831854820251465) / num2) + end + start;
  }

  private float easeInOutElastic(float start, float end, float value)
  {
    end -= start;
    float num1 = 1f;
    float num2 = num1 * 0.3f;
    float num3 = 0.0f;
    if ((double) value == 0.0)
      return start;
    if ((double) (value /= num1 * 0.5f) == 2.0)
      return start + end;
    float num4;
    if ((double) num3 == 0.0 || (double) num3 < (double) Mathf.Abs(end))
    {
      num3 = end;
      num4 = num2 / 4f;
    }
    else
      num4 = num2 / 6.28318548f * Mathf.Asin(end / num3);
    return (double) value < 1.0 ? (float) (-0.5 * ((double) num3 * (double) Mathf.Pow(2f, 10f * --value) * (double) Mathf.Sin((float) (((double) value * (double) num1 - (double) num4) * 6.2831854820251465) / num2))) + start : (float) ((double) num3 * (double) Mathf.Pow(2f, -10f * --value) * (double) Mathf.Sin((float) (((double) value * (double) num1 - (double) num4) * 6.2831854820251465) / num2) * 0.5) + end + start;
  }

  public enum EaseType
  {
    easeInQuad,
    easeOutQuad,
    easeInOutQuad,
    easeInCubic,
    easeOutCubic,
    easeInOutCubic,
    easeInQuart,
    easeOutQuart,
    easeInOutQuart,
    easeInQuint,
    easeOutQuint,
    easeInOutQuint,
    easeInSine,
    easeOutSine,
    easeInOutSine,
    easeInExpo,
    easeOutExpo,
    easeInOutExpo,
    easeInCirc,
    easeOutCirc,
    easeInOutCirc,
    linear,
    spring,
    easeInBounce,
    easeOutBounce,
    easeInOutBounce,
    easeInBack,
    easeOutBack,
    easeInOutBack,
    easeInElastic,
    easeOutElastic,
    easeInOutElastic,
    punch,
  }

  public enum LoopType
  {
    none,
    loop,
    pingPong,
  }

  public enum NamedValueColor
  {
    _Color,
    _SpecColor,
    _Emission,
    _ReflectColor,
  }

  public static class Defaults
  {
    public static float time = 1f;
    public static float delay = 0.0f;
    public static iTween.NamedValueColor namedColorValue = iTween.NamedValueColor._Color;
    public static iTween.LoopType loopType = iTween.LoopType.none;
    public static iTween.EaseType easeType = iTween.EaseType.easeOutExpo;
    public static float lookSpeed = 3f;
    public static bool isLocal = false;
    public static Space space = (Space) 1;
    public static bool orientToPath = false;
    public static Color color = Color.white;
    public static float updateTimePercentage = 0.05f;
    public static float updateTime = 1f * iTween.Defaults.updateTimePercentage;
    public static int cameraFadeDepth = 999999;
    public static float lookAhead = 0.05f;
    public static bool useRealTime = false;
    public static Vector3 up = Vector3.up;
  }

  private class CRSpline
  {
    public Vector3[] pts;

    public CRSpline(params Vector3[] pts)
    {
      this.pts = new Vector3[pts.Length];
      Array.Copy((Array) pts, (Array) this.pts, pts.Length);
    }

    public Vector3 Interp(float t)
    {
      int num1 = this.pts.Length - 3;
      int index = Mathf.Min(Mathf.FloorToInt(t * (float) num1), num1 - 1);
      float num2 = t * (float) num1 - (float) index;
      Vector3 pt1 = this.pts[index];
      Vector3 pt2 = this.pts[index + 1];
      Vector3 pt3 = this.pts[index + 2];
      Vector3 pt4 = this.pts[index + 3];
      return Vector3.op_Multiply(0.5f, Vector3.op_Addition(Vector3.op_Addition(Vector3.op_Addition(Vector3.op_Multiply(Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Addition(Vector3.op_UnaryNegation(pt1), Vector3.op_Multiply(3f, pt2)), Vector3.op_Multiply(3f, pt3)), pt4), num2 * num2 * num2), Vector3.op_Multiply(Vector3.op_Subtraction(Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Multiply(2f, pt1), Vector3.op_Multiply(5f, pt2)), Vector3.op_Multiply(4f, pt3)), pt4), num2 * num2)), Vector3.op_Multiply(Vector3.op_Addition(Vector3.op_UnaryNegation(pt1), pt3), num2)), Vector3.op_Multiply(2f, pt2)));
    }
  }

  private delegate float EasingFunction(float start, float end, float Value);

  private delegate void ApplyTween();
}
