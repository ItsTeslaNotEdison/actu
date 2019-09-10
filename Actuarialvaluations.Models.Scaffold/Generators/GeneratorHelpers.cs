namespace Actuarialvaluations.Models.Scaffold.Generators
{

  using System.Collections.Generic;

  /// <summary>
  /// Static class providing generic code helpers
  /// </summary>
  public static class GeneratorHelpers
  {
    /// <summary>
    /// Will find a public member with a given type and name, and replace it with a the new name
    /// </summary>
    /// <param name="code">The lines of code</param>
    /// <param name="findMemberType">The type of the member to find</param>
    /// <param name="findMemberName">The name of the member to find</param>
    /// <param name="replaceMemberName">The replacement name</param>
    public static void ReplaceMember(
      List<string> code,
      string findMemberType,
      string findMemberName,
      string replaceMemberName)
    {
      string findPropertyCode = $"public {findMemberType} {findMemberName}";
      string replacePropertyName = $"public {findMemberType} {replaceMemberName}";

      GeneratorHelpers.ReplaceCode(code, findPropertyCode, replacePropertyName);
    }

    /// <summary>
    /// Will replace any instance of the find text with the replace text in all lines
    /// </summary>
    /// <param name="codeLines">The lines of code</param>
    /// <param name="findText">The find text</param>
    /// <param name="replaceText">The replaceText</param>
    /// <param name="onlyFirstInstance">Indicates whether the code must </param>
    public static void ReplaceCode(
      List<string> codeLines,
      string findText,
      string replaceText,
      bool onlyFirstInstance = true)
    {
      for (var i = 0; i < codeLines.Count; i++)
      {
        if (codeLines[i].Contains(findText))
        {
          codeLines[i] = codeLines[i].Replace(findText, replaceText);
          if (onlyFirstInstance)
          {
            return;
          }
        }
      }
    }
  }
}
