namespace Gldf.Net.Tests.TestHelper
{
    public static class AssertionExtensions
    {
        public static XmlStringAssertions ShouldBe(this string xml)
        {
            return new(xml);
        }
    }
}