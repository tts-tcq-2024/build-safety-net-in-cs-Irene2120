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
        Assert.Equal("A000",result);         //assert
    }
    [Fact]
    public void GenerateSoundex_ValidName_ReturnsCorrectSoundex()
    {
        string input="Abcd";    //arrange
        string result = Soundex.GenerateSoundex(input); //act
        Assert.Equal("A123",result);   //assert
    }
    [Fact]
    public void GenerateSoundex_LongString_ReturnsTruncated()
    {
        string input="JackandJill"; //arrange
        string result = Soundex.GenerateSoundex(input); //act
        Assert.Equal("J532",result);    //only first4 ->assert
    }

    [Fact]
    public void GenerateSoundex_NumbersInString_ReturnsCorrectSoundex()
    {
        string input="Abcd456"; //arrange
        string result = Soundex.GenerateSoundex(input);          //act
        Assert.Equal("A123",result);    //numbers ignored ->assert
    }
  [Fact]
    public void GenerateSoundex_TwoSimilarletters()
    {
        string input="Coffee"; //arrange
        string result = Soundex.GenerateSoundex(input);          //act
        Assert.Equal("C100",result);    //assert
    }
    [Fact]
    public void GenerateSoundex_NumberAsFirstLetter()
    {
        string input="6blur"; //arrange
        string result = Soundex.GenerateSoundex(input);          //act
        Assert.Equal("6146",result);    //assert
    }
      [Fact]
    public void GenerateSoundex_WordsWithSpace()
    {
        string input="Co  ld"; //arrange
        string result = Soundex.GenerateSoundex(input);          //act
        Assert.Equal("C430",result);    //assert
    }
    [Fact]
    public void GenerateSoundex_WithSpecialCharacters()
    {
        string input="Hello@abc"; //arrange
        string result = Soundex.GenerateSoundex(input);          //act
        Assert.Equal("H412",result);    //assert
    }
    [Fact]
   public void GenerateSoundex_WordwithVowels()
   {
       string input ="Ate";
       string result =Soundex.GenerateSoundex(input);
       Assert.Equal("A300",result);
   }
  
}
