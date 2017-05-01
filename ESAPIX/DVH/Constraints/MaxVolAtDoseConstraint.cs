﻿#region

using ESAPIX.Facade.Types;

#endregion

namespace ESAPIX.DVH.Constraints
{
    public class MaxVolAtDoseConstraint : VolumeAtDoseConstraint
    {
        public MaxVolAtDoseConstraint()
        {
            PassingFunc = vol => { return vol <= Volume ? ResultType.PASSED : GetFailedResultType(); };
        }

        public override string ToString()
        {
            //Mayo format
            var vol = Volume.ToString().Replace(",", "");
            var volUnit = VolumeType == VolumePresentation.AbsoluteCm3 ? "cc" : "%";
            var doseUnit = ConstraintDose.UnitAsString;
            var dose = ConstraintDose.ValueAsString;
            return $"V{dose}{doseUnit}[{volUnit}] <= {vol}";
        }
    }
}