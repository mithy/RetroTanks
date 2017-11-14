//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity projectilePoolEntity { get { return GetGroup(GameMatcher.ProjectilePool).GetSingleEntity(); } }
    public ProjectilePoolComponent projectilePool { get { return projectilePoolEntity.projectilePool; } }
    public bool hasProjectilePool { get { return projectilePoolEntity != null; } }

    public GameEntity SetProjectilePool(ProjectilePool newValue) {
        if (hasProjectilePool) {
            throw new Entitas.EntitasException("Could not set ProjectilePool!\n" + this + " already has an entity with ProjectilePoolComponent!",
                "You should check if the context already has a projectilePoolEntity before setting it or use context.ReplaceProjectilePool().");
        }
        var entity = CreateEntity();
        entity.AddProjectilePool(newValue);
        return entity;
    }

    public void ReplaceProjectilePool(ProjectilePool newValue) {
        var entity = projectilePoolEntity;
        if (entity == null) {
            entity = SetProjectilePool(newValue);
        } else {
            entity.ReplaceProjectilePool(newValue);
        }
    }

    public void RemoveProjectilePool() {
        projectilePoolEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ProjectilePoolComponent projectilePool { get { return (ProjectilePoolComponent)GetComponent(GameComponentsLookup.ProjectilePool); } }
    public bool hasProjectilePool { get { return HasComponent(GameComponentsLookup.ProjectilePool); } }

    public void AddProjectilePool(ProjectilePool newValue) {
        var index = GameComponentsLookup.ProjectilePool;
        var component = CreateComponent<ProjectilePoolComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceProjectilePool(ProjectilePool newValue) {
        var index = GameComponentsLookup.ProjectilePool;
        var component = CreateComponent<ProjectilePoolComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveProjectilePool() {
        RemoveComponent(GameComponentsLookup.ProjectilePool);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherProjectilePool;

    public static Entitas.IMatcher<GameEntity> ProjectilePool {
        get {
            if (_matcherProjectilePool == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ProjectilePool);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherProjectilePool = matcher;
            }

            return _matcherProjectilePool;
        }
    }
}
