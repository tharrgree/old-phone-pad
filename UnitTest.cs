using NUnit.Framework;

[TestFixture]
public class PhonePadTests
{
    [Test]
    public void Test_NullInput_ReturnsEmptyString()
    {
        // Arrange
        string input = null;

        // Act
        string result = PhonePad.OldPhonePad(input);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Test_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string input = "";

        // Act
        string result = PhonePad.OldPhonePad(input);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Test_SingleKeyPress_ReturnsCorrectLetter()
    {
        // Arrange
        string input = "2#";

        // Act
        string result = PhonePad.OldPhonePad(input);

        // Assert
        Assert.AreEqual("A", result);
    }

    [Test]
    public void Test_MultipleKeyPresses_ReturnsCorrectLetter()
    {
        // Arrange
        string input = "222#";

        // Act
        string result = PhonePad.OldPhonePad(input);

        // Assert
        Assert.AreEqual("C", result);
    }

    [Test]
    public void Test_PauseBetweenSameKeys_ReturnsCorrectLetters()
    {
        // Arrange
        string input = "22 2#";

        // Act
        string result = PhonePad.OldPhonePad(input);

        // Assert
        Assert.AreEqual("AB", result);
    }

    [Test]
    public void Test_SendButtonEndsProcessing()
    {
        // Arrange
        string input = "4433555 555666#777";

        // Act
        string result = PhonePad.OldPhonePad(input);

        // Assert
        Assert.AreEqual("HELLO", result);
    }

    [Test]
    public void Test_IgnoreStarKey()
    {
        // Arrange
        string input = "227*#";

        // Act
        string result = PhonePad.OldPhonePad(input);

        // Assert
        Assert.AreEqual("B", result);
    }

    [Test]
    public void Test_InvalidCharactersAreIgnored()
    {
        // Arrange
        string input = "22@33#";

        // Act
        string result = PhonePad.OldPhonePad(input);

        // Assert
        Assert.AreEqual("BC", result);
    }

    [Test]
    public void Test_SpaceAsPause()
    {
        // Arrange
        string input = "55 555#";

        // Act
        string result = PhonePad.OldPhonePad(input);

        // Assert
        Assert.AreEqual("KJ", result);
    }

    [Test]
    public void Test_ZeroKey_ReturnsSpace()
    {
        // Arrange
        string input = "0#";

        // Act
        string result = PhonePad.OldPhonePad(input);

        // Assert
        Assert.AreEqual(" ", result);
    }

    [Test]
    public void Test_ComplexInput_ReturnsCorrectOutput()
    {
        // Arrange
        string input = "8 88777444666*664#";

        // Act
        string result = PhonePad.OldPhonePad(input);

        // Assert
        Assert.AreEqual("TURING", result);
    }

    [Test]
    public void Test_ConsecutiveSpaces_AreHandledCorrectly()
    {
        // Arrange
        string input = "222  2#";

        // Act
        string result = PhonePad.OldPhonePad(input);

        // Assert
        Assert.AreEqual("CA", result);
    }

    [Test]
    public void Test_InputWithoutSendButton_ReturnsEmptyString()
    {
        // Arrange
        string input = "222";

        // Act
        string result = PhonePad.OldPhonePad(input);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }
}