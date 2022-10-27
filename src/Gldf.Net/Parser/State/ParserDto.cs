using Gldf.Net.Container;
using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using System.Collections.Generic;

namespace Gldf.Net.Parser.State
{
    public class ParserDto<T> where T : TypedBase
    {

        public bool LoadFileContent { get; set; }

        public GldfContainer Container { get; set; }

        public ICollection<T> Items { get; set; } = new List<T>();

        public ParserDto(ContainerDto containerDto)
        {
            Container = containerDto.Container;
            LoadFileContent = containerDto.LoadFileContent;
        }

        public ParserDto(ParserDto<GldfFileTyped> containerDto)
        {
            Container = containerDto.Container;
            LoadFileContent = containerDto.LoadFileContent;
        }
    }
}