using Gldf.Net.Domain.Typed.Definition;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser.Extensions;

public static class EquipmentExtensions
{
    public static EquipmentTyped GetTyped(this IEnumerable<EquipmentTyped> equipments, string id) =>
        equipments.FirstOrDefault(equipment => equipment.Id.Equals(id, StringComparison.Ordinal));
}