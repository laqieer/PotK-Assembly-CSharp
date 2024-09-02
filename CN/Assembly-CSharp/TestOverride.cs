// Decompiled with JetBrains decompiler
// Type: TestOverride
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TestOverride
{
  public int Test(object o, string str)
  {
    Debug.Log((object) "call Test(object o, string str)");
    return 1;
  }

  public int Test(char c)
  {
    Debug.Log((object) "call Test(char c)");
    return 2;
  }

  public int Test(int i)
  {
    Debug.Log((object) "call Test(int i)");
    return 3;
  }

  public int Test(double d)
  {
    Debug.Log((object) "call Test(double d)");
    return 4;
  }

  public int Test(int i, int j)
  {
    Debug.Log((object) "call Test(int i, int j)");
    return 5;
  }

  public int Test(string str)
  {
    Debug.Log((object) "call Test(string str)");
    return 6;
  }

  public static int Test(string str1, string str2)
  {
    Debug.Log((object) "call static Test(string str1, string str2)");
    return 7;
  }

  public int Test(object o)
  {
    Debug.Log((object) "call Test(object o)");
    return 8;
  }

  public int Test(params object[] objs)
  {
    Debug.Log((object) "call Test(params object[] objs)");
    return 9;
  }

  public int Test(TestOverride.Space e)
  {
    Debug.Log((object) "call Test(TestEnum e)");
    return 10;
  }

  public enum Space
  {
    World = 1,
  }
}
