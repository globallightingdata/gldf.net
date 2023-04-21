using System;

namespace Gldf.Net.Validation.Model;

[Flags]
public enum ValidationFlags
{
    Zip = 1,
    Container = 2,
    Schema = 4,
    All = 7
}