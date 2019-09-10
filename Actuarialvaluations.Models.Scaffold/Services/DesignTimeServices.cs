namespace Actuarialvaluations.Models.Scaffold.Services
{
  using Actuarialvaluations.Models.Scaffold.Generators;
  using Microsoft.EntityFrameworkCore.Design;
  using Microsoft.EntityFrameworkCore.Scaffolding;
  using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
  using Microsoft.Extensions.DependencyInjection;

  /// <summary>
  /// The DesignTimeServices class
  /// </summary>
  public class DesignTimeServices : IDesignTimeServices
  {
    /// <summary>
    /// Configure design time services
    /// </summary>
    /// <param name="serviceCollection">The service collection</param>
    public virtual void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
    {
      serviceCollection.AddSingleton<IReverseEngineerScaffolder, DBScaffolder>();
      serviceCollection.AddSingleton<ICSharpDbContextGenerator, DbContextGenerator>();
      serviceCollection.AddSingleton<ICSharpEntityTypeGenerator, EntityTypeGenerator>();
    }
  }
}
