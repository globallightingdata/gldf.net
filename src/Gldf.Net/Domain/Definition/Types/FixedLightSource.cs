namespace Gldf.Net.Domain.Definition.Types
{
    public class FixedLightSource : LightSourceType
    {
        public bool? ZhagaStandard { get; set; }

        public bool ShouldSerializeZhagaStandard() => ZhagaStandard != null;
    }
}