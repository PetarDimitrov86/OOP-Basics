public abstract class Component
{
    private string name;
    private string type;

    protected Component(string name, string type)
    {
        this.name = name;
        this.type = type;
    }

    public string Name {get { return this.name; } }
    public string Type {get { return this.type; } }

}