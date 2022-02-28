using System;
using System.Data;

public static class ExpressionParser
{
    private static readonly DataTable DataTable = new ();

    public static (bool success, float value) Parse(string expression)
    {
        try   { return (true, Convert.ToSingle(DataTable.Compute(expression, ""))); }
        catch { return (false, float.NaN); }
    }
}