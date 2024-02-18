using Godot;
using System.Collections.Generic;

namespace GMCS;

public partial class ComponentManager : GodotObject
{
    public bool EnableProcess = new();
    public bool EnablePhysicsProcess = new();

    public List<IComponent> components = new();

    public bool CheckComponents()
    {
        if (components == null || components.Count == 0)
        {
            GD.Print("[ComponentManager] -> no component");
            return false;
        }

        return true;
    }

    public void Process(double delta)
    {
        for (int i = 0; i < components.Count; i++)
        {
            components[i]._Process(delta);
        }
    }

    public void PhysicsProcess(double delta)
    {
        for (int i = 0; i < components.Count; i++)
        {
            components[i]._PhysicsProcess(delta);
        }
    }

    public void Init()
    {
        if (!CheckComponents())
            return;

        for (int i = 0; i < components.Count; i++)
        {
            components[i]._Register();
            components[i].EmitSignal(IComponent.SignalName.Register);
            components[i]._Ready();
            components[i].EmitSignal(IComponent.SignalName.Ready);
        }

        GD.Print("[ComponentManager] -> init done");
    }
}
