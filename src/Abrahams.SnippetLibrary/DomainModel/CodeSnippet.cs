﻿using System.Collections.Generic;

namespace Abrahams.SnippetLibrary.DomainModel
{
    public class CodeSnippet
    {
        public string Description { get; set; }
        public string CodeSample { get; set; }
        public Language Language { get; set; }
        public List<Tag> Tags { get; } = new List<Tag>();
        // TODO: Switch to nullable reference types c# 8 features
    }
}
