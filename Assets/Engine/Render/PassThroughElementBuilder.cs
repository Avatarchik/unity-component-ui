﻿using UnityEngine;

namespace Assets.Engine.Render
{
    public class PassThroughElementBuilder : IRootElementBuilder
    {
        private IRootElementBuilder childBuilder;

        public PassThroughElementBuilder(IRootElementBuilder builder)
        {
            childBuilder = builder;
        }

        public GameObject Build(IRootElementBuilder previousBuilder)
        {
            var previousPassThroughBuilder = (previousBuilder as PassThroughElementBuilder);
            var previousChildBuilder = previousPassThroughBuilder?.childBuilder;

            return childBuilder.Build(previousChildBuilder);
        }
    }
}
