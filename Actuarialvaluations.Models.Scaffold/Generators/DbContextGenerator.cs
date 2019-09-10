﻿namespace Actuarialvaluations.Models.Scaffold.Generators
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Microsoft.EntityFrameworkCore.Design;
  using Microsoft.EntityFrameworkCore.Metadata;
  using Microsoft.EntityFrameworkCore.Scaffolding;
  using Microsoft.EntityFrameworkCore.Scaffolding.Internal;

  /// <summary>
  /// The DbContextGenerator class
  /// </summary>
  public class DbContextGenerator : CSharpDbContextGenerator
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DbContextGenerator"/> class.
    /// </summary>
    /// <param name="legacyProviderCodeGenerators">The legacy provider code generators</param>
    /// <param name="providerCodeGenerators">The provider code generators</param>
    /// <param name="annotationCodeGenerator">The annotation code generator</param>
    /// <param name="cSharpHelper">The C# helper</param>
#pragma warning disable CS0618 // Type or member is obsolete
    public DbContextGenerator(
      IEnumerable<IScaffoldingProviderCodeGenerator> legacyProviderCodeGenerators,
      IEnumerable<IProviderConfigurationCodeGenerator> providerCodeGenerators,
      IAnnotationCodeGenerator annotationCodeGenerator,
      ICSharpHelper cSharpHelper)
#pragma warning restore CS0618 // Type or member is obsolete
      : base(legacyProviderCodeGenerators, providerCodeGenerators, annotationCodeGenerator, cSharpHelper)
    {
    }

    /// <summary>
    /// Write the code
    /// </summary>
    /// <param name="model">The model</param>
    /// <param name="namespace">The nemespace</param>
    /// <param name="contextName">The context name</param>
    /// <param name="connectionString">The connection string</param>
    /// <param name="useDataAnnotations">A value indicating whether to use data annotations</param>
    /// <param name="suppressConnectionStringWarning">A value indicating whether to suppress connection string warnings</param>
    /// <returns>The code</returns>
    public override string WriteCode(IModel model, string @namespace, string contextName, string connectionString, bool useDataAnnotations, bool suppressConnectionStringWarning)
    {
      @namespace = @namespace.Replace("Models.Models", "Models");

      List<string> code = base.WriteCode(model, @namespace, contextName, connectionString, useDataAnnotations, true).Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();

      this.CreateModelBuilder(model, @namespace, contextName, code);
      this.MarkAutogenerated(code);
      this.RemoveConnectionString(code);
      this.RenameConflictingProperties(model, code);

      return string.Join(Environment.NewLine, code);
    }

    /// <summary>
    /// Create the model builder class
    /// </summary>
    /// <param name="model">The model</param>
    /// <param name="namespace">The namespace</param>
    /// <param name="contextName">The context name</param>
    /// <param name="dbContextCode">The DB Context code</param>
    private void CreateModelBuilder(IModel model, string @namespace, string contextName, List<string> dbContextCode)
    {
      // Get the class name by removing the word "Context" from the end of the context name
      string className = $"{contextName.Remove(contextName.Length - 7)}ModelBuilder";

      List<string> code = new List<string>();

      this.MarkAutogenerated(code);

      code.AddRange(new string[]
      {
        $"namespace {@namespace}",
        $"{{",
        $"  using System;",
        $"  using Microsoft.AspNet.OData.Builder;",
        $"  using Microsoft.OData.Edm;",
        $"",
        $"  /// <summary>",
        $"  /// <see cref=\"{className}\"/> exposes methods to allow OData support for <see cref=\"{contextName}\"/>.",
        $"  /// </summary>",
        $"  public sealed class {className}",
        $"  {{",
        $"    /// <summary>",
        $"    /// Gets the EDM Model",
        $"    /// </summary>",
        $"    /// <param name=\"serviceProvider\">The service provider</param>",
        $"    /// <returns>The EDM Model</returns>",
        $"    public IEdmModel GetEdmModel(IServiceProvider serviceProvider)",
        $"    {{",
        $"      ODataConventionModelBuilder builder = new ODataConventionModelBuilder(serviceProvider);",
        $"",
      });

      code.AddRange(model.GetEntityTypes().Select(entityType => $"      builder.EntitySet<{entityType.Name}>(nameof({entityType.Name})).EntityType.Filter().Count().Expand().OrderBy().Page().Select();"));

      code.AddRange(new string[]
      {
        $"",
        $"      return builder.GetEdmModel();",
        $"    }}",
        $"  }}",
        $"}}",
      });

      DBScaffolder.BaseFiles.Add(
        new ScaffoldFile()
        {
          FileName = $"{className}.cs",
          FileContents = string.Join(Environment.NewLine, code)
        });
    }

    /// <summary>
    /// Mark the output file as auto-generated
    /// </summary>
    /// <param name="code">The code</param>
    private void MarkAutogenerated(List<string> code)
    {
      code.InsertRange(
        0,
        new List<string>
        {
            $"//------------------------------------------------------------------------------",
            $"// <auto-generated>",
            $"//     This code was auto-generated.",
            $"//",
            $"//     Changes to this file may cause incorrect behavior and will be lost if",
            $"//     the code is regenerated.",
            $"// </auto-generated>",
            $"//------------------------------------------------------------------------------",
            $"",
        });
    }

    /// <summary>
    /// Remove the connection string from the OnConfiguring method
    /// </summary>
    /// <param name="code">The code</param>
    private void RemoveConnectionString(List<string> code)
    {
      int index = code.IndexOf("        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)");
      if (index > -1)
      {
        code.RemoveRange(index + 2, 4);
      }
    }

    private void RenameConflictingProperties(IModel model, List<string> codeLines)
    {
      foreach (var entityType in model.GetEntityTypes())
      {
        var uglyDefaultPropertyName = $"e => e.{entityType.Name}1";
        var niceDefaultPropertyName = $"e => e.{entityType.Name}Name";

        for (var i = 0; i < codeLines.Count; i++)
        {
          if (codeLines[i].Contains(uglyDefaultPropertyName))
          {
            codeLines[i] = codeLines[i].Replace(uglyDefaultPropertyName, niceDefaultPropertyName);
            break;
          }
        }
      }
    }
  }
}
