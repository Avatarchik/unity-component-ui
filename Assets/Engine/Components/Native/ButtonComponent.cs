﻿using System.Collections.Generic;
using Assets.Engine.Render;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Engine.Components.Native
{
    public class ButtonComponent : BaseNativeComponent
    {
        public override void Render(GameObjectElementBuilder builder, IDictionary<string, object> props)
        {
            var canvasRenderer = builder.AddComponent<CanvasRenderer>();
            var image = builder.AddComponent<Image>();

            image.SetProperty(e => e.color, Color.blue);
        }
    }
}
