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
        Assert.Equal("A123",result);
    }
    [Fact]
    public void GenerateSoundex_LongString_ReturnsTruncated()
    {
        string input="JackandJill";
        string result = Soundex.GenerateSoundex(input);
        Assert.Equal("J020",result);    //only first4 
    }

    [Fact]
    public void GenerateSoundex_NumbersInString_ReturnsCorrectSoundex()
    {
        string input="Abcd456";
        string result = Soundex.GenerateSoundex(input);
        Assert.Equal("A123",result);    //numbers ignored
    }

    [Fact]
    public void InitializeSoundex_Validname_ReturnsInitializedSoundex()
    {
        string input="Jack";
        var result = Soundex.InitializeSoundex(input);
        Assert.Equal("J",result.ToString());    //only first char
    }
    [Fact]
    public void AppendingSoundexXharacters_ProcessCharCorrectly()
    {
        var soundexBuilder= new StringBuilder("J");
        char prevCode ='J';
        
      Soundex.AppendingSoundexCharacters("Jack",soundexBuilder,ref prevCode);
        
        Assert.Equal("J02",soundexBuilder.ToString());  
    }
    [Fact]
    public void GetSoundexCode_ValidCharacter_ReturnsCorrectCode()
    {
        char character="B";
        
        char result = Soundex.GetSoundexCode(character);
        
        Assert.Equal('1',result);    
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
