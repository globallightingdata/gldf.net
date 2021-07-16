﻿using Gldf.Net.Domain.Descriptive.Types;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Descriptive
{
    public class Electrical
    {
        public ClampingRange ClampingRange { get; set; }

        public string SwitchingCapacity { get; set; }

        public SafetyClass? ElectricalSafetyClass { get; set; }

        public IngressProtectionIPCode? IngressProtectionIPCode { get; set; }

        public IKRating? IKRating { get; set; }

        public double? PowerFactor { get; set; }

        public bool? ConstantLightOutput { get; set; }

        public bool ShouldSerializeElectricalSafetyClass() => ElectricalSafetyClass != null;

        public bool ShouldSerializeIngressProtectionIPCode() => IngressProtectionIPCode != null;

        public bool ShouldSerializeIKRating() => IKRating != null;

        public bool ShouldSerializePowerFactor() => PowerFactor != null;

        public bool ShouldSerializeConstantLightOutput() => ConstantLightOutput != null;
    }
}