﻿using System;
namespace SourceConsole.Templates
{
    public interface ITemplate
    {
        string TransformText();
        SourceEnum TemplateEnum();
        string GetFileName();
    }
}
