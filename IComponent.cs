using Godot;

namespace GMCS;

public partial class IComponent : GodotObject
{
    [Signal] public delegate void RegisterEventHandler();
    [Signal] public delegate void ReadyEventHandler();

    public bool EnableProcess = new();
    public bool EnablePhysicsProcess = new();

    public virtual void _Register()
    {
    }

    public virtual void _Ready()
    {
    }

    public virtual void _Process(double delta)
    {
    }

    public virtual void _PhysicsProcess(double delta)
    {
    }

    public virtual void _Destroy()
    {
        Free();
    }
}
