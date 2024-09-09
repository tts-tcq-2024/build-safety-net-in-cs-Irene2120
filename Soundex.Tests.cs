using Xunit;
using System;
using System.Text;

public class SoundexTests
{
    [Fact]
    public void GenerateSoundex_EmptyString_ReturnsEmptyString()
    {
        string input=""; //arrange

        string result = Soundex.GenerateSoundex(input);   //Act

        Assert.Equal(string.Empty,result);      //assert
    }
    [Fact]
    public void GenerateSoundex_SingleCharacter_ReturnsPaddedCode()
    {
        string input ="A"; //arrange
        string result =Soundex.GenerateSoundex(input);   //act
        Assert.Equal("A000",result);         //act
    }
    [Fact]
    public void GenerateSoundex_ValidName_ReturnsCorrectSoundex()
    {
        string input="Abcd";
        string result = Soundex.GenerateSoundex(input);
        Assert.Equal("0123",result);
    }
    [Fact]
    public void HandlesEmptyString()
    {
        Assert.Equal(string.Empty, Soundex.GenerateSoundex(""));
    }

    [Fact]
    public void HandlesSingleCharacter()
    {
        Assert.Equal("A000", Soundex.GenerateSoundex("A"));
    }

   
}
