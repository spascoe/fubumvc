using System;
using System.Collections.Generic;
using System.Text;
using FubuMVC.Core.Assets.Files;
using System.Linq;

namespace FubuMVC.Core.Assets.Content
{
    public class Combination : IContentSource
    {
        private readonly IEnumerable<IContentSource> _innerSources;
        public static readonly string Separator = Environment.NewLine + Environment.NewLine;

        public Combination(IEnumerable<IContentSource> innerSources)
        {
            _innerSources = innerSources;
        }

        public string GetContent(IContentPipeline pipeline)
        {
            var builder = new StringBuilder();
            _innerSources.Select(x => x.GetContent(pipeline)).Each(content =>
            {
                builder.AppendLine(content);
                builder.AppendLine();
            });

            return builder.ToString().TrimEnd();
        }

        public IEnumerable<AssetFile> Files
        {
            get { return _innerSources.SelectMany(x => x.Files); }
        }

        public IEnumerable<IContentSource> InnerSources
        {
            get { return _innerSources; }
        }

        public override string ToString()
        {
            return "Combination";
        }
    }
}