using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class MergeDictionariesTests
{
    [Test]
    public void Test_Merge_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        var dict1 = new Dictionary<string, int>();
        var dict2 = new Dictionary<string, int>();

        // Act
        var result = MergeDictionaries.Merge(dict1, dict2);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Merge_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsNonEmptyDictionary()
    {
        // Arrange
        var dict1 = new Dictionary<string, int>();
        var dict2 = new Dictionary<string, int> { { "key1", 1 }, { "key2", 2 } };

        // Act
        var result = MergeDictionaries.Merge(dict1, dict2);

        // Assert
        Assert.That(result, Is.EqualTo(dict2));
    }

    [Test]
    public void Test_Merge_TwoNonEmptyDictionaries_ReturnsMergedDictionary()
    {
        // Arrange
        var dict1 = new Dictionary<string, int> { { "key1", 1 }, { "key2", 2 } };
        var dict2 = new Dictionary<string, int> { { "key3", 3 }, { "key4", 4 } };
        var expectedDict = new Dictionary<string, int> { { "key1", 1 }, { "key2", 2 }, { "key3", 3 }, { "key4", 4 } };

        // Act
        var result = MergeDictionaries.Merge(dict1, dict2);

        // Assert
        Assert.That(result, Is.EqualTo(expectedDict));
    }

    [Test]
    public void Test_Merge_OverlappingKeys_ReturnsMergedDictionaryWithValuesFromDict2()
    {
        // Arrange
        var dict1 = new Dictionary<string, int> { { "key1", 1 }, { "key2", 2 } };
        var dict2 = new Dictionary<string, int> { { "key1", 3 }, { "key2", 4 } };
        var expectedDict = new Dictionary<string, int> { { "key1", 3 }, { "key2", 4 } };

        // Act
        var result = MergeDictionaries.Merge(dict1, dict2);

        // Assert
        Assert.That(result, Is.EqualTo(expectedDict));
    }
}
