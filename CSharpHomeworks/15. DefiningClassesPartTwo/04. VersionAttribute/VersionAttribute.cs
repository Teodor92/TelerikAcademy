[System.AttributeUsage(
    System.AttributeTargets.Class |
    System.AttributeTargets.Struct |
    System.AttributeTargets.Enum |
    System.AttributeTargets.Method)]

public class VersionAttribute : System.Attribute
{
    private double version;

    public VersionAttribute(double version)
    {
        this.version = version;
    }

    public double Version
    {
        get
        {
            return this.version;
        }
    }
}