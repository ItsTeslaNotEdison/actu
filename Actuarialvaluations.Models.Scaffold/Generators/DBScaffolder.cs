namespace Actuarialvaluations.Models.Scaffold.Generators
{
  using System.Collections.Generic;
  using System.IO;
  using Microsoft.EntityFrameworkCore.Design;
  using Microsoft.EntityFrameworkCore.Scaffolding;
  using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
  using Microsoft.EntityFrameworkCore.Storage.Internal;

  /// <summary>
  /// ScaffoldDatabaseOperations used to get output path.
  /// </summary>
  public class DBScaffolder : ReverseEngineerScaffolder
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DBScaffolder"/> class.
    /// </summary>
    /// <param name="databaseModelFactory">.</param>
    /// <param name="scaffoldingModelFactory">.</param>
    /// <param name="modelCodeGeneratorSelector">.</param>
    /// <param name="cSharpUtilities">.</param>
    /// <param name="cSharpHelper">.</param>
    /// <param name="connectionStringResolver">.</param>
    public DBScaffolder(
            IDatabaseModelFactory databaseModelFactory,
            IScaffoldingModelFactory scaffoldingModelFactory,
            IModelCodeGeneratorSelector modelCodeGeneratorSelector,
            ICSharpUtilities cSharpUtilities,
            ICSharpHelper cSharpHelper,
            INamedConnectionStringResolver connectionStringResolver)
      : base(databaseModelFactory, scaffoldingModelFactory, modelCodeGeneratorSelector, cSharpUtilities, cSharpHelper, connectionStringResolver)
    {
    }

    /// <summary>
    /// Gets the list of base files to create.
    /// </summary>
    public static List<ScaffoldFile> BaseFiles { get; } = new List<ScaffoldFile>();

    /// <summary>
    /// Gets the list of extension files to create.
    /// </summary>
    public static List<ScaffoldFile> ExtensionFiles { get; } = new List<ScaffoldFile>();

    /// <inheritdoc/>
    public override SavedModelFiles Save(ScaffoldedModel scaffoldedModel, string outputDir, bool overwriteFiles)
    {
      string outputDirBase = Path.Combine(outputDir, "Base");
      string outputDirExtensions = Path.Combine(outputDir, "Extensions");

      if (!Directory.Exists(outputDirBase)) { Directory.CreateDirectory(outputDirBase); }
      if (!Directory.Exists(outputDirExtensions)) { Directory.CreateDirectory(outputDirExtensions); }

      // Save base files then let the base class do the actual entities.
      foreach (ScaffoldFile scaffoldFile in DBScaffolder.BaseFiles)
      {
        string fileName = Path.Combine(outputDirBase, scaffoldFile.FileName);
        File.WriteAllText(fileName, scaffoldFile.FileContents);
      }
      BaseFiles.Clear();

      // Save extension files then let the base class do the actual entities.
      foreach (ScaffoldFile scaffoldFile in DBScaffolder.ExtensionFiles)
      {
        string fileName = Path.Combine(outputDirExtensions, scaffoldFile.FileName);
        if (!File.Exists(fileName))
        {
          File.WriteAllText(fileName, scaffoldFile.FileContents);
        }
      }
      ExtensionFiles.Clear();

      return base.Save(scaffoldedModel, outputDirBase, overwriteFiles);
    }
  }

  /// <summary>
  /// The ScaffoldFile class
  /// </summary>
  public class ScaffoldFile
  {
    /// <summary>
    /// Gets or sets the file name
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// Gets or sets the code in the file
    /// </summary>
    public string FileContents { get; set; }
  }
}
