using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var idText = id is null ? "" : $"[{id}] - "; 
        var departmentText = department is null ? "OWNER" : department.ToUpper();
        
        return $"{idText}{name} - {departmentText}";
    }
}
