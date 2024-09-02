// Decompiled with JetBrains decompiler
// Type: CriMana.Detail.AutoResisterRendererResourceFactories
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace CriMana.Detail
{
  public static class AutoResisterRendererResourceFactories
  {
    public static void InvokeAutoRegister()
    {
      foreach (Type nestedType in typeof (AutoResisterRendererResourceFactories).GetNestedTypes(BindingFlags.Public))
      {
        if (!nestedType.IsSubclassOf(typeof (RendererResourceFactory)))
        {
          Debug.LogError((object) ("[CRIWARE] internal logic error. " + nestedType.Name + " is required to be a subclass of RendererResourceFactory."));
        }
        else
        {
          RendererResourceFactoryPriorityAttribute customAttribute = (RendererResourceFactoryPriorityAttribute) Attribute.GetCustomAttribute((MemberInfo) nestedType, typeof (RendererResourceFactoryPriorityAttribute));
          if (customAttribute == null)
            Debug.LogError((object) ("[CRIWARE] internal logic error. need priority attribute. (" + nestedType.Name + ")"));
          else
            RendererResourceFactory.RegisterFactory((RendererResourceFactory) Activator.CreateInstance(nestedType), customAttribute.priority);
        }
      }
    }

    [RendererResourceFactoryPriority(7000)]
    public class RendererResourceFactoryAndroidH264Rgb : RendererResourceFactory
    {
      public override RendererResource CreateRendererResource(
        int playerId,
        MovieInfo movieInfo,
        bool additive,
        Shader userShader)
      {
        bool flag1 = movieInfo.codecType == CodecType.H264;
        bool flag2 = !movieInfo.hasAlpha;
        return flag1 && flag2 ? (RendererResource) new RendererResourceAndroidH264Rgb(playerId, movieInfo, additive, userShader) : (RendererResource) null;
      }

      protected override void OnDisposeManaged()
      {
      }

      protected override void OnDisposeUnmanaged()
      {
      }
    }

    [RendererResourceFactoryPriority(5000)]
    public class RendererResourceFactorySofdecPrimeYuv : RendererResourceFactory
    {
      public override RendererResource CreateRendererResource(
        int playerId,
        MovieInfo movieInfo,
        bool additive,
        Shader userShader)
      {
        return movieInfo.codecType == CodecType.SofdecPrime ? (RendererResource) new RendererResourceSofdecPrimeYuv(playerId, movieInfo, additive, userShader) : (RendererResource) null;
      }

      protected override void OnDisposeManaged()
      {
      }

      protected override void OnDisposeUnmanaged()
      {
      }
    }
  }
}
