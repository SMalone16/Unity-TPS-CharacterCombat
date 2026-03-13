using System;
using System.Collections.Generic;
using NUnit.Framework;

public class StateFactoryTests
{
    [Test]
    public void Factory_Returns_NonNull_CoreStates()
    {
        var factory = new PlayerStateFactory(null);

        Assert.NotNull(factory.Grounded());
        Assert.NotNull(factory.Attack());
        Assert.NotNull(factory.Skill());
        Assert.NotNull(factory.Dash());
    }

    [Test]
    public void Factory_Uses_Unique_StateClass_Types_ForCoreFlow()
    {
        var factory = new PlayerStateFactory(null);
        var coreTypes = new HashSet<Type>
        {
            factory.Idle().GetType(),
            factory.Walk().GetType(),
            factory.Run().GetType(),
            factory.Jump().GetType(),
            factory.Fall().GetType(),
            factory.Attack().GetType(),
            factory.Skill().GetType(),
            factory.Dash().GetType(),
            factory.Grounded().GetType()
        };

        Assert.AreEqual(9, coreTypes.Count, "Each core state should map to one dedicated class with no duplicates.");
    }
}
