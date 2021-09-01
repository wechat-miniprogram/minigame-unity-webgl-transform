////////////////////////////////////////////////////////////////////////////////

using Markdig.Renderers;
using Markdig.Syntax.Inlines;

namespace WeChatWASM.MDV
{
    ////////////////////////////////////////////////////////////////////////////////
    // <code>...</code>
    /// <see cref="Markdig.Renderers.Html.Inlines.CodeInlineRenderer"/>

    public class RendererInlineCode : MarkdownObjectRenderer<RendererMarkdown, CodeInline>
    {
        protected override void Write( RendererMarkdown renderer, CodeInline node )
        {
            var prevStyle = renderer.Style;
            renderer.Style.Fixed = true;
            renderer.Text( node.Content );
            renderer.Style = prevStyle;
        }
    }
}
