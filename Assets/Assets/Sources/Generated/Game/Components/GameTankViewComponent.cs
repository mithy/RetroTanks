//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TankViewComponent tankView { get { return (TankViewComponent)GetComponent(GameComponentsLookup.TankView); } }
    public bool hasTankView { get { return HasComponent(GameComponentsLookup.TankView); } }

    public void AddTankView(TankView newValue) {
        var index = GameComponentsLookup.TankView;
        var component = CreateComponent<TankViewComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTankView(TankView newValue) {
        var index = GameComponentsLookup.TankView;
        var component = CreateComponent<TankViewComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTankView() {
        RemoveComponent(GameComponentsLookup.TankView);
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

    static Entitas.IMatcher<GameEntity> _matcherTankView;

    public static Entitas.IMatcher<GameEntity> TankView {
        get {
            if (_matcherTankView == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TankView);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTankView = matcher;
            }

            return _matcherTankView;
        }
    }
}
