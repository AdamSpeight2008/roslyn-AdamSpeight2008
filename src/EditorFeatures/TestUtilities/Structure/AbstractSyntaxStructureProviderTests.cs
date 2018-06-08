﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Editor.UnitTests.Workspaces;
using Microsoft.CodeAnalysis.Structure;
using Microsoft.CodeAnalysis.Test.Utilities;
using Microsoft.CodeAnalysis.Text;
using Xunit;

namespace Microsoft.CodeAnalysis.Editor.UnitTests.Structure
{
    [UseExportProvider]
    public abstract class AbstractSyntaxStructureProviderTests
    {
        protected abstract string LanguageName { get; }

        protected virtual string WorkspaceKind => CodeAnalysis.WorkspaceKind.Test;

        private Task<ImmutableArray<BlockSpan>> GetBlockSpansAsync(Document document, int position)
        {
            return GetBlockSpansWorkerAsync(document, position);
        }

        internal abstract Task<ImmutableArray<BlockSpan>> GetBlockSpansWorkerAsync(Document document, int position);

        protected async Task VerifyBlockSpansAsync(string markupCode, params Tuple<string, string, string, bool, bool>[] expectedRegionData)
        {
            using (var workspace = TestWorkspace.Create(WorkspaceKind, LanguageName, compilationOptions: null, parseOptions: null, content: markupCode))
            {
                var hostDocument = workspace.Documents.Single();
                workspace.Options = workspace.Options.WithChangedOption(
                    BlockStructureOptions.MaximumBannerLength, LanguageName, 120);
                Assert.True(hostDocument.CursorPosition.HasValue, "Test must specify a position.");
                var position = hostDocument.CursorPosition.Value;

                var expectedRegions = expectedRegionData.Select(data => CreateBlockSpan(data, hostDocument.AnnotatedSpans)).ToArray();

                var document = workspace.CurrentSolution.GetDocument(hostDocument.Id);
                var actualRegions = await GetBlockSpansAsync(document, position);

                Assert.True(expectedRegions.Length == actualRegions.Length, $"Expected {expectedRegions.Length} regions but there were {actualRegions.Length}");

                for (int i = 0; i < expectedRegions.Length; i++)
                {
                    AssertRegion(expectedRegions[i], actualRegions[i]);
                }
            }
        }

        protected async Task VerifyNoBlockSpansAsync(string markupCode)
        {
            using (var workspace = TestWorkspace.Create(WorkspaceKind, LanguageName, compilationOptions: null, parseOptions: null, content: markupCode))
            {
                var hostDocument = workspace.Documents.Single();
                Assert.True(hostDocument.CursorPosition.HasValue, "Test must specify a position.");
                var position = hostDocument.CursorPosition.Value;

                var document = workspace.CurrentSolution.GetDocument(hostDocument.Id);
                var actualRegions = await GetBlockSpansAsync(document, position);

                Assert.True(actualRegions.Length == 0, $"Expected no regions but found {actualRegions.Length}.");
            }
        }

        protected Tuple<string, string, string, bool, bool> Region(string textSpanName, string hintSpanName, string bannerText, bool autoCollapse, bool isDefaultCollapsed = false)
        {
            return Tuple.Create(textSpanName, hintSpanName, bannerText, autoCollapse, isDefaultCollapsed);
        }

        protected Tuple<string, string, string, bool, bool> Region(string textSpanName, string bannerText, bool autoCollapse, bool isDefaultCollapsed = false)
        {
            return Tuple.Create(textSpanName, textSpanName, bannerText, autoCollapse, isDefaultCollapsed);
        }

        private static BlockSpan CreateBlockSpan(
            Tuple<string, string, string, bool, bool> regionData,
            IDictionary<string, ImmutableArray<TextSpan>> spans)
        {
            var textSpanName = regionData.Item1;
            var hintSpanName = regionData.Item2;
            var bannerText = regionData.Item3;
            var autoCollapse = regionData.Item4;
            var isDefaultCollapsed = regionData.Item5;

            Assert.True(spans.ContainsKey(textSpanName) && spans[textSpanName].Length == 1, $"Test did not specify '{textSpanName}' span.");
            Assert.True(spans.ContainsKey(hintSpanName) && spans[hintSpanName].Length == 1, $"Test did not specify '{hintSpanName}' span.");

            var textSpan = spans[textSpanName][0];
            var hintSpan = spans[hintSpanName][0];

            return new BlockSpan(isCollapsible: true,
                textSpan: textSpan, 
                hintSpan: hintSpan,
                type: BlockTypes.Nonstructural,
                bannerText: bannerText,
                autoCollapse: autoCollapse, 
                isDefaultCollapsed: isDefaultCollapsed);
        }

        internal static void AssertRegion(BlockSpan expected, BlockSpan actual)
        {
            Assert_TextSpan_Start(expected.TextSpan.Start, actual.TextSpan.Start);
            Assert_TextSpan_End(expected.TextSpan.End, actual.TextSpan.End);
            Assert_HintSpan_Start(expected.HintSpan.Start, actual.HintSpan.Start);
            Assert_HintSpan_End(expected.HintSpan.End, actual.HintSpan.End);
            Assert_BannerText(expected.BannerText, actual.BannerText);
            Assert_AutoCollapse(expected.AutoCollapse, actual.AutoCollapse);
            Assert_IsDefaultCollapsed(expected.IsDefaultCollapsed, actual.IsDefaultCollapsed);
        }

        internal static void Assert_TextSpan_Start(int expected, int actual) => Assert.True(expected == actual, $".TextSpan.Start is different. (Expected:{expected}, Actual:{actual})");
        internal static void Assert_TextSpan_End(int expected, int actual)=> Assert.True(expected == actual, $".TextSpan.End (Expected:{expected}, Actual:{actual})");
        internal static void Assert_HintSpan_Start(int expected, int actual) => Assert.True(expected == actual, $".HintSpan.Start is different. (Expected:{expected}, Actual:{actual})");
        internal static void Assert_HintSpan_End(int expected, int actual) => Assert.True(expected == actual, $".HintSpan.End is different. (Expected:{expected}, Actual:{actual})");
        internal static void Assert_BannerText(string expected, string actual) => Assert.True(expected == actual, $".BannerText is different. (Expected:{expected}, Actual:{actual})");
        internal static void Assert_AutoCollapse(bool expected, bool actual) => Assert.True(expected == actual, $".AutoCollapse is different. (Expected:{expected}, Actual:{actual})");
        internal static void Assert_IsDefaultCollapsed(bool expected, bool actual) => Assert.True(expected == actual, $".IsDefaultCollapsed is different. (Expected:{expected}, Actual:{actual})");
    }
}
