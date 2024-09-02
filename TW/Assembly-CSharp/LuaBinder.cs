// Decompiled with JetBrains decompiler
// Type: LuaBinder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
public static class LuaBinder
{
  public static List<string> wrapList = new List<string>();

  public static void Bind(IntPtr L, string type = null)
  {
    if (type == null || LuaBinder.wrapList.Contains(type))
      return;
    LuaBinder.wrapList.Add(type);
    type += "Wrap";
    string key = type;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (LuaBinder.\u003C\u003Ef__switch\u0024map29 == null)
    {
      // ISSUE: reference to a compiler-generated field
      LuaBinder.\u003C\u003Ef__switch\u0024map29 = new Dictionary<string, int>(80)
      {
        {
          "AnimationBlendModeWrap",
          0
        },
        {
          "AnimationClipWrap",
          1
        },
        {
          "AnimationStateWrap",
          2
        },
        {
          "AnimationWrap",
          3
        },
        {
          "AppConstWrap",
          4
        },
        {
          "ApplicationWrap",
          5
        },
        {
          "AssetBundleWrap",
          6
        },
        {
          "AsyncOperationWrap",
          7
        },
        {
          "AudioClipWrap",
          8
        },
        {
          "AudioSourceWrap",
          9
        },
        {
          "BehaviourWrap",
          10
        },
        {
          "BlendWeightsWrap",
          11
        },
        {
          "BoxColliderWrap",
          12
        },
        {
          "CameraClearFlagsWrap",
          13
        },
        {
          "CameraWrap",
          14
        },
        {
          "CharacterControllerWrap",
          15
        },
        {
          "ColliderWrap",
          16
        },
        {
          "ComponentWrap",
          17
        },
        {
          "DebuggerWrap",
          18
        },
        {
          "DelegateFactoryWrap",
          19
        },
        {
          "DelegateWrap",
          20
        },
        {
          "EnumWrap",
          21
        },
        {
          "GameObjectWrap",
          22
        },
        {
          "IEnumeratorWrap",
          23
        },
        {
          "InputWrap",
          24
        },
        {
          "KeyCodeWrap",
          25
        },
        {
          "LightTypeWrap",
          26
        },
        {
          "LightWrap",
          27
        },
        {
          "LocalizationWrap",
          28
        },
        {
          "MaterialWrap",
          29
        },
        {
          "MeshColliderWrap",
          30
        },
        {
          "MeshRendererWrap",
          31
        },
        {
          "MonoBehaviourWrap",
          32
        },
        {
          "NGUIToolsWrap",
          33
        },
        {
          "ObjectWrap",
          34
        },
        {
          "ParticleAnimatorWrap",
          35
        },
        {
          "ParticleEmitterWrap",
          36
        },
        {
          "ParticleRendererWrap",
          37
        },
        {
          "ParticleSystemWrap",
          38
        },
        {
          "PhysicsWrap",
          39
        },
        {
          "PlayModeWrap",
          40
        },
        {
          "QualitySettingsWrap",
          41
        },
        {
          "QueueModeWrap",
          42
        },
        {
          "RectTransformWrap",
          43
        },
        {
          "RenderSettingsWrap",
          44
        },
        {
          "RenderTextureWrap",
          45
        },
        {
          "RendererWrap",
          46
        },
        {
          "ScreenWrap",
          47
        },
        {
          "SkinnedMeshRendererWrap",
          48
        },
        {
          "SleepTimeoutWrap",
          49
        },
        {
          "SpaceWrap",
          50
        },
        {
          "SphereColliderWrap",
          51
        },
        {
          "System_ObjectWrap",
          52
        },
        {
          "TextureWrap",
          53
        },
        {
          "TimeWrap",
          54
        },
        {
          "TouchPhaseWrap",
          55
        },
        {
          "TrackedReferenceWrap",
          56
        },
        {
          "TransformWrap",
          57
        },
        {
          "TweenPositionWrap",
          58
        },
        {
          "TweenRotationWrap",
          59
        },
        {
          "TweenScaleWrap",
          60
        },
        {
          "TweenWidthWrap",
          61
        },
        {
          "TypeWrap",
          62
        },
        {
          "UIAtlasWrap",
          63
        },
        {
          "UICameraWrap",
          64
        },
        {
          "UICenterOnChildWrap",
          65
        },
        {
          "UIGridWrap",
          66
        },
        {
          "UIInputWrap",
          67
        },
        {
          "UILabelWrap",
          68
        },
        {
          "UIProgressBarWrap",
          69
        },
        {
          "UIRectWrap",
          70
        },
        {
          "UISliderWrap",
          71
        },
        {
          "UISpriteWrap",
          72
        },
        {
          "UITextureWrap",
          73
        },
        {
          "UIToggleWrap",
          74
        },
        {
          "UITweenerWrap",
          75
        },
        {
          "UIWidgetContainerWrap",
          76
        },
        {
          "UIWidgetWrap",
          77
        },
        {
          "UtilWrap",
          78
        },
        {
          "stringWrap",
          79
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!LuaBinder.\u003C\u003Ef__switch\u0024map29.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        AnimationBlendModeWrap.Register(L);
        break;
      case 1:
        AnimationClipWrap.Register(L);
        break;
      case 2:
        AnimationStateWrap.Register(L);
        break;
      case 3:
        AnimationWrap.Register(L);
        break;
      case 4:
        AppConstWrap.Register(L);
        break;
      case 5:
        ApplicationWrap.Register(L);
        break;
      case 6:
        AssetBundleWrap.Register(L);
        break;
      case 7:
        AsyncOperationWrap.Register(L);
        break;
      case 8:
        AudioClipWrap.Register(L);
        break;
      case 9:
        AudioSourceWrap.Register(L);
        break;
      case 10:
        BehaviourWrap.Register(L);
        break;
      case 11:
        BlendWeightsWrap.Register(L);
        break;
      case 12:
        BoxColliderWrap.Register(L);
        break;
      case 13:
        CameraClearFlagsWrap.Register(L);
        break;
      case 14:
        CameraWrap.Register(L);
        break;
      case 15:
        CharacterControllerWrap.Register(L);
        break;
      case 16:
        ColliderWrap.Register(L);
        break;
      case 17:
        ComponentWrap.Register(L);
        break;
      case 18:
        DebuggerWrap.Register(L);
        break;
      case 19:
        DelegateFactoryWrap.Register(L);
        break;
      case 20:
        DelegateWrap.Register(L);
        break;
      case 21:
        EnumWrap.Register(L);
        break;
      case 22:
        GameObjectWrap.Register(L);
        break;
      case 23:
        IEnumeratorWrap.Register(L);
        break;
      case 24:
        InputWrap.Register(L);
        break;
      case 25:
        KeyCodeWrap.Register(L);
        break;
      case 26:
        LightTypeWrap.Register(L);
        break;
      case 27:
        LightWrap.Register(L);
        break;
      case 28:
        LocalizationWrap.Register(L);
        break;
      case 29:
        MaterialWrap.Register(L);
        break;
      case 30:
        MeshColliderWrap.Register(L);
        break;
      case 31:
        MeshRendererWrap.Register(L);
        break;
      case 32:
        MonoBehaviourWrap.Register(L);
        break;
      case 33:
        NGUIToolsWrap.Register(L);
        break;
      case 34:
        ObjectWrap.Register(L);
        break;
      case 35:
        ParticleAnimatorWrap.Register(L);
        break;
      case 36:
        ParticleEmitterWrap.Register(L);
        break;
      case 37:
        ParticleRendererWrap.Register(L);
        break;
      case 38:
        ParticleSystemWrap.Register(L);
        break;
      case 39:
        PhysicsWrap.Register(L);
        break;
      case 40:
        PlayModeWrap.Register(L);
        break;
      case 41:
        QualitySettingsWrap.Register(L);
        break;
      case 42:
        QueueModeWrap.Register(L);
        break;
      case 43:
        RectTransformWrap.Register(L);
        break;
      case 44:
        RenderSettingsWrap.Register(L);
        break;
      case 45:
        RenderTextureWrap.Register(L);
        break;
      case 46:
        RendererWrap.Register(L);
        break;
      case 47:
        ScreenWrap.Register(L);
        break;
      case 48:
        SkinnedMeshRendererWrap.Register(L);
        break;
      case 49:
        SleepTimeoutWrap.Register(L);
        break;
      case 50:
        SpaceWrap.Register(L);
        break;
      case 51:
        SphereColliderWrap.Register(L);
        break;
      case 52:
        System_ObjectWrap.Register(L);
        break;
      case 53:
        TextureWrap.Register(L);
        break;
      case 54:
        TimeWrap.Register(L);
        break;
      case 55:
        TouchPhaseWrap.Register(L);
        break;
      case 56:
        TrackedReferenceWrap.Register(L);
        break;
      case 57:
        TransformWrap.Register(L);
        break;
      case 58:
        TweenPositionWrap.Register(L);
        break;
      case 59:
        TweenRotationWrap.Register(L);
        break;
      case 60:
        TweenScaleWrap.Register(L);
        break;
      case 61:
        TweenWidthWrap.Register(L);
        break;
      case 62:
        TypeWrap.Register(L);
        break;
      case 63:
        UIAtlasWrap.Register(L);
        break;
      case 64:
        UICameraWrap.Register(L);
        break;
      case 65:
        UICenterOnChildWrap.Register(L);
        break;
      case 66:
        UIGridWrap.Register(L);
        break;
      case 67:
        UIInputWrap.Register(L);
        break;
      case 68:
        UILabelWrap.Register(L);
        break;
      case 69:
        UIProgressBarWrap.Register(L);
        break;
      case 70:
        UIRectWrap.Register(L);
        break;
      case 71:
        UISliderWrap.Register(L);
        break;
      case 72:
        UISpriteWrap.Register(L);
        break;
      case 73:
        UITextureWrap.Register(L);
        break;
      case 74:
        UIToggleWrap.Register(L);
        break;
      case 75:
        UITweenerWrap.Register(L);
        break;
      case 76:
        UIWidgetContainerWrap.Register(L);
        break;
      case 77:
        UIWidgetWrap.Register(L);
        break;
      case 78:
        UtilWrap.Register(L);
        break;
      case 79:
        stringWrap.Register(L);
        break;
    }
  }
}
