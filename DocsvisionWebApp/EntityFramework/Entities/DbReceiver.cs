using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsvisionWebApp.EntityFramework.Entities;

public class DbReceiver
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
