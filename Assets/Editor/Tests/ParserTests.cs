﻿using System;
using Assets.Editor.Language;
using NUnit.Framework;

namespace Tests
{
    public class ParserTests
    {
        private readonly Parser parser = new Parser();

        [Test]
        public void TemplateWithOneComponentSelfTerminating()
        {
            var ast = parser.Parse(@"
template: {
    <Container />
}");
            Assert.AreEqual("Container", ast.Template.RootNode.Name);
        }

        [Test]
        public void TemplateWithOneComponent()
        {
            var ast = parser.Parse(@"
template: {
    <Container></Container>
}");
            Assert.AreEqual("Container", ast.Template.RootNode.Name);
        }

        [Test]
        public void TemplateWithNestedComponent()
        {
            var ast = parser.Parse(@"
template: {
    <Container><Nested /></Container>
}");
            Assert.AreEqual("Container", ast.Template.RootNode.Name);
            Assert.AreEqual("Nested", ast.Template.RootNode.Children[0].Name);
        }

        [Test]
        public void TemplateWithDeeplyNestedComponent()
        {
            var ast = parser.Parse(@"
template: {
    <Container><Nested><Nested2><Nested3><Nested4></Nested4></Nested3></Nested2></Nested></Container>
}");
            Assert.AreEqual("Container", ast.Template.RootNode.Name);
            Assert.AreEqual("Nested", ast.Template.RootNode.Children[0].Name);
            Assert.AreEqual("Nested2", ast.Template.RootNode.Children[0].Children[0].Name);
            Assert.AreEqual("Nested3", ast.Template.RootNode.Children[0].Children[0].Children[0].Name);
            Assert.AreEqual("Nested4", ast.Template.RootNode.Children[0].Children[0].Children[0].Children[0].Name);
        }

        [Test]
        public void TemplateWithMultipleChildren()
        {
            var ast = parser.Parse(@"
template: {
    <Container><Nested /><Nested2 /><Nested3 /></Container>
}");
            Assert.AreEqual("Container", ast.Template.RootNode.Name);
            Assert.AreEqual("Nested", ast.Template.RootNode.Children[0].Name);
            Assert.AreEqual("Nested2", ast.Template.RootNode.Children[1].Name);
            Assert.AreEqual("Nested3", ast.Template.RootNode.Children[2].Name);
        }

        [Test]
        public void TemplateWithMultipleNestedChildren()
        {
            var ast = parser.Parse(@"
template: {
    <Container><Nested /><Nested2 /><Nested3><Nested4 /><Nested5><Nested6></Nested6></Nested5></Nested3></Container>
}");
            Assert.AreEqual("Container", ast.Template.RootNode.Name);
            Assert.AreEqual("Nested", ast.Template.RootNode.Children[0].Name);
            Assert.AreEqual("Nested2", ast.Template.RootNode.Children[1].Name);
            Assert.AreEqual("Nested3", ast.Template.RootNode.Children[2].Name);
            Assert.AreEqual("Nested4", ast.Template.RootNode.Children[2].Children[0].Name);
            Assert.AreEqual("Nested5", ast.Template.RootNode.Children[2].Children[1].Name);
            Assert.AreEqual("Nested6", ast.Template.RootNode.Children[2].Children[1].Children[0].Name);
        }

        [Test]
        public void TemplateWithOneComponentAndOneProp()
        {
            var ast = parser.Parse(@"
props: {
    iterations: ""System.Int32""
}
template: {
    <Container />
}");
            Assert.AreEqual("Container", ast.Template.RootNode.Name);

            Assert.AreEqual("iterations", ast.Props[0].Name);
            Assert.AreEqual(typeof(Int32), ast.Props[0].Type);
        }

        [Test]
        public void TemplateWithOneComponentAndMultipleProps()
        {
            var ast = parser.Parse(@"
props: {
    someInt: ""System.Int32""
    someString: ""System.String""
    someSingle: ""System.Single""
    someDouble: ""System.Double""
    someDateTime: ""System.DateTime""
}
template: {
    <Container />
}");
            Assert.AreEqual("Container", ast.Template.RootNode.Name);

            Assert.AreEqual("someInt", ast.Props[0].Name);
            Assert.AreEqual(typeof(Int32), ast.Props[0].Type);

            Assert.AreEqual("someString", ast.Props[1].Name);
            Assert.AreEqual(typeof(String), ast.Props[1].Type);

            Assert.AreEqual("someSingle", ast.Props[2].Name);
            Assert.AreEqual(typeof(Single), ast.Props[2].Type);

            Assert.AreEqual("someDouble", ast.Props[3].Name);
            Assert.AreEqual(typeof(Double), ast.Props[3].Type);

            Assert.AreEqual("someDateTime", ast.Props[4].Name);
            Assert.AreEqual(typeof(DateTime), ast.Props[4].Type);
        }
    }
}
